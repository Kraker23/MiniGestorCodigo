using MiniGestorCodigo.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGestorCodigo.BL
{
    public class gGrupos
    {
        public static List<Grupo> getGrupos()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.Grupo.ToList();
            }
        }

        public static Grupo getGrupoById(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.Grupo.FirstOrDefault(x => x.idGrupo.Equals(id));
            }
        }


        public static Grupo NewGrupo(string nombre)
        {
            using (BBDD ent = new BBDD())
            {
                Grupo g= ent.Grupo.Add(new Grupo { NombreGrupo=nombre,UsuarioModificacion=Globales.usuarioActual.idUsuario});
                ent.SaveChanges();
                return g;

            }
        }

        public static GrupoUsuario NewGrupoUsuario(int idgrupo, int idusuario)
        {
            using (BBDD ent = new BBDD())
            {
                GrupoUsuario g = ent.GrupoUsuario.Add(new GrupoUsuario { idGrupo=idgrupo,idUsuario=idusuario, UsuarioModificacion = Globales.usuarioActual.idUsuario });
                ent.SaveChanges();
                return g;

            }
        }

        public static void RemoveGrupoUsuario(int idgrupo, int idusuario)
        {
            using (BBDD ent = new BBDD())
            {
                ent.GrupoUsuario.Remove( ent.GrupoUsuario.First(x=>x.idGrupo == idgrupo && x.idUsuario == idusuario));
                ent.SaveChanges();

            }
        }



        public static List<GrupoUsuario> getGruposUsuarios()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.GrupoUsuario.ToList();
            }
        }

        
    }
}
