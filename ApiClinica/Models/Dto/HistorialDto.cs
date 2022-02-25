namespace ApiClinica.Models.Dto
{
    public class HistorialDto
    { 
    public int idHistorial { get; set; }
    public string alergia { get; set; }
    public string enfermedad { get; set; }
    public string tratamiento { get; set; }
    public string medicacion { get; set; }
    public string prescripcion { get; set; }
    public int Paciente_idPaciente { get; set; }
}
}
