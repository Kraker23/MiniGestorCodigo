using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGestorCodigo.UI.GestorContrasenas
{
    public partial class frmGeneradorPassword : Form
    {

        GeneradorPassword generador = new GeneradorPassword();
        private string pass;
        public string passGenerada;
        public frmGeneradorPassword()
        {
            InitializeComponent();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            lblLongitud.Text = $"Longitud Password : {trackBar.Value.ToString()}";
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            pass = generador.generar(trackBar.Value, chkSimbolos.Checked, chkNumeros.Checked, chkMayusculas.Checked, chkMinusculas.Checked);

            txtPassword.Text = pass;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            passGenerada = pass;
            this.Close();
            
        }

        private void frmGeneradorPassword_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmGeneradorPassword_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
