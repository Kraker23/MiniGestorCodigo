using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gCarpetas
    {
        public static List<carpetas> getCarpetas()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.carpetas.ToList();
            }
        }

        public static carpetas getCarpetasById(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.carpetas.FirstOrDefault(x => x.idCarpeta.Equals(id));
            }
        }

        public static void addCarpetas(carpetas carpeta)
        {
            using (BBDD ent = new BBDD())
            {
                ent.carpetas.Add(carpeta);
                ent.SaveChanges();
            }
        }

        public static void deleteCarpetas(carpetas carpeta)
        {
            using (BBDD ent = new BBDD())
            {
                ent.carpetas.Attach(carpeta);
                ent.carpetas.Remove(carpeta);
                ent.SaveChanges();
            }
        }

        public static void updateCarpeta(carpetas carpeta)
        {
            using (BBDD ent = new BBDD())
            {

                ent.carpetas.Attach(carpeta);
                ent.Entry(carpeta).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }
    }
}
