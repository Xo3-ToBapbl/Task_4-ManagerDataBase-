using ManagerDataBase.PL.Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ManagerDataBase.PL.Services
{
    public class Parser
    {
        private Regex regex = new Regex(@"[a-я]*", RegexOptions.IgnoreCase);
        private string _errorFilesFolderPath;

        public ConcurrentDictionary<string, ManagerPL> ManagersPL { get; set; }

        public Parser(string errorFilesFolderPath)
        {
            _errorFilesFolderPath = errorFilesFolderPath;
            ManagersPL = new ConcurrentDictionary<string, ManagerPL>();
        }

        public void Parse(string filePath)
        {
            bool exceptionFlag = false;
            StreamReader reader = new StreamReader(filePath);
            try
            {
                ManagerPL managerPL = new ManagerPL()
                {
                    SecondName = regex.Match(Path.GetFileName(filePath)).Value,
                    PathToFile = filePath
                };
                ICollection<SalePL> salesPL = new List<SalePL>();
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] sailesInfo = currentLine.Split(';');
                    SalePL salePL = new SalePL()
                    {
                        Date = DateTime.ParseExact(sailesInfo[0], "ddMyyyy", null),
                        Client = sailesInfo[1],
                        Product = sailesInfo[2],
                        Cost = Convert.ToInt32(sailesInfo[3])
                    };
                    salesPL.Add(salePL);
                    currentLine = reader.ReadLine();
                }

                managerPL.Sales = salesPL;
                ManagersPL.GetOrAdd(managerPL.SecondName, managerPL);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file {0} could not be read:", Path.GetFileName(filePath));
                Console.WriteLine(e.Message);
                exceptionFlag = true;                
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (exceptionFlag)
                {
                    string targetPath = Path.Combine(_errorFilesFolderPath, Path.GetFileName(filePath));
                    if (!File.Exists(targetPath))
                    {
                        File.Move(filePath, targetPath);
                    }
                    else
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }
    }
}
