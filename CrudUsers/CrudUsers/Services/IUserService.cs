using CrudUsers.Entities;

namespace CrudUsers.Services
{
    public interface IUserService
    {
        Task<User> GetByIdUser(int id);
        Task<User> GetByNameUser(string name);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);

        Task<List<User>> GetAllUser();

    }
}
