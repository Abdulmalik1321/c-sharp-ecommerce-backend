using System.Text;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Utils;

namespace BackendTeamwork.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;
        private IConfiguration _config;

        public UserService(IUserRepository UserRepository, IConfiguration config)
        {
            _UserRepository = UserRepository;
            _config = config;
        }

        public IEnumerable<User> FindMany()
        {
            return _UserRepository.FindMany();
        }
        public async Task<User?> FindOne(Guid id)
        {
            return await _UserRepository.FindOne(id);
        }

        public async Task<User> CreateOne(User newUser)
        {
            byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);
            PasswordUtils.HashPassword(newUser.Password, out string hashedPassword, pepper);
            newUser.Password = hashedPassword;
            return await _UserRepository.CreateOne(newUser);
        }

        public async Task<User?> UpdateOne(Guid userId, User updatedUser)
        {
            User? targetUser = await _UserRepository.FindOne(userId);
            if (targetUser is null)
            {
                return null;
            }
            byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);
            PasswordUtils.HashPassword(updatedUser.Password, out string hashedPassword, pepper);
            updatedUser.Password = hashedPassword;
            return await _UserRepository.UpdateOne(updatedUser);
        }

        public async Task<User?> DeleteOne(Guid userId)
        {
            User? deletedUser = await _UserRepository.FindOne(userId);
            if (deletedUser is null)
            {
                return null;
            }
            return await _UserRepository.DeleteOne(deletedUser);
        }


    }
}