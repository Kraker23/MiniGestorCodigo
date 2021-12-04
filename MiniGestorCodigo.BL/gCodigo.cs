using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gCodigo
    {

        /// Devuelve todos los codigos
        public static List<codigos> getCodigos()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.codigosSet.ToList();
            }
        }

        /// Devuelve un codigo concreto segun su id
        public static codigos getCodigoByID(int idCodigo)
        { 
            using (BBDD ent = new BBDD())
            {
                return ent.codigosSet.Find(idCodigo);
            }
        }

        public static void updateCodigo(codigos codigo)
        {
            using (BBDD ent = new BBDD())
            {
                // Actualizar codogo en la BBDD

                ent.codigosSet.Attach(codigo);
                ent.Entry(codigo).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void deleteCodigo(codigos codigo)
        {
            using (BBDD ent = new BBDD())
            {
                // Eliminar codigo en la BBDD

                ent.codigosSet.Attach(codigo);
                ent.Entry(codigo).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }

        public static void addCodigo(codigos codigo)
        {
            using (BBDD ent = new BBDD())
            {
                ent.codigosSet.Add(codigo);
                ent.SaveChanges();
            }
        }

    }
}
