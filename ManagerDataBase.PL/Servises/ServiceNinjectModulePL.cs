using ManagerDataBase.BLL.Interfaces;
using ManagerDataBase.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.PL.Servises
{
    public class ServiceNinjectModulePL : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceBLL>().To<ServiceBLL>();
        }
    }
}
