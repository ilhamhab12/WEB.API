using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.API.DataAccess.Model;
using Bootcamp.API.DataAccess.Param;
using Bootcamp.API.DataAccess.Context;

namespace Bootcamp.API.Common.Interfaces.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Supplier supplier = new Supplier();
        public bool Delete(int? Id)
        {
            var result = 0;
            supplier = Get(Id);
            supplier.IsDelete = true;
            supplier.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = myContext.SaveChanges();
            if (result == 0)
            {
                return status = true;
            }
            return status;
        }

        public List<Supplier> Get()
        {
            var get = myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Supplier Get(int? Id)
        {
            var getId = myContext.Suppliers.Find(Id);
            return getId;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            var supplier = new Supplier();
            supplier.Name = supplierParam.Name;
            supplier.JoinDate = DateTimeOffset.UtcNow.LocalDateTime;
            supplier.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
            myContext.Suppliers.Add(supplier);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return status = true;
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            var result = 0;
            var supplier = Get(Id);
            //var get = myContext.Suppliers.Find(id);
            supplier.Name = supplierParam.Name;
            supplier.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return status = true;
            }
            return status;
        }
    }
}
