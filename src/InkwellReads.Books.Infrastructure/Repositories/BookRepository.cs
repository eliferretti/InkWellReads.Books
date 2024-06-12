using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using InkwellReads.Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InkwellReads.Books.Infrastructure.Repositories
{
    public class BookRepository : IRepository<Book, string>
    {
        private DataContext _context { get; init; }

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string id)
            => await _context.Books.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task<IEnumerable<Book>> GetAllAsync() =>
            await _context.Books.Include(a => a.Author).Include(c => c.Category).ToListAsync();

        public async Task<Book> GetSingleAsync(string id) =>
            await _context.Books.Include(a => a.Author).Include(c => c.Category).FirstOrDefaultAsync(b => b.Id == id) ?? new Book();

        public async Task SaveAsync(Book data)
        {
            await _context.Books.AddAsync(data);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Book data)
        {
            _context.Books.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
