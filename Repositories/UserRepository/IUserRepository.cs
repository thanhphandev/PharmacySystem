using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacySystem.Models;

namespace PharmacySystem.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task AddUser(UserModel user);
        Task UpdateUser(UserModel user);
        Task DeleteUser(string username);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserByUsername(string username);
    }
}
