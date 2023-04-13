using CrudUsers.Context;
using CrudUsers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudUsers.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext context;
        public UserService(DataBaseContext dataContext)
        {
            this.context = dataContext;
        }
        public async Task<User> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<string> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("Usuario no existe.");
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return "Usuario eliminado correctamente";
        }

        public async Task<List<User>> GetAllUser()
        {
            var listUser = await context.Users.ToListAsync();
            return listUser;
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

        public async Task<User> GetByNameUser(string name)
        {
            var user = await context.Users.FindAsync(name);
            if (user == null)
            {
                throw new Exception("Usuario no existe.");
            }
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var updateUser = await context.Users.FindAsync(user.Id);
            if (updateUser == null)
            {
                throw new Exception("Usuario no existe.");
            }
            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Address = user.Address;
            updateUser.CityId  = user.CityId;
            await context.SaveChangesAsync();
            return updateUser;
        }

    }
}
