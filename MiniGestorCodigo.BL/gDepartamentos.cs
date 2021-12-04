using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class gDepartamentos
    {
        public static List<departamentos> getDepartamentos()
        {
            using (BBDD ent = new BBDD())
            {
                return ent.departamentosSet.ToList();
            }
        }

        public static departamentos getDepartamentosById(int idDepartamento)
        {
            using (BBDD ent = new BBDD())
            {
                return ent.departamentosSet.FirstOrDefault(x => x.idDepartamento == idDepartamento);
            }
        }
    }
}
