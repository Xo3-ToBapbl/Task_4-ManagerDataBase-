using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.BL
{
    public class Watcher
    {
        private string _folderPath;

        public Watcher(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void RunWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(_folderPath);
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Filter = "*.csv";

            watcher.Created += new FileSystemEventHandler(OnCreated);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'q\' to quit the sample.\n");
            while (Console.Read() != 'q');
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File {0}: {1} {2}",e.Name, e.FullPath, e.ChangeType);
        }


    }
}
