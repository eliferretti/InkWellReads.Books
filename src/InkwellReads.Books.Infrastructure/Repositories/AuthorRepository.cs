using InkwellReads.Books.Infrastructure.Data;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InkwellReads.Books.Infrastructure.Repositories
{
    public class AuthorRepository : IRepository<Author, string>
    {
        private DataContext _context { get; init; }

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string id)
            => await _context.Authors.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task<IEnumerable<Author>> GetAllAsync()
            => await _context.Authors.Include(a => a.Books).ToListAsync();

        public async Task<Author> GetSingleAsync(string id)
            => await _context.Authors.FindAsync(id) ?? new Author();

        public async Task SaveAsync(Author Data)
        {
            await _context.Authors.AddAsync(Data);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Author data)
        {
            _context.Authors.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
