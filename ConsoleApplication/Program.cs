using AutoMapper;
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePL service = new ServicePL();
            service.Start();

            Console.ReadKey();
        }

    }
}

#region CheckFB
//public static void CheckDataBase(string connectionString)
//{
//    DbContext dbContext = new ManagersDBContext(connectionString);
//    Database db = dbContext.Database;
//    db.CreateIfNotExists();
//}
#endregion
#region ManagerDTO
//ICollection<SaleDTO> salesDTO = new List<SaleDTO>()
//{
//    new SaleDTO()
//    {
//        Date = DateTime.Now,
//        Client = "Patrick Viewer",
//        Product = "Philips LM12",
//        Cost = 220
//    },
//    new SaleDTO()
//    {
//        Date = DateTime.Now,
//        Client = "Infy Yaroshik",
//        Product = "LG G2",
//        Cost = 335
//    },
//};
//ManagerDTO managerDTO = new ManagerDTO()
//{
//    SecondName = "Navik",
//    Sales = salesDTO,
//};

//Mapper.Initialize(cfg =>
//{
//    cfg.CreateMap<SaleDTO, SaleEntity>().
//    ForMember(dest => dest.Manager, option => option.Ignore());
//    cfg.CreateMap<ManagerDTO, ManagerEntity>();
//});
//Mapper.AssertConfigurationIsValid();
//ManagerEntity managerEntity = Mapper.Map<ManagerDTO, ManagerEntity>(managerDTO);
#endregion
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
#region ManagersPL
//ICollection<SalePL> salesPL1 = new List<SalePL>()
//{
//    new SalePL()
//    {
//        Date = DateTime.Now,
//        Client = "Pit Pitterson",
//        Product = "KG LM12",
//        Cost = 155
//    },
//    new SalePL()
//    {
//        Date = DateTime.Now,
//        Client = "Injy Yaroshik",
//        Product = "LG G2",
//        Cost = 220
//    },
//};

//ICollection<SalePL> salesPL2 = new List<SalePL>()
//{
//    new SalePL()
//    {
//        Date = DateTime.Now,
//        Client = "Piter Jonson",
//        Product = "PC LM12",
//        Cost = 330
//    },
//    new SalePL()
//    {
//        Date = DateTime.Now,
//        Client = "Lebron James",
//        Product = "Iphone 6",
//        Cost = 680
//    },
//};

//ManagerPL managerPL1 = new ManagerPL()
//{
//    SecondName = "Sidorov",
//    Sales = salesPL1,
//};

//ManagerPL managerPL2 = new ManagerPL()
//{
//    SecondName = "Sidorov",
//    Sales = salesPL2,
//};

//ManagerPL managerPL3 = new ManagerPL()
//{
//    SecondName = "Stupak",
//};

//ManagerPL managerPL4 = new ManagerPL()
//{
//    SecondName = "Ibra",
//};

//ManagerPL managerPL5 = new ManagerPL()
//{
//    SecondName = "Louder",
//};

//ManagerPL managerPL6 = new ManagerPL()
//{
//    SecondName = "Tander",
//};

//ManagerPL managerPL7 = new ManagerPL()
//{
//    SecondName = "Biber",
//};

//ManagerPL managerPL8 = new ManagerPL()
//{
//    SecondName = "Saiter",
//};

//ManagerPL managerPL9 = new ManagerPL()
//{
//    SecondName = "Bot",
//};

//ManagerPL managerPL10 = new ManagerPL()
//{
//    SecondName = "Kot",
//};

//BlockingCollection<ManagerPL> managersPL = new BlockingCollection<ManagerPL>()
//{
//    managerPL1,
//    managerPL2,
//    managerPL3,
//    managerPL4,
//    managerPL5,
//    managerPL6,
//    managerPL7,
//    managerPL8,
//    managerPL9,
//    managerPL10
//};
#endregion
