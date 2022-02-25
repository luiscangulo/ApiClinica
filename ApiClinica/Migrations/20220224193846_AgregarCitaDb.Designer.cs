﻿// <auto-generated />
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
    [Migration("20220224193846_AgregarCitaDb")]
    partial class AgregarCitaDb
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

                    b.Property<int?>("Doctor_idDoctorNavigationidDoctor")
                        .HasColumnType("int");

                    b.Property<int>("Paciente_idPaciente")
                        .HasColumnType("int");

                    b.Property<int?>("Paciente_idPacienteNavigationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horaCita")
                        .HasColumnType("datetime2");

                    b.HasKey("idCita");

                    b.HasIndex("Doctor_idDoctorNavigationidDoctor");

                    b.HasIndex("Paciente_idPacienteNavigationId");

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

                    b.Property<int?>("Especialidad_idEspecialidadNavigationidEspecialidad")
                        .HasColumnType("int");

                    b.Property<int>("Horario_idHorario")
                        .HasColumnType("int");

                    b.Property<int?>("Horario_idHorarioNavigationidHorario")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_idUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("Usuario_idUsuarioNavigationidUsuario")
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

                    b.HasIndex("Especialidad_idEspecialidadNavigationidEspecialidad");

                    b.HasIndex("Horario_idHorarioNavigationidHorario");

                    b.HasIndex("Usuario_idUsuarioNavigationidUsuario");

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

                    b.Property<int?>("Paciente_idPacienteNavigationId")
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

                    b.HasIndex("Paciente_idPacienteNavigationId");

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

                    b.Property<int?>("Usuario_idUsuarioNavigationidUsuario")
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

                    b.HasIndex("Usuario_idUsuarioNavigationidUsuario");

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

            modelBuilder.Entity("ApiClinica.Models.Cita", b =>
                {
                    b.HasOne("ApiClinica.Models.Doctor", "Doctor_idDoctorNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("Doctor_idDoctorNavigationidDoctor");

                    b.HasOne("ApiClinica.Models.Paciente", "Paciente_idPacienteNavigation")
                        .WithMany("Cita")
                        .HasForeignKey("Paciente_idPacienteNavigationId");
                });

            modelBuilder.Entity("ApiClinica.Models.Doctor", b =>
                {
                    b.HasOne("ApiClinica.Models.Especialidad", "Especialidad_idEspecialidadNavigation")
                        .WithMany("Doctor")
                        .HasForeignKey("Especialidad_idEspecialidadNavigationidEspecialidad");

                    b.HasOne("ApiClinica.Models.Horario", "Horario_idHorarioNavigation")
                        .WithMany("Doctor")
                        .HasForeignKey("Horario_idHorarioNavigationidHorario");

                    b.HasOne("ApiClinica.Models.Usuario", "Usuario_idUsuarioNavigation")
                        .WithMany("Doctor")
                        .HasForeignKey("Usuario_idUsuarioNavigationidUsuario");
                });

            modelBuilder.Entity("ApiClinica.Models.Historial", b =>
                {
                    b.HasOne("ApiClinica.Models.Paciente", "Paciente_idPacienteNavigation")
                        .WithMany("Historial")
                        .HasForeignKey("Paciente_idPacienteNavigationId");
                });

            modelBuilder.Entity("ApiClinica.Models.Paciente", b =>
                {
                    b.HasOne("ApiClinica.Models.Usuario", "Usuario_idUsuarioNavigation")
                        .WithMany("Paciente")
                        .HasForeignKey("Usuario_idUsuarioNavigationidUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
