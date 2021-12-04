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
    public partial class frmAddUsuario : Form
    {
        private List<departamentos> departamentos;
        private usuarios usr;

        public event UsuarioGuardado actualizarLista;
        public delegate void UsuarioGuardado();


        public frmAddUsuario()
        {
            InitializeComponent();

            CargarDepartamentos();

            
        }

        public frmAddUsuario(usuarios usuario)
        {
            InitializeComponent();

            CargarDepartamentos();

            this.usr = usuario;

            txtNombreUsuario.Text = usuario.nombre;
            txtCorreo.Text = usuario.correo;
            txtContrasena1.Text = usuario.password;

            int index = cbDepartamentos.Items.IndexOf(departamentos.FirstOrDefault(x => x.idDepartamento == usuario.fk_IdDepartamento).nombreDepartamento);
            cbDepartamentos.SelectedIndex = index;
        }

        private void CargarDepartamentos()
        {
            departamentos = gDepartamentos.getDepartamentos();

            foreach (departamentos dep in departamentos)
            {
                cbDepartamentos.Items.Add(dep.nombreDepartamento);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usr == null)
            {
                usr = new usuarios();

                usr.nombre = txtNombreUsuario.Text;
                usr.correo = txtCorreo.Text;
                usr.password = txtContrasena1.Text;

                int index = cbDepartamentos.SelectedIndex;
        
                usr.fk_IdDepartamento = departamentos.FirstOrDefault(x => x.nombreDepartamento == cbDepartamentos.Items[index]).idDepartamento;
                usr.fechaModificacion = DateTime.Now;


                gUsuarios.addUsuario(usr);
            }
            else
            {
                usr.nombre = txtNombreUsuario.Text;
                usr.correo = txtCorreo.Text;
                usr.password = txtContrasena1.Text;

                int index = cbDepartamentos.SelectedIndex;

                usr.fk_IdDepartamento = departamentos.FirstOrDefault(x => x.nombreDepartamento == cbDepartamentos.Items[index]).idDepartamento;
                usr.fechaModificacion = DateTime.Now;


                gUsuarios.modUsuario(usr);
            }

            if (actualizarLista != null)
                actualizarLista();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
