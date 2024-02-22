using Library.Core.Entities;
using Library.Core.IRepositories;
using Library.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            book.Delete();

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books
                .Include(x => x.Loans)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books
                .Include(x => x.Loans)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(Book book)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
