using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.API.DataAccess.Param
{
    public class SupplierParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset JoinDate { get; set; }
    }
}
