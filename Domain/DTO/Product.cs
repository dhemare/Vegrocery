using System;
using System.Collections.Generic;
using System.Text;

namespace Vegrocery.Domain.DTO
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
