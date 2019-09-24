using System;
using System.Collections.Generic;
using System.Text;

namespace Vegrocery.Domain.DTO
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
