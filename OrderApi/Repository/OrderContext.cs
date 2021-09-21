using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Repository
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> option) : base(option)
        { }

        public DbSet<OrderModel> Orders { get; set; }
    }
}
