using DevtoCloneV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Interfaces.Service
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserByEmail(int email);
        public Task<User> GetUserByEmail(string email);
        public Task CreateUser(User user);
        public Task UpdateUser(int id, User user);
        public Task DeleteUser(int id);
    }
}
