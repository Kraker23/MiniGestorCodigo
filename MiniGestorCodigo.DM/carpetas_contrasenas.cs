//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniGestorCodigo.DM
{
    using System;
    using System.Collections.Generic;
    
    public partial class carpetas_contrasenas
    {
        public int idCarpeta { get; set; }
        public string nombre { get; set; }
        public Nullable<int> fk_idCarpetaPadre { get; set; }
        public int fk_idUsuario { get; set; }
    }
}