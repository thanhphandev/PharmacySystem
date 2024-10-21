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
        void AddUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(string username);
        List<UserModel> GetAllUsers();
        UserModel GetUserByUsername(string username);
    }
}
