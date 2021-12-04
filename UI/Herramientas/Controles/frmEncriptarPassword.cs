using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Controls.HerramientaTextos;
using static MiniGestorCodigo.UI.frmMain;

namespace MiniGestorCodigo.UI.Herramientas.Controles
{
    public partial class frmEncriptarPassword : Form
    {
        public frmEncriptarPassword()
        {
            InitializeComponent();
        }
        public partesPrograma partes;
        

        public frmEncriptarPassword(partesPrograma partes)
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
        

        private void frmEncriptarPassword_Load(object sender, EventArgs e)
        {
            cEncriptarDesencriptarTexto c = new cEncriptarDesencriptarTexto();
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);
        }
    }
}
