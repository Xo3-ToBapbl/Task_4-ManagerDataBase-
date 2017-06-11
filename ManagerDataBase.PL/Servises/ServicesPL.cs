using AutoMapper;
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.BLL.Interfaces;
using ManagerDataBase.PL.Classes;
using ManagerDataBase.PL.Servises;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManagerDataBase.PL.Services
{
    public class ServicePL
    {
        private IServiceBLL _serviceBLL;
        private StandardKernel _kernel;
        private Timer _timer;
        private TimerCallback _timerCallBack;
        private Parser _parser;       
        private ICollection<string> _filesPaths;
        private ICollection<ManagerPL> _managersFiles;

        private string _connectionString;
        private string _scannedFolderPath;
        private string _processedFilesFolderPath;
        private string _errorFilesFolderPath;

        public string ScannedFolderPath
        {
            get
            {
                return _scannedFolderPath;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    _scannedFolderPath = value;
                }
                else
                {
                    _scannedFolderPath = CreateFolder(value);
                }
            }
        }

        public string ProcessedFilesFolderPath
        {
            get
            {
                return _processedFilesFolderPath;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    _processedFilesFolderPath = value;
                }
                else
                {
                    _processedFilesFolderPath = CreateFolder(value);
                }
            }
        }

        public string ErrorFilesFolderPath
        {
            get
            {
                return _errorFilesFolderPath;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    _errorFilesFolderPath = value;
                }
                else
                {
                    _errorFilesFolderPath = CreateFolder(value);
                }
            }
        }


        public ServicePL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ManagersDataBaseConnection"].ConnectionString;
            ScannedFolderPath = ConfigurationManager.AppSettings["ManagersFolderPath"];
            ProcessedFilesFolderPath = ConfigurationManager.AppSettings["ManagersProcessedFilesFolderPath"];
            ErrorFilesFolderPath = ConfigurationManager.AppSettings["ManagersErrorFilesFolderPath"];

            _kernel = new StandardKernel(new ServiceNinjectModulePL(_connectionString));
            _parser = new Parser(ErrorFilesFolderPath);

            _serviceBLL = _kernel.Get<IServiceBLL>();
        }


        public void Start()
        {
            Console.WriteLine("Preparing database, please do not close application.");
            CheckDataBase();         
            if (_scannedFolderPath != null)
            {
                Console.WriteLine("Application working. Press any key to close application.\n");

                _timerCallBack = new TimerCallback(Scan);
                _timer = new Timer(_timerCallBack, _scannedFolderPath, 0, 1000);
            }            
        }

        public void Stop()
        {
            _timer.Dispose();
        }

        private void CheckDataBase()
        {
            _serviceBLL.CheckDataBase();
        }

        private void Scan(object managersFolderPath)
        {
            _filesPaths = Directory.GetFiles((string)managersFolderPath, "*.csv").ToList();
            if (_filesPaths.Count != 0)
            {
                _timer.Change(Timeout.Infinite, 0);

                Parallel.ForEach(_filesPaths, _parser.Parse);
                _managersFiles = _parser.ManagersPL.Values;

                Parallel.ForEach(_managersFiles, ProcessManagers);

                _filesPaths.Clear();
                _parser.ManagersPL.Clear();
               
                _timer.Change(0, 1000);
            }
        }

        private void ProcessManagers(ManagerPL managerPL)
        {          
            AddToDataBase(managerPL);

            string targetPath = Path.Combine(ProcessedFilesFolderPath, Path.GetFileName(managerPL.PathToFile));
            if(!File.Exists(targetPath))
            {
                File.Move(managerPL.PathToFile, targetPath);
            }
            else
            {
                File.Delete(managerPL.PathToFile);
            }
        }

        private string CreateFolder(string scannedFolderPath)
        {
            try
            {
                Directory.CreateDirectory(scannedFolderPath);
                return scannedFolderPath;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Can't start application, directory is not created: {e.ToString()}. \nCheck App.config and start again.");
                Thread.Sleep(10000);
                Environment.Exit(0);              
                return null;
            }
        }
  
        private void AddToDataBase(ManagerPL managerPL)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ManagerPL, ManagerDTO>();
                cfg.CreateMap<SalePL, SaleDTO>();
            });
            ManagerDTO managerDTO = Mapper.Map<ManagerPL, ManagerDTO>(managerPL);
            _serviceBLL.HandleManagerInfo(managerDTO);
        }
    }
}
