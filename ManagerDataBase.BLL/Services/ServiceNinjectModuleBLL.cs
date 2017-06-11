using ManagerDataBase.DAL.Interfaces;
using ManagerDataBase.DAL.Repositories;
using Ninject.Modules;

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
