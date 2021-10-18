﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea6Lab.DAL;

namespace Tarea6Lab.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Tarea6Lab.Entidades.Permisos", b =>
                {
                    b.Property<int>("PermisoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("VecesAsignado")
                        .HasColumnType("INTEGER");

                    b.HasKey("PermisoId");

                    b.ToTable("Permiso");

                    b.HasData(
                        new
                        {
                            PermisoId = 1,
                            Descripcion = "Para usuarios",
                            Nombre = "Usuario",
                            VecesAsignado = 0
                        },
                        new
                        {
                            PermisoId = 2,
                            Descripcion = "Para administradores",
                            Nombre = "Administrador",
                            VecesAsignado = 0
                        },
                        new
                        {
                            PermisoId = 3,
                            Descripcion = "Para Estudiantes",
                            Nombre = "Estudiante",
                            VecesAsignado = 0
                        },
                        new
                        {
                            PermisoId = 4,
                            Descripcion = "Para que empleados puedan acceder",
                            Nombre = "Empleado",
                            VecesAsignado = 0
                        },
                        new
                        {
                            PermisoId = 5,
                            Descripcion = "Para que Solteros accedan",
                            Nombre = "Solteros",
                            VecesAsignado = 0
                        });
                });

            modelBuilder.Entity("Tarea6Lab.Entidades.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Tarea6Lab.Entidades.RolesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EsAsignado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermisoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RolId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("RolesDetalle");
                });

            modelBuilder.Entity("Tarea6Lab.Entidades.RolesDetalle", b =>
                {
                    b.HasOne("Tarea6Lab.Entidades.Roles", null)
                        .WithMany("Detalle")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tarea6Lab.Entidades.Roles", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
