using System.ComponentModel.DataAnnotations;

namespace Vacunacion.Models
{
    public class Brigade
    {
        [Key]
        public int BrigadeId { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "La Descripción no debe contener caracteres especiales.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo Latitud es obligatorio.")]
        
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "El campo Longitud es obligatorio.")]
      
        public decimal Longitude { get; set; }
        public int CampaignId { get; set; }
    }
}
