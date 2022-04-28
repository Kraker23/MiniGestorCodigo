using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.BL;
using MiniGestorCodigo.DM;
using Utilities.Extensions;

namespace MiniGestorCodigo.UI
{
    public partial class frmLoggin : Form
    {
        private bool depurando = false;
            
        public frmLoggin()
        {
            InitializeComponent();
        }

        public frmLoggin(int id)
        {
            usuarios usr = gUsuarios.getUsuarioById(id);

            InitializeComponent();

            txtCorreo.Text = usr.correo;
            txtContrasena.Focus();
        }
        public frmLoggin(int id,string contraseña)
        {
            usuarios usr = gUsuarios.getUsuarioById(id);

            InitializeComponent();

            txtCorreo.Text = usr.correo;
            txtContrasena.Text = contraseña;
            depurando = true;
        }
        private void frmLoggin_Load(object sender, EventArgs e)
        {
            if (depurando)
            {
                iniciarSesion();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            iniciarSesion();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            iniciarSesion();
        }

        private void iniciarSesion()
        {
            string correo = txtCorreo.Text;
            string passwd = txtContrasena.Text.EncryptAES();

            usuarios usuario = gUsuarios.getUsuarioCorreo(correo);

            if (usuario != null)
            {
                if (correo.Equals(usuario.correo) && passwd.Equals(usuario.password))
                {

                    Globales.SetUsuarioActual(usuario);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña introducida no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No existe ningun usuario con el correo electronico indicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                iniciarSesion();
            }
        }

        private void frmLoggin_Shown(object sender, EventArgs e)
        {


            txtContrasena.Focus();
        }
    }
}
