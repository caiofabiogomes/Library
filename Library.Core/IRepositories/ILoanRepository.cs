using Library.Core.Entities;

namespace Library.Core.IRepositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<Loan> GetByIdAsync(int id);
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(Loan loan);
        Task<List<Loan>> GetAllByUserIdAsync(int userId);
    }
}
