using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.DM;
using MiniGestorCodigo.BL;
using Utilities.Extensions;
using Utilities.Controls.Leyenda;

namespace MiniGestorCodigo.UI.GestorContrasenas
{
    public partial class cPassword : UserControl
    {        
        #region Variables
        private bool contrasenaVisible = false;
        private int idContrasena = -1;
        private int? idPadre;
        private bool updateArbolContrasenas = true;
        private bool favorita;
        public event EventGuardado actualizarArbol;
        public delegate void EventGuardado();

        public event EventCerrar CerrarVentana;
        public delegate void EventCerrar(string nombrePassword);

        public List<departamentos> departamentos;
        public List<usuarios> usuarios;
        public List<Grupo> grupos;
        public List<PasswordGrupo> PasswordGrupo;
        public List<PasswordUsuario> PasswordUsuario;
        public List<PasswordDepartamento> PasswordDepar;
        public string nombreAntiguo;
        #endregion

        #region Controles

        public Utilities.Controls.Leyenda.Menu.MenuButton btCompartirDepartamentos;
        private List<departamentofiltro> filtroDepartamentos;
        private bool abiertofiltroDepartamentos;

        public Utilities.Controls.Leyenda.Menu.MenuButton btCompartirUsuarios;
        private List<Usuariofiltro> filtroUsuarios;
        private bool abiertofiltroUsuarios;

        public Utilities.Controls.Leyenda.Menu.MenuButton btCompartirGrupos;
        private List<Grupofiltro> filtroGrupos;
        private bool abiertofiltroGrupos;
        #endregion

        #region Constructores

        public cPassword(int idPadre)
        {
            InitializeComponent();

            this.idPadre = idPadre;

            List<PasswordGrupo> PasswordGrupo = new List<PasswordGrupo>();
            List<PasswordUsuario> PasswordUsuario = new List<PasswordUsuario>();
            List<PasswordDepartamento> PasswordDepar = new List<PasswordDepartamento>();

            txtContrasena.UseSystemPasswordChar = true;

            nombreAntiguo = "Nueva Password";

            CrearBTDepartamentos();
            CrearBTUsuarios();
            CrearBTGrupos();
            btnExit.Text = "Cancelar";
        }


        public cPassword(int idContrasena, bool mod)
        {
            InitializeComponent();

            // Ocultar contraseña
            txtContrasena.UseSystemPasswordChar = true;

            //Rellenar campos


            PasswordGrupo = new List<PasswordGrupo>();
            PasswordUsuario = new List<PasswordUsuario>();
            PasswordDepar = new List<PasswordDepartamento>();

            this.idContrasena = idContrasena;

            if (idContrasena != -1)
            {
                contrasenas pass = gContrasenas.getContrasenasByID(idContrasena);
                nombreAntiguo = pass.nombre;

                txtContrasena.Text = pass.contrasena.DecryptAES();
                txtNombreContrasena.Text = pass.nombre;
                txtUsuario.Text = pass.usuario;
                txtDescripcion.Text = pass.descripcion;


                GestionFavorito(pass.Favorita.Value);

                if (pass.fk_idUsuario != Globales.usuarioActual.idUsuario)
                {
                    btnAceptar.Enabled = false;
                    btnExit.Enabled = false;
                }
                PasswordGrupo = gContrasenas.getPasswordGrupo(idContrasena);
                PasswordUsuario = gContrasenas.getPasswordUsuario(idContrasena);
                PasswordDepar = gContrasenas.getPasswordDepar(idContrasena);


                CrearBTDepartamentos();
                CrearBTUsuarios();
                CrearBTGrupos();

            }
            btnExit.Text = "Cerrar";

            GestionarVisibilidad(mod);
        }

       

        // Constructor para añadir contraseñas desde el context menu del icono de la app en la barra de notificaciones
        public cPassword()
        {
            InitializeComponent();
            updateArbolContrasenas = false;


            List<PasswordGrupo> PasswordGrupo = new List<PasswordGrupo>();
            List<PasswordUsuario> PasswordUsuario = new List<PasswordUsuario>();
            List<PasswordDepartamento> PasswordDepar = new List<PasswordDepartamento>();

            nombreAntiguo = "Nueva Password";

            CrearBTDepartamentos();
            CrearBTUsuarios();
            CrearBTGrupos();
            btnExit.Text = "Cancelar";
        }

        #endregion




        #region Eventos
        // Mostrar u ocultar contraseña
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            contrasenaVisible = !contrasenaVisible;

            txtContrasena.UseSystemPasswordChar = !contrasenaVisible;
            if (!contrasenaVisible)
            {
                this.btnMostrar.Image = global::MiniGestorCodigo.UI.Properties.Resources.visibilidad_1_;
            }
            else
            {
                this.btnMostrar.Image = global::MiniGestorCodigo.UI.Properties.Resources.ocultar_2_;
            }

        }


        // Guardar contraseña
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (idContrasena == -1)
            {
                contrasenas pass = new contrasenas();

                pass.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                pass.nombre = txtNombreContrasena.Text;
                pass.fk_idCarpeta = idPadre;
                pass.contrasena = txtContrasena.Text.EncryptAES();
                pass.usuario = txtUsuario.Text;
                pass.descripcion = txtDescripcion.Text;
                pass.Favorita = favorita;
                contrasenas c = gContrasenas.addContrasenas(pass);
                if (c.fk_idUsuario == Globales.usuarioActual.idUsuario)
                {
                    gContrasenas.UpdatePasswordDepar(c.idContrasena, filtroDepartamentos.Where(x => x.activado == true).ToList().Select(x => x.id).ToList());
                    gContrasenas.UpdatePasswordGrupo(c.idContrasena, filtroGrupos.Where(x => x.activado == true).ToList().Select(x => x.id).ToList());
                    gContrasenas.UpdatePasswordUsuario(c.idContrasena, filtroUsuarios.Where(x => x.activado == true).ToList().Select(x => x.id).ToList());
                }
                if (updateArbolContrasenas)
                    actualizarArbol?.Invoke();
            }
            else
            {
                contrasenas pass = gContrasenas.getContrasenasByID(idContrasena);

                pass.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                pass.nombre = txtNombreContrasena.Text;
                pass.contrasena = txtContrasena.Text.EncryptAES();
                pass.usuario = txtUsuario.Text;
                pass.descripcion = txtDescripcion.Text;
                pass.Favorita = favorita;

                gContrasenas.updateContrasenas(pass);
                if (pass.fk_idUsuario == Globales.usuarioActual.idUsuario)
                {
                    gContrasenas.UpdatePasswordDepar(pass.idContrasena, filtroDepartamentos.Where(x => x.activado == true).ToList().Select(x => x.id).ToList());
                    gContrasenas.UpdatePasswordGrupo(pass.idContrasena, filtroGrupos.Where(x => x.activado == true).ToList().Select(x => x.id).ToList());
                    gContrasenas.UpdatePasswordUsuario(pass.idContrasena, filtroUsuarios.Where(x => x.activado == true).ToList().Select(x => x.id).ToList());
                }

                if (updateArbolContrasenas)
                    actualizarArbol?.Invoke();
            }

            //this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }


        private void GestionFavorito(bool pssFav)
        {
            favorita = pssFav;
            if (favorita)
            {
                this.btFavorita.Image = global::MiniGestorCodigo.UI.Properties.Resources.FavoritoSi;
            }
            else
            {
                this.btFavorita.Image = global::MiniGestorCodigo.UI.Properties.Resources.FavoritoNo;
            }
        }

        private void btFavorita_Click(object sender, EventArgs e)
        {
            if (favorita)
            {
                favorita = false;
                this.btFavorita.Image = global::MiniGestorCodigo.UI.Properties.Resources.FavoritoNo;
            }
            else
            {
                favorita = true;
                this.btFavorita.Image = global::MiniGestorCodigo.UI.Properties.Resources.FavoritoSi;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CerrarVentana?.Invoke(nombreAntiguo);
            //if (idContrasena==-1)
            //{
            //    CerrarVentana?.Invoke("Nueva Password");
            //}
            //else
            //{
            //    CerrarVentana?.Invoke(nombreAntiguo);
            //}
        }


        #endregion


        #region BtDepartamento

        private void CrearBTDepartamentos()
        {
            departamentos = gDepartamentos.getDepartamentos().OrderBy(x => x.nombreDepartamento).ToList();

            btCompartirDepartamentos = new Utilities.Controls.Leyenda.Menu.MenuButton();
            btCompartirDepartamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btCompartirDepartamentos.Image = global::MiniGestorCodigo.UI.Properties.Resources.grupo;
            btCompartirDepartamentos.Size = new System.Drawing.Size(29, 22);
            btCompartirDepartamentos.TextImageRelation = TextImageRelation.ImageBeforeText;// "Leyenda Adplanning";
            //btCompartirDepartamentos.Dock = DockStyle.Right;
            btCompartirDepartamentos.Location = new Point(369, 92);
            btCompartirDepartamentos.BringToFront();
            btCompartirDepartamentos.Click += btCompartirDepartamentos_Click;


            ContextMenuStrip menu = new ContextMenuStrip();
            filtroDepartamentos = new List<departamentofiltro>();

            for (int i = 0; i < departamentos.Count(); i++)
            {
                bool activopordefecto = false;
                if (idContrasena != -1)
                {
                    if (PasswordDepar.Exists(x => x.idDepartamento == departamentos[i].idDepartamento && x.idPassword == idContrasena))
                    {
                        activopordefecto = true;
                    }

                }
                Random rnd = new Random();
                int rndColor = rnd.Next() * departamentos[i].idDepartamento * -1;
                ToolStripCheck tch1 = new ToolStripCheck(
                    departamentos[i].nombreDepartamento,
                    //Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(-65536)),
                    Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(rndColor)),
                    departamentos[i].idDepartamento,
                    tch1ComparDepartamento_Click,
                    activopordefecto);
                menu.Items.Add(tch1);
                filtroDepartamentos.Add(new departamentofiltro { depart = departamentos[i].nombreDepartamento, activado = activopordefecto, id = departamentos[i].idDepartamento });
            }


            //System.Drawing.Color.FromArgb()


            menu.AutoClose = false;
            btCompartirDepartamentos.Menu = menu;
            this.Controls.Add(btCompartirDepartamentos);

        }

        private void tch1ComparDepartamento_Click(object sender, EventArgs e)
        {
            ActivarFiltroComparDepar(((ToolStripCheck)sender).ID);
        }

        private void ActivarFiltroComparDepar(int id)
        {
            if (filtroDepartamentos.HasContent())
            {
                //filtroDepartamentos[posicion].activado = filtroDepartamentos[posicion].activado ? false : true;
                filtroDepartamentos.First(x => x.id == id).activado = filtroDepartamentos.First(x => x.id == id).activado ? false : true;
            }

        }
        private void btCompartirDepartamentos_Click(object sender, EventArgs e)
        {
            Utilities.Controls.Leyenda.Menu.MenuButton bt = sender as Utilities.Controls.Leyenda.Menu.MenuButton;
            //bt.Menu.IsDropDown
            if (bt.Menu.IsDropDown && abiertofiltroDepartamentos)
            {
                bt.Menu.Close();
                abiertofiltroDepartamentos = false;
            }
            else
            {
                abiertofiltroDepartamentos = true;
                bt.Menu.Show();
            }
        }

        public class departamentofiltro
        {
            public string depart { get; set; }
            public int id { get; set; }
            public bool activado { get; set; }
        }
        #endregion


        #region BtUsuarios

        private void CrearBTUsuarios()
        {
            usuarios = gUsuarios.getUsuarios().OrderBy(x => x.nombre).ToList();

            btCompartirUsuarios = new Utilities.Controls.Leyenda.Menu.MenuButton();
            btCompartirUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btCompartirUsuarios.Image = global::MiniGestorCodigo.UI.Properties.Resources.reunion;
            btCompartirUsuarios.Size = new System.Drawing.Size(29, 22);
            btCompartirUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;// "Leyenda Adplanning";
            //btCompartirUsuarios.Dock = DockStyle.Right;
            btCompartirUsuarios.Location = new Point(369, 129);
            btCompartirUsuarios.BringToFront();
            btCompartirUsuarios.Click += btCompartirUsuarios_Click;


            ContextMenuStrip menu = new ContextMenuStrip();
            filtroUsuarios = new List<Usuariofiltro>();

            for (int i = 0; i < usuarios.Count(); i++)
            {

                if (Globales.GetUsuarioActual().idUsuario != usuarios[i].idUsuario)
                {

                    bool activopordefecto = false;
                    if (idContrasena != -1)
                    {
                        if (PasswordUsuario.Exists(x => x.idUsuario == usuarios[i].idUsuario && x.idPassword == idContrasena))
                        {
                            activopordefecto = true;
                        }

                    }
                    Random rnd = new Random();
                    int rndColor = rnd.Next() * usuarios[i].idUsuario * -1;
                    ToolStripCheck tch1 = new ToolStripCheck(
                        usuarios[i].nombre,
                        //Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(-65536)),
                        Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(rndColor)),
                        usuarios[i].idUsuario,
                        tch1ComparUsuario_Click,
                        activopordefecto);
                    menu.Items.Add(tch1);
                    filtroUsuarios.Add(new Usuariofiltro { user = usuarios[i].nombre, activado = activopordefecto, id = usuarios[i].idUsuario });
                }
            }


            //System.Drawing.Color.FromArgb()


            menu.AutoClose = false;
            btCompartirUsuarios.Menu = menu;
            this.Controls.Add(btCompartirUsuarios);

        }

        private void tch1ComparUsuario_Click(object sender, EventArgs e)
        {
            ActivarFiltroComparUser(((ToolStripCheck)sender).ID);
        }

        private void ActivarFiltroComparUser(int id)
        {
            if (filtroUsuarios.HasContent())
            {
                //filtroUsuarios.First(x=>x.id==id).activado = filtroUsuarios[posicion].activado ? false : true;
                filtroUsuarios.First(x => x.id == id).activado = filtroUsuarios.First(x => x.id == id).activado ? false : true;
            }

        }
        private void btCompartirUsuarios_Click(object sender, EventArgs e)
        {
            Utilities.Controls.Leyenda.Menu.MenuButton bt = sender as Utilities.Controls.Leyenda.Menu.MenuButton;
            //bt.Menu.IsDropDown
            if (bt.Menu.IsDropDown && abiertofiltroUsuarios)
            {
                bt.Menu.Close();
                abiertofiltroUsuarios = false;
            }
            else
            {
                abiertofiltroUsuarios = true;
                bt.Menu.Show();
            }
        }

        public class Usuariofiltro
        {
            public string user { get; set; }
            public int id { get; set; }
            public bool activado { get; set; }
        }
        #endregion


        #region BtGrupos

        private void CrearBTGrupos()
        {
            grupos = gGrupos.getGrupos().OrderBy(x => x.NombreGrupo).ToList();

            btCompartirGrupos = new Utilities.Controls.Leyenda.Menu.MenuButton();
            btCompartirGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btCompartirGrupos.Image = global::MiniGestorCodigo.UI.Properties.Resources.usuarios_multiples_en_silueta;
            btCompartirGrupos.Size = new System.Drawing.Size(29, 22);
            btCompartirGrupos.TextImageRelation = TextImageRelation.ImageBeforeText;// "Leyenda Adplanning";
            //btCompartirGrupos.Dock = DockStyle.Right;
            btCompartirGrupos.Location = new Point(369, 152);
            btCompartirGrupos.BringToFront();
            btCompartirGrupos.Click += btCompartirGrupos_Click;


            ContextMenuStrip menu = new ContextMenuStrip();
            filtroGrupos = new List<Grupofiltro>();

            for (int i = 0; i < grupos.Count(); i++)
            {
                bool activopordefecto = false;
                if (idContrasena != -1)
                {
                    if (PasswordGrupo.Exists(x => x.idGrupo == grupos[i].idGrupo && x.idPassword == idContrasena))
                    {
                        activopordefecto = true;
                    }

                }
                Random rnd = new Random();
                int rndColor = rnd.Next() * grupos[i].idGrupo * -1;
                ToolStripCheck tch1 = new ToolStripCheck(
                    grupos[i].NombreGrupo,
                    //Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(-65536)),
                    Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(rndColor)),
                    grupos[i].idGrupo,
                    tch1ComparGrupo_Click,
                    activopordefecto);
                menu.Items.Add(tch1);
                filtroGrupos.Add(new Grupofiltro { grupo = grupos[i].NombreGrupo, activado = activopordefecto, id = grupos[i].idGrupo });

            }

            /*
            //System.Drawing.Color.FromArgb()
            */

            menu.AutoClose = false;
            btCompartirGrupos.Menu = menu;
            this.Controls.Add(btCompartirGrupos);

        }

        private void tch1ComparGrupo_Click(object sender, EventArgs e)
        {
            ActivarFiltroComparGroup(((ToolStripCheck)sender).ID);
        }

        private void ActivarFiltroComparGroup(int id)
        {
            if (filtroGrupos.HasContent())
            {
                //filtroGrupos[posicion].activado = filtroGrupos[posicion].activado ? false : true;
                filtroGrupos.First(x => x.id == id).activado = filtroGrupos.First(x => x.id == id).activado ? false : true;
            }

        }
        private void btCompartirGrupos_Click(object sender, EventArgs e)
        {
            Utilities.Controls.Leyenda.Menu.MenuButton bt = sender as Utilities.Controls.Leyenda.Menu.MenuButton;
            //bt.Menu.IsDropDown
            if (bt.Menu.IsDropDown && abiertofiltroGrupos)
            {
                bt.Menu.Close();
                abiertofiltroGrupos = false;
            }
            else
            {
                abiertofiltroGrupos = true;
                bt.Menu.Show();
            }
        }

        public class Grupofiltro
        {
            public string grupo { get; set; }
            public int id { get; set; }
            public bool activado { get; set; }
        }
        #endregion

        private void GestionarVisibilidad(bool mod)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = mod;
            }
            btnMostrar.Enabled = true;
        }
    }
}
