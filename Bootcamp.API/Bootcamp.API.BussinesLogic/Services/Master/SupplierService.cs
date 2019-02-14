using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.API.DataAccess.Model;
using Bootcamp.API.DataAccess.Param;
using Bootcamp.API.Common.Interfaces;
using Bootcamp.API.Common.Interfaces.Master;

namespace Bootcamp.API.BussinesLogic.Services.Master
{
    public class SupplierService : ISupplierService
    {
        bool status = false;
        private readonly ISupplierRepository _supplierRepository; 
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public bool Delete(int? Id)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert id if you want to delete");
                Console.Read();
            }
            else if (Id.ToString() == " ")
            {
                Console.WriteLine("Dont Insert white space");
                Console.Read();
            }
            else
            {
                status = _supplierRepository.Delete(Id);
                Console.WriteLine("Delete Succesfully");
                Console.Read();
            }
            return status;
        }

        public List<Supplier> Get()
        {
            return _supplierRepository.Get();
        }

        public Supplier Get(int? Id)
        {
            return _supplierRepository.Get(Id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            if (supplierParam == null)
            {
                Console.WriteLine("Please Insert Data");
                Console.Read();
            }
            else if (supplierParam.ToString() == " ")
            {
                Console.WriteLine("Dont Insert white space");
                Console.Read();
            }
            else
            {
                status = _supplierRepository.Insert(supplierParam);
                Console.WriteLine("Insert Successfuly");
                Console.Read();
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Please Insert Id");
                Console.Read();
            }
            else if (Id.ToString() == " ")
            {
                Console.WriteLine("Dont Insert white space");
                Console.Read();
            }
            else
            {
                if (supplierParam == null)
                {
                    Console.WriteLine("Please Insert Supplier");
                    Console.Read();
                }
                else if (supplierParam.ToString() == " ")
                {
                    Console.WriteLine("Dont Insert white space");
                    Console.Read();
                }
                else
                {
                    status = _supplierRepository.Update(Id, supplierParam);
                    Console.WriteLine("Update Successfuly");
                    Console.Read();
                }
            }
            return status;
        }
    }
}
