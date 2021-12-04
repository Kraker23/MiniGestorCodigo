using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gUsuarios
    {
        public static List<usuarios> getUsuarios()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.usuarios.ToList();
            }
        }

        public static usuarios getUsuarioCorreo(string correoE)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.usuarios.FirstOrDefault(x => x.correo.Equals(correoE));
            }
        }

        public static usuarios getUsuarioById(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.usuarios.FirstOrDefault(x => x.idUsuario.Equals(id));
            }
        }

        public static void addUsuario(usuarios usuario)
        {
            using (BBDD ent = new BBDD())
            {
                try
                {
                    ent.usuarios.Add(usuario);
                    ent.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Fallo al insertar en la BBDD");
                }
            }
        }

        public static void modUsuario(usuarios usuario)
        {
            using (BBDD ent = new BBDD())
            {

                ent.usuarios.Attach(usuario);
                ent.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void delUsuario(usuarios usuario)
        {
            using (BBDD ent = new BBDD())
            {

                ent.usuarios.Attach(usuario);
                ent.Entry(usuario).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }
    }
}
