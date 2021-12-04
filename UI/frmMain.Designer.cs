namespace MiniGestorCodigo.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.iconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMenuIcono = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miContrasenas = new System.Windows.Forms.ToolStripMenuItem();
            this.miNuevaContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.miNuevaNota = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miCapturaPantalla = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miNuevoCorreo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.miCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtCambiarUsuario = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbGestorCodigo = new System.Windows.Forms.ToolStripButton();
            this.tsbGestorNotas = new System.Windows.Forms.ToolStripButton();
            this.tsbgPersonas = new System.Windows.Forms.ToolStripDropDownButton();
            this.miGestorGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.miGestorDeUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbGestorContrasenas = new System.Windows.Forms.ToolStripButton();
            this.tsddHerramientas = new System.Windows.Forms.ToolStripDropDownButton();
            this.separadorDeTextoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMoverArchivos = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEncriptarPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentanas = new System.Windows.Forms.ToolStripDropDownButton();
            this.mniExternas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.cmsMenuIcono.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGestorCodigo,
            this.tsbGestorNotas,
            this.tsbgPersonas,
            this.toolStripButton1,
            this.tsbGestorContrasenas,
            this.tsddHerramientas,
            this.mnuVentanas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1348, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // iconApp
            // 
            this.iconApp.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.iconApp.ContextMenuStrip = this.cmsMenuIcono;
            this.iconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("iconApp.Icon")));
            this.iconApp.Text = "Gestor de utilidades";
            this.iconApp.Visible = true;
            this.iconApp.Click += new System.EventHandler(this.iconApp_Click);
            this.iconApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iconApp_MouseDoubleClick);
            // 
            // cmsMenuIcono
            // 
            this.cmsMenuIcono.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miContrasenas,
            this.miNuevaContrasena,
            this.toolStripSeparator1,
            this.miNotas,
            this.miNuevaNota,
            this.Separator1,
            this.miHerramientas,
            this.toolStripSeparator4,
            this.miCapturaPantalla,
            this.toolStripSeparator2,
            this.miNuevoCorreo,
            this.toolStripSeparator3,
            this.miAbrir,
            this.miCerrar});
            this.cmsMenuIcono.Name = "cmsMenuIcono";
            this.cmsMenuIcono.Size = new System.Drawing.Size(178, 232);
            // 
            // miContrasenas
            // 
            this.miContrasenas.Name = "miContrasenas";
            this.miContrasenas.Size = new System.Drawing.Size(177, 22);
            this.miContrasenas.Text = "Contraseñas";
            // 
            // miNuevaContrasena
            // 
            this.miNuevaContrasena.Name = "miNuevaContrasena";
            this.miNuevaContrasena.Size = new System.Drawing.Size(177, 22);
            this.miNuevaContrasena.Text = "Nueva contraseña";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // miNotas
            // 
            this.miNotas.Name = "miNotas";
            this.miNotas.Size = new System.Drawing.Size(177, 22);
            this.miNotas.Text = "Notas";
            // 
            // miNuevaNota
            // 
            this.miNuevaNota.Name = "miNuevaNota";
            this.miNuevaNota.Size = new System.Drawing.Size(177, 22);
            this.miNuevaNota.Text = "Nueva Nota";
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(174, 6);
            // 
            // miHerramientas
            // 
            this.miHerramientas.Name = "miHerramientas";
            this.miHerramientas.Size = new System.Drawing.Size(177, 22);
            this.miHerramientas.Text = "Herramientas";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(174, 6);
            // 
            // miCapturaPantalla
            // 
            this.miCapturaPantalla.Name = "miCapturaPantalla";
            this.miCapturaPantalla.Size = new System.Drawing.Size(177, 22);
            this.miCapturaPantalla.Text = "Captura de pantalla";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // miNuevoCorreo
            // 
            this.miNuevoCorreo.Name = "miNuevoCorreo";
            this.miNuevoCorreo.Size = new System.Drawing.Size(177, 22);
            this.miNuevoCorreo.Text = "Nuevo correo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // miAbrir
            // 
            this.miAbrir.Name = "miAbrir";
            this.miAbrir.Size = new System.Drawing.Size(177, 22);
            this.miAbrir.Text = "Abrir / Ver";
            // 
            // miCerrar
            // 
            this.miCerrar.Name = "miCerrar";
            this.miCerrar.Size = new System.Drawing.Size(177, 22);
            this.miCerrar.Text = "Cerrar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslUsuario,
            this.tsbtCambiarUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 702);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1348, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslUsuario
            // 
            this.tslUsuario.Name = "tslUsuario";
            this.tslUsuario.Size = new System.Drawing.Size(47, 17);
            this.tslUsuario.Text = "Usuario";
            // 
            // tsbtCambiarUsuario
            // 
            this.tsbtCambiarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtCambiarUsuario.Image = global::MiniGestorCodigo.UI.Properties.Resources.user1_refresh;
            this.tsbtCambiarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCambiarUsuario.Name = "tsbtCambiarUsuario";
            this.tsbtCambiarUsuario.Size = new System.Drawing.Size(32, 20);
            this.tsbtCambiarUsuario.Text = "Cambiar Usuario";
            this.tsbtCambiarUsuario.ButtonClick += new System.EventHandler(this.tsbtCambiarUsuario_ButtonClick);
            // 
            // tsbGestorCodigo
            // 
            this.tsbGestorCodigo.Image = ((System.Drawing.Image)(resources.GetObject("tsbGestorCodigo.Image")));
            this.tsbGestorCodigo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGestorCodigo.Name = "tsbGestorCodigo";
            this.tsbGestorCodigo.Size = new System.Drawing.Size(101, 35);
            this.tsbGestorCodigo.Text = "Gestor de código";
            this.tsbGestorCodigo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGestorCodigo.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbGestorNotas
            // 
            this.tsbGestorNotas.Image = global::MiniGestorCodigo.UI.Properties.Resources.notebook;
            this.tsbGestorNotas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGestorNotas.Name = "tsbGestorNotas";
            this.tsbGestorNotas.Size = new System.Drawing.Size(93, 35);
            this.tsbGestorNotas.Text = "Gestor de notas";
            this.tsbGestorNotas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGestorNotas.Click += new System.EventHandler(this.tsbGestorNotas_Click);
            // 
            // tsbgPersonas
            // 
            this.tsbgPersonas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGestorGrupos,
            this.miGestorDeUsuarios});
            this.tsbgPersonas.Image = global::MiniGestorCodigo.UI.Properties.Resources.users2;
            this.tsbgPersonas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbgPersonas.Name = "tsbgPersonas";
            this.tsbgPersonas.Size = new System.Drawing.Size(120, 35);
            this.tsbgPersonas.Text = "Gestor de Personas";
            this.tsbgPersonas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // miGestorGrupos
            // 
            this.miGestorGrupos.Image = global::MiniGestorCodigo.UI.Properties.Resources.grupo_1_;
            this.miGestorGrupos.Name = "miGestorGrupos";
            this.miGestorGrupos.Size = new System.Drawing.Size(172, 22);
            this.miGestorGrupos.Text = "Gestor Grupos";
            this.miGestorGrupos.Click += new System.EventHandler(this.miGestorGrupos_Click);
            // 
            // miGestorDeUsuarios
            // 
            this.miGestorDeUsuarios.Image = global::MiniGestorCodigo.UI.Properties.Resources.user1;
            this.miGestorDeUsuarios.Name = "miGestorDeUsuarios";
            this.miGestorDeUsuarios.Size = new System.Drawing.Size(172, 22);
            this.miGestorDeUsuarios.Text = "Gestor de Usuarios";
            this.miGestorDeUsuarios.Click += new System.EventHandler(this.miGestorDeUsuarios_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::MiniGestorCodigo.UI.Properties.Resources.mail;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(109, 35);
            this.toolStripButton1.Text = "Correo electrónico";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // tsbGestorContrasenas
            // 
            this.tsbGestorContrasenas.Image = global::MiniGestorCodigo.UI.Properties.Resources.safe;
            this.tsbGestorContrasenas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGestorContrasenas.Name = "tsbGestorContrasenas";
            this.tsbGestorContrasenas.Size = new System.Drawing.Size(111, 35);
            this.tsbGestorContrasenas.Text = "Gestor contraseñas";
            this.tsbGestorContrasenas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGestorContrasenas.Click += new System.EventHandler(this.tsbGestorContrasenas_Click);
            // 
            // tsddHerramientas
            // 
            this.tsddHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separadorDeTextoToolStripMenuItem,
            this.mniMoverArchivos,
            this.mniEncriptarPassword,
            this.mniExternas});
            this.tsddHerramientas.Image = global::MiniGestorCodigo.UI.Properties.Resources.customer_support;
            this.tsddHerramientas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddHerramientas.Name = "tsddHerramientas";
            this.tsddHerramientas.Size = new System.Drawing.Size(91, 35);
            this.tsddHerramientas.Text = "Herramientas";
            this.tsddHerramientas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // separadorDeTextoToolStripMenuItem
            // 
            this.separadorDeTextoToolStripMenuItem.Image = global::MiniGestorCodigo.UI.Properties.Resources.contract;
            this.separadorDeTextoToolStripMenuItem.Name = "separadorDeTextoToolStripMenuItem";
            this.separadorDeTextoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.separadorDeTextoToolStripMenuItem.Text = "Separador de Texto";
            this.separadorDeTextoToolStripMenuItem.Click += new System.EventHandler(this.separadorDeTextoToolStripMenuItem_Click);
            // 
            // mniMoverArchivos
            // 
            this.mniMoverArchivos.Image = global::MiniGestorCodigo.UI.Properties.Resources.windows;
            this.mniMoverArchivos.Name = "mniMoverArchivos";
            this.mniMoverArchivos.Size = new System.Drawing.Size(180, 22);
            this.mniMoverArchivos.Text = "Mover Archivos";
            this.mniMoverArchivos.Click += new System.EventHandler(this.mniMoverArchivos_Click);
            // 
            // mniEncriptarPassword
            // 
            this.mniEncriptarPassword.Image = global::MiniGestorCodigo.UI.Properties.Resources.safe;
            this.mniEncriptarPassword.Name = "mniEncriptarPassword";
            this.mniEncriptarPassword.Size = new System.Drawing.Size(180, 22);
            this.mniEncriptarPassword.Text = "Encriptar Password";
            this.mniEncriptarPassword.Click += new System.EventHandler(this.mniEncriptarPassword_Click);
            // 
            // mnuVentanas
            // 
            this.mnuVentanas.Image = global::MiniGestorCodigo.UI.Properties.Resources.windows;
            this.mnuVentanas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuVentanas.Name = "mnuVentanas";
            this.mnuVentanas.Size = new System.Drawing.Size(67, 35);
            this.mnuVentanas.Text = "Ventanas";
            this.mnuVentanas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuVentanas.DropDownOpening += new System.EventHandler(this.tsddVentanas_DropDownOpening);
            // 
            // mniExternas
            // 
            this.mniExternas.Image = global::MiniGestorCodigo.UI.Properties.Resources.folder_edit;
            this.mniExternas.Name = "mniExternas";
            this.mniExternas.Size = new System.Drawing.Size(180, 22);
            this.mniExternas.Text = "Externas";
            this.mniExternas.Click += new System.EventHandler(this.mniExternas_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 724);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de utilidades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsMenuIcono.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGestorCodigo;
        private System.Windows.Forms.ToolStripButton tsbGestorNotas;
        private System.Windows.Forms.NotifyIcon iconApp;
        private System.Windows.Forms.ContextMenuStrip cmsMenuIcono;
        private System.Windows.Forms.ToolStripMenuItem miAbrir;
        private System.Windows.Forms.ToolStripMenuItem miContrasenas;
        private System.Windows.Forms.ToolStripMenuItem miNotas;
        private System.Windows.Forms.ToolStripMenuItem miCerrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miNuevaNota;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem miNuevaContrasena;
        private System.Windows.Forms.ToolStripMenuItem miCapturaPantalla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miNuevoCorreo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsbGestorContrasenas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslUsuario;
        private System.Windows.Forms.ToolStripSplitButton tsbtCambiarUsuario;
        private System.Windows.Forms.ToolStripDropDownButton tsddHerramientas;
        private System.Windows.Forms.ToolStripMenuItem separadorDeTextoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miHerramientas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsbgPersonas;
        private System.Windows.Forms.ToolStripMenuItem miGestorGrupos;
        private System.Windows.Forms.ToolStripMenuItem miGestorDeUsuarios;
        private System.Windows.Forms.ToolStripDropDownButton mnuVentanas;
        private System.Windows.Forms.ToolStripMenuItem mniMoverArchivos;
        private System.Windows.Forms.ToolStripMenuItem mniEncriptarPassword;
        private System.Windows.Forms.ToolStripMenuItem mniExternas;
    }
}