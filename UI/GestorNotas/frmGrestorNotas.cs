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
using static MiniGestorCodigo.UI.frmMain;

namespace MiniGestorCodigo.UI
{
    public partial class frmGrestorNotas : Form
    {
        private Utilities.Controls.EditarImagen.frmCaptura frmCapturaPantalla = new Utilities.Controls.EditarImagen.frmCaptura();

        private List<notas> notasList;
        private List<notas_compartidas> notasCompartidas;
        private notas notaSeleccionada;
        private notas notaCompartidaSeleccionada;
        public partesPrograma partes;

        public frmGrestorNotas(partesPrograma partes)
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

        public frmGrestorNotas()
        {
            InitializeComponent();

            CrearListaNotas();
            CrearListaNotasCompartidas();
        }

        #region ListView

        private void CrearListaNotas()
        {
            notasList = gNotas.getNotas();

            ListViewItem item;

            lvNotasUsuario.Items.Clear();

            foreach (notas nota in notasList.Where(x => x.fk_idUsuario == Globales.GetUsuarioActual().idUsuario))
            {
                item = new ListViewItem();
                item.Text = nota.titulo;
                item.Tag = nota;

                lvNotasUsuario.Items.Add(item);

            }
        }

        private void CrearListaNotasCompartidas()
        {
            notasCompartidas = gNotasCompartidas.getNotasCompatidasByUser(Globales.GetUsuarioActual().idUsuario);

            List<notas> tmpNotasCompartidas = new List<notas>();
            lvNotasCompartidas.Items.Clear();

            //Obtener lista de notas compartidas
            foreach (notas_compartidas comp in notasCompartidas)
            {
                tmpNotasCompartidas.Add(notasList.FirstOrDefault(x => x.idNota == comp.fk_idNota));
            }

            //Añadir las notas a la lista
            ListViewItem item;
            foreach (notas nota in tmpNotasCompartidas)
            {
                item = new ListViewItem();
                item.Text = nota.titulo;
                item.Tag = nota;

                lvNotasCompartidas.Items.Add(item);
            }
        }

        #endregion

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CrearListaNotas();
        }

        private void btnAnadirNota_Click(object sender, EventArgs e)
        {
            frmNota newNota = new frmNota();
            newNota.FormClosing += new FormClosingEventHandler(formAnadirNota_Close);
            newNota.Show();

        }

        void formAnadirNota_Close(object sender, EventArgs e)
        {
            CrearListaNotas();
        }

        private void lvNotasUsuario_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvNotasUsuario.SelectedItems[0];

            notas nota = (notas)item.Tag;

            frmNota formNota = new frmNota(nota);
            formNota.Show();

            CrearListaNotas();
        }

        private void btnEliminarNota_Click(object sender, EventArgs e)
        {

            if (lvNotasUsuario.SelectedItems.Count > 0)
            {
                ListViewItem item = lvNotasUsuario.SelectedItems[0];

                notas nota = (notas)item.Tag;

                if (MessageBox.Show(string.Format("Seguro que quieres borrar la nota '{0}' ", nota.titulo), "Eliminar nota", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        gNotas.deleteNota(nota);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: No se ha podido eliminar la carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        CrearListaNotas();
                    }
                }
            }
        }

        private void frmGrestorNotas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                frmCapturaPantalla.CapturarPantallaCompleta();
                frmCapturaPantalla.Show();
            }
        }

        private void tsbCompartirNota_Click(object sender, EventArgs e)
        {
            if (notaSeleccionada != null)
            {
                frmCompartirNota frm = new frmCompartirNota(notaSeleccionada);
                frm.ShowDialog();
            }
            else
            {
                Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Primero tienes que seleccionar una nota antes de compartirla", "Seleccionar nota", 1);
            }
        }

        private void lvNotasUsuario_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                notaSeleccionada = (notas)lvNotasUsuario.SelectedItems[0].Tag;
            } 
            catch
            (Exception ex)
            {
                notaSeleccionada = null;
            }
        }

        private void lvNotasCompartidas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                notaCompartidaSeleccionada = (notas)lvNotasCompartidas.SelectedItems[0].Tag;

                if (notaCompartidaSeleccionada != null)
                {
                    frmNota frm = new frmNota(notaCompartidaSeleccionada, false);
                    frm.ShowDialog();
                }
            }
            catch
            (Exception ex)
            {
                notaCompartidaSeleccionada = null;
            }
        }
    }
}
