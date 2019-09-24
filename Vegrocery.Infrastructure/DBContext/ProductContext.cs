using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vegrocery.Infrastructure.Entities;

namespace Vegrocery.Infrastructure.DBContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
               
    }
}
