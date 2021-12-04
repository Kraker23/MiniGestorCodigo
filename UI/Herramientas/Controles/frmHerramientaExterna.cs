using MiniGestorCodigo.BL;
using MiniGestorCodigo.DM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MiniGestorCodigo.UI.frmMain;

namespace MiniGestorCodigo.UI.Herramientas.Controles
{
    public partial class frmHerramientaExterna : Form
    {

        public event EventGuardado actualizarControles;
        public delegate void EventGuardado();

        public HerramientaExterna hExterna;
        public partesPrograma partes;

        public frmHerramientaExterna(partesPrograma partes,int idHExt)
            : this()
        {
            this.partes = partes;

            switch (partes)
            {
                case partesPrograma.Main: this.Text = "Gestor"; break;
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
            this.hExterna = gHerramientaExterna.getHerramientaExternaById(idHExt);
            txtNombre.Text = hExterna.HerramientaExterna1;
            txtPath.Text = hExterna.PathHerramienta;
        }

        public frmHerramientaExterna(partesPrograma partes)
            : this()
        {
            this.partes = partes;

            switch (partes)
            {
                case partesPrograma.Main: this.Text = "Gestor"; break;
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

        public frmHerramientaExterna()
        {
            InitializeComponent();
            if (hExterna== null)
            {
                hExterna = new HerramientaExterna();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPath.Text))
            {
                if (hExterna.idHerramientaExterna > 0)
                {
                    HerramientaExterna ext = gHerramientaExterna.getHerramientaExternaById(hExterna.idHerramientaExterna);

                    ext.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                    ext.HerramientaExterna1 = txtNombre.Text;
                    ext.PathHerramienta = txtPath.Text;
                    ext.UsuarioOrdenador = Environment.UserName;
                    ext.FechaModificacion = DateTime.Now;

                    gHerramientaExterna.modHerr_Externa(ext);

                    actualizarControles?.Invoke();
                }
                else
                {
                    HerramientaExterna ext = new HerramientaExterna();

                    ext.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                    ext.HerramientaExterna1 = txtNombre.Text;
                    ext.PathHerramienta = txtPath.Text;
                    ext.UsuarioOrdenador = Environment.UserName;
                    ext.FechaModificacion = DateTime.Now;

                    gHerramientaExterna.addHerr_Externa(ext);

                    actualizarControles?.Invoke();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No se puede dejar ninguno de los campos vacios");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtPath.Text= openFileDialog.FileName;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
