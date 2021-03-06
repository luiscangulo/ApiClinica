// <auto-generated />
using System;
using ApiClinica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiClinica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220226015355_AgregarPacienteDb")]
    partial class AgregarPacienteDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiClinica.Models.Cita", b =>
                {
                    b.Property<int>("idCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Doctor_idDoctor")
                        .HasColumnType("int");

                    b.Property<int>("Paciente_idPaciente")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horaCita")
                        .HasColumnType("datetime2");

                    b.HasKey("idCita");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("ApiClinica.Models.Doctor", b =>
                {
                    b.Property<int>("idDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Especialidad_idEspecialidad")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_idUsuario")
                        .HasColumnType("int");

                    b.Property<string>("apellidosDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("celularDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ciDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idDoctor");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ApiClinica.Models.Especialidad", b =>
                {
                    b.Property<int>("idEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreEspecialidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEspecialidad");

                    b.ToTable("Especialidads");
                });

            modelBuilder.Entity("ApiClinica.Models.Historial", b =>
                {
                    b.Property<int>("idHistorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Paciente_idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("alergia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enfermedad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tratamiento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idHistorial");

                    b.ToTable("Historials");
                });

            modelBuilder.Entity("ApiClinica.Models.Horario", b =>
                {
                    b.Property<int>("idHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doctor_idDoctor")
                        .HasColumnType("int");

                    b.Property<DateTime>("horaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horaSalida")
                        .HasColumnType("datetime2");

                    b.HasKey("idHorario");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("ApiClinica.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Usuario_idUsuario")
                        .HasColumnType("int");

                    b.Property<string>("apellidoMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("edad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ApiClinica.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
