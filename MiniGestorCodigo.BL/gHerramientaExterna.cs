using MiniGestorCodigo.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGestorCodigo.BL
{
    public class gHerramientaExterna
    {
        public static List<HerramientaExterna> getHerramientaExterna()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.HerramientaExterna.ToList();
            }
        }

        public static List<HerramientaExterna> getHerramientaExternaByIdUser(int iduser, string UsarioOrdenador)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.HerramientaExterna.Where(x => x.fk_idUsuario.Equals(iduser) && x.UsuarioOrdenador.Equals(UsarioOrdenador)).ToList();
            }
        }

        public static HerramientaExterna getHerramientaExternaById(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.HerramientaExterna.FirstOrDefault(x => x.idHerramientaExterna.Equals(id));
            }
        }

        public static void addHerr_Externa(HerramientaExterna hExterna)
        {
            using (BBDD ent = new BBDD())
            {
                try
                {
                    ent.HerramientaExterna.Add(hExterna);
                    ent.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Fallo al insertar en la BBDD");
                }
            }
        }

        public static void modHerr_Externa(HerramientaExterna hExterna)
        {
            using (BBDD ent = new BBDD())
            {

                ent.HerramientaExterna.Attach(hExterna);
                ent.Entry(hExterna).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void delHerr_Externa(HerramientaExterna hExterna)
        {
            using (BBDD ent = new BBDD())
            {

                ent.HerramientaExterna.Attach(hExterna);
                ent.Entry(hExterna).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }
    }
}
