using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagerDataBase.BL
{
    public class Scaner
    {
        private Timer _timer;
        private TimerCallback _timerCallBack;
        private Parser _parser;
        private string _folderPath;
        private ICollection<string> _filesPaths;

        public Scaner(string folderPath)
        {
            _parser = new Parser();
            FolderPath = folderPath;
        }


        public string FolderPath
        {
            get
            {
                return _folderPath;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    _folderPath = value;
                }
            }
        }


        public void StartScaner()
        {
            if (_folderPath != null)
            {
                Console.WriteLine("Scaner start.\n");
                _timerCallBack = new TimerCallback(Scan);
                _timer = new Timer(_timerCallBack, _folderPath, 0, 1000);
            }
        }

        public void StopScaner()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
        }

        private void Scan(object obj)
        {
            string managersFolderPath = (string)obj;
            _filesPaths = Directory.GetFiles(managersFolderPath, "*.csv").ToList();
            if (_filesPaths.Count != 0)
            {
                Console.WriteLine("Scaner suspend.\n");
                _timer.Change(Timeout.Infinite, 0);
                HandleFiles();
            }
        }

        private void HandleFiles()
        {
            foreach (string filePath in _filesPaths)
            {
                _parser.Parse(filePath);
                File.Delete(filePath);
            }
            Console.WriteLine("Scaner start.\n");
            _filesPaths.Clear();
            _timer.Change(0, 1000);
        }
    }
}
