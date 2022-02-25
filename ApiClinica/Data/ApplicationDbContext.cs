using ApiClinica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ApiClinica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }
        public DbSet<Paciente> Pacientes {  get; set;}
        public DbSet<Usuario> Usuarios {  get; set;}  
        public DbSet<Historial> Historials {  get; set;}

        public DbSet<Doctor> Doctors {  get; set;}
        public DbSet<Especialidad> Especialidads { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        public DbSet<Cita> Citas { get; set; }
    }
}
