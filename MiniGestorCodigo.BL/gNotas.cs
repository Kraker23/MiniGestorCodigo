using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gNotas
    {
        public static List<notas> getNotas()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas.ToList();
            }
        }

        public static notas getNotaByID(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas.FirstOrDefault(x => x.idNota == id);
            }
        }

        public static List<notas> getNotaByUser(int fk_idUsuario)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas.Where(x => x.fk_idUsuario == fk_idUsuario).ToList();
            }
        }

        public static void updateNota(notas nota)
        {
            using (BBDD ent = new BBDD())
            {

                ent.notas.Attach(nota);
                ent.Entry(nota).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void deleteNota(notas nota)
        {
            using (BBDD ent = new BBDD())
            {

                ent.notas.Attach(nota);
                ent.Entry(nota).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }

        public static void addNota(notas nota)
        {
            using (BBDD ent = new BBDD())
            {
                try
                {
                    ent.notas.Add(nota);
                    ent.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Fallo al insertar en la BBDD");
                }
            }
        }
    }
}
