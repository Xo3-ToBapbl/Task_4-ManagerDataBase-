using ManagerDataBase.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerDataBase.BLL.DTO;
using ManagerDataBase.DAL.Interfaces;
using AutoMapper;
using ManagerDataBase.DAL.Entities;

namespace ManagerDataBase.BLL.Services
{
    public class Service : IService
    {
        public Service(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }

        IUnitOfWork DataBase { get; set; }


        public void AddSalesInfo(SaleDTO saleDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SaleDTO, Sale>());
            Sale sale = Mapper.Map<SaleDTO, Sale>(saleDTO);            
            DataBase.Sales.Create(sale);
            DataBase.SaveChanges();
        }

        public ManagerDTO GetManagerDTO(int id)
        {
            var manager = DataBase.Managers.Get(id);
            if (manager != null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Manager, ManagerDTO>();
                    cfg.CreateMap<Sale, SaleDTO>();
                });
                Mapper.AssertConfigurationIsValid();
                ManagerDTO managerDTO = Mapper.Map<Manager, ManagerDTO>(manager);
                return managerDTO;
            }
            else
            {
                return null;
            }
        }

        public ICollection<SaleDTO> GetSalesDTO(int managerId)
        {
            var sales = DataBase.Sales.FindAll(x => x.ManagerId == managerId).ToList();
            if (sales != null)
            {
                ICollection<SaleDTO> salesDTO = new List<SaleDTO>();
                Mapper.Initialize(cfg => cfg.CreateMap<Sale, SaleDTO>());

                foreach (var sale in sales)
                {
                    SaleDTO saleDTO = Mapper.Map<Sale, SaleDTO>(sale);
                    salesDTO.Add(saleDTO);
                }
                return salesDTO;
            }
            else
            {
                return null;
            }
        }


        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
