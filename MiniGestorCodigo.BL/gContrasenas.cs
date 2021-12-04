using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;


namespace MiniGestorCodigo.BL
{
    public class gContrasenas
    {
        public static List<contrasenas> getContrasenas()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.contrasenas.ToList();
            }
        }

        public static contrasenas getContrasenasByID(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.contrasenas.FirstOrDefault(x => x.idContrasena == id);
            }
        }


        public static List<contrasenas> getContrasenasByIDs(List<int?> ids)
        {
            using (BBDD ent = new BBDD())
            {
                List<contrasenas> c = new List<contrasenas>();
                foreach (int? id in ids)
                {
                    c.Add(ent.contrasenas.FirstOrDefault(x => x.idContrasena == id.Value));
                }
                return c;
            }
        }

        public static List<contrasenas> getContrasenasByUsuario(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.contrasenas.Where(x => x.fk_idUsuario == id).ToList();
            }
        }

        public static void updateContrasenas(contrasenas contrasena)
        {
            using (BBDD ent = new BBDD())
            {

                ent.contrasenas.Attach(contrasena);
                ent.Entry(contrasena).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void deleteContrasenas(contrasenas contrasena)
        {
            using (BBDD ent = new BBDD())
            {

                ent.contrasenas.Attach(contrasena);
                ent.Entry(contrasena).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }

        public static contrasenas addContrasenas(contrasenas contrasena)
        {
            using (BBDD ent = new BBDD())
            {
                try
                {
                    contrasenas c=ent.contrasenas.Add(contrasena);
                    ent.SaveChanges();

                    return c;
                }
                catch (Exception e)
                {
                    throw new Exception("Fallo al insertar en la BBDD");
                }
            }
        }


        public static void UpdatePasswordUsuario(int idpass, List<int> idsusuarios)
        {
            using (BBDD ent = new BBDD())
            {
                if (idsusuarios == null || idsusuarios.Count() == 0)
                {
                    ent.PasswordUsuario.RemoveRange(ent.PasswordUsuario.Where(x => x.idPassword == idpass));
                }
                else
                {

                    //ent.PasswordUsuario.RemoveRange(ent.PasswordUsuario.Where(x => x.idPassword == idpass && !idsusuarios.Exists(i => i == x.idUsuario)));
                    foreach (PasswordUsuario pd in ent.PasswordUsuario.Where(x => x.idPassword == idpass))
                    {
                        ent.PasswordUsuario.Remove(pd);
                    }
                    foreach (int i in idsusuarios)
                    {
                         ent.PasswordUsuario.Add(new PasswordUsuario { idPassword = idpass, idUsuario = i, UsuarioModificacion = Globales.usuarioActual.idUsuario });
                    }
                }
                ent.SaveChanges();
                //return g;

            }
        }
        
        public static void UpdatePasswordGrupo(int idpass, List<int> idsGrupos)
        {
            using (BBDD ent = new BBDD())
            {
                if (idsGrupos == null || idsGrupos.Count() == 0)
                {
                    ent.PasswordGrupo.RemoveRange(ent.PasswordGrupo.Where(x => x.idPassword == idpass));
                }
                else
                {

                   // ent.PasswordGrupo.RemoveRange(ent.PasswordGrupo.Where(x => x.idPassword == idpass && !idsGrupos.Exists(i => i == x.idGrupo)));
                    foreach (PasswordGrupo pd in ent.PasswordGrupo.Where(x => x.idPassword == idpass))
                    {
                        ent.PasswordGrupo.Remove(pd);
                    }
                    foreach (int i in idsGrupos)
                    {
                        ent.PasswordGrupo.Add(new PasswordGrupo { idPassword = idpass, idGrupo = i, UsuarioModificacion = Globales.usuarioActual.idUsuario });
                    }
                }
                ent.SaveChanges();

            }
        }

        public static void UpdatePasswordDepar(int idpass, List<int> idsDeparts)
        {
            using (BBDD ent = new BBDD())
            {
                if (idsDeparts == null || idsDeparts.Count() == 0)
                {
                    ent.PasswordDepartamento.RemoveRange(ent.PasswordDepartamento.Where(x => x.idPassword == idpass));
                }
                else
                {

                    //ent.PasswordDepartamento.RemoveRange(ent.PasswordDepartamento.Where(x => x.idPassword == idpass && !idsDeparts.Exists(i => i == x.idDepartamento)));

                    foreach (PasswordDepartamento pd in ent.PasswordDepartamento.Where(x => x.idPassword == idpass))
                    {
                        ent.PasswordDepartamento.Remove(pd);
                    }

                    foreach (int i in idsDeparts)
                    {
                        ent.PasswordDepartamento.Add(new PasswordDepartamento { idPassword = idpass, idDepartamento = i, UsuarioModificacion = Globales.usuarioActual.idUsuario });
                        
                    }
                }
                ent.SaveChanges();

            }
        }

        public static List<PasswordDepartamento> getPasswordDepar(int idpass)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.PasswordDepartamento.Where(x => x.idPassword == idpass).ToList();
            }
        }
        public static List<PasswordUsuario> getPasswordUsuario(int idpass)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.PasswordUsuario.Where(x => x.idPassword == idpass).ToList();
            }
        }
        public static List<PasswordGrupo> getPasswordGrupo(int idpass)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.PasswordGrupo.Where(x=>x.idPassword==idpass).ToList();
            }
        }


        public static List<int?> getContrasenasCompartidas(int idUsuarioVisualizador)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.Query_VerPasswordCompartidas(idUsuarioVisualizador).ToList();
            }
        }
    }
}
