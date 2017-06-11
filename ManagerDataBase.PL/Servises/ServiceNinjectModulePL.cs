using ManagerDataBase.BLL.Interfaces;
using ManagerDataBase.BLL.Services;
using Ninject.Modules;

namespace ManagerDataBase.PL.Servises
{
    public class ServiceNinjectModulePL : NinjectModule
    {
        private string _connectionString;

        public ServiceNinjectModulePL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IServiceBLL>().To<ServiceBLL>().WithConstructorArgument("connectionString", _connectionString);
        }
    }
}
