using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gCategorias
    {

        public static List<categorias> getCategorias()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.categoriasSet.ToList();
            }
        }

        public static categorias getCategoriasById(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.categoriasSet.FirstOrDefault(x => x.idCategoria == id);
            }
        }

        public static categorias getCategoriasByName(string nombre)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.categoriasSet.FirstOrDefault(x => x.nombreCategoria == nombre);
            }
        }

        public static void addCategoria(categorias cat)
        {
            using (BBDD ent = new BBDD())
            {

                ent.categoriasSet.Add(cat);
                ent.SaveChanges();
            }
        }

        public static void modCategoria(categorias cat)
        {
            using (BBDD ent = new BBDD())
            {

                ent.categoriasSet.Attach(cat);
                ent.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void delCategoria(categorias cat)
        {
            using (BBDD ent = new BBDD())
            {

                ent.categoriasSet.Attach(cat);
                ent.Entry(cat).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }

    }
}
