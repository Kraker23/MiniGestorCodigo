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
    public partial class frmCambiarPassword : Form
    {
        public frmCambiarPassword()
        {
            InitializeComponent();
            lError.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtPassword1.Text == txtPassword2.Text)
            {
                usuarios usr = Globales.GetUsuarioActual();
                usr.password = txtPassword1.Text;

                gUsuarios.modUsuario(usr);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lError.Text = "Las contraseñas no coinciden";
            }

        }

        private void frmCambiarPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(this, EventArgs.Empty);
            }
        }
    }
}
