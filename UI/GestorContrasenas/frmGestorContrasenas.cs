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
using Utilities.Extensions;
using MiniGestorCodigo.UI.GestorContrasenas;
using static MiniGestorCodigo.UI.frmMain;

namespace MiniGestorCodigo.UI
{
    public partial class frmGestorContrasenas : Form
    {

        #region Variables
        public class DatoNodoPass
        {
            public int id { get; set; }
            public int? idPadre { get; set; }
            public string Nombre { get; set; }
            public TreeLevelContras Level { get; set; }
            public int? fkIdUsuario { get; set; }
        }
        public enum TreeLevelContras
        {
            Usuario = 1,
            Carpeta = 2,
            SubCarpetas = 3,
            Pass = 4,
            Compartida=5,
            ComCarpeta=6,
            ComSubCarpeta=7,
            ComPass=8

        }

        private List<DatoNodoPass> data;
        private List<DatoNodoPass> datos;
        private List<DatoNodoPass> datosCompartidos;

        public bool cargando;
        private List<DatoNodoPass> nodosExpandidos;

        private List<contrasenas> lContrasenas;
        private List<carpetas_contrasenas> lCarpetas;


        private List<contrasenas> ContrasenasCompartidas;
        private List<carpetas_contrasenas> CarpetasCompartidas;

        public delegate void actualizarArbol();
        public event EventHandler EventHand;
        public partesPrograma partes;

        #endregion

        /* Set the index of image from the 
           ImageList for selected and unselected tree nodes.*/
        public int Usuario  ;
        public int Compartida ;
        public int carpeta ;
        public int pass ;

        #region constructor

        public frmGestorContrasenas(partesPrograma partes)
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
        public frmGestorContrasenas()
        {
            InitializeComponent();
            //generarArbolContrasenas();
            generarArbolContrasenas_v2();
            nodosExpandidos = new List<DatoNodoPass>();
        }


        #endregion

        #region Arbol

        private void generarArbolContrasenas_v2()
        {
            cargando = true;
            tsbContrasenas.BeginUpdate();
            tsbContrasenas.Nodes.Clear();

            datos = new List<DatoNodoPass>();
            datosCompartidos = new List<DatoNodoPass>();
            lContrasenas = gContrasenas.getContrasenasByUsuario(Globales.GetUsuarioActual().idUsuario);
            lCarpetas = gCarpetasContrasenas.getCarpetasContrasenasByUser(Globales.GetUsuarioActual().idUsuario);
            CarpetasCompartidas = new List<carpetas_contrasenas>();


            ContrasenasCompartidas = gContrasenas.getContrasenasByIDs(gContrasenas.getContrasenasCompartidas(Globales.usuarioActual.idUsuario));
            DatoNodoPass item = new DatoNodoPass();

            //Añadir el usuario a la lista
            item.Nombre = Globales.GetUsuarioActual().nombre;
            item.id = Globales.GetUsuarioActual().idUsuario;
            item.Level = TreeLevelContras.Usuario;

            datos.Add(item);

            //Añadir Elemento de Contraseñas Compartidas a la lista
            item = new DatoNodoPass();
            item.Nombre = "Compartidas";
            item.id = -3;
            item.Level = TreeLevelContras.Compartida;

            datos.Add(item);

            CrearArbol();
            setearImagenes();


            //List<DatoNodoPass> nodoBase = datos.Where(x => x.id == Globales.GetUsuarioActual().idUsuario && x.Nombre == Globales.GetUsuarioActual().nombre && x.Level == TreeLevelContras.Usuario).ToList();
            List<DatoNodoPass> nodoBase = datos.Where(x => x.Level == TreeLevelContras.Usuario || x.Level == TreeLevelContras.Compartida).ToList();
            foreach (DatoNodoPass nodo in nodoBase)
            {
                TreeNode tNode = new TreeNode();

                tNode.Name = nodo.Nombre;
                tNode.Tag = (DatoNodoPass)nodo;
                tNode.Text = nodo.Nombre;
                if (nodo.id >= 0)
                {
                    tNode.ImageIndex = Usuario;
                    tNode.SelectedImageIndex = Usuario;
                }
                else
                {
                    tNode.ImageIndex = Compartida;
                    tNode.SelectedImageIndex = Compartida;

                }
                tNode.Nodes.Add("");


                tsbContrasenas.Nodes.Add(tNode);
            }

            AbrirExpandidos();

            tsbContrasenas.EndUpdate();
            cargando = false;
        }

        private void AbrirExpandidos()
        {
            
            if (nodosExpandidos.HasContent())
            {
                RecursivoAbrirExpandidos(tsbContrasenas.Nodes);
            }
        }

        private void RecursivoAbrirExpandidos(TreeNodeCollection nodos)
        {
            foreach (TreeNode node in nodos)
            {
                DatoNodoPass nodoSel = ((DatoNodoPass)node.Tag);
                if (nodosExpandidos.Exists(x => x.id == nodoSel.id && x.Level == nodoSel.Level))
                {
                    node.Expand();
                    if (node.Nodes.Count>0)
                    {
                        RecursivoAbrirExpandidos(node.Nodes);
                    }
                }
            }
        }

        private void setearImagenes()
        {
            // Load the images in an ImageList.
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Image.FromFile("carpeta.png"));
            myImageList.Images.Add(Image.FromFile("llave.png"));
            myImageList.Images.Add(Image.FromFile("compartir.png"));
            myImageList.Images.Add(Image.FromFile("usuario.png"));

            Usuario = 3;
            Compartida = 2;
            carpeta = 0;
            pass = 1;

            // Assign the ImageList to the TreeView.
            tsbContrasenas.ImageList = myImageList;

            // Set the TreeView control's default image and selected image indexes.
            tsbContrasenas.ImageIndex = 0;
           // tsbContrasenas.SelectedImageIndex = 1;

           
        }

        private void CrearArbol()
        {
            DatoNodoPass item = new DatoNodoPass();

            // Añadir las carpetas a la lista
            foreach (carpetas_contrasenas carpeta in lCarpetas)
            {
                item = new DatoNodoPass();

                item.id = carpeta.idCarpeta;
                item.Nombre = carpeta.nombre;

                if (carpeta.fk_idCarpetaPadre == null)
                {
                    item.fkIdUsuario = carpeta.fk_idUsuario;
                    item.Level = TreeLevelContras.Carpeta;
                }
                else
                {
                    item.idPadre = carpeta.fk_idCarpetaPadre;
                    item.Level = TreeLevelContras.SubCarpetas;
                }

                datos.Add(item);
            }

            //agregamos las contraseñas
            foreach (contrasenas pswd in lContrasenas)
            {
                item = new DatoNodoPass();

                item.id = pswd.idContrasena;
                item.Nombre = pswd.nombre;

                if (pswd.fk_idCarpeta == null)
                {
                    item.fkIdUsuario = pswd.fk_idUsuario;
                }
                else
                {
                    item.idPadre = pswd.fk_idCarpeta;
                }

                item.Level = TreeLevelContras.Pass;

                datos.Add(item);
            }

            foreach (contrasenas pswd in ContrasenasCompartidas.Where(x=>x.fk_idCarpeta !=null))
            {
                BuscarCarpetas(pswd.fk_idCarpeta.Value);
            }

            foreach (carpetas_contrasenas carpeta in CarpetasCompartidas)
            {
                item = new DatoNodoPass();

                item.id = carpeta.idCarpeta;
                item.Nombre = carpeta.nombre;

                if (carpeta.fk_idCarpetaPadre == null)
                {
                    item.fkIdUsuario = carpeta.fk_idUsuario;
                    item.Level = TreeLevelContras.ComCarpeta;
                }
                else
                {
                    item.idPadre = carpeta.fk_idCarpetaPadre;
                    item.Level = TreeLevelContras.ComSubCarpeta;
                }

                datosCompartidos.Add(item);
            }

            foreach (contrasenas pswd in ContrasenasCompartidas)
            {
                item = new DatoNodoPass();

                item.id = pswd.idContrasena;
                item.Nombre = pswd.nombre;

                if (pswd.fk_idCarpeta == null)
                {
                    item.fkIdUsuario = pswd.fk_idUsuario;
                }
                else
                {
                    item.idPadre = pswd.fk_idCarpeta;
                }

                item.Level = TreeLevelContras.ComPass;

                datosCompartidos.Add(item);
            }

        }

        private void BuscarCarpetas(int fk_idCarpeta)
        {
            carpetas_contrasenas cc = gCarpetasContrasenas.getCarpetasContrasenasByIDCarpeta(fk_idCarpeta);
            if (!CarpetasCompartidas.Exists(x => x.idCarpeta == cc.idCarpeta))
            {
                CarpetasCompartidas.Add(cc);
            }

            if (cc.fk_idCarpetaPadre!=null)
            {
                BuscarCarpetas(cc.fk_idCarpetaPadre.Value);
            }
        }


        /// <summary>
        /// Metodo para añadir nodos carpeta
        /// </summary>
        /// <param name="node"> TreeNode padre </param>
        private void anadirNodosCarpeta_v2(TreeNode node)
        {
            DatoNodoPass nodo = (DatoNodoPass)node.Tag;
            if (nodo.Level == TreeLevelContras.Usuario)
            {

                List<DatoNodoPass> carpetas = datos.Where(x => x.fkIdUsuario == nodo.id && x.Level == TreeLevelContras.Carpeta && x != (DatoNodoPass)node.Tag).ToList();
                TreeNode nodeC;
                foreach (DatoNodoPass carp in carpetas)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = carp.Nombre;
                    nodeC.Name = carp.Nombre;
                    nodeC.Tag = (DatoNodoPass)carp;
                    nodeC.ImageIndex = carpeta;
                    nodeC.SelectedImageIndex = carpeta;
                    nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
            else if (nodo.Level == TreeLevelContras.Carpeta || nodo.Level == TreeLevelContras.SubCarpetas)
            {
                List<DatoNodoPass> carpetas = datos.Where(x => x.idPadre == nodo.id &&( x.Level == TreeLevelContras.Carpeta || x.Level == TreeLevelContras.SubCarpetas) && x != (DatoNodoPass)node.Tag).ToList();

                TreeNode nodeC;
                foreach (DatoNodoPass carp in carpetas)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = carp.Nombre;
                    nodeC.Name = carp.Nombre;
                    nodeC.Tag = (DatoNodoPass)carp;
                    nodeC.ImageIndex = carpeta;
                    nodeC.SelectedImageIndex = carpeta;
                    nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
            else if (nodo.Level == TreeLevelContras.Compartida)
            {
                List<DatoNodoPass> carpetas = datosCompartidos.Where(x => x.Level == TreeLevelContras.ComCarpeta && x != (DatoNodoPass)node.Tag).ToList();
                //List<DatoNodoPass> carpetas = datos.Where(x => x.fkIdUsuario == nodo.id && x.Level == TreeLevelContras.ComCarpeta && x != (DatoNodoPass)node.Tag).ToList();
                TreeNode nodeC;
                foreach (DatoNodoPass carp in carpetas)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = carp.Nombre;
                    nodeC.Name = carp.Nombre;
                    nodeC.Tag = (DatoNodoPass)carp;
                    nodeC.ImageIndex = carpeta;
                    nodeC.SelectedImageIndex = carpeta;
                    nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
            else if (nodo.Level == TreeLevelContras.ComCarpeta || nodo.Level == TreeLevelContras.ComSubCarpeta)
            {
                List<DatoNodoPass> carpetas = datosCompartidos.Where(x => x.idPadre == nodo.id && (x.Level == TreeLevelContras.ComCarpeta || x.Level == TreeLevelContras.ComSubCarpeta) && x != (DatoNodoPass)node.Tag).ToList();

                TreeNode nodeC;
                foreach (DatoNodoPass carp in carpetas)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = carp.Nombre;
                    nodeC.Name = carp.Nombre;
                    nodeC.Tag = (DatoNodoPass)carp;
                    nodeC.ImageIndex = carpeta;
                    nodeC.SelectedImageIndex = carpeta;
                    nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
        }

        /// <summary>
        /// Metodo para añadir nodos contraseña
        /// </summary>
        /// <param name="node"> TreeNode padre </param>
        private void anadirNodosContrasena_v2(TreeNode node)
        {
            DatoNodoPass nodo = (DatoNodoPass)node.Tag;

           // if (nodo.Level == TreeLevelContras.Usario && nodo.id==-3)//contraseñasCompartidas
            if (nodo.Level == TreeLevelContras.Compartida )//contraseñasCompartidas
            {
                List<DatoNodoPass> pasw = datosCompartidos.Where(x => x.idPadre == nodo.id && x.Level == TreeLevelContras.ComPass && x != (DatoNodoPass)node.Tag).ToList();
                TreeNode nodeC;
                foreach (DatoNodoPass psw in pasw)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = psw.Nombre;
                    nodeC.Name = psw.Nombre;
                    nodeC.Tag = (DatoNodoPass)psw;
                    nodeC.ImageIndex = pass;
                    nodeC.SelectedImageIndex = pass;
                    //nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
            else if (nodo.Level == TreeLevelContras.ComCarpeta || nodo.Level == TreeLevelContras.ComSubCarpeta)
            {
                List<DatoNodoPass> pasw = datosCompartidos.Where(x => x.idPadre == nodo.id && x.Level == TreeLevelContras.ComPass && x != (DatoNodoPass)node.Tag).ToList();

                TreeNode nodeC;
                foreach (DatoNodoPass psw in pasw)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = psw.Nombre;
                    nodeC.Name = psw.Nombre;
                    nodeC.Tag = (DatoNodoPass)psw;
                    nodeC.ImageIndex = pass;
                    nodeC.SelectedImageIndex = pass;
                    //nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
            else if (nodo.Level == TreeLevelContras.Usuario)
            {
                List<DatoNodoPass> pasw = datos.Where(x => x.fkIdUsuario == nodo.id && x.Level == TreeLevelContras.Pass && x != (DatoNodoPass)node.Tag).ToList();
                TreeNode nodeC;
                foreach (DatoNodoPass psw in pasw)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = psw.Nombre;
                    nodeC.Name = psw.Nombre;
                    nodeC.Tag = (DatoNodoPass)psw;
                    nodeC.ImageIndex = pass;
                    nodeC.SelectedImageIndex = pass;
                    //nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
            else if (nodo.Level == TreeLevelContras.Carpeta || nodo.Level == TreeLevelContras.SubCarpetas)
            {
                List<DatoNodoPass> pasw = datos.Where(x => x.idPadre == nodo.id && x.Level == TreeLevelContras.Pass && x != (DatoNodoPass)node.Tag).ToList();

                TreeNode nodeC;
                foreach (DatoNodoPass psw in pasw)
                {
                    nodeC = new TreeNode();

                    nodeC.Text = psw.Nombre;
                    nodeC.Name = psw.Nombre;
                    nodeC.Tag = (DatoNodoPass)psw;
                    nodeC.ImageIndex = pass;
                    nodeC.SelectedImageIndex = pass;
                    //nodeC.Nodes.Add("");

                    node.Nodes.Add(nodeC);
                }
            }
        }

        /// <summary>
        /// Metodo para generar el arbol
        /// </summary>
        private void generarArbolContrasenas()
        {
            updateData();

            tsbContrasenas.BeginUpdate();
            tsbContrasenas.Nodes.Clear();

            DatoNodoPass nodo = data.FirstOrDefault(x => x.id == Globales.GetUsuarioActual().idUsuario && x.Nombre == Globales.GetUsuarioActual().nombre && x.Level == TreeLevelContras.Usuario);
            TreeNode tNode = new TreeNode();

            tNode.Name = nodo.Nombre;
            tNode.Tag = (DatoNodoPass)nodo;
            tNode.Text = nodo.Nombre;
            tNode.Nodes.Add("");


            tsbContrasenas.Nodes.Add(tNode);
            anadirNodosCarpeta(tNode);
            anadirNodosContrasena(tNode);


            tsbContrasenas.EndUpdate();
        }

        /// <summary>
        /// Metodo para añadir nodos carpeta
        /// </summary>
        /// <param name="node"> TreeNode padre </param>
        private void anadirNodosCarpeta(TreeNode node)
        {
            DatoNodoPass nodo = (DatoNodoPass)node.Tag;

            List<DatoNodoPass> carpetas = data.Where(x => x.idPadre == nodo.id && x.Level == TreeLevelContras.Carpeta && x != (DatoNodoPass)node.Tag).ToList();

            TreeNode nodeC;
            foreach (DatoNodoPass carp in carpetas)
            {
                nodeC = new TreeNode();

                nodeC.Text = carp.Nombre;
                nodeC.Name = carp.Nombre;
                nodeC.Tag = (DatoNodoPass)carp;
                nodeC.Nodes.Add("");

                node.Nodes.Add(nodeC);
            }
        }

        /// <summary>
        /// Metodo para añadir nodos contraseña
        /// </summary>
        /// <param name="node"> TreeNode padre </param>
        private void anadirNodosContrasena(TreeNode node)
        {
            DatoNodoPass nodo = (DatoNodoPass)node.Tag;

            if (node.Name == Globales.GetUsuarioActual().nombre && nodo.id == Globales.GetUsuarioActual().idUsuario)
            {
                List<DatoNodoPass> contrasenas = data.Where(x => x.idPadre == null && x.Level == TreeLevelContras.Pass).ToList();

                TreeNode nodePass;
                foreach (DatoNodoPass cont in contrasenas)
                {
                    nodePass = new TreeNode();

                    nodePass.Text = cont.Nombre;
                    nodePass.Name = cont.Nombre;
                    nodePass.Tag = (DatoNodoPass)cont;
                    nodePass.Nodes.Add("");

                    node.Nodes.Add(nodePass);
                }
            }
            else
            {
                List<DatoNodoPass> contrasenas = data.Where(x => x.idPadre == nodo.id && x.Level == TreeLevelContras.Pass).ToList();

                TreeNode nodePass;
                foreach (DatoNodoPass cont in contrasenas)
                {
                    nodePass = new TreeNode();

                    nodePass.Text = cont.Nombre;
                    nodePass.Name = cont.Nombre;
                    nodePass.Tag = (DatoNodoPass)cont;
                    nodePass.Nodes.Add("");

                    node.Nodes.Add(nodePass);
                }
            }
        }


        /// <summary>
        /// Metodo para actualizar los datos para generar el arbol
        /// </summary>
        private void updateData()
        {
            data = new List<DatoNodoPass>();
            lContrasenas = gContrasenas.getContrasenasByUsuario(Globales.GetUsuarioActual().idUsuario);
            lCarpetas = gCarpetasContrasenas.getCarpetasContrasenasByUser(Globales.GetUsuarioActual().idUsuario);
            DatoNodoPass item = new DatoNodoPass();

            //Añadir el usuario a la lista
            item.Nombre = Globales.GetUsuarioActual().nombre;
            item.id = Globales.GetUsuarioActual().idUsuario;
            item.Level = TreeLevelContras.Usuario;

            data.Add(item);


            // Añadir las contraseñas a la lista
            foreach (contrasenas pswd in lContrasenas)
            {
                item = new DatoNodoPass();

                item.id = pswd.idContrasena;
                item.Nombre = pswd.nombre;

                
                item.idPadre = pswd.fk_idCarpeta;

                item.Level = TreeLevelContras.Pass;

                data.Add(item);
            }


            // Añadir las carpetas a la lista
            foreach (carpetas_contrasenas carpeta in lCarpetas)
            {
                item = new DatoNodoPass();

                item.id = carpeta.idCarpeta;
                item.Nombre = carpeta.nombre;

                if (carpeta.fk_idCarpetaPadre == null)
                {
                    item.idPadre = carpeta.fk_idUsuario;
                    item.Level = TreeLevelContras.Carpeta;
                }
                else
                {
                    item.idPadre = carpeta.fk_idCarpetaPadre;
                    item.Level = TreeLevelContras.SubCarpetas;
                }

                data.Add(item);
            }
        }

        /// <summary>
        /// Evento para expandir nodos
        /// </summary>
        private void tsbContrasenas_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            /*if (!cargando)
            {*/
                tsbContrasenas.BeginUpdate();


                TreeNode node = e.Node;
                node.Nodes.Clear();

                AdministrarExpandidos(node, true);

                /* anadirNodosCarpeta(node);
                 anadirNodosContrasena(node);*/
                anadirNodosCarpeta_v2(node);
                anadirNodosContrasena_v2(node);

                tsbContrasenas.EndUpdate();
           // }
        }

        private void tsbContrasenas_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (!cargando)
            {
                TreeNode node = e.Node;

                AdministrarExpandidos(node, false);
            }
        }

        private void AdministrarExpandidos(TreeNode node,bool expandir)
        {
            DatoNodoPass nodoSel = ((DatoNodoPass)node.Tag);

            if (expandir && !nodosExpandidos.Exists(x=>x.id==nodoSel.id && x.Level==nodoSel.Level))
            {
                nodosExpandidos.Add(nodoSel);
            }
            else if (!expandir && nodosExpandidos.Exists(x => x.id == nodoSel.id && x.Level == nodoSel.Level))
            {
                nodosExpandidos.Remove(nodosExpandidos.First(x => x.id == nodoSel.id && x.Level == nodoSel.Level));
            }


        }

        #endregion

        #region Eventos Tool Strip

        // Añadir carpeta
        private void tsbAddCarpeta_Click(object sender, EventArgs e)
        {
            DatoNodoPass nodo = getNodoActual_v2();
            if (nodo.Level == TreeLevelContras.Carpeta || nodo.Level == TreeLevelContras.SubCarpetas)
            {
                frmAddCarpeta frmAdd = new frmAddCarpeta(nodo.id, false, false);
                frmAdd.actualizarArbol += generarArbolContrasenas_v2;
                frmAdd.ShowDialog();
            }
            else
            {
                frmAddCarpeta frmAdd = new frmAddCarpeta(null, false, false);
                frmAdd.actualizarArbol += generarArbolContrasenas_v2;
                frmAdd.ShowDialog();
            }

        }

        // Modificar carpeta
        private void tsbModCarpeta_Click(object sender, EventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

            if (nodo.Level == TreeLevelContras.Carpeta)
            {
                frmAddCarpeta frmAdd = new frmAddCarpeta(nodo.id, true, false);
                frmAdd.Text = "Modificar nombre carpeta";
                frmAdd.actualizarArbol += generarArbolContrasenas_v2;
                frmAdd.ShowDialog();
            }
        }

        // Borrar carpeta
        private void tsbDellCarpeta_Click(object sender, EventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

            if (nodo.Level == TreeLevelContras.Carpeta)
            {
                carpetas_contrasenas del = gCarpetasContrasenas.getCarpetasContrasenasByIDCarpeta(nodo.id);

                gCarpetasContrasenas.deleteCarpetasContrasenas(del);

                Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se ha borrado la carpeta", "Borrar carpeta", 1);
                generarArbolContrasenas_v2();
            }
        }



        // Añadir contraseña
        private void tsbAddContrasena_Click(object sender, EventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

           if (nodo.Level == TreeLevelContras.Pass && nodo.idPadre != null)
            {
                //frmContrasena contrasena = new frmContrasena((int)nodo.idPadre);
                //contrasena.ShowDialog();

                cPassword pass = new cPassword((int)nodo.idPadre);
                pass.actualizarArbol += generarArbolContrasenas_v2;
                pass.CerrarVentana += Pass_CerrarVentana;
                C_CargarPassword(pass, "Nueva Password");
            }
           else
            {
                //frmContrasena contrasena = new frmContrasena(nodo.id);
                //contrasena.actualizarArbol += generarArbolContrasenas_v2;
                //contrasena.ShowDialog();


                cPassword pass = new cPassword(nodo.id);
                pass.CerrarVentana += Pass_CerrarVentana;
                pass.actualizarArbol += generarArbolContrasenas_v2;
                C_CargarPassword(pass, "Nueva Password");
            }
        }

        private void Pass_CerrarVentana(string nombrePassword)
        {
            int pageIndice = -1;
            for (int i = 0; i < tabPasswords.TabPages.Count; i++)
            {
                if (tabPasswords.TabPages[i].Tag.ToString() == nombrePassword)
                {
                    pageIndice = i;
                    break;
                }
            }
            if (pageIndice >= 0)
            {
                tabPasswords.TabPages[pageIndice].Controls.Clear();
                tabPasswords.TabPages.Remove(tabPasswords.TabPages[pageIndice]);
            }
        }


        // Modificar contraseña
        private void tsbModContrasena_Click(object sender, EventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

            if (nodo.Level == TreeLevelContras.Pass)
            {
                //frmContrasena contrasena = new frmContrasena(nodo.id, true);
                //contrasena.actualizarArbol += generarArbolContrasenas_v2;
                //contrasena.ShowDialog();

                cPassword pass = new cPassword(nodo.id, true);
                pass.actualizarArbol += generarArbolContrasenas_v2;
                pass.CerrarVentana += Pass_CerrarVentana;
                C_CargarPassword(pass, nodo.Nombre);
            }
        }

        // Borrar contraseña
        private void tsbDellContrasena_Click(object sender, EventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

            if (nodo.Level == TreeLevelContras.Pass)
            {
                contrasenas pass = gContrasenas.getContrasenasByID(nodo.id);
                gContrasenas.deleteContrasenas(pass);

                generarArbolContrasenas_v2();
            }
        }

        #endregion

        #region Otros metodos

        /// <summary>
        /// Metodo para obtener el nodo seleccionado del arbol
        /// </summary>
        /// <returns> Nodo seleccionado </returns>
        private TreeNode getNodoActual()
        {
            return tsbContrasenas.SelectedNode;
        }
        /// <summary>
        /// Metodo para obtener el nodo seleccionado del arbol
        /// </summary>
        /// <returns> Nodo seleccionado </returns>
        private DatoNodoPass getNodoActual_v2()
        {
            return (DatoNodoPass)tsbContrasenas.SelectedNode.Tag;
        }

        #endregion

        private void tsbContrasenas_DoubleClick(object sender, EventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

            contrasenas pass = gContrasenas.getContrasenasByID(nodo.id);

            Clipboard.SetText(pass.contrasena.DecryptAES());

            Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se ha copiado la contraseña al portapapeles", "Contraseña copiada", 1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            generarArbolContrasenas_v2();
        }

        
        private void C_CargarPassword(cPassword pass, string NombrePassword)
        {
            int pageIndice = -1;
            for (int i = 0; i < tabPasswords.TabPages.Count; i++)
            {
                if (tabPasswords.TabPages[i].Tag.ToString() == NombrePassword)
                {
                    pageIndice = i;
                    break;
                }
            }
            if (pageIndice < 0)
            {
                //TabPage tb = new TabPage(Control);
                TabPage tb = new TabPage();
                tb.Text = NombrePassword;
                tb.Tag = NombrePassword;

                pass.Dock = DockStyle.Fill;

                tb.Controls.Add(pass);
                tabPasswords.TabPages.Add(tb);
                tabPasswords.SelectedTab = tabPasswords.TabPages[tabPasswords.TabPages.Count - 1];
            }
            else
            {
                tabPasswords.TabPages[pageIndice].Controls.Clear();
                tabPasswords.TabPages[pageIndice].Text = NombrePassword;
                pass.Dock = DockStyle.Fill;
                tabPasswords.TabPages[pageIndice].Controls.Add(pass);
                tabPasswords.SelectedTab = tabPasswords.TabPages[pageIndice];
            }

        }

      
        private void cMenuArbol_Opening(object sender, CancelEventArgs e)
        {
            DatoNodoPass nodo = (DatoNodoPass)getNodoActual().Tag;

            if (nodo.Level == TreeLevelContras.Pass)
            {
                //cMenuArbol.Items.Clear();

                //ToolStripMenuItem t = new ToolStripMenuItem();
                //t.Text = "Modificar Contraseña";
                //t.Name = "Modificar Contraseña";
                //t.Click += tsbModContrasena_Click;

                //cMenuArbol.Items.Add(t); cMenuArbol.Refresh(); cMenuArbol.Update();
                cMenuArbol.Items["miModificarContraseña"].Visible = true;
                cMenuArbol.Items["miModificarCarpeta"].Visible = false;
            }

            else if (nodo.Level == TreeLevelContras.Carpeta ||
                nodo.Level == TreeLevelContras.SubCarpetas)
            {
                //cMenuArbol.Items.Clear();

                //ToolStripMenuItem t = new ToolStripMenuItem();
                //t.Text = "Modificar Carpeta";
                //t.Name = "Modificar Carpeta";
                //t.Click += tsbModCarpeta_Click;

                //cMenuArbol.Items.Add(t); cMenuArbol.Refresh(); cMenuArbol.Update(); 
                cMenuArbol.Items["miModificarContraseña"].Visible = false;
                cMenuArbol.Items["miModificarCarpeta"].Visible = true;
            }
            else
            {
                //cMenuArbol.Items.Clear(); cMenuArbol.Refresh(); cMenuArbol.Update();
                cMenuArbol.Items["miModificarContraseña"].Visible = false;
                cMenuArbol.Items["miModificarCarpeta"].Visible = false;
            }
        }

        private void tsbContrasenas_Click(object sender, EventArgs e)
        {

        }

        private void tsbContrasenas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Display context menu for eg:
                cMenuArbol.Show();
            }
        }

        private void tsbContrasenas_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tsbContrasenas.SelectedNode = e.Node;
            }
        }
    }
}
