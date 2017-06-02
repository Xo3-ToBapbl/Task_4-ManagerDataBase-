using ManagerDataBase.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Path
            string currentDirectoryPath = Path.GetDirectoryName(Environment.CurrentDirectory);
            string managersFolderPath = Path.Combine(currentDirectoryPath, 
                ConfigurationManager.AppSettings["ManagersFolderPath"]);
            #endregion
            Scaner scaner = new Scaner(managersFolderPath);
            scaner.StartScaner();
            
            #region Close application
            //Console.WriteLine("\nPress any key to close.");
            Console.ReadLine();
            #endregion
        }
    }
}
