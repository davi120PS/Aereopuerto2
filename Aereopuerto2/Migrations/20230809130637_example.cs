using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aereopuerto2.Migrations
{
    /// <inheritdoc />
    public partial class example : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    PKEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Puesto = table.Column<string>(type: "longtext", nullable: true),
                    Matricula = table.Column<string>(type: "longtext", nullable: false),
                    Contraseña = table.Column<string>(type: "longtext", nullable: false),
                    Correo = table.Column<string>(type: "longtext", nullable: false),
                    Sexo = table.Column<string>(type: "longtext", nullable: false),
                    Horarios = table.Column<string>(type: "longtext", nullable: true),
                    Estatus = table.Column<string>(type: "longtext", nullable: true),
                    Conexion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.PKEmpleado);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    PKCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FKEmpleado = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    INE = table.Column<string>(type: "longtext", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "longtext", nullable: false),
                    TipoServicio = table.Column<string>(type: "longtext", nullable: false),
                    Pasajeros = table.Column<int>(type: "int", nullable: false),
                    Solicitud = table.Column<string>(type: "longtext", nullable: false),
                    NombreConductor = table.Column<string>(type: "longtext", nullable: true),
                    HoraConductor = table.Column<string>(type: "longtext", nullable: true),
                    HoraHotel = table.Column<string>(type: "longtext", nullable: true),
                    Estatus = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.PKCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Empleado_FKEmpleado",
                        column: x => x.FKEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "PKEmpleado");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    PKConductor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FKEmpleado = table.Column<int>(type: "int", nullable: true),
                    Licencia = table.Column<int>(type: "int", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estatus = table.Column<string>(type: "longtext", nullable: false),
                    Calificaciones = table.Column<int>(type: "int", nullable: false),
                    NotasAdicionales = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.PKConductor);
                    table.ForeignKey(
                        name: "FK_Conductor_Empleado_FKEmpleado",
                        column: x => x.FKEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "PKEmpleado");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    PKSistemas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Detalles = table.Column<string>(type: "longtext", nullable: false),
                    FKEmpleado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.PKSistemas);
                    table.ForeignKey(
                        name: "FK_Sistema_Empleado_FKEmpleado",
                        column: x => x.FKEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "PKEmpleado");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    PKChat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FKCliente = table.Column<int>(type: "int", nullable: true),
                    FKEmpleado = table.Column<int>(type: "int", nullable: true),
                    Gerente = table.Column<string>(type: "longtext", nullable: false),
                    Mensaje = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.PKChat);
                    table.ForeignKey(
                        name: "FK_Chat_Cliente_FKCliente",
                        column: x => x.FKCliente,
                        principalTable: "Cliente",
                        principalColumn: "PKCliente");
                    table.ForeignKey(
                        name: "FK_Chat_Empleado_FKEmpleado",
                        column: x => x.FKEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "PKEmpleado");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    PKReservas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FKEmpleado = table.Column<int>(type: "int", nullable: true),
                    FKCliente = table.Column<int>(type: "int", nullable: true),
                    HoraConductor = table.Column<string>(type: "longtext", nullable: false),
                    HoraHotel = table.Column<string>(type: "longtext", nullable: false),
                    Estatus = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.PKReservas);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_FKCliente",
                        column: x => x.FKCliente,
                        principalTable: "Cliente",
                        principalColumn: "PKCliente");
                    table.ForeignKey(
                        name: "FK_Reserva_Empleado_FKEmpleado",
                        column: x => x.FKEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "PKEmpleado");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "PKCliente", "Apellido", "Correo", "Edad", "Estatus", "FKEmpleado", "HoraConductor", "HoraHotel", "INE", "Nombre", "NombreConductor", "Pasajeros", "Solicitud", "Telefono", "TipoServicio" },
                values: new object[,]
                {
                    { 1, "Rabanne", "paco@", 36, "Por confirmar", null, "POR ASIGNAR", "POR ASIGNAR", "PACCB24", "Paco", "", 1, "Aceptable", 23412, "VIP" },
                    { 2, "Herrera", "caro@", 23, "Por confirmar", null, "POR ASIGNAR", "POR ASIGNAR", "CAHR3G", "Carolina", "", 2, "Aceptable", 87868, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "PKEmpleado", "Conexion", "Contraseña", "Correo", "Estatus", "Horarios", "Matricula", "Nombre", "Puesto", "Sexo" },
                values: new object[,]
                {
                    { 1, 0, "123", "davi@", "", "", "davi", "David", "Sistema", "Hombre" },
                    { 2, 0, "123", "dieg@", "", "", "dieg", "Diego", "Reservas", "Hombre" },
                    { 3, 0, "123", "joge@", "", "2PM-10PM", "joge", "Jorge", "Conductor", "Hombre" },
                    { 4, 0, "123", "joge@", "", "10PM-6AM", "jony", "Jonathan", "Conductor", "Hombre" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_FKCliente",
                table: "Chat",
                column: "FKCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_FKEmpleado",
                table: "Chat",
                column: "FKEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_FKEmpleado",
                table: "Cliente",
                column: "FKEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Conductor_FKEmpleado",
                table: "Conductor",
                column: "FKEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_FKCliente",
                table: "Reserva",
                column: "FKCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_FKEmpleado",
                table: "Reserva",
                column: "FKEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Sistema_FKEmpleado",
                table: "Sistema",
                column: "FKEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Sistema");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
