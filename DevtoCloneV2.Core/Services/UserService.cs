using DevtoCloneV2.Core.Entities;
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
            try
            {
                var users = await _userRepository.GetAllUsers();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = (await _userRepository.GetUserById(id)) ?? throw new Exception();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = (await _userRepository.GetUserByEmail(email)) ?? throw new Exception();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateUser(User user)
        {
            try
            {
                _userRepository.CreateUser(user);
                await _userRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(int id, User user)
        {
            try
            {
                var existingUser = await GetUserById(id);

                existingUser.Username = user.Username;
                existingUser.Email = user.Email;

                _userRepository.UpdateUser(existingUser);
                await _userRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                var existingUser = await GetUserById(id);

                _userRepository.DeleteUser(existingUser);
                await _userRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
