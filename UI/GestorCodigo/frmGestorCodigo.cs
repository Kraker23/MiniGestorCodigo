using System;
using System.Collections;
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
    public partial class frmGestorCodigo : Form
    {

        #region Variables
        private Timer timer;
        private List<DatoNodo> nodosExpandidos = new List<DatoNodo>();
        private bool expandir = false;
        private List<DatoNodo> aux;
        private cCodigo controlCodigo;
        private List<categorias> lCategorias;
        private List<codigo_categoria> lCodigosCategorias;

        private Utilities.Controls.EditarImagen.frmCaptura frmCapturaPantalla = new Utilities.Controls.EditarImagen.frmCaptura();

        public partesPrograma partes;
        #endregion

        public frmGestorCodigo(partesPrograma partes)
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
        public frmGestorCodigo()
        {

            InitializeComponent();
            Start();
            startTimer();

            tsbBorrarCodigo.Visible = false;
            tsbAnadirCodigo.Visible = false;

            tsbAnadirCarpeta.Visible = false;
            tsbCambiarNombreCarpeta.Visible = false;
            tsbBorrarCarpeta.Visible = false;

            cargarArbolCategorias();

            //expandirArbolUsuario();

            if (Globales.GetUsuarioActual().idUsuario == 1 || Globales.GetUsuarioActual().idUsuario == 7)
                tsbAddCategoria.Visible = true;
            else
                tsbAddCategoria.Visible = false;

            expandirArbolUsuario();

        }

        

        #region Metodos

        /// <summary>
        /// Carga los datos de un codigo para mostrarlos dentro del formulario
        /// </summary>
        /// <param name="id">Identificador del codigo</param>
        /// 
        private void CargarCodigo(int id)
        {
            // Limpiemos el panel de controles
            splitContainer1.Panel2.Controls.Clear();

            // Creamos una instancia que ocupe todo el panel
            cCodigo c = new cCodigo(id, getNodoActual());
            c.Dock = DockStyle.Fill;

            c.codigoGuardado += gurdarCodigo_click;

            // Añadimos la instancia al panel
            splitContainer1.Panel2.Controls.Add(c);
        }

        public DatoNodo getNodoActual()
        {
            try
            {
                return (DatoNodo)treeVistaCarpetas.SelectedNode.Tag;
            }
            catch (Exception ex)
            {
                ex = null;
                return null;
            }
        }

        #endregion

        private void expandirArbolUsuario()
        {
            DatoNodo usr = aux.FirstOrDefault(x => x.Nombre == Globales.GetUsuarioActual().nombre);

            DatoNodo dep = aux.FirstOrDefault(x => x.id == Globales.GetUsuarioActual().fk_IdDepartamento);

            treeVistaCarpetas.BeginUpdate();
            foreach (TreeNode nodoDep in treeVistaCarpetas.Nodes)
            {
                if (nodoDep.Name == dep.Nombre)
                {
                    nodoDep.Expand();

                    foreach (TreeNode nodoUsuario in nodoDep.Nodes)
                    {
                        if (nodoUsuario.Name == usr.Nombre)
                        {
                            nodoUsuario.Expand();
                            nodoUsuario.Nodes.Clear();

                            TreeNode node;
                            foreach (DatoNodo nodo in aux.Where(x => x.idPadre == usr.id && x.Level == TreeLevel.Carpeta || x.Level == TreeLevel.SubCarpetas || x.Level == TreeLevel.Codigo))
                            {
                                node = new TreeNode();

                                node.Name = nodo.Nombre;   
                                node.Tag = nodo;
                                node.Nodes.Add("");
                                nodoUsuario.Nodes.Add(node);
                            }

                            break;
                        }

                    }
                    break;
                }
            }
            treeVistaCarpetas.EndUpdate();

            //ActualizarArbol();

        }


        #region Eventos


        private void Programa_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void tsbAnadirCarpeta_Click(object sender, EventArgs e)
        {
            DatoNodo nodo = getNodoActual();

            if (validarAutor(nodo))
            {
                int? idPadre = nodo.id;

                if (nodo.Level == TreeLevel.Usuario)
                    idPadre = null;

                frmAddCarpeta formAddCarpeta = new frmAddCarpeta(idPadre, false, true);
                formAddCarpeta.ShowDialog();

                ActualizarArbol();
            }
            else
                MessageBox.Show("Error: No puedes añadir una carpeta fuera del espacio de tu usuario/a", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbBorrarCarpeta_Click(object sender, EventArgs e)
        {
            DatoNodo nodo = getNodoActual();


            if (validarAutor(nodo))
            {

                carpetas ca = gCarpetas.getCarpetas().FirstOrDefault(x => x.fk_IdCarpetaPadre == nodo.id);
                codigos co = gCodigo.getCodigos().FirstOrDefault(x => x.fk_Idcarpeta == nodo.id);

                if (ca != null || co != null)
                {
                    MessageBox.Show("Error: No purdes borrar una carpeta con contenido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show(string.Format("Seguro que quieres borrar la carpeta '{0}' ", nodo.Nombre), "Eliminar carpeta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        carpetas tmp = gCarpetas.getCarpetasById(nodo.id);
                        gCarpetas.deleteCarpetas(tmp);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: No se ha podido eliminar la carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ActualizarArbol();
                }

            }
            else
                MessageBox.Show("Error: No puedes borrar una carpeta que no es tuya", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbAnadirCodigo_Click(object sender, EventArgs e)
        {
            DatoNodo nodo = getNodoActual();

            splitContainer1.Panel2.Controls.Clear();
            controlCodigo = new cCodigo(nodo);
            controlCodigo.Dock = DockStyle.Fill;

            controlCodigo.codigoGuardado += gurdarCodigo_click;

            //controlCodigo.addCodigo += SeleccionarCodigo(this, EventArgs.Empty);

            splitContainer1.Panel2.Controls.Add(controlCodigo);

        }

        void gurdarCodigo_click()
        {
            ActualizarArbol();
        }



        private void SeleccionarCodigo(object sender, EventArgs e)
        {
            ActualizarArbol();
            //MessageBox.Show(e.ToString(), "Evento");
           
        }

        private void tsbBorrarCodigo_Click(object sender, EventArgs e)
        {
            DatoNodo node = getNodoActual();

            if (node != null)
            {
                if (validarAutor(node))
                {
                    if (MessageBox.Show(string.Format("Seguro que quieres borrar el código '{0}' ", node.Nombre), "Eliminar código", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {

                            codigos cTmp = gCodigo.getCodigoByID(node.id);
                            codigo_categoria ccTmp = gCodigoCategoria.getCodigoCategoriaByIdCodigo(node.id);
                            gCodigo.deleteCodigo(cTmp);
                            gCodigoCategoria.deleteCodigoCategoria(ccTmp);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: No se ha podido eliminar el codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            splitContainer1.Panel2.Controls.Clear();
                            ActualizarArbol();
                        }
                    }
                }
                else
                    MessageBox.Show("Error: No puedes borrar un codigo que no es tuyo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbCambiarNombreCarpeta_Click(object sender, EventArgs e)
        {
            DatoNodo nodo = getNodoActual();

            if (nodo != null)
            {
                try
                {
                    frmAddCarpeta formModCarpeta = new frmAddCarpeta(nodo.id, true, true);

                    formModCarpeta.Text = "Cambiar nombre";
                    formModCarpeta.Show();
                }
                finally
                {
                    ActualizarArbol();
                }
            }
        }

        private void tsbActualizarArbol_Click(object sender, EventArgs e)
        {
            ActualizarArbol();
            cargarArbolCategorias();
        }

        #endregion

        #region Arbol

        #region Creacion arbol (CRISTIAN)

        #region Datos Arbol    
        //listas de datos que me interesaria guardar si fuera necesario
        public List<carpetas> carpetasAll;
        
        //lista que se le pasa al arbol
        public List<DatoNodo> datos;
        
        //niveles de nodo
        //public enum TreeLevel { Departamento = 1, Usuario = 2, Carpeta = 3, SubCarpetas = 4, Codigo = 5 }

        //clase de pauta para cada nodo
        //public class DatoNodo
        //{
        //    public int id { get; set; }
        //    public int? idPadre { get; set; }
        //    public string Nombre { get; set; }
        //    public TreeLevel Level { get; set; }
        //    public int? fkIdUsuario { get; set; }
        //}

        /// <summary>
        /// Funcion que te creara todo el arbol y su estructura
        /// </summary>
        public void Start()
        {
            try
            {
                treeVistaCarpetas.Nodes.Clear();

                datos = cargarDatos();

                treeVistaCarpetas.BeginUpdate();

                if (datos != null && datos.Count > 0)
                {

                    foreach (DatoNodo item in datos.Where(x => x.Level == TreeLevel.Departamento).OrderBy(x => x.Nombre).ToList())
                    {
                        //DevExpress.XtraTreeList.Nodes.TreeListNode node = new TreeListNode();
                        DatoNodo Nodo = new DatoNodo();
                        Nodo.id = item.id;
                        Nodo.Nombre = item.Nombre;
                        Nodo.Level = TreeLevel.Departamento;


                        TreeNode node = new TreeNode(item.Nombre);
                        node.Tag = Nodo;
                        node.Name = item.Nombre;
                        node.Nodes.Add("");
                        treeVistaCarpetas.Nodes.Add(node);

                        
                    }

                }

                // treeVistaCarpetas.ExpandAll();


                treeVistaCarpetas.EndUpdate();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Funcion que carga los datos de la base de datos en el formulario y 
        /// los trato de tal manera para conseguir los datos con la forma que quiero( tambien es posible haciendo una query en la Base de datos)
        /// </summary>
        /// <returns></returns>
        private List<DatoNodo> cargarDatos()
        {
            aux = new List<DatoNodo>();

            carpetasAll = BL.gCarpetas.getCarpetas();

            List<departamentos> departamentos = gDepartamentos.getDepartamentos();
            List<usuarios> usuarios = gUsuarios.getUsuarios();
            List<carpetas> carpetas = carpetasAll.Where(x => x.fk_IdCarpetaPadre == null).ToList();
            List<carpetas> subcarpetas = carpetasAll.Where(x => x.fk_IdCarpetaPadre != null).ToList();
            List<codigos> codigos = gCodigo.getCodigos();

            #region Nodos departamentos
            foreach (departamentos item in departamentos)
            {
                DatoNodo dato = new DatoNodo();
                dato.id = item.idDepartamento;
                dato.idPadre = null;
                dato.Level = TreeLevel.Departamento;
                dato.Nombre = item.nombreDepartamento;
                aux.Add(dato);
            }
            #endregion

            #region Nodos usuarios
            foreach (usuarios item in usuarios)
            {
                DatoNodo dato = new DatoNodo();
                dato.id = item.idUsuario;
                dato.idPadre = item.fk_IdDepartamento;// departamentos.First(x=>x.departamento==item.fk_iddepartamento).idDepartamento;
                dato.Level = TreeLevel.Usuario;
                dato.Nombre = item.nombre;
                aux.Add(dato);
            }
            #endregion

            #region Nodos carpetas
            foreach (carpetas item in carpetas)
            {
                DatoNodo dato = new DatoNodo();
                dato.id = item.idCarpeta;
                dato.idPadre = item.fk_IdUsuario;// cambiar el IdUsuario por idCarpetaUsuario
                dato.Level = TreeLevel.Carpeta;
                dato.Nombre = item.nombreCarpeta;
                dato.fkIdUsuario = item.fk_IdUsuario;
                aux.Add(dato);
            }
            #endregion

            #region Nodos subCarpetas
            foreach (carpetas item in subcarpetas)
            {
                DatoNodo dato = new DatoNodo();
                dato.id = item.idCarpeta;
                dato.idPadre = item.fk_IdCarpetaPadre;// carpetasAll.First(x => x.idCarpeta == item.carpetaPadre).idCarpeta;
                dato.Level = TreeLevel.SubCarpetas;
                dato.Nombre = item.nombreCarpeta;
                dato.fkIdUsuario = item.fk_IdUsuario;
                aux.Add(dato);
            }
            #endregion

            #region Nodos Codigo
            foreach (codigos item in codigos)
            {
                DatoNodo dato = new DatoNodo();
                dato.id = item.idCodigo;
                dato.idPadre = item.fk_Idcarpeta;
                dato.Level = TreeLevel.Codigo;
                dato.Nombre = item.nombreCodigo;
                dato.fkIdUsuario = item.fk_IdAutor;
                aux.Add(dato);
            }
            #endregion

            return aux;
        }

        //evento que se ejecuta cuando se expande un nodo, se crea en el la vista de Diseño en la parte de eventos
        private void treeVistaCarpetas_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeVistaCarpetas.BeginUpdate();
            DatoNodo Valor = (DatoNodo)e.Node.Tag;

            // Añadimos el nodo que queremos expandir a la lista si es que no esta
            if (nodosExpandidos.FirstOrDefault(x => x.id == Valor.id && x.Level == Valor.Level && x.Nombre == Valor.Nombre && x.fkIdUsuario == Valor.fkIdUsuario) == null
                && expandir == false)
                nodosExpandidos.Add(Valor);


            // Si el nodo que queremos expandir es un codigo, cargamos su informacion dentro del formulario

            switch (Valor.Level)
            {
                case TreeLevel.Departamento:
                    //si el nodo que expando es de Departamento le cargo nodos de Usuario

                    AgregarNodosUsuario(e, Valor);
                    //AgregarNodosCarpeta(e, Valor);

                    break;

                case TreeLevel.Usuario:
                    //si el nodo que expando es de Usuario le cargo nodos de Carpeta
                    AgregarNodosCarpeta(e, Valor);
                    AgregarNodosCodigo(e, Valor);
                    //Tambien hay que añadir nodos codigo que se encuentren fuera de una carpeta
                    break;

                case TreeLevel.Carpeta:
                    //si el nodo que expando es de Carpeta le cargo nodos de SubCarpetas y Codigos
                    e.Node.Nodes.Clear();

                    if (datos.Exists(x => x.idPadre == Valor.id && x.Level == TreeLevel.SubCarpetas))
                    {
                        AgregarNodosSubCarpeta(e, Valor);
                    }
                    if (datos.Exists(x => x.idPadre == Valor.id && x.Level == TreeLevel.Codigo))
                    {
                        AgregarNodosCodigo(e, Valor);
                    }
                    break;

                case TreeLevel.SubCarpetas:
                    //si el nodo que expando es de SubCarpetas le cargo nodos de  SubCarpetas y Codigos
                    e.Node.Nodes.Clear();

                    if (datos.Exists(x => x.idPadre == Valor.id && x.Level == TreeLevel.SubCarpetas))
                    {
                        AgregarNodosSubCarpeta(e, Valor);
                    }
                    if (datos.Exists(x => x.idPadre == Valor.id && x.Level == TreeLevel.Codigo))
                    {
                        AgregarNodosCodigo(e, Valor);
                    }
                    break;
            }

            treeVistaCarpetas.EndUpdate();
        }

        #endregion

        #region AgregarNodos
        //Todos estos metodos se pueden sustituir por uno solo, que sea mas general, he puesto esto como ejemplo por si tubieras que hacer un arbol muy especifico para cada nivel de nodo

        private void AgregarNodosUsuario(TreeViewCancelEventArgs e, DatoNodo Valor)
        {
            treeVistaCarpetas.BeginUpdate();

            e.Node.Nodes.Clear();


            foreach (DatoNodo item in datos.Where(x => x.idPadre == Valor.id && x.Level == TreeLevel.Usuario).OrderBy(x => x.Nombre).ToList())
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = item.id;
                Nodo.Nombre = item.Nombre;
                Nodo.Level = TreeLevel.Usuario;
                Nodo.fkIdUsuario = item.fkIdUsuario;

                TreeNode node = new TreeNode(item.Nombre);
                node.Tag = Nodo;
                node.Name = item.Nombre;
                node.Nodes.Add("");
                e.Node.Nodes.Add(node);


            }
            treeVistaCarpetas.EndUpdate();
        }

        private void AgregarNodosCarpeta(TreeViewCancelEventArgs e, DatoNodo Valor)
        {
            treeVistaCarpetas.BeginUpdate();

            if (e != null)
                e.Node.Nodes.Clear();

            //datos = cargarDatos();

            foreach (DatoNodo item in datos.Where(x => x.idPadre == Valor.id && x.Level == TreeLevel.Carpeta).OrderBy(x => x.Nombre).ToList())
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = item.id;
                Nodo.Nombre = item.Nombre;
                Nodo.Level = TreeLevel.Carpeta;
                Nodo.fkIdUsuario = item.fkIdUsuario;

                TreeNode node = new TreeNode(item.Nombre);
                node.Tag = Nodo;
                node.Name = item.Nombre;
                node.Nodes.Add("");
                e.Node.Nodes.Add(node);
            }
            treeVistaCarpetas.EndUpdate();
        }

        private void AgregarNodosSubCarpeta(TreeViewCancelEventArgs e, DatoNodo Valor)
        {
            treeVistaCarpetas.BeginUpdate();



            foreach (DatoNodo item in datos.Where(x => x.idPadre == Valor.id && x.Level == TreeLevel.SubCarpetas).OrderBy(x => x.Nombre).ToList())
            {
                DatoNodo Nodo = new DatoNodo();
                Nodo.id = item.id;
                Nodo.Nombre = item.Nombre;
                Nodo.Level = TreeLevel.SubCarpetas;
                Nodo.fkIdUsuario = item.fkIdUsuario;
                Nodo.idPadre = item.idPadre;

                TreeNode node = new TreeNode(item.Nombre);
                node.Tag = Nodo;
                node.Name = item.Nombre;
                node.Nodes.Add("");
                e.Node.Nodes.Add(node);
            }
            treeVistaCarpetas.EndUpdate();
        }

        private void AgregarNodosCodigo(TreeViewCancelEventArgs e, DatoNodo Valor)
        {
            treeVistaCarpetas.BeginUpdate();

            List<DatoNodo> list = datos.Where(x => x.Level == TreeLevel.Codigo).ToList();

            switch (Valor.Level)
            {
                case TreeLevel.Usuario:

                    foreach (DatoNodo item in list.Where(x => x.idPadre == null ).OrderBy(x => x.Nombre).ToList()) // x => x.idPadre == null && x.Level == TreeLevel.Codigo
                    {
                        if (Valor.id == item.fkIdUsuario)
                        {
                            DatoNodo Nodo = new DatoNodo();
                            Nodo.id = item.id;
                            Nodo.Nombre = item.Nombre;
                            Nodo.Level = TreeLevel.Codigo;
                            Nodo.fkIdUsuario = item.fkIdUsuario;

                            TreeNode node = new TreeNode(item.Nombre);
                            node.Tag = Nodo;
                            node.Name = item.Nombre;
                            //node.Nodes.Add("");
                            e.Node.Nodes.Add(node);
                        }
                    }
                    break;

                case TreeLevel.SubCarpetas:
                case TreeLevel.Carpeta:

                    foreach (DatoNodo item in list.Where(x => x.idPadre == Valor.id))
                    {
                        if (Valor.fkIdUsuario == item.fkIdUsuario)
                        {
                            DatoNodo Nodo = new DatoNodo();
                            Nodo.id = item.id;
                            Nodo.Nombre = item.Nombre;
                            Nodo.Level = TreeLevel.Codigo;

                            TreeNode node = new TreeNode(item.Nombre);
                            node.Tag = Nodo;
                            node.Name = item.Nombre;
                            //node.Nodes.Add("");
                            e.Node.Nodes.Add(node);
                        }
                    }
                    break;
            }

            //codigos cod;
            //foreach (DatoNodo item in datos.Where(x => x.idPadre == Valor.id && x.Level == TreeLevel.Codigo))
            //{
            //    //cod = gCodigo.getCodigoByID(item.id);

            //    if (Valor.id == item.fkIdUsuario)
            //    {
            //        DatoNodo Nodo = new DatoNodo();
            //        Nodo.id = item.id;
            //        Nodo.Nombre = item.Nombre;
            //        Nodo.Level = TreeLevel.Codigo;

            //        TreeNode node = new TreeNode(item.Nombre);
            //        node.Tag = Nodo;
            //        //node.Nodes.Add("");
            //        e.Node.Nodes.Add(node);
            //    }




            //    //switch (Valor.Level)
            //    //{
            //    //    case TreeLevel.Usuario:
            //    //        usuarios usr = gUsuarios.getUsuarioById(Valor.id);

            //    //        if (cod.fk_IdAutor == usr.idUsuario)
            //    //        {
            //    //            DatoNodo Nodo = new DatoNodo();
            //    //            Nodo.id = item.id;
            //    //            Nodo.Nombre = item.Nombre;
            //    //            Nodo.Level = TreeLevel.Codigo;

            //    //            TreeNode node = new TreeNode(item.Nombre);
            //    //            node.Tag = Nodo;
            //    //            //node.Nodes.Add("");
            //    //            e.Node.Nodes.Add(node);
            //    //        }
            //    //        break;

            //    //    case TreeLevel.Carpeta:
            //    //    case TreeLevel.SubCarpetas:
            //    //        carpetas carp = gCarpetas.getCarpetasById(Valor.id);

            //    //        if (carp.fk_IdUsuario == cod.fk_IdAutor)
            //    //        {
            //    //            DatoNodo Nodo = new DatoNodo();
            //    //            Nodo.id = item.id;
            //    //            Nodo.Nombre = item.Nombre;
            //    //            Nodo.Level = TreeLevel.Codigo;

            //    //            TreeNode node = new TreeNode(item.Nombre);
            //    //            node.Tag = Nodo;
            //    //            //node.Nodes.Add("");
            //    //            e.Node.Nodes.Add(node);
            //    //        }
            //    //        break;
            //    //}



            //    //DatoNodo Nodo = new DatoNodo();
            //    //Nodo.id = item.id;
            //    //Nodo.Nombre = item.Nombre;
            //    //Nodo.Level = TreeLevel.Codigo;

            //    //TreeNode node = new TreeNode(item.Nombre);
            //    //node.Tag = Nodo;
            //    ////node.Nodes.Add("");
            //    //e.Node.Nodes.Add(node);
            //}
            treeVistaCarpetas.EndUpdate();
        }

        #endregion

        #endregion

        #region Eventos

        private void treeVistaCarpetas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                DatoNodo nodo = (DatoNodo)e.Node.Tag;

                switch (nodo.Level)
                {
                    case TreeLevel.Codigo:

                        tsbBorrarCodigo.Visible = true;
                        tsbAnadirCodigo.Visible = false;
                        tsbAnadirCarpeta.Visible = false;
                        tsbBorrarCarpeta.Visible = false;
                        tsbCambiarNombreCarpeta.Visible = false;

                        CargarCodigo(nodo.id);

                        break;

                    case TreeLevel.SubCarpetas:
                    case TreeLevel.Carpeta:

                        tsbBorrarCodigo.Visible = false;
                        tsbAnadirCodigo.Visible = true;
                        tsbAnadirCarpeta.Visible = true;
                        tsbBorrarCarpeta.Visible = true;
                        tsbCambiarNombreCarpeta.Visible = true;

                        splitContainer1.Panel2.Controls.Clear();

                        break;

                    case TreeLevel.Departamento:

                        tsbBorrarCodigo.Visible = false;
                        tsbAnadirCodigo.Visible = false;
                        tsbAnadirCarpeta.Visible = false;
                        tsbBorrarCarpeta.Visible = false;
                        tsbCambiarNombreCarpeta.Visible = false;

                        splitContainer1.Panel2.Controls.Clear();

                        break;

                    case TreeLevel.Usuario:

                        tsbBorrarCodigo.Visible = false;
                        tsbAnadirCodigo.Visible = true;
                        tsbAnadirCarpeta.Visible = true;
                        tsbBorrarCarpeta.Visible = false;
                        tsbCambiarNombreCarpeta.Visible = false;

                        splitContainer1.Panel2.Controls.Clear();

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: No se ha podido cargar los dados.\n ({0})", ex));
            }
        }

        private void treeVistaCarpetas_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            DatoNodo Valor = (DatoNodo)e.Node.Tag;

            // Si tenemos el nodo que acabamos de contraer en la lista de nodos expandidos, lo sacamos
            if (expandir == false && nodosExpandidos.Exists(x => x.id == Valor.id && x.Level == Valor.Level && x.Nombre == Valor.Nombre && x.fkIdUsuario == Valor.fkIdUsuario))
            {
                nodosExpandidos.Remove(nodosExpandidos.First(x => x.id == Valor.id && x.Level == Valor.Level && x.Nombre == Valor.Nombre && x.fkIdUsuario == Valor.fkIdUsuario));
            }

        }

        #endregion

        #region Actualizar

        public void ActualizarArbol()
        {

            Start();

            expandir = true;

            List<DatoNodo> nodoExpandidosOrden = nodosExpandidos.OrderByDescending(x => x.Level).ToList();

            for (int i = 0; i < nodoExpandidosOrden.Count; i++)
                ExpandirNodosArbol(nodoExpandidosOrden[i], false, null);

            expandir = false;
        }

        private TreeNode ExpandirNodosArbol(DatoNodo padre, bool busqueda, string text)
        {
            TreeNode node = null;
            TreeNode nodeExpand = null;
            TreeNode treeNodePadre = null;
            TreeNode treeNode = null;
            DatoNodo padreOld = null;

            if (padre != null)
                switch (padre.Level)
                {

                    case TreeLevel.Codigo:
                        padreOld = padre;

                        if (busqueda)
                        {
                            padre = aux.FirstOrDefault(x => (x.id == padreOld.idPadre) && x.Level == TreeLevel.Carpeta
                            || x.Level == TreeLevel.SubCarpetas);

                        }
                        else
                            padre = nodosExpandidos.FirstOrDefault(x => (x.id == padreOld.idPadre) && x.Level == TreeLevel.Carpeta
                            || x.Level == TreeLevel.SubCarpetas || x.Level == TreeLevel.Usuario || x.Level == TreeLevel.Departamento);

                        //padre = nodosExpandidos.FirstOrDefault(x => (x.id == padreOld.idPadre) && x.Level == TreeLevel.Carpeta || x.Level == TreeLevel.SubCarpetas);


                        #region EXPANDIR
                        node = ExpandirNodosArbol(padre, busqueda, text);

                        if (node != null)
                        {
                            nodeExpand = node.Nodes.Find(padreOld.Nombre, false).FirstOrDefault();


                            if (nodeExpand != null)
                                if (busqueda && text != null && nodeExpand.Text.ToLower().Contains(text.ToLower()))
                                    nodeExpand.BackColor = Color.Yellow;
                        }

                        #endregion

                        break;

                    case TreeLevel.SubCarpetas:
                        padreOld = padre;

                        if (busqueda)
                            padre = aux.FirstOrDefault(x => x.id == padreOld.idPadre && (x.Level == TreeLevel.Carpeta || x.Level == TreeLevel.SubCarpetas) && x.fkIdUsuario == padreOld.fkIdUsuario);
                        else
                            padre = nodosExpandidos.FirstOrDefault(x => x.id == padreOld.idPadre && (x.Level == TreeLevel.Carpeta || x.Level == TreeLevel.SubCarpetas) && x.fkIdUsuario == padreOld.fkIdUsuario);



                        #region EXPANDIR
                        node = ExpandirNodosArbol(padre, busqueda, text);
                        if (node != null)
                        {
                            nodeExpand = node.Nodes.Find(padreOld.Nombre, false).FirstOrDefault();

                            if (nodeExpand != null)
                            {
                                treeNodePadre = nodeExpand;

                                if (!nodeExpand.IsExpanded)
                                {
                                    nodeExpand.Expand();

                                }
                            }
                        }

                        if (nodeExpand != null)
                            if (busqueda && text != null && nodeExpand.Text.ToLower().Contains(text.ToLower()))
                                nodeExpand.BackColor = Color.Yellow;

                        #endregion

                        break;

                    case TreeLevel.Carpeta:
                        padreOld = padre;

                        if (busqueda)
                            padre = aux.FirstOrDefault(x => x.id == padre.fkIdUsuario && x.Level == TreeLevel.Usuario);
                        else
                            padre = nodosExpandidos.FirstOrDefault(x => x.id == padre.fkIdUsuario && x.Level == TreeLevel.Usuario);

                        #region EXPANDIR
                        node = ExpandirNodosArbol(padre, busqueda, text);
                        if (node != null)
                        {
                            nodeExpand = node.Nodes.Find(padreOld.Nombre, false).FirstOrDefault();

                            if (nodeExpand != null)
                            {
                                treeNodePadre = nodeExpand;

                                if (!nodeExpand.IsExpanded)
                                {
                                    nodeExpand.Expand();

                                }
                            }
                        }

                        if (nodeExpand != null)
                            if (busqueda && text != null && nodeExpand.Text.ToLower().Contains(text.ToLower()))
                                nodeExpand.BackColor = Color.Yellow;

                        #endregion

                        break;

                    case TreeLevel.Usuario:
                        padreOld = padre;


                        usuarios usr = gUsuarios.getUsuarioById(padre.id);

                        if (busqueda)
                            padre = aux.FirstOrDefault(x => x.id == usr.fk_IdDepartamento && x.Level == TreeLevel.Departamento);
                        else
                            padre = nodosExpandidos.FirstOrDefault(x => x.id == usr.fk_IdDepartamento && x.Level == TreeLevel.Departamento);


                        #region EXPANDIR
                        node = ExpandirNodosArbol(padre, busqueda, text);

                        if (node != null)
                        {
                            nodeExpand = node.Nodes.Find(padreOld.Nombre, false).FirstOrDefault();

                            if (nodeExpand != null)
                            {
                                treeNodePadre = nodeExpand;

                                if (!nodeExpand.IsExpanded)
                                {
                                    nodeExpand.Expand();
                                }
                            }
                        }

                        if (nodeExpand != null)
                            if (busqueda && text != null && nodeExpand.Text.ToLower().Contains(text.ToLower()))
                                nodeExpand.BackColor = Color.Yellow;

                        #endregion

                        break;

                    case TreeLevel.Departamento:
                        TreeNode treeNodeDep = treeVistaCarpetas.Nodes.Find(padre.Nombre, false).FirstOrDefault();

                        if (treeNodeDep != null)
                        {
                            treeNodePadre = treeNodeDep;

                            if (!treeNodeDep.IsExpanded)
                            {
                                treeNodeDep.Expand();
                            }

                            if (treeNodeDep != null)
                                if (busqueda && text != null && treeNodeDep.Text.ToLower().Contains(text.ToLower()))
                                    treeNodeDep.BackColor = Color.Yellow;
                        }

                        break;
                }
            return treeNodePadre;
        }

        #endregion

        #endregion

        #region ArbolCategorias

        private void cargarArbolCategorias()
        {

            tvCategorias.BeginUpdate();
            lCategorias = gCategorias.getCategorias();
            List<DatoNodo> categorias = new List<DatoNodo>();

            tvCategorias.Nodes.Clear();

            DatoNodo datoNodo;
            foreach (categorias cat in lCategorias)
            {
                datoNodo = new DatoNodo();

                datoNodo.id = cat.idCategoria;
                datoNodo.idPadre = null;
                datoNodo.Nombre = cat.nombreCategoria;

                categorias.Add(datoNodo);
            }

            TreeNode node;
            foreach (DatoNodo nodo in categorias.OrderBy(x => x.Nombre).ToList())
            {
                node = new TreeNode(nodo.Nombre);

                node.Tag = nodo;
                node.Name = nodo.Nombre;
                node.Nodes.Add("");

                tvCategorias.Nodes.Add(node);
            }

            tvCategorias.EndUpdate();
        }

        private void tvCategorias_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

            DatoNodo node = (DatoNodo)e.Node.Tag;
            lCodigosCategorias = gCodigoCategoria.getCodigoCategoria();

            categorias cat = lCategorias.FirstOrDefault(x => x.idCategoria == node.id);
            List<codigos> cods = gCodigo.getCodigos();

            e.Node.Nodes.Clear();

            DatoNodo datoNodo;
            TreeNode treeNode;
            codigos codExpand;
            foreach (codigo_categoria codCat in lCodigosCategorias.Where(x => x.fk_idCategoria == cat.idCategoria))
            {
                codExpand = cods.FirstOrDefault(x => x.idCodigo == codCat.fk_idCodigo);

                if (codExpand != null)
                {
                    datoNodo = new DatoNodo();

                    datoNodo.Nombre = codExpand.nombreCodigo;
                    datoNodo.id = codExpand.idCodigo;
                    datoNodo.fkIdUsuario = codExpand.fk_IdAutor;


                    treeNode = new TreeNode(datoNodo.Nombre);
                    treeNode.Name = datoNodo.Nombre;
                    treeNode.Tag = datoNodo;

                    e.Node.Nodes.Add(treeNode);
                }

            }

            //List<codigos> lCodigos = gCodigo.getCodigos().Where(x => x.)


        }

        private void tvCategorias_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DatoNodo node = (DatoNodo)e.Node.Tag;
            
            if (node.Level == TreeLevel.Codigo)
            {
                splitContainer1.Panel2.Controls.Clear();

                cCodigo controlCod = new cCodigo(node.id, node);
                controlCod.Dock = DockStyle.Fill;
                controlCod.codigoGuardado += gurdarCodigo_click;

                splitContainer1.Panel2.Controls.Add(controlCod);
            }

        }

        #endregion


        #region Validaciones

        public static bool validarAutor(DatoNodo nodo)
        {
            bool result = true;

            switch (nodo.Level)
            {
                case TreeLevel.Codigo:

                    codigos cod = gCodigo.getCodigoByID(nodo.id);

                    if (cod != null)
                        if (Globales.GetUsuarioActual().idUsuario != cod.fk_IdAutor)
                            result = false;

                    break;

                case TreeLevel.Carpeta:
                case TreeLevel.SubCarpetas:

                    carpetas car = gCarpetas.getCarpetasById(nodo.id);

                    if (Globales.GetUsuarioActual().idUsuario != car.fk_IdUsuario)
                        result = false;

                    break;

                case TreeLevel.Usuario:

                    if (Globales.GetUsuarioActual().idUsuario != nodo.id)
                        result = false;

                    break;
            }

            return result;
        }

        #endregion


        #region Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if (txtBuscar.Text.Count() > 1)
            {
                treeVistaCarpetas.CollapseAll();

                List<TreeNode> coincidencias = new List<TreeNode>();

                string busca = txtBuscar.Text;

                BusquedaDatos(busca);

                foreach (TreeNode coincidencia in coincidencias)
                    coincidencia.BackColor = Color.Yellow;

            }
            else
            {
                treeVistaCarpetas.CollapseAll();
                foreach (TreeNode node in treeVistaCarpetas.Nodes)
                {
                    node.BackColor = Color.White;
                }
            }
        }

        private void BusquedaDatos(string busqueda)
        {
            List<DatoNodo> coincidencias = aux.Where(x => x.Nombre.ToLower().Contains(busqueda.ToLower())).ToList();

            if (coincidencias.Count > 0)
            {
                foreach (DatoNodo nodo in coincidencias.OrderByDescending(x => x.Level).ToList())
                {
                    ExpandirNodosArbol(nodo, true, busqueda);
                    TreeNode node = treeVistaCarpetas.Nodes.Find(nodo.Nombre, true).FirstOrDefault();

                    if (node != null)
                    {
                        node.BackColor = Color.Yellow;
                    }
                }
            }
        }
        
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBuscar_Click(null, null);
            }

        }

        private void startTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(btnBuscar_Click);
            timer.Start();
        }



        #endregion

        private void frmGestorCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                frmCapturaPantalla.CapturarPantallaCompleta();
                frmCapturaPantalla.Show();
            }
        }

        private void tsbAddCategoria_Click(object sender, EventArgs e)
        {
            frmAddCategoria frmCat = new frmAddCategoria();
            DialogResult r = frmCat.ShowDialog();

            if (r == DialogResult.OK)
            {
                ActualizarArbol();
                cargarArbolCategorias();
            }
        }
    }
}
