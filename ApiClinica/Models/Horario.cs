using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiClinica.Models
{
    public class Horario
    {
        public Horario()
        {
            Doctor = new HashSet<Doctor>();
        }
        [Key]
        public int idHorario { get; set; }
        public string dias { get; set; }
        public DateTime horaIngreso { get; set; }
        public DateTime horaSalida { get; set; }


        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
