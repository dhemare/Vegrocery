using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegrocery.WebAPI.Contracts
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
