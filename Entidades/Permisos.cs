using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea6Lab.Entidades
{
   public class Permisos
    {
        [Key]
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int VecesAsignado { get; set; }

        public Permisos()
        {
            PermisoId = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            VecesAsignado = 0;
        }
    }
}
