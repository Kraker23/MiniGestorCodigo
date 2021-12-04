using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGestorCodigo.DM;

namespace MiniGestorCodigo.BL
{
    public class Globales
    {
        public static usuarios usuarioActual; // = gUsuarios.getUsuarioById(1)

        public enum VisibilidadFormulario { Mostrar, Ocultar}

        public static usuarios GetUsuarioActual()
        {
            return usuarioActual;
        }
        public static void SetUsuarioActual(usuarios usuario)
        {
            usuarioActual = usuario;
        }

    }

   


}
