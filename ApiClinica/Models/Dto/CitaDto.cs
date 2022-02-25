using System;

namespace ApiClinica.Models.Dto
{
    public class CitaDto
    {   public int idCita { get; set; }
        public DateTime fechaCita { get; set; }
        public DateTime horaCita { get; set; }
        public int Paciente_idPaciente { get; set; }
        public int Doctor_idDoctor { get; set; }
    }
}
