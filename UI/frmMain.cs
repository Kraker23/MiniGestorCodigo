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
using MiniGestorCodigo.UI.GestorGrupos;
using Utilities.Controls.HerramientaTextos;
using MiniGestorCodigo.UI.Herramientas.Controles;
using HerramientaMoverArchivos;
using MiniGestorCodigo.UI.GestorContrasenas;
using System.Diagnostics;

namespace MiniGestorCodigo.UI
{
    public partial class frmMain : Form
    {
        private bool cerrar = false;
        private bool visible = true;
        private Utilities.Controls.EditarImagen.frmCaptura frmCapturaPantalla= new Utilities.Controls.EditarImagen.frmCaptura();

        public frmMain()
        {
            InitializeComponent();

            cargarMenuIcono();
            tslUsuario.Text = Globales.usuarioActual.nombre;
            //this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //frmGestorCodigo frmPrograma = new frmGestorCodigo();
            //frmPrograma.MdiParent = this;
            //frmPrograma.Show();

            Form frm = null;

            GetFormularios(typeof(frmGestorCodigo)).ForEach(f =>
            {
                if (((frmGestorCodigo)f).partes == partesPrograma.Codigo) { frm = f; }
            });

            if (frm == null)
            {
                new frmGestorCodigo(partesPrograma.Codigo) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }

        private void tsbGestorNotas_Click(object sender, EventArgs e)
        {
            //frmNota nota = new frmNota();
            //frmGrestorNotas nota = new frmGrestorNotas();
            //nota.MdiParent = this;
            //nota.Show();

            Form frm = null;

            GetFormularios(typeof(frmGrestorNotas)).ForEach(f =>
            {
                if (((frmGrestorNotas)f).partes == partesPrograma.Notas) { frm = f; }
            });

            if (frm == null)
            {
                new frmGrestorNotas(partesPrograma.Notas) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }

        private void iconApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }


        #region Menu contextual

        #region carga datos

        private void cargarMenuIcono()
        {
            CargarNotasMenu();
            CargarContrasenasMenu();
            CargarHerramientasMenu();

            //Captura pantalla
            ((ToolStripMenuItem)cmsMenuIcono.Items["miCapturaPantalla"]).Click += CapturaPantallaClick;
            //Abrir / ver
            ((ToolStripMenuItem)cmsMenuIcono.Items["miAbrir"]).Click += AbrirClick;
            // Cerrar
            ((ToolStripMenuItem)cmsMenuIcono.Items["miCerrar"]).Click += CerrarClick;
            //Añadir nota
            ((ToolStripMenuItem)cmsMenuIcono.Items["miNuevaNota"]).Click += AddNotaItemClick;
            //Añadir contraseña
            ((ToolStripMenuItem)cmsMenuIcono.Items["miNuevaContrasena"]).Click += CrearNuevaContrasena;


        }

        /// <summary>
        /// Actualizar lista de notas en el menu contextual
        /// </summary>
        private void CargarNotasMenu()
        {
            List<notas> lNotas = gNotas.getNotaByUser(Globales.GetUsuarioActual().idUsuario);
            ((ToolStripMenuItem)cmsMenuIcono.Items["miNotas"]).DropDownItems.Clear();
            foreach (notas nota in lNotas)
            {
                ToolStripMenuItem iNota = new ToolStripMenuItem();
                iNota.Name = nota.titulo + String.Format(" ({0})", nota.idNota);
                iNota.Text = nota.titulo;
                iNota.Tag = nota;

                iNota.Click += NotaItemClick;

                ((ToolStripMenuItem)cmsMenuIcono.Items["miNotas"]).DropDownItems.Add(iNota);
            }

                    
        }

        private void CargarContrasenasMenu()
        {
            List<contrasenas> contrasenas = gContrasenas.getContrasenasByUsuario(Globales.GetUsuarioActual().idUsuario);

            ToolStripMenuItem iPass;
            ((ToolStripMenuItem)cmsMenuIcono.Items["miContrasenas"]).DropDownItems.Clear();
            foreach (contrasenas pass in contrasenas.Where(x=>x.Favorita==true))
            {
                iPass = new ToolStripMenuItem();
                iPass.Name = pass.nombre;
                iPass.Text = pass.nombre;
                iPass.Tag = pass;

                iPass.Click += copiarContrasenaPortapapeles;

                ((ToolStripMenuItem)cmsMenuIcono.Items["miContrasenas"]).DropDownItems.Add(iPass);
            }
        }

        private void CargarHerramientasMenu()
        {
            ((ToolStripMenuItem)cmsMenuIcono.Items["miHerramientas"]).DropDownItems.Clear();
            //Separador Texto
            ToolStripMenuItem item = new ToolStripMenuItem();
            
            item.Name = "Separador Texto";
            item.Text = "Separador Texto";

            item.Click += AbrirSeparadorTexto;


            ((ToolStripMenuItem)cmsMenuIcono.Items["miHerramientas"]).DropDownItems.Add(item);


            //MoverArchivos
            ToolStripMenuItem MoverArchivos = new ToolStripMenuItem();

            MoverArchivos.Name = "Mover Archivos";
            MoverArchivos.Text = "Mover Archivos";

            MoverArchivos.Click += AbrirMoverArchivos;
            ((ToolStripMenuItem)cmsMenuIcono.Items["miHerramientas"]).DropDownItems.Add(MoverArchivos);


            //Encriptar Password
            ToolStripMenuItem encriptar = new ToolStripMenuItem();

            encriptar.Name = "Encriptar Password";
            encriptar.Text = "Encriptar Password";

            encriptar.Click += AbrirEncriptarPassword;
            ((ToolStripMenuItem)cmsMenuIcono.Items["miHerramientas"]).DropDownItems.Add(encriptar);


            

            //Herramientas Externas
            ((ToolStripMenuItem)cmsMenuIcono.Items["miHerramientas"]).DropDownItems.Add(CargarHerramientasExternas());

            //mniExternas.DropDownItems.Clear();
            //mniExternas.DropDownItems.Add(CargarHerramientasExternas());
            //tsddHerramientas.DropDownItems.Add(CargarHerramientasExternas());



            tsddHerramientas.DropDownItems.Clear();

            this.tsddHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separadorDeTextoToolStripMenuItem,
            this.mniMoverArchivos,
            this.mniEncriptarPassword,
            CargarHerramientasExternas()});

        }

        

        private ToolStripMenuItem CargarHerramientasExternas()
        {
            ToolStripMenuItem items = new ToolStripMenuItem();

            items.Name = "Herramientas Externas";
            items.Text = "Herramientas Externas";

            //Nueva HErramienta Externa 
            ToolStripMenuItem hext = new ToolStripMenuItem();

            hext.Name = "Nueva Herramienta Externa";
            hext.Text = "Nueva Herramienta Externa";

            hext.Click += AbrirNuevaHerramientaExterna;
            items.DropDownItems.Add(hext);


            List<HerramientaExterna> externas = gHerramientaExterna.getHerramientaExternaByIdUser(Globales.usuarioActual.idUsuario, Environment.UserName);
            if (externas.HasContent())
            {
                foreach (HerramientaExterna item in externas)
                {
                    ToolStripMenuItem externa = new ToolStripMenuItem();

                    externa.Name = item.HerramientaExterna1;
                    externa.Text = item.HerramientaExterna1;
                    externa.Tag = item.PathHerramienta;
                    externa.Click += AbrirHerramientaExterna;

                    ToolStripMenuItem modificar = new ToolStripMenuItem();
                    modificar.Name = "Modificar";
                    modificar.Text = "Modificar";
                    modificar.Tag = item.idHerramientaExterna.ToString();
                    modificar.Click += AbrirModificarHerramientaExterna;
                    externa.DropDownItems.Add(modificar);
                    items.DropDownItems.Add(externa);
                }
                return items;
            }
            else
            {
                return items;
            }
        }

        private void AbrirHerramientaExterna(object sender, EventArgs e)
        {
            Process.Start(((ToolStripMenuItem)sender).Tag.ToString());
        }

        private void AbrirModificarHerramientaExterna(object sender, EventArgs e)
        {
            frmHerramientaExterna frm = new frmHerramientaExterna(partesPrograma.H_Externas,int.Parse(((ToolStripMenuItem)sender).Tag.ToString()));
            frm.Dock = DockStyle.Fill;
            frm.actualizarControles += frmHerramientaExterna_actualizarControles;
            frm.Show();
        }

        private void AbrirNuevaHerramientaExterna(object sender, EventArgs e)
        {
            Form frmAux = null;
            GetFormulariosGeneral(typeof(frmHerramientaExterna)).ForEach(f =>
            {
                if (((frmHerramientaExterna)f).partes == partesPrograma.H_Externas) { frmAux = f; }
            });

            if (frmAux == null)
            {
                //new frmMoverArchivos(partesPrograma.H_MoverArchivos) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
                frmHerramientaExterna frm = new frmHerramientaExterna(partesPrograma.H_Externas);
                frm.Dock = DockStyle.Fill;
                frm.actualizarControles += frmHerramientaExterna_actualizarControles;
                frm.Show();
            }
            else
            {
                frmAux.WindowState = FormWindowState.Normal;
                frmAux.Activate();
            }
        }

        private void frmHerramientaExterna_actualizarControles()
        {
            CargarHerramientasMenu();
        }

        private void AbrirEncriptarPassword(object sender, EventArgs e)
        {
            Form frmAux = null;
            GetFormulariosGeneral(typeof(frmEncriptarPassword)).ForEach(f =>
            {
                if (((frmEncriptarPassword)f).partes == partesPrograma.H_EncriptarPassword) { frmAux = f; }
            });

            if (frmAux == null)
            {
                //new frmMoverArchivos(partesPrograma.H_MoverArchivos) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
                frmEncriptarPassword frm = new frmEncriptarPassword();
                frm.Dock = DockStyle.Fill;
                frm.Size = new Size(739, 360);
                frm.Show();
            }
            else
            {
                frmAux.WindowState = FormWindowState.Normal;
                frmAux.Activate();
            }
        }

        private void AbrirMoverArchivos(object sender, EventArgs e)
        {

            Form frmAux = null;
            GetFormulariosGeneral(typeof(frmMoverArchivos)).ForEach(f =>
            {
                if (((frmMoverArchivos)f).partes == partesPrograma.H_MoverArchivos) { frmAux = f; }
            });

            if (frmAux == null)
            {
                //new frmMoverArchivos(partesPrograma.H_MoverArchivos) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
                frmMoverArchivos frmMoverArchivos = new frmMoverArchivos();
                frmMoverArchivos.Dock = DockStyle.Fill;
                frmMoverArchivos.Size = new Size(739, 360);
                frmMoverArchivos.Show();
            }
            else
            {
                frmAux.WindowState = FormWindowState.Normal;
                frmAux.Activate();
            }
        }

        private void AbrirSeparadorTexto(object sender, EventArgs e)
        {
            Form frmAux = null;
            GetFormulariosGeneral(typeof(frmMoverArchivos)).ForEach(f =>
            {
                if (((frmMoverArchivos)f).partes == partesPrograma.H_MoverArchivos) { frmAux = f; }
            });

            if (frmAux == null)
            {
                frmSeparadorTexto st = new frmSeparadorTexto();
                st.Dock = DockStyle.Fill;
                st.Size = new Size(700, 300);
                st.Show();
            }
            else
            {
                frmAux.WindowState = FormWindowState.Normal;
                frmAux.Activate();
            }
        }

        private void CrearNuevaContrasena(object sender, EventArgs e)
        {
            Form f = new Form();
            cPassword c = new cPassword();
            f.Dock = DockStyle.Fill;
            f.Controls.Add(c);
            f.Size = new Size(429, 389);
            f.Text = "Nueva contraseña";
            f.ShowDialog();
            //frmContrasena frm = new frmContrasena();
            //frm.ShowDialog();
        }

        private void copiarContrasenaPortapapeles(object sender, EventArgs e)
        {
            ToolStripItem send = (ToolStripItem)sender;
            contrasenas pass = (contrasenas)send.Tag;

            Clipboard.SetText(pass.contrasena.DecryptAES());
            Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se copiado la contraseña al portapapeles", "Contraseña copiada", 1);
        }

        #endregion

        #region eventos

        /// <summary>
        /// EventHandler al seleccionar una nota de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NotaItemClick(object sender, EventArgs e)
        {

            notas nota = (notas)((ToolStripMenuItem)sender).Tag;

            frmNota fNota = new frmNota(nota);
            fNota.ShowDialog();
        }

        /// <summary>
        /// EventHandler para añadir una nueva nota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AddNotaItemClick(object sender, EventArgs e)
        {

            frmNota fNota = new frmNota();
            fNota.ShowDialog();
        }

        /// <summary>
        /// Hacer el formulario visible
        /// </summary>
        void AbrirClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            //this.Visible = true;

            visible = true;
            this.ShowInTaskbar = true;

        }

        /// <summary>
        /// Cerrar el programa
        /// </summary>
        void CerrarClick(object sender, EventArgs e) 
        {
            visible = false;
            cerrar = true;
            iconApp.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Realizar una captura de pantalla
        /// </summary>
        void CapturaPantallaClick(object sender, EventArgs e)
        {
            frmCapturaPantalla.CapturarPantallaCompleta();
            frmCapturaPantalla.Show();
        }

        #endregion

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
            {
                this.WindowState = FormWindowState.Minimized;

                visible = false;

                e.Cancel = true;
                this.ShowInTaskbar = false;
            }
        }

        private void tsbGestorUsuarios_Click(object sender, EventArgs e)
        {
            frmGestorUsuarios frmUsr = new frmGestorUsuarios();
            frmUsr.Dock = DockStyle.Fill;
            frmUsr.MdiParent = this;
            frmUsr.Show();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (!cerrar)
            {
                if (visible)
                    this.ShowInTaskbar = true;
                else
                    this.ShowInTaskbar = false;
            }

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //frmCorreo frmCorreos = new frmCorreo();
            //frmCorreos.MdiParent = this;
            //frmCorreos.Show();

            Form frm = null;

            GetFormularios(typeof(frmCorreo)).ForEach(f =>
            {
                if (((frmCorreo)f).partes == partesPrograma.Correo) { frm = f; }
            });

            if (frm == null)
            {
                new frmCorreo(partesPrograma.Correo) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }


        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                frmCapturaPantalla.CapturarPantallaCompleta();
                frmCapturaPantalla.Show();
            }
        }

        private void tsbGestorContrasenas_Click(object sender, EventArgs e)
        {
            //frmGestorContrasenas frmContrasenas = new frmGestorContrasenas();
            //frmContrasenas.MdiParent = this;
            //frmContrasenas.Show();

            Form frm = null;

            GetFormularios(typeof(frmGestorContrasenas)).ForEach(f =>
            {
                if (((frmGestorContrasenas)f).partes == partesPrograma.Contraseñas) { frm = f; }
            });

            if (frm == null)
            {
                new frmGestorContrasenas(partesPrograma.Contraseñas) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }

        private void iconApp_Click(object sender, EventArgs e)
        {
            CargarNotasMenu();
            CargarContrasenasMenu();
            CargarHerramientasMenu();
        }

        private void tsbGestorGrupos_Click(object sender, EventArgs e)
        {

            frmGestorGrupos frm = new frmGestorGrupos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbtCambiarUsuario_ButtonClick(object sender, EventArgs e)
        {
            frmLoggin frmlog = new frmLoggin();
            DialogResult r = frmlog.ShowDialog();
            if (r == DialogResult.OK)
            {
                ultimo_inicio last = new ultimo_inicio();

                last.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                last.idOrdenador = 0;
                last.nombreOrdenador = Environment.MachineName;

                gUltimoInicio.addUltimoInicio(last);

                tslUsuario.Text = Globales.usuarioActual.nombre;
            }
        }

        private void Frmlog_CambioUsuario()
        {
            throw new NotImplementedException();
        }

        private void separadorDeTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form frm = new Form();
            //SeparadorTexto st = new SeparadorTexto();
            //st.Dock = DockStyle.Fill;
            //frm.Size= new Size(700, 300);
            //frm.Controls.Add(st);
            //frm.MdiParent = this;
            //frm.Show();

            Form frm = null;

            GetFormularios(typeof(frmSeparadorTexto)).ForEach(f =>
            {
                if (((frmSeparadorTexto)f).partes == partesPrograma.H_SeparadorTexto) { frm = f; }
            });

            if (frm == null)
            {
                new frmSeparadorTexto(partesPrograma.H_SeparadorTexto) { MdiParent = this, WindowState = FormWindowState.Maximized }.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }

        private void miGestorGrupos_Click(object sender, EventArgs e)
        {
            //frmGestorGrupos frm = new frmGestorGrupos();
            //frm.Dock = DockStyle.Fill;
            //frm.MdiParent = this;
            //frm.Show();

            Form frm = null;

            GetFormularios(typeof(frmGestorGrupos)).ForEach(f =>
            {
                if (((frmGestorGrupos)f).partes == partesPrograma.PersonasGrupo) { frm = f; }
            });

            if (frm == null)
            {
                new frmGestorGrupos(partesPrograma.PersonasGrupo) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }

        private void miGestorDeUsuarios_Click(object sender, EventArgs e)
        {
           /* frmGestorUsuarios frmUsr = new frmGestorUsuarios();
            frmUsr.Dock = DockStyle.Fill;
            frmUsr.MdiParent = this;
            frmUsr.Show();*/

            Form frm = null;

            GetFormularios(typeof(frmGestorUsuarios)).ForEach(f =>
            {
                if (((frmGestorUsuarios)f).partes == partesPrograma.PersonasUsuarios) { frm = f; }
            });

            if (frm == null)
            {
                new frmGestorUsuarios(partesPrograma.PersonasUsuarios) { MdiParent = this,Dock = DockStyle.Fill }.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }

        }

        private void mniMoverArchivos_Click(object sender, EventArgs e)
        {
            Form frm = null;

            GetFormularios(typeof(frmMoverArchivos)).ForEach(f =>
            {
                if (((frmMoverArchivos)f).partes == partesPrograma.H_MoverArchivos) { frm = f; }
            });

            if (frm == null)
            {
                new frmMoverArchivos(partesPrograma.H_MoverArchivos) { MdiParent = this, WindowState = FormWindowState.Maximized}.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }
        
        private void mniEncriptarPassword_Click(object sender, EventArgs e)
        {
            Form frm = null;

            GetFormularios(typeof(frmEncriptarPassword)).ForEach(f =>
            {
                if (((frmEncriptarPassword)f).partes == partesPrograma.H_EncriptarPassword) { frm = f; }
            });

            if (frm == null)
            {
                new frmEncriptarPassword(partesPrograma.H_EncriptarPassword) { MdiParent = this, WindowState = FormWindowState.Maximized }.Show();
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
        }

        private void mniExternas_Click(object sender, EventArgs e)
        {

        }

        #region Gestion Ventanas

        // es necesario una lista Enum con el nombre que le quieres dar a cada formulario
        public enum partesPrograma
        {
            Main,
            Codigo,
            Notas,
            PersonasGrupo,
            PersonasUsuarios,
            Correo,
            Contraseñas,
            H_SeparadorTexto,
            H_MoverArchivos,
            H_EncriptarPassword,
            H_Externas
        }

        //listado de ventanas abiertas
        private void tsddVentanas_DropDownOpening(object sender, EventArgs e)
        {
            // cargar las ventanas abiertas dentro del mdi
            mnuVentanas.DropDownItems.Clear();
            ToolStripItem item;

            foreach (Form form in this.MdiChildren.ToList())
            {
                item = mnuVentanas.DropDownItems.Add(form.Text, null, mnuiVentana_Click);
                item.Tag = form;
                item.Image = form.Icon.ToBitmap();
            }
        }

        //cambiar de ventana a una ya abierta
        private void mnuiVentana_Click(object sender, EventArgs e)
        {
            ((Form)((ToolStripMenuItem)sender).Tag).BringToFront();
        }

        //obtenecion del formulario abierto del mismo tipo si existe
        private List<Form> GetFormularios(Type tipo)
        {
            return this.MdiChildren.Where(form => form.GetType() == tipo).ToList();
        }

        private List<Form> GetFormulariosGeneral(Type tipo)
        {
            List<Form> result = new List<Form>();
            FormCollection formulariosApp = Application.OpenForms;

            foreach (Form f in formulariosApp)
            {
                if (f.GetType() == tipo)
                {
                    result.Add(f);
                    //f.Close();
                }
            }
            return result;
            
            //return OwnedForms.Where(form => form.GetType() == tipo).ToList();
        }


        #endregion

        
    }
}