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
            string pass;
            pass = generador.generar(trackBar.Value, chkSimbolos.Checked, chkNumeros.Checked, chkMayusculas.Checked, chkMinusculas.Checked);

            txtPassword.Text = pass;
        }
    }
}
