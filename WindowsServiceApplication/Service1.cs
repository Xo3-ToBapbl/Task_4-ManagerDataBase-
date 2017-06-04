using ManagerDataBase.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceApplication
{
    public partial class Service1 : ServiceBase
    {
        private Scaner _scaner;

        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
        }

        protected override void OnStart(string[] args)
        {
            #region Path
            string currentDirectoryPath = Path.GetDirectoryName(Environment.CurrentDirectory);
            string managersFolderPath = Path.Combine(currentDirectoryPath,
                ConfigurationManager.AppSettings["ManagersFolderPath"]);
            #endregion
            _scaner = new Scaner(managersFolderPath);
            Thread scanerThread = new Thread(new ThreadStart(_scaner.StartScaner));
            scanerThread.Start(); 
        }

        protected override void OnStop()
        {
            _scaner.StopScaner();
            Thread.Sleep(1000);
        }
    }
}
