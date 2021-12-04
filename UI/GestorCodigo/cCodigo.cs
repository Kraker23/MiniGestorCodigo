using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.BL;
using MiniGestorCodigo.DM;
using MiniGestorCodigo.UI;
using static MiniGestorCodigo.UI.frmGestorCodigo;

namespace MiniGestorCodigo.UI
{
    public partial class cCodigo : UserControl
    {
        private frmGestorCodigo programaPadre = null;
        private int idSinCategoria = 0;
        private int idCodigo = 0;
        private int idCodigoCategoria = 0;
        private DatoNodo nodo;
        

        private List<codigo_categoria> lCodigosCategoria;
        private List<categorias> lCategorias;
        private List<codigos> lCodigos;

        private Utilities.Controls.EditarImagen.frmCaptura frmCapturaPantalla = new Utilities.Controls.EditarImagen.frmCaptura();

        public event EventCodigoGuardado codigoGuardado;
        public delegate void EventCodigoGuardado();

        // Constructor vacio para añadir codigos nuevos
        public cCodigo(DatoNodo nodo)
        {
            InitializeComponent();
            cargarCategorias();

            this.nodo = nodo;

            lCodigosCategoria = gCodigoCategoria.getCodigoCategoria().ToList();
            lCodigos = gCodigo.getCodigos().ToList();

        }

        // Constructor para cargar un codigo
        public cCodigo(int idCodigo, DatoNodo nodo)
        {
            InitializeComponent();


            this.idCodigo = idCodigo;
            this.nodo = nodo;

            cargarCategorias();


            lCodigosCategoria = gCodigoCategoria.getCodigoCategoria().ToList();
            lCodigos = gCodigo.getCodigos().ToList();


            cbCategorias.SelectedIndex = idSinCategoria;

            codigos codigoActual = lCodigos.FirstOrDefault(x => x.idCodigo == idCodigo);

            // Obtenemos el autor del codigo
            usuarios usuarioCodigoActual = gUsuarios.getUsuarioById(codigoActual.fk_IdAutor);

            // Objtenemos la categoria
            codigo_categoria tmp = gCodigoCategoria.getCodigoCategoria().FirstOrDefault(x => x.fk_idCodigo == codigoActual.idCodigo);

            categorias categoriaCodigoActual = null;

            if (tmp != null)
                categoriaCodigoActual = lCategorias.FirstOrDefault(x => x.idCategoria == tmp.fk_idCategoria);

            // Rellenamos el formulario con los datos de la BBDD
            txtNombre.Text = codigoActual.nombreCodigo;

            txtNombre.Focus();

            txtDescripcion.Text = codigoActual.descripcion;

            if (categoriaCodigoActual != null)
                cbCategorias.SelectedItem = categoriaCodigoActual.nombreCategoria;

            txtUltimaModificacion.Text = codigoActual.fechaModificacion.ToString();
            txtAutor.Text = usuarioCodigoActual.nombre;
            rtxtCodigo.Text = codigoActual.codigo;

            // Mostrar boton de editar
            btnGuardarCodigo.Visible = true;
        }

        #region metodos

        private void cargarCategorias()
        {
            lCategorias = gCategorias.getCategorias();

            foreach (categorias cat in lCategorias)
            {
                cbCategorias.Items.Add(cat.nombreCategoria);
            }

            idSinCategoria = cbCategorias.FindStringExact("Sin categoria");
            cbCategorias.SelectedIndex = idSinCategoria;
        }

        #region validaciones

        private bool validarCodigo(DatoNodo nodo, bool mod)
        {

            if (txtNombre.Text == "" || txtNombre.Text.Length < 2)
                return false;

            if (txtNombre.Text.Length >= 150)
            {
                MessageBox.Show("El nombre del codigo no puede contener mas de 150 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (rtxtCodigo.Text == "" || rtxtCodigo.Text.Length < 2)
                return false;

            //if (mod != true)
            //{
            //    #region Evitar 2 codigos con el mismo nombre dentro de la misma carpeta
            //    codigos codigosCarpeta = gCodigo.getCodigos().FirstOrDefault(x => x.nombreCodigo == txtNombre.Text);

            //    if (codigosCarpeta != null)
            //        return false;

            //    #endregion
            //}

            return true;
        }

        #endregion

        #endregion

        private void btnGuardarCodigo_Click(object sender, EventArgs e)
        {
            if (validarAutor(nodo))
            {

                if (idCodigo != 0) // Modificar codigo
                {
                    modificarCodigo();
                }
                else
                {
                    guardarCodigoNuevo();
                }
            }
            else
                MessageBox.Show("Error: No puedes modificar un codigo que no es de tu usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            codigoGuardado();
        }

        private void modificarCodigo()
        {
            codigos oldCodigo = lCodigos.FirstOrDefault(x => x.idCodigo == idCodigo);

            oldCodigo.nombreCodigo = txtNombre.Text;
            oldCodigo.descripcion = txtDescripcion.Text;
            oldCodigo.fechaModificacion = DateTime.Now;
            oldCodigo.codigo = rtxtCodigo.Text;
            oldCodigo.fk_IdUsuarioUltimaModificacion = Globales.GetUsuarioActual().idUsuario;

            if (validarCodigo(nodo, true))
            {
                codigo_categoria codCat = lCodigosCategoria.FirstOrDefault(x => x.fk_idCodigo == idCodigo);
                categorias cat = lCategorias.FirstOrDefault(x => x.idCategoria == codCat.fk_idCategoria);

                gCodigo.updateCodigo(oldCodigo);

                if (cat != null && cbCategorias.SelectedItem.ToString() != cat.nombreCategoria)
                {

                    int index = cbCategorias.SelectedIndex;
                    string nombreCategoria = (string)cbCategorias.Items[index];

                    int idCat = lCategorias.FirstOrDefault(x => x.nombreCategoria == nombreCategoria).idCategoria;

                    codCat.fk_idCategoria = idCat;

                    gCodigoCategoria.updateCodigoCategoria(codCat);
                }
            }
        }

        private void guardarCodigoNuevo()
        {
            String msg = "";
            codigos codigoNuevo = new codigos();

            codigoNuevo.nombreCodigo = txtNombre.Text;
            codigoNuevo.descripcion = txtDescripcion.Text;
            codigoNuevo.fechaModificacion = DateTime.Now;
            codigoNuevo.codigo = rtxtCodigo.Text;
            codigoNuevo.fk_IdAutor = Globales.GetUsuarioActual().idUsuario;
            codigoNuevo.fk_IdUsuarioUltimaModificacion = Globales.GetUsuarioActual().idUsuario;

            // Obtener la categoria
            string nombreCat = cbCategorias.SelectedItem.ToString();
            categorias categoria = lCategorias.FirstOrDefault(x => x.nombreCategoria == nombreCat);

            if (nodo.Level == TreeLevel.Codigo)
                codigoNuevo.fk_Idcarpeta = nodo.idPadre;

            else if (nodo.Level == TreeLevel.Usuario)
                codigoNuevo.fk_Idcarpeta = null;

            else if (nodo.Level == TreeLevel.Departamento)
                MessageBox.Show("No puedes crear un codigo fuera de tu espacio de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
                codigoNuevo.fk_Idcarpeta = nodo.id;



            #region Evitar 2 codigos con el mismo nombre dentro de la misma carpeta
            codigos codActual = gCodigo.getCodigoByID(this.idCodigo);

            if (codActual != null)
            {
                codigos codigosCarpeta = gCodigo.getCodigos().FirstOrDefault(x => x.nombreCodigo == txtNombre.Text && x.fk_Idcarpeta == codActual.fk_Idcarpeta);

                if (codigosCarpeta != null)
                {
                    MessageBox.Show("Ya existe un codigo con el mismo nombre dentro de la carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            #endregion




            if (validarCodigo(nodo, false))
            {
                gCodigo.addCodigo(codigoNuevo);
                lCodigos = gCodigo.getCodigos().ToList();


                this.idCodigo = lCodigos.Max(x => x.idCodigo);

                codigo_categoria codCat = new codigo_categoria();

                codCat.fk_idCategoria = categoria.idCategoria;
                codCat.fk_idCodigo = idCodigo;

                gCodigoCategoria.addCodigoCategoria(codCat);

                lCodigosCategoria = gCodigoCategoria.getCodigoCategoria();
                this.idCodigoCategoria = lCodigosCategoria.Max(x => x.idCodigoCategoria);


            }
            else
                MessageBox.Show("Error: " + "El codigo no es valido para introducir-lo en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                if (txtNombre.Focused) txtDescripcion.Focus();
                else if (txtDescripcion.Focused) cbCategorias.Focus();
                else if (cbCategorias.Focused) rtxtCodigo.Focus();
                else if (rtxtCodigo.Focused) btnGuardarCodigo.Focus();
                else txtNombre.Focus();
            }
        }

        private void btnPortapapeles_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtxtCodigo.Text, true);
        }

        private void cCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                frmCapturaPantalla.CapturarPantallaCompleta();
                frmCapturaPantalla.Show();
            }
        }
    }
}
