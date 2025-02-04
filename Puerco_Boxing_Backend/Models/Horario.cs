using System.ComponentModel.DataAnnotations;

namespace Puerco_Boxing_Backend.Models
{
    public class Horario
    {
        public int Id  { get; set; }
        public TimeSpan HoraInicio { get; set; } //Hora de inicio de la clase

        public TimeSpan HoraFin {  get; set; } //Hora de fin de la clase

        public bool Disponible { get; set; } = true; //Indica si está disponible 


    }
}
