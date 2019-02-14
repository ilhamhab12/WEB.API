using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using Common.Interface.Master;
using Common.Interface;

namespace BussinessLogic.Interface.Master
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService (ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        bool status = false;
        public bool Delete(int? Id)
        {
            var idDel = Get(Id);
            if (idDel != null)
            {
                status = _supplierRepository.Delete(Id);
            }
            return status;
        }

        public List<Supplier> Get()
        {
            return _supplierRepository.Get().ToList();
        }

        public Supplier Get(int? Id)
        {
           return _supplierRepository.Get(Id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            if(supplierParam != null)
            {
                status = _supplierRepository.Insert(supplierParam);
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            if(Id != null && supplierParam != null)
            {
                status = _supplierRepository.Update(Id, supplierParam);
            }
            return status;
        }
    }
}
