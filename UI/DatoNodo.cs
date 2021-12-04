using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGestorCodigo.UI
{
    public class DatoNodo
    {
        public int id { get; set; }
        public int? idPadre { get; set; }
        public string Nombre { get; set; }
        public TreeLevel Level { get; set; }
        public int? fkIdUsuario { get; set; }
    }

    public enum TreeLevel
    {
        Departamento = 1,
        Usuario = 2,
        Carpeta = 3,
        SubCarpetas = 4,
        Codigo = 5
    }
}
