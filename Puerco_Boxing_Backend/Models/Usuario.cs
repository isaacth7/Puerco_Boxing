using System.ComponentModel.DataAnnotations;

namespace Puerco_Boxing_Backend.Models
{
    public class Usuario
    {
        [Key]  // Define esta propiedad como clave primaria
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]  // Valida que sea un correo electrónico válido
        public string Correo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Required]
        public string Cedula { get; set; }

        public string Rol { get; set; } = "cliente";

        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;
    }
}
