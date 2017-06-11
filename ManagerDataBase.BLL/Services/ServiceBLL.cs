using ManagerDataBase.BLL.Interfaces;
using System.Collections.Generic;
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.DAL.Interfaces;
using AutoMapper;
using ManagerDataBase.DAL.Entities;
using Ninject;

namespace ManagerDataBase.BLL.Services
{
    public class ServiceBLL : IServiceBLL
    {
        private StandardKernel _kernel;

        public IUnitOfWork DataBase { get; set; }

        public ServiceBLL(string connectionString)
        {
            _kernel = new StandardKernel(new ServiceNinjectModuleBLL(connectionString));
            DataBase = _kernel.Get<IUnitOfWork>();
        }


        public void CheckDataBase()
        {
            DataBase.CreateDataBase();
        }

        public void HandleManagerInfo(ManagerDTO managerDTO)
        {
            IUnitOfWork DataBase = _kernel.Get<IUnitOfWork>();

            int? managerId = DataBase.Managers.GetId(x => x.SecondName == managerDTO.SecondName);
            if (managerId != null)
            {
                AddSalesInfo(managerDTO, (int)managerId, DataBase);
            }
            else
            {
                AddNewManager(managerDTO, DataBase);
            }
            DataBase.Dispose();
        }

        private void AddSalesInfo(ManagerDTO managerDTO, int managerId, IUnitOfWork DataBase)
        {
            
            if (managerDTO.Sales.Count != 0)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SaleDTO, SaleEntity>().
                    ForMember(dest => dest.Manager, option => option.Ignore());
                });
                ICollection<SaleEntity> sales = Mapper.Map<ICollection<SaleDTO>, ICollection<SaleEntity>>(managerDTO.Sales);

                foreach (SaleEntity sale in sales)
                {
                    sale.ManagerId = (int)managerId;
                    DataBase.Sales.Create(sale);
                }
                DataBase.SaveChanges();
            }
        }

        private void AddNewManager(ManagerDTO managerDTO, IUnitOfWork DataBase)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SaleDTO, SaleEntity>().
                ForMember(dest => dest.Manager, option => option.Ignore());
                cfg.CreateMap<ManagerDTO, ManagerEntity>();
            });
            Mapper.AssertConfigurationIsValid();
            ManagerEntity manager = Mapper.Map<ManagerDTO, ManagerEntity>(managerDTO);
            DataBase.Managers.Create(manager);
            DataBase.SaveChanges();
        }
    }
}
