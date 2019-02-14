using Bootcamp.API.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.API.DataAccess.Model
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset JoinDate { get; set; }
    }
}
