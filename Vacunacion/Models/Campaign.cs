using System.ComponentModel.DataAnnotations;


namespace Vacunacion.Models
{
    public class Campaign
    {
        [Key]
        public int CampaignId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Nombre debe tener entre 2 y 50 caracteres.")]
        [RegularExpression(@"^[A-Za-zÁáÉéÍíÓóÚúÜüÑñ\s]+$", ErrorMessage = "El campo Nombre no debe contener caracteres especiales.")]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "El campo Tipo Vacuna es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Tipo Vacuna debe tener entre 2 y 50 caracteres.")]
        public string TypeVacine { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int UserId { get; set; }

        // Relación con Brigades
        public ICollection<Brigade>? Brigades { get; set; }
    }
}
