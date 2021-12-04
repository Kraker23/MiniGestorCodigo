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
    public partial class frmNota : Form
    {
        private notas notaOriginal;
        private bool editar = true;

        public frmNota()
        {
            InitializeComponent();
            setColor();

        }

        public frmNota(notas nota)
        {
            InitializeComponent();
            setColor();

            this.notaOriginal = nota;

            txtTituloNota.Text = nota.titulo;
            txtDescripcionNota.Text = nota.descripcion;

        }

        public frmNota(notas nota, bool editar)
        {
            InitializeComponent();
            setColor();
            this.editar = false;
            this.notaOriginal = nota;

            txtTituloNota.Text = nota.titulo;
            txtDescripcionNota.Text = nota.descripcion;
            txtTituloNota.ReadOnly = true;
            txtDescripcionNota.ReadOnly = true;

            this.Text = "Nota compartida";
        }

        private void buildSeparator()
        {
            label1.AutoSize = false;
            label1.Height = 2;
            label1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void setColor()
        {
            Random r = new Random();

            int red = r.Next(0, 240);
            int blue = r.Next(0, 240);
            int green = r.Next(0, 240);

            txtDescripcionNota.BackColor = Color.FromArgb(red, green, blue);
            txtTituloNota.BackColor = Color.FromArgb(red, green, blue);
            this.BackColor = Color.FromArgb(red, green, blue);

        }

        private void txt_Enter(object sender, EventArgs e)
        {
            if (notaOriginal == null && txtDescripcionNota.Text == "Nota...")
                txtDescripcionNota.Text = "";

        }

        private void txtTituloNota_Enter(object sender, EventArgs e)
        {
            if (notaOriginal == null && txtTituloNota.Text == "Titulo...")
                txtTituloNota.Text = "";
        }

        private void txtTituloNota_TextChanged(object sender, EventArgs e)
        {
            guardarNota(txtTituloNota);
        }


        /// <summary>
        /// Guardar / actualizar cambios en las notas
        /// </summary>
        /// <param name="text">TextBox que se ha modificado</param>
        private void guardarNota(TextBox text)
        {
            if (editar)
            {
                int numeroCaracters = text.Text.Count();

                if (numeroCaracters > 7 && numeroCaracters % 8 == 0 && (text.Text != "Titulo..." || text.Text != "Nota..." || text.Text != ""))
                {
                    if (notaOriginal == null)
                    {
                        notas tmp = new notas();
                        tmp.titulo = txtTituloNota.Text;
                        tmp.descripcion = txtDescripcionNota.Text;
                        tmp.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                        tmp.fechaModificacion = DateTime.Now;

                        try
                        {
                            gNotas.addNota(tmp);
                            notaOriginal = gNotas.getNotaByUser(Globales.GetUsuarioActual().idUsuario).FirstOrDefault(x => x.titulo == tmp.titulo && x.descripcion == tmp.descripcion);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error: No se ha podido guardar la nota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (notaOriginal.fk_idUsuario == Globales.GetUsuarioActual().idUsuario)
                        {
                            notaOriginal.titulo = txtTituloNota.Text;
                            notaOriginal.descripcion = txtDescripcionNota.Text;
                            notaOriginal.fechaModificacion = DateTime.Now;

                            try
                            {
                                gNotas.updateNota(notaOriginal);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Error: No se ha podido guardar la nota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("No puedes modificar una nota que no es tuya", "Error de permisos", 1);
                        }
                    }

                }
            }
        }

        private void txtDescripcionNota_TextChanged(object sender, EventArgs e)
        {
            guardarNota(txtDescripcionNota);
        }

        private void frmNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            //guardarNota(txtDescripcionNota);

            if (notaOriginal != null)
            {
                notaOriginal.titulo = txtTituloNota.Text;
                notaOriginal.descripcion = txtDescripcionNota.Text;
                notaOriginal.fechaModificacion = DateTime.Now;

                gNotas.updateNota(notaOriginal);
            }
        }
    }
}
