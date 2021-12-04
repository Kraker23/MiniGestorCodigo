using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public static class gUltimoInicio
    {
        public static ultimo_inicio getUltimoInicioByNombreOrdenador(string nombrePC)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.ultimo_inicio.FirstOrDefault(x => x.nombreOrdenador.Equals(nombrePC));
            }
        }

        public static void addUltimoInicio(ultimo_inicio ultimo_)
        {
            using (BBDD ent = new BBDD())
            {
                ent.ultimo_inicio.Add(ultimo_);
                ent.SaveChanges();
            }
        }

        public static void deleteUltimoInicio(ultimo_inicio ultimo_)
        {
            using (BBDD ent = new BBDD())
            {
                ent.ultimo_inicio.Attach(ultimo_);
                ent.ultimo_inicio.Remove(ultimo_);
                ent.SaveChanges();
            }
        }

        public static void updateUltimoInicio(ultimo_inicio ultimo_)
        {
            using (BBDD ent = new BBDD())
            {

                ent.ultimo_inicio.Attach(ultimo_);
                ent.Entry(ultimo_).State = System.Data.Entity.EntityState.Modified;
                ent.SaveChanges();

            }
        }
    }
}
