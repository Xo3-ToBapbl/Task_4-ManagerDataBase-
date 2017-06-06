using ManagerDataBase.DAL.Interfaces;
using ManagerDataBase.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.BLL.Services
{
    public class ServiceNinjectModuleBLL: NinjectModule
    {
        private string _connectionString;

        public ServiceNinjectModuleBLL(string connectionString)
        {
            _connectionString = connectionString;
        }


        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("connectionString", _connectionString);
        }
    }
}
