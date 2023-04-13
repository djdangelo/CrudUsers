using System.ComponentModel.DataAnnotations;

namespace CrudUsers.Entities
{
    public class User
    {
        public int Id { get; init; }
        [MaxLength(20, ErrorMessage = "El nombre solo debe tener 20 carasteres.")]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int CityId { get; set; }
        public virtual City? City { get; }
        public virtual List<Role>? Roles { get; set; }

    }
}
