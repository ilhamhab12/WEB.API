using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        MyContext myContext = new MyContext();
        Supplier supplier = new Supplier();

        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            var SupplierId = Get(Id);
            SupplierId.IsDelete = true;
            SupplierId.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public List<Supplier> Get()
        {
            return myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
        }

        public Supplier Get(int? Id)
        {
            return myContext.Suppliers.Find(Id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            supplier.Name = supplierParam.Name;
            supplier.JoinDate = DateTimeOffset.UtcNow.LocalDateTime;
            supplier.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
            myContext.Suppliers.Add(supplier);
            result = myContext.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            var result = 0;
            var SupplierId = Get(Id);
            SupplierId.Name = supplierParam.Name;
            SupplierId.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
