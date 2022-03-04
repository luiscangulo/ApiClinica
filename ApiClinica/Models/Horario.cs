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
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClinica.Models
{
    public class Horario
    {
        public Horario()
        {
            this.Doctors = new HashSet<Doctor>();
        }
        [Key]
        public int idHorario { get; set; }
        public string dias { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime horaIngreso { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime horaSalida { get; set; }

        public int doctor_idDoctor { get; set; }

        [NotMapped]
        public virtual Doctor Doctor { get; set; }

        [NotMapped]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
