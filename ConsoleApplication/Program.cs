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
