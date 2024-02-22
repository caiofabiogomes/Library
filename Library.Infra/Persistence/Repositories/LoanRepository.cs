using Library.Core.Entities;
using Library.Core.IRepositories;
using Library.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _dbContext;
        public LoanRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Loan loan)
        {
            loan.Delete();

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _dbContext.Loans
                .Include(x => x.Book)
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Loan>> GetAllByUserIdAsync(int userId)
        {
            return await _dbContext.Loans
                .Include(x => x.Book)
                .Where(x => x.UserId == userId && !x.Book.IsDeleted)
                .ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _dbContext.Loans
                .Include(x => x.Book)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(Loan loan)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
