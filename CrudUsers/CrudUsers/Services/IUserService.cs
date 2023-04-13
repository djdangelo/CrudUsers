using CrudUsers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsers.Services
{
    public interface IUserService
    {
        Task<User> GetByIdUser(int id);
        Task<User> GetByNameUser(string name);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<string> DeleteUser(int id);

        Task<List<User>> GetAllUser();

    }
}
