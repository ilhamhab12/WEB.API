using BussinessLogic.Interface;
using BussinessLogic.Interface.Master;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bootcamp.API.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        // GET: api/Suppliers
        public IEnumerable<Supplier> Get()
        {
            // return new string[] { "value1", "value2" };
            return _supplierService.Get();
        }

        // GET: api/Suppliers/5
        public Supplier Get(int id)
        {
            return _supplierService.Get(id);
        }

        // POST: api/Suppliers
        public void Post([FromBody]SupplierParam supplierParam)
        {
            _supplierService.Insert(supplierParam);
        }

        // PUT: api/Suppliers/5
        public void Put(int id, SupplierParam supplierParam)
        {
            _supplierService.Update(id, supplierParam);
        }

        // DELETE: api/Suppliers/5
        public void Delete(int id)
        {
            _supplierService.Delete(id);
        }
    }
}
