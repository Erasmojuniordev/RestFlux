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
    public class ProductRepository : IProductRepository
    {
        private readonly RestFluxDbContext _context;

        public ProductRepository(RestFluxDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product) 
            => await _context.Products.AddAsync(product);

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                   .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
