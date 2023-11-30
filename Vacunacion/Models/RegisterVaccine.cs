using System.ComponentModel.DataAnnotations;

namespace Vacunacion.Models
{
    public class RegisterVaccine
    {
        internal int TotalVacunas;

        [Key]
        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int UserId { get; set; }
    }
}
