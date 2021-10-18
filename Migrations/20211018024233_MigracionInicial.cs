﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea6Lab.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    VecesAsignado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "RolesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EsAsignado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesDetalle_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "PermisoId", "Descripcion", "Nombre", "VecesAsignado" },
                values: new object[] { 1, "Para usuarios", "Usuario", 0 });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "PermisoId", "Descripcion", "Nombre", "VecesAsignado" },
                values: new object[] { 2, "Para administradores", "Administrador", 0 });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "PermisoId", "Descripcion", "Nombre", "VecesAsignado" },
                values: new object[] { 3, "Para Estudiantes", "Estudiante", 0 });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "PermisoId", "Descripcion", "Nombre", "VecesAsignado" },
                values: new object[] { 4, "Para que empleados puedan acceder", "Empleado", 0 });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "PermisoId", "Descripcion", "Nombre", "VecesAsignado" },
                values: new object[] { 5, "Para que Solteros accedan", "Solteros", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_RolesDetalle_RolId",
                table: "RolesDetalle",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "RolesDetalle");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
