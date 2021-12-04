using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gNotasCompartidas
    {
        public static List<notas_compartidas> getNotasCompartidas()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas_compartidas.ToList();
            }
        }

        public static notas_compartidas getNotaCompartidaByID(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas_compartidas.FirstOrDefault(x => x.idNotaCompartida == id);
            }
        }

        public static List<notas_compartidas> getNotaCompartidaByIdNota(int idNota)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas_compartidas.Where(x => x.fk_idNota == idNota).ToList();
            }
        }

        public static List<notas_compartidas> getNotasCompatidasByUser(int idUsuario)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.notas_compartidas.Where(x => x.fk_idUsuario == idUsuario).ToList();
            }
        }


        public static void updateNotaCompatida(notas_compartidas nota)
        {
            using (BBDD ent = new BBDD())
            {

                ent.notas_compartidas.Attach(nota);
                ent.Entry(nota).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void deleteNotaCompatida(notas_compartidas nota)
        {
            using (BBDD ent = new BBDD())
            {

                ent.notas_compartidas.Attach(nota);
                ent.Entry(nota).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }

        public static void addNotaCompatida(notas_compartidas nota)
        {
            using (BBDD ent = new BBDD())
            {

                ent.notas_compartidas.Add(nota);
                ent.SaveChanges();
            }
        }
    }
}
