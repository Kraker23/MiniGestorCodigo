namespace MiniGestorCodigo.UI
{
    partial class frmGestorContrasenas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestorContrasenas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tsbContrasenas = new System.Windows.Forms.TreeView();
            this.cMenuArbol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miModificarCarpeta = new System.Windows.Forms.ToolStripMenuItem();
            this.miModificarContraseña = new System.Windows.Forms.ToolStripMenuItem();
            this.miVerContraseña = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPasswords = new System.Windows.Forms.TabControl();
            this.tsbAddContrasena = new System.Windows.Forms.ToolStripButton();
            this.tsbModContrasena = new System.Windows.Forms.ToolStripButton();
            this.tsbDellContrasena = new System.Windows.Forms.ToolStripButton();
            this.tsbAddCarpeta = new System.Windows.Forms.ToolStripButton();
            this.tsbModCarpeta = new System.Windows.Forms.ToolStripButton();
            this.tsbDellCarpeta = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cMenuArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddContrasena,
            this.tsbModContrasena,
            this.tsbDellContrasena,
            this.tsbAddCarpeta,
            this.tsbModCarpeta,
            this.tsbDellCarpeta,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tsbContrasenas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPasswords);
            this.splitContainer1.Size = new System.Drawing.Size(800, 425);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // tsbContrasenas
            // 
            this.tsbContrasenas.ContextMenuStrip = this.cMenuArbol;
            this.tsbContrasenas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsbContrasenas.Location = new System.Drawing.Point(0, 0);
            this.tsbContrasenas.Name = "tsbContrasenas";
            this.tsbContrasenas.Size = new System.Drawing.Size(266, 425);
            this.tsbContrasenas.TabIndex = 0;
            this.tsbContrasenas.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tsbContrasenas_BeforeCollapse);
            this.tsbContrasenas.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tsbContrasenas_BeforeExpand);
            this.tsbContrasenas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tsbContrasenas_NodeMouseClick);
            this.tsbContrasenas.Click += new System.EventHandler(this.tsbContrasenas_Click);
            this.tsbContrasenas.DoubleClick += new System.EventHandler(this.tsbContrasenas_DoubleClick);
            this.tsbContrasenas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbContrasenas_MouseDown);
            // 
            // cMenuArbol
            // 
            this.cMenuArbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miModificarCarpeta,
            this.miModificarContraseña,
            this.miVerContraseña});
            this.cMenuArbol.Name = "cMenuArbol";
            this.cMenuArbol.Size = new System.Drawing.Size(189, 70);
            this.cMenuArbol.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuArbol_Opening);
            // 
            // miModificarCarpeta
            // 
            this.miModificarCarpeta.Name = "miModificarCarpeta";
            this.miModificarCarpeta.Size = new System.Drawing.Size(188, 22);
            this.miModificarCarpeta.Text = "Modificar Carpeta";
            this.miModificarCarpeta.Click += new System.EventHandler(this.tsbModCarpeta_Click);
            // 
            // miModificarContraseña
            // 
            this.miModificarContraseña.Name = "miModificarContraseña";
            this.miModificarContraseña.Size = new System.Drawing.Size(188, 22);
            this.miModificarContraseña.Text = "Modificar Contraseña";
            this.miModificarContraseña.Click += new System.EventHandler(this.tsbModContrasena_Click);
            // 
            // miVerContraseña
            // 
            this.miVerContraseña.Name = "miVerContraseña";
            this.miVerContraseña.Size = new System.Drawing.Size(188, 22);
            this.miVerContraseña.Text = "Ver Contraseña";
            this.miVerContraseña.Click += new System.EventHandler(this.miVerContraseña_Click);
            // 
            // tabPasswords
            // 
            this.tabPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPasswords.Location = new System.Drawing.Point(0, 0);
            this.tabPasswords.Name = "tabPasswords";
            this.tabPasswords.SelectedIndex = 0;
            this.tabPasswords.Size = new System.Drawing.Size(530, 425);
            this.tabPasswords.TabIndex = 0;
            this.tabPasswords.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabPasswords_DrawItem);
            this.tabPasswords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPasswords_MouseDown);
            // 
            // tsbAddContrasena
            // 
            this.tsbAddContrasena.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddContrasena.Image = global::MiniGestorCodigo.UI.Properties.Resources.key1_add;
            this.tsbAddContrasena.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddContrasena.Name = "tsbAddContrasena";
            this.tsbAddContrasena.Size = new System.Drawing.Size(23, 22);
            this.tsbAddContrasena.Text = "Anadir contraseña";
            this.tsbAddContrasena.Click += new System.EventHandler(this.tsbAddContrasena_Click);
            // 
            // tsbModContrasena
            // 
            this.tsbModContrasena.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModContrasena.Image = global::MiniGestorCodigo.UI.Properties.Resources.key1_preferences;
            this.tsbModContrasena.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModContrasena.Name = "tsbModContrasena";
            this.tsbModContrasena.Size = new System.Drawing.Size(23, 22);
            this.tsbModContrasena.Text = "Modificar contraseña";
            this.tsbModContrasena.Click += new System.EventHandler(this.tsbModContrasena_Click);
            // 
            // tsbDellContrasena
            // 
            this.tsbDellContrasena.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDellContrasena.Image = global::MiniGestorCodigo.UI.Properties.Resources.key1_delete;
            this.tsbDellContrasena.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDellContrasena.Name = "tsbDellContrasena";
            this.tsbDellContrasena.Size = new System.Drawing.Size(23, 22);
            this.tsbDellContrasena.Text = "Borrar contraseña";
            this.tsbDellContrasena.Click += new System.EventHandler(this.tsbDellContrasena_Click);
            // 
            // tsbAddCarpeta
            // 
            this.tsbAddCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddCarpeta.Image = global::MiniGestorCodigo.UI.Properties.Resources.folder_add;
            this.tsbAddCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddCarpeta.Name = "tsbAddCarpeta";
            this.tsbAddCarpeta.Size = new System.Drawing.Size(23, 22);
            this.tsbAddCarpeta.Text = "Añadir carpeta";
            this.tsbAddCarpeta.Click += new System.EventHandler(this.tsbAddCarpeta_Click);
            // 
            // tsbModCarpeta
            // 
            this.tsbModCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModCarpeta.Image = global::MiniGestorCodigo.UI.Properties.Resources.folder_edit;
            this.tsbModCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModCarpeta.Name = "tsbModCarpeta";
            this.tsbModCarpeta.Size = new System.Drawing.Size(23, 22);
            this.tsbModCarpeta.Text = "Modificar carpeta";
            this.tsbModCarpeta.Click += new System.EventHandler(this.tsbModCarpeta_Click);
            // 
            // tsbDellCarpeta
            // 
            this.tsbDellCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDellCarpeta.Image = global::MiniGestorCodigo.UI.Properties.Resources.folder_delete;
            this.tsbDellCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDellCarpeta.Name = "tsbDellCarpeta";
            this.tsbDellCarpeta.Size = new System.Drawing.Size(23, 22);
            this.tsbDellCarpeta.Text = "Borrar carpeta";
            this.tsbDellCarpeta.Click += new System.EventHandler(this.tsbDellCarpeta_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MiniGestorCodigo.UI.Properties.Resources.document_refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Actualizar lista contraseñas";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmGestorContrasenas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestorContrasenas";
            this.Text = "Gestor de contrasenas";
            this.Load += new System.EventHandler(this.frmGestorContrasenas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cMenuArbol.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tsbContrasenas;
        private System.Windows.Forms.ToolStripButton tsbAddContrasena;
        private System.Windows.Forms.ToolStripButton tsbModContrasena;
        private System.Windows.Forms.ToolStripButton tsbDellContrasena;
        private System.Windows.Forms.ToolStripButton tsbAddCarpeta;
        private System.Windows.Forms.ToolStripButton tsbModCarpeta;
        private System.Windows.Forms.ToolStripButton tsbDellCarpeta;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabPasswords;
        private System.Windows.Forms.ContextMenuStrip cMenuArbol;
        private System.Windows.Forms.ToolStripMenuItem miModificarCarpeta;
        private System.Windows.Forms.ToolStripMenuItem miModificarContraseña;
        private System.Windows.Forms.ToolStripMenuItem miVerContraseña;
    }
}