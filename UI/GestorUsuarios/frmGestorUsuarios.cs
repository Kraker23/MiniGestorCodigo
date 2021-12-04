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
using static MiniGestorCodigo.UI.frmMain;

namespace MiniGestorCodigo.UI
{
    public partial class frmGestorUsuarios : Form
    {

        private Utilities.Controls.EditarImagen.frmCaptura frmCapturaPantalla = new Utilities.Controls.EditarImagen.frmCaptura();

        public partesPrograma partes;

        public frmGestorUsuarios(partesPrograma partes)
            : this()
        {
            this.partes = partes;

            switch (partes)
            {
                case partesPrograma.Main:this.Text = "Gestor"; break;
                case partesPrograma.Codigo: this.Text = "Gestor de Codigo"; break;
                case partesPrograma.Notas: this.Text = "Gestor de Notas"; break;
                case partesPrograma.PersonasGrupo: this.Text = "Gestor de Grupo"; break;
                case partesPrograma.PersonasUsuarios: this.Text = "Gestor de Usuarios"; break;
                case partesPrograma.Correo: this.Text = "Correo Electronico"; break;
                case partesPrograma.Contraseñas: this.Text = "Gestor de Contraseñas"; break;
                case partesPrograma.H_SeparadorTexto: this.Text = "Herramientas Separador Texto"; break;
                case partesPrograma.H_MoverArchivos: this.Text = "Herramientas Mover Archivos"; break;
                case partesPrograma.H_EncriptarPassword: this.Text = "Herramientas Encriptar Password"; break;
                default:
                    break;
            }
        }

        public frmGestorUsuarios()
        {
            InitializeComponent();

            CargarDatosGrid();
        }

        private void CargarDatosGrid()
        {
            List<usuarios> usuarios = gUsuarios.getUsuarios();
            List<departamentos> departamentos = gDepartamentos.getDepartamentos();

            dgvListaUsuarios.Rows.Clear();

            DataGridViewRow fila;

            foreach (usuarios usr in usuarios)
            {
                int rowId = dgvListaUsuarios.Rows.Add();

                fila = dgvListaUsuarios.Rows[rowId];

                fila.Cells["cNombre"].Value = usr.nombre;
                fila.Cells["cCorreo"].Value = usr.correo;
                fila.Cells["cDepartamento"].Value = departamentos.FirstOrDefault(x => x.idDepartamento == usr.fk_IdDepartamento).nombreDepartamento;


                //dgvListaUsuarios.Rows.Add(fila);
            }

            
        }

        private void tsbNuevoUsuario_Click(object sender, EventArgs e)
        {
            frmAddUsuario frmAdd = new frmAddUsuario();
            frmAdd.Text = "Añadir usuario";
            frmAdd.actualizarLista += CargarDatosGrid;
            frmAdd.ShowDialog();
        }

        private void tsbModificarUsuario_Click(object sender, EventArgs e)
        {
            int index = dgvListaUsuarios.CurrentCell.RowIndex;

            string correo = (string) dgvListaUsuarios.Rows[index].Cells["cCorreo"].Value;

            usuarios usr = gUsuarios.getUsuarioCorreo(correo);

            if (usr != null)
            {
                frmAddUsuario frmAdd = new frmAddUsuario(usr);
                frmAdd.Text = "Modificar usuario";
                frmAdd.actualizarLista += CargarDatosGrid;
                frmAdd.ShowDialog();
            }
        }

        private void tsbBorrarUsuario_Click(object sender, EventArgs e)
        {
            int index = dgvListaUsuarios.CurrentCell.RowIndex;

            string correo = (string)dgvListaUsuarios.Rows[index].Cells["cCorreo"].Value;

            usuarios usr = gUsuarios.getUsuarioCorreo(correo);

            gUsuarios.delUsuario(usr);

            CargarDatosGrid();
        }

        private void frmGestorUsuarios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                frmCapturaPantalla.CapturarPantallaCompleta();
                frmCapturaPantalla.Show();
            }
        }
    }

}
