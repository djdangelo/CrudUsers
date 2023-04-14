using CrudUsers.Entities;

namespace CrudUsers.Services
{
    public interface IRoleService
    {
        Task<Role> GetRoleById(int id);
        Task<Role> CreateRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task<string> DeleteRole(int id);
        Task<List<Role>> GetAllRole();
    }
}
