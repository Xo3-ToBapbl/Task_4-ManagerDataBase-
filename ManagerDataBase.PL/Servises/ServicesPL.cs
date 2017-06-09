using AutoMapper;
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.BLL.Interfaces;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.PL.Classes;
using ManagerDataBase.PL.Servises;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.PL.Services
{
    public class ServicePL
    {
        private IServiceBLL _serviceBLL;
        private StandardKernel _kernel;

        public ServicePL(string connectionString)
        {
            _kernel = new StandardKernel(new ServiceNinjectModulePL(connectionString));
            _serviceBLL = _kernel.Get<IServiceBLL>();
        }

        public void AddToDataBase(ManagerPL managerPL)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ManagerPL, ManagerDTO>();
                cfg.CreateMap<SalePL, SaleDTO>();
            });
            ManagerDTO managerDTO = Mapper.Map<ManagerPL, ManagerDTO>(managerPL);
            _serviceBLL.HandleManagerInfo(managerDTO);
        }
    }
}
