namespace ApiClinica.Models.Dto
{
    public class DoctorDto
    {   public int idDoctor { get; set; }
        public string ciDoctor { get; set; }
        public string nombreDoctor { get; set; }
        public string apellidosDoctor { get; set; }
        public string celularDoctor { get; set; }
        public int Usuario_idUsuario { get; set; }
        public int Especialidad_idEspecialidad { get; set; }
        public int Horario_idHorario { get; set; }
    }
}
