using CrudUsers.Context;
using CrudUsers.Entities;

namespace CrudUsers.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext context;
        public UserService(DataBaseContext dataContext)
        {
            this.context = dataContext;
        }
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
               throw new Exception("Usuario no existe.");
            }
            return user;
        }

        public Task<User> GetByNameUser(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
