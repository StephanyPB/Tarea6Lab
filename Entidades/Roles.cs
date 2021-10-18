using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea6Lab.Entidades
{
     public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }  
        [ForeignKey("RolId")]
        public virtual List<RolesDetalle> Detalle { get; set; }


        public Roles()
        {
            RolId = 0;
            FechaCreacion = DateTime.Now;
            Descripcion = string.Empty;
            Activo = false;
            Detalle = new List<RolesDetalle>();
        }

        public void AgregarDetalle(RolesDetalle detalle)
        {
            this.Detalle.Add(detalle);
        }
        public void AgregarDetalle(int RolId, int PermisoId, bool esAsignado, string descripcion)
        {
            this.Detalle.Add(new RolesDetalle(0, RolId, PermisoId, esAsignado, descripcion));
        }
    }
}
