using Microsoft.EntityFrameworkCore;
using RestFlux.Application.Interfaces;
using RestFlux.Domain.Entities;
using RestFlux.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestFluxDbContext _context;
        public OrderRepository(RestFluxDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order) 
            => await _context.Orders.AddAsync(order);

        public async Task<Order?> GetByIdAsync(int id) 
            =>  await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);


        public async Task SaveChangesAsync() 
            => await _context.SaveChangesAsync();

    }
}
