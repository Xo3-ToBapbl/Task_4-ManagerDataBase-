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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ManagerDTO, ManagerEntity>();
                cfg.CreateMap<SaleDTO, SaleEntity>();
            });
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
        }

        private void AddSalesInfo(ManagerDTO managerDTO, int managerId)
        {           
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
