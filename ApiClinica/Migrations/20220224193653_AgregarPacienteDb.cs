using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiClinica.Migrations
{
    public partial class AgregarPacienteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Horarios",
                columns: table => new
                {
                    idHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dias = table.Column<string>(nullable: true),
                    horaIngreso = table.Column<DateTime>(nullable: false),
                    horaSalida = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.idHorario);
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
                    Especialidad_idEspecialidad = table.Column<int>(nullable: false),
                    Horario_idHorario = table.Column<int>(nullable: false),
                    Usuario_idUsuarioNavigationidUsuario = table.Column<int>(nullable: true),
                    Especialidad_idEspecialidadNavigationidEspecialidad = table.Column<int>(nullable: true),
                    Horario_idHorarioNavigationidHorario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.idDoctor);
                    table.ForeignKey(
                        name: "FK_Doctors_Especialidads_Especialidad_idEspecialidadNavigationidEspecialidad",
                        column: x => x.Especialidad_idEspecialidadNavigationidEspecialidad,
                        principalTable: "Especialidads",
                        principalColumn: "idEspecialidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Horarios_Horario_idHorarioNavigationidHorario",
                        column: x => x.Horario_idHorarioNavigationidHorario,
                        principalTable: "Horarios",
                        principalColumn: "idHorario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Usuarios_Usuario_idUsuarioNavigationidUsuario",
                        column: x => x.Usuario_idUsuarioNavigationidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
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
                    Usuario_idUsuario = table.Column<int>(nullable: false),
                    Usuario_idUsuarioNavigationidUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_Usuario_idUsuarioNavigationidUsuario",
                        column: x => x.Usuario_idUsuarioNavigationidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    idCita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCita = table.Column<DateTime>(nullable: false),
                    horaCita = table.Column<DateTime>(nullable: false),
                    Paciente_idPaciente = table.Column<int>(nullable: false),
                    Doctor_idDoctor = table.Column<int>(nullable: false),
                    Paciente_idPacienteNavigationId = table.Column<int>(nullable: true),
                    Doctor_idDoctorNavigationidDoctor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.idCita);
                    table.ForeignKey(
                        name: "FK_Citas_Doctors_Doctor_idDoctorNavigationidDoctor",
                        column: x => x.Doctor_idDoctorNavigationidDoctor,
                        principalTable: "Doctors",
                        principalColumn: "idDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_Paciente_idPacienteNavigationId",
                        column: x => x.Paciente_idPacienteNavigationId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Paciente_idPaciente = table.Column<int>(nullable: false),
                    Paciente_idPacienteNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historials", x => x.idHistorial);
                    table.ForeignKey(
                        name: "FK_Historials_Pacientes_Paciente_idPacienteNavigationId",
                        column: x => x.Paciente_idPacienteNavigationId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Doctor_idDoctorNavigationidDoctor",
                table: "Citas",
                column: "Doctor_idDoctorNavigationidDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Paciente_idPacienteNavigationId",
                table: "Citas",
                column: "Paciente_idPacienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Especialidad_idEspecialidadNavigationidEspecialidad",
                table: "Doctors",
                column: "Especialidad_idEspecialidadNavigationidEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Horario_idHorarioNavigationidHorario",
                table: "Doctors",
                column: "Horario_idHorarioNavigationidHorario");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Usuario_idUsuarioNavigationidUsuario",
                table: "Doctors",
                column: "Usuario_idUsuarioNavigationidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Historials_Paciente_idPacienteNavigationId",
                table: "Historials",
                column: "Paciente_idPacienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Usuario_idUsuarioNavigationidUsuario",
                table: "Pacientes",
                column: "Usuario_idUsuarioNavigationidUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Historials");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidads");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
