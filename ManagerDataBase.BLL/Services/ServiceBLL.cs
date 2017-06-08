using ManagerDataBase.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.DAL.Interfaces;
using AutoMapper;
using ManagerDataBase.DAL.Entities;

namespace ManagerDataBase.BLL.Services
{
    public class ServiceBLL : IServiceBLL
    {
        public ServiceBLL(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }

        IUnitOfWork DataBase { get; set; }

        public void HandleManagerInfo(ManagerDTO managerDTO)
        {
            int? managerId = DataBase.Managers.GetId(x => x.SecondName == managerDTO.SecondName);
            if (managerId != null)
            {
                AddSalesInfo(managerDTO, (int)managerId);
            }
            else
            {
                AddNewManager(managerDTO);
            }
            DataBase.Dispose();
        }

        private void AddSalesInfo(ManagerDTO managerDTO, int managerId)
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

        private void AddNewManager(ManagerDTO managerDTO)
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


        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
