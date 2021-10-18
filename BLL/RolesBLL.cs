using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tarea6Lab.DAL;
using Tarea6Lab.Entidades;

namespace Tarea6Lab.BLL
{
     public class RolesBLL
    {
        /// <summary>
        /// Permite Guardar una entidad en la base de datos
        /// </summary>

        public static bool Guardar(Roles role)
        {
            if (!Existe(role.RolId))
                return Insertar(role);
            else
                return Modificar(role);
        }
        private static bool Insertar(Roles roles)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la DB
            Contexto db = new Contexto();
            try
            {
                if (db.Roles.Add(roles) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Modificar una entidad en la base de datos
        /// </summary>
        private static bool Modificar(Roles role)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                //busca la entidad en la base de datos y la elimina
                db.Database.ExecuteSqlRaw($"Delete FROM RolesDetalle Where RolId={role.RolId}");

                foreach (var item in role.Detalle)
                {
                    item.Id = 0;
                    db.Entry(item).State = EntityState.Added;
                }

                //marcar la entidad como modificada para que el contexto sepa como proceder
                db.Entry(role).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
       
        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                Roles roles = db.Roles.Find(id);

                if (Existe(id))
                {
                    db.Roles.Remove(roles);
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        public static Roles Buscar(int id)
        {
            Contexto db = new Contexto();
            Roles roles = new Roles();
            try
            {
                roles = db.Roles.Include(x => x.Detalle).Where(x => x.RolId == id).SingleOrDefault();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return roles;
        }
        /// <summary>
        /// Permite extraer una lista de Roles de la base de datos
        /// </summary>
        public static List<Roles> GetList(Expression<Func<Roles, bool>> expression)
        {
            List<Roles> Roles = new List<Roles>();
            Contexto db = new Contexto();
            try
            {
                Roles = db.Roles.Where(expression).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Roles;
        }
        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Roles.Any(x => x.RolId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
