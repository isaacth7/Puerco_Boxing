using System.ComponentModel.DataAnnotations;

namespace Puerco_Boxing_Backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } // "Cliente" o "Administrador"
        public string ImagenPerfil { get; set; } // Nueva propiedad para la imagen
    }

}
