using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Vacunacion.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "El campo CI es obligatorio.")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "El campo CI no debe contener caracteres especiales.")]
        public string CI { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Nombre debe tener entre 2 y 50 caracteres.")]
        [RegularExpression(@"^[A-Za-zÁáÉéÍíÓóÚúÜüÑñ\s]+$", ErrorMessage = "El campo Nombre no debe contener caracteres especiales.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Apellido debe tener entre 2 y 50 caracteres.")]
        [RegularExpression(@"^[A-Za-zÁáÉéÍíÓóÚúÜüÑñ\s]+$", ErrorMessage = "El campo Apellido no debe contener caracteres especiales.")]
        public string LastName { get; set; }
        [RegularExpression(@"^[A-Za-zÁáÉéÍíÓóÚúÜüÑñ\s]+$", ErrorMessage = "El campo Segundo Apellido no debe contener caracteres especiales.")]
        public string SecondLastName { get; set; }
        [Required(ErrorMessage = "El campo Género es obligatorio.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El campo Teléfono no debe exceder los 15 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo Teléfono debe contener solo números.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [RegularExpression("^[a-zA-Z0-9\\s]*$", ErrorMessage = "La dirección debe contener solo letras, números y espacios.")]
        public string Address { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        // Clave foránea
        public int UserId { get; set; }
     
    }
}
