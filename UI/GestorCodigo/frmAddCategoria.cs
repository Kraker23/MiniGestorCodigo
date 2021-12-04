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
    public partial class frmAddCategoria : Form
    {
        public frmAddCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreCat.Text.Length > 2)
            {
                categorias cat = new categorias();

                cat.nombreCategoria = txtNombreCat.Text;
                cat.descripcionCategoria = txtDescripcionCat.Text;
                cat.fechaModificacion = DateTime.Now;

                gCategorias.addCategoria(cat);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            
        }
    }
}
