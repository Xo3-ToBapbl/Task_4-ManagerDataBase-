
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

            SaleDTO saleDTO = new SaleDTO()
            {
                Date = DateTime.Now,
                Client = "Peter Jonson",
                Product = "IPhone",
                Cost = 550,
                ManagerId = 1
            };

            service.AddSalesInfo(saleDTO);


            //ManagerDTO managerDTO = service.GetManagerDTO(1);
            

            #region Close application
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();
            #endregion
        }
    }
}
