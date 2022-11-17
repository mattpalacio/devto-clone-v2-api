using DevtoCloneV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User?> GetUserById(object id);
        public Task<User?> GetUserByEmail(string email);
        public void CreateUser(User user);
        public void CreateUsers(IEnumerable<User> users);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        public Task SaveAsync();
    }
}
