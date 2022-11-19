using DevtoCloneV2.Core.Entities;
using DevtoCloneV2.Core.Exceptions;
using DevtoCloneV2.Core.Interfaces.Repository;
using DevtoCloneV2.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id)
                ?? throw new NotFoundCoreException($"User with id {id} not found.");
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email)
                ?? throw new NotFoundCoreException($"User with email {email} not found.");
        }

        public async Task CreateUser(User user)
        {
            _userRepository.CreateUser(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUser(int id, User user)
        {
            var existingUser = await GetUserById(id);
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;

            _userRepository.UpdateUser(existingUser);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUser(int id)
        {
            var existingUser = await GetUserById(id);
            _userRepository.DeleteUser(existingUser);
            await _userRepository.SaveAsync();
        }
    }
}
