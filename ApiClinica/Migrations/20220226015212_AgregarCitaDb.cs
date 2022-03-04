using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiClinica.Migrations
{
    public partial class AgregarCitaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    idCita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCita = table.Column<DateTime>(nullable: false),
                    horaCita = table.Column<DateTime>(nullable: false),
                    Paciente_idPaciente = table.Column<int>(nullable: false),
                    Doctor_idDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.idCita);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    idDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ciDoctor = table.Column<string>(nullable: true),
                    nombreDoctor = table.Column<string>(nullable: true),
                    apellidosDoctor = table.Column<string>(nullable: true),
                    celularDoctor = table.Column<string>(nullable: true),
                    Usuario_idUsuario = table.Column<int>(nullable: false),
                    Especialidad_idEspecialidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.idDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Especialidads",
                columns: table => new
                {
                    idEspecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEspecialidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidads", x => x.idEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Historials",
                columns: table => new
                {
                    idHistorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alergia = table.Column<string>(nullable: true),
                    enfermedad = table.Column<string>(nullable: true),
                    tratamiento = table.Column<string>(nullable: true),
                    medicacion = table.Column<string>(nullable: true),
                    prescripcion = table.Column<string>(nullable: true),
                    Paciente_idPaciente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historials", x => x.idHistorial);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    idHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dias = table.Column<string>(nullable: true),
                    horaIngreso = table.Column<DateTime>(nullable: false),
                    horaSalida = table.Column<DateTime>(nullable: false),
                    doctor_idDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.idHorario);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(nullable: false),
                    apellidoPaterno = table.Column<string>(nullable: false),
                    apellidoMaterno = table.Column<string>(nullable: false),
                    edad = table.Column<string>(nullable: false),
                    ci = table.Column<string>(nullable: false),
                    celular = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: false),
                    Usuario_idUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Especialidads");

            migrationBuilder.DropTable(
                name: "Historials");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
