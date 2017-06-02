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
        private string _folderPath;
        private ICollection<string> _filesPaths;

        public Scaner(string folderPath)
        {
            
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
                _timerCallBack = new TimerCallback(Scan);
                _timer = new Timer(_timerCallBack, _folderPath, 0, 1000);
            }
        }

        private void Scan(object obj)
        {
            string managersFolderPath = (string)obj;
            _filesPaths = Directory.GetFiles(managersFolderPath, "*.csv").ToList();
            if (_filesPaths.Count != 0)
            {
                _timer.Change(Timeout.Infinite, 0);
                HandleFiles();
            }
        }

        private void HandleFiles()
        {
            foreach (string filePath in _filesPaths)
            {
                Console.WriteLine(filePath);
                File.Delete(filePath);
            }
            _filesPaths.Clear();
            _timer.Change(0, 1000);
        }
    }
}
