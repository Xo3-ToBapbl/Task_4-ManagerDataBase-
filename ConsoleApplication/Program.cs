
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.BLL.Services;
using ManagerDataBase.DAL.EFContext;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.Interfaces;
using ManagerDataBase.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;

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

            //Scaner scaner = new Scaner(managersFolderPath);
            //scaner.StartScaner();
            #endregion
            EFUnitOfWork genericContext = new EFUnitOfWork();
            Service service = new Service(genericContext);

            ICollection<SaleDTO> salesDTO = new List<SaleDTO>()
            {
                new SaleDTO()
                {
                    Date = DateTime.Now,
                    Client = "Bill Murray",
                    Product = "Sony Xperia Z6",
                    Cost = 220
                },
                new SaleDTO()
                {
                    Date = DateTime.Now,
                    Client = "Poul Sweet",
                    Product = "Xbox One",
                    Cost = 445
                }
            };
            ManagerDTO managerDTO = new ManagerDTO()
            {
                SecondName = "Lanister",
                Sales = salesDTO,               
            };

            service.HandleManagerInfo(managerDTO);





            #region Close application
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();
            #endregion
        }
    }
}
