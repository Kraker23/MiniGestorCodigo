using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;


namespace MiniGestorCodigo.BL
{
    public class gCarpetasContrasenas
    {
        public static List<carpetas_contrasenas> getCarpetasContrasenas()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.carpetas_contrasenas.ToList();
            }
        }

        public static carpetas_contrasenas getCarpetasContrasenasByIDCarpeta(int idCarpeta)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.carpetas_contrasenas.FirstOrDefault(x => x.idCarpeta == idCarpeta);
            }
        }

        public static List<carpetas_contrasenas> getCarpetasContrasenasByUser(int id)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.carpetas_contrasenas.Where(x => x.fk_idUsuario == id).ToList();
            }
        }

        public static void updateCarpetasContrasenas(carpetas_contrasenas contrasena)
        {
            using (BBDD ent = new BBDD())
            {

                ent.carpetas_contrasenas.Attach(contrasena);
                ent.Entry(contrasena).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }

        public static void deleteCarpetasContrasenas(carpetas_contrasenas contrasena)
        {
            using (BBDD ent = new BBDD())
            {

                ent.carpetas_contrasenas.Attach(contrasena);
                ent.Entry(contrasena).State = System.Data.Entity.EntityState.Deleted;
                ent.SaveChanges();

            }
        }

        public static void addCarpetasContrasenas(carpetas_contrasenas contrasena)
        {
            using (BBDD ent = new BBDD())
            {
                try
                {
                    ent.carpetas_contrasenas.Add(contrasena);
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
