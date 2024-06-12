using InkwellReads.Books.Infrastructure.Data;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InkwellReads.Books.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category, string>
    {
        private DataContext _context { get; init; }

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string id)
            => await _context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Category> GetSingleAsync(string id)
            => await _context.Categories.FindAsync(id) ?? new Category();

        public async Task SaveAsync(Category data)
        {
            await _context.Categories.AddAsync(data);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Category data)
        {
            _context.Categories.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
