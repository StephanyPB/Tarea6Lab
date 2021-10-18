using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea6Lab.Entidades;

namespace Tarea6Lab.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        
        public DbSet<Permisos> Permiso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source = data\Permisoscontrol.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permisos>().HasData(
               new Permisos { PermisoId = 1, Nombre = "Usuario", VecesAsignado = 0, Descripcion = "Para usuarios" },
                new Permisos { PermisoId = 2, Nombre = "Administrador", VecesAsignado = 0, Descripcion = "Para administradores" },
                 new Permisos { PermisoId = 3, Nombre = "Estudiante", VecesAsignado = 0, Descripcion = "Para Estudiantes" },
                  new Permisos { PermisoId = 4, Nombre = "Empleado", VecesAsignado = 0, Descripcion = "Para que empleados puedan acceder" },
                  new Permisos { PermisoId = 5, Nombre = "Solteros", VecesAsignado = 0, Descripcion = "Para que Solteros accedan" }
               );
        }

    }
}
