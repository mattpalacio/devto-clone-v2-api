using DevtoCloneV2.Core.Entities;
using DevtoCloneV2.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(object id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public void CreateUsers(IEnumerable<User> users)
        {
            _context.Users.AddRange(users);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(User user)
        {
            if (_context.Entry(user).State is EntityState.Modified)
            {
                _context.Users.Attach(user);
            }
            _context.Users.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
