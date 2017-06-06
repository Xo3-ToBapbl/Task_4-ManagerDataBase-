using ManagerDataBase.BLL.DTO;
using ManagerDataBase.BLL.Interfaces;
using ManagerDataBase.BLL.Services;
using ManagerDataBase.DAL.EFContext;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.Interfaces;
using ManagerDataBase.DAL.Repositories;
using ManagerDataBase.PL.Classes;
using ManagerDataBase.PL.Services;
using ManagerDataBase.PL.Servises;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Reflection;

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
            string connectionString = ConfigurationManager.
                ConnectionStrings["ManagersDataBaseConnection"].ConnectionString;
            #endregion
            StandardKernel _kernel = new StandardKernel
                (new ServiceNinjectModuleBLL(connectionString), new ServiceNinjectModulePL());

            ServicePL service = new ServicePL(_kernel.Get<IServiceBLL>());

            var managers = service.GetAllManagersFromBL();

            foreach (var manger in managers)
                Console.WriteLine(manger.SecondName);



            #region Close application
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();
            #endregion
        }
    }
}

//ICollection<SaleDTO> salesDTO = new List<SaleDTO>()
//            {
//                new SaleDTO()
//                {
//                    Date = DateTime.Now,
//                    Client = "Patrick Viewer",
//                    Product = "Philips LM12",
//                    Cost = 220
//                }

//            };
//ManagerDTO managerDTO = new ManagerDTO()
//{
//    SecondName = "Kotov",
//    Sales = salesDTO,
//};
//ICollection<SaleDTO> salesDTO = new List<SaleDTO>()
//                        {
//                            new SaleDTO()
//                            {
//                                Date = DateTime.Now,
//                                Client = "Ivan Stupak",
//                                Product = "Sony Z4",
//                                Cost = 880
//                            },
//                            new SaleDTO()
//                            {
//                                Date = DateTime.Now,
//                                Client = "Alex Bugalov",
//                                Product = "Nokia 4G",
//                                Cost = 335
//                            }
//                        };
//ManagerDTO managerDTO = new ManagerDTO()
//{
//    SecondName = "Kulagin",
//    Sales = salesDTO,
//};
//ICollection<SalePL> salesPL = new List<SalePL>()
//            {
//                new SalePL()
//                {
//                    Date = DateTime.Now,
//                    Client = "Vasya Pupkin",
//                    Product = "Parasha",
//                    Cost = 220
//                }
//            };
//ManagerPL managerPL = new ManagerPL()
//{
//    SecondName = "Jonson",
//    Sales = salesPL
//};

//ServicesPL service = new ServicesPL();
//ManagerDTO dto = service.AddToDataBase(managerPL);
