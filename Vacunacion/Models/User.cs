using System.ComponentModel.DataAnnotations;
using NuGet.DependencyResolver;

namespace Vacunacion.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        // Relación con People
        public ICollection<Person>? Person { get; set; }
    }
}
