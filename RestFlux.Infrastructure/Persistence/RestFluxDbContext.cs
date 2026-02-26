using Microsoft.EntityFrameworkCore;
using RestFlux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Infrastructure.Persistence
{
    public class RestFluxDbContext : DbContext
    {
        public RestFluxDbContext(DbContextOptions<RestFluxDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
