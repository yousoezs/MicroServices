using GraphiteApi.Order.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphiteApi.Order.DataAccess.Contexts
{
    public class OrderContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailsModel> UserOrderDetails { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base (options) { }
    }
}
