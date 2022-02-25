using System;

namespace ApiClinica.Models.Dto
{
    public class HorarioDto
    {

        public int idHorario { get; set; }
        public string dias { get; set; }
        public DateTime horaIngreso { get; set; }
        public DateTime horaSalida { get; set; }
    }
}