using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gCodigoCategoria
    {

        public static List<codigo_categoria> getCodigoCategoria()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.codigo_categoria.ToList();
            }
        }

        public static void addCodigoCategoria(codigo_categoria codigoCategoria)
        {
            using (BBDD ent = new BBDD())
            {
                ent.codigo_categoria.Add(codigoCategoria);
                ent.SaveChanges();
            }
        }

        public static codigo_categoria getCodigoCategoriaByIdCodigo(int idCodigo)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.codigo_categoria.FirstOrDefault(x => x.fk_idCodigo == idCodigo);
            }
        }


        public static void updateCodigoCategoria(codigo_categoria codigoCategoria)
        {
            using (BBDD ent = new BBDD())
            {

                ent.codigo_categoria.Attach(codigoCategoria);
                ent.Entry(codigoCategoria).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void deleteCodigoCategoria(codigo_categoria codigoCategoria)
        {
            using (BBDD ent = new BBDD())
            {

                ent.codigo_categoria.Attach(codigoCategoria);
                ent.Entry(codigoCategoria).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }
    }
}
