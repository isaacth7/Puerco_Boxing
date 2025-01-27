using System.ComponentModel.DataAnnotations;

namespace Puerco_Boxing_Backend.Models
{
    public class Horario
    {
        [Key]
        public int Id  { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; } //Hora de inicio de la clase

        [Required]
        public TimeSpan HoraFin {  get; set; } //Hora de fin de la clase

        public bool Disponible { get; set; } = true; //Indica si está disponible 
    }
}
