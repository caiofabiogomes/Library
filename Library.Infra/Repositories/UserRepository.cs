using Library.Core.Entities;
using Library.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;
        public UserRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            user.Delete();

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .ToListAsync();
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == passwordHash && !x.IsDeleted);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(x => x.Loans)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(User user)
        { 
            await _dbContext.SaveChangesAsync();
        }
    }
}
