using AutoMapper;
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.BLL.Interfaces;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.PL.Classes;
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

        public ServicePL(IServiceBLL serviceBLL)
        {
            _serviceBLL = serviceBLL;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ManagerPL, ManagerDTO>();
                cfg.CreateMap<SalePL, SaleDTO>();
            });
        }

        public void AddToDataBase(ManagerPL managerPL)
        {
            ManagerDTO managerDTO = Mapper.Map<ManagerPL, ManagerDTO>(managerPL);
            _serviceBLL.HandleManagerInfo(managerDTO);
        }
    }
}
