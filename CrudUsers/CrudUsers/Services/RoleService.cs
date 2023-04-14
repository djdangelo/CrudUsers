using CrudUsers.Context;
using CrudUsers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudUsers.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataBaseContext context;
        public RoleService(DataBaseContext dataContext)
        {
            this.context = dataContext;
        }
        public async Task<Role> CreateRole(Role role)
        {
            context.Roles.Add(role);
            await context.SaveChangesAsync();
            return role;
        }

        public async Task<string> DeleteRole(int id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Rol no existe");
            }
            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return "Rol eliminado correctamente.";
        }

        public async Task<List<Role>> GetAllRole()
        {
            var listRole = await context.Roles.ToListAsync();
            return listRole;
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Rol no existe.");
            }
            return role;
        }

        public async Task<Role> UpdateRole(Role updateRole)
        {
            var role = await context.Roles.FindAsync(updateRole.Id);
            if (role == null)
            {
                throw new Exception("Rol no existe.");
            }
            role.Name = updateRole.Name;
            await context.SaveChangesAsync();
            return updateRole;
        }
    }
}
