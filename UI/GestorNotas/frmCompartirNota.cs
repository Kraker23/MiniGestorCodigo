using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.DM;
using MiniGestorCodigo.BL;

namespace MiniGestorCodigo.UI
{
    public partial class frmCompartirNota : Form
    {
        private notas notaCompartir;
        List<usuarios> usuarios;
        private List<String> usuariosCompartir;
        

        public frmCompartirNota(notas notaCompartir)
        {
            InitializeComponent();

            usuariosCompartir = new List<string>();
            this.notaCompartir = notaCompartir;

            cargarListaUsuarios();
        }

        private void cargarListaUsuarios()
        {
            usuarios = gUsuarios.getUsuarios();
            List<notas_compartidas> compartidas = gNotasCompartidas.getNotaCompartidaByIdNota(notaCompartir.idNota);

            foreach (usuarios usr in usuarios)
            {
                if (compartidas.FirstOrDefault(x => x.fk_idUsuario == usr.idUsuario) != null)
                    clbListaUsuarios.Items.Add(usr.nombre, true);

                else
                    clbListaUsuarios.Items.Add(usr.nombre, false);
            }

        }

        private void clbListaUsuarios_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                usuariosCompartir.Add((String)clbListaUsuarios.Items[e.Index]);
            else
                usuariosCompartir.Remove((String)clbListaUsuarios.Items[e.Index]);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            notas_compartidas compartir;
            usuarios usr;

            foreach (string stUsuario in usuariosCompartir)
            {
                usr = this.usuarios.FirstOrDefault(x => x.nombre == stUsuario);

                compartir = new notas_compartidas();

                compartir.fk_idNota = notaCompartir.idNota;
                compartir.fk_idPropietario = Globales.GetUsuarioActual().idUsuario;
                compartir.fk_idUsuario = usr.idUsuario;

                gNotasCompartidas.addNotaCompatida(compartir);
            }

            this.Close();
        }
    }
}
