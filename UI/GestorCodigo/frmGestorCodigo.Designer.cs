namespace MiniGestorCodigo.UI
{
    partial class frmGestorCodigo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestorCodigo));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbActualizarArbol = new System.Windows.Forms.ToolStripButton();
            this.tsbAnadirCarpeta = new System.Windows.Forms.ToolStripButton();
            this.tsbCambiarNombreCarpeta = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrarCarpeta = new System.Windows.Forms.ToolStripButton();
            this.tsbAnadirCodigo = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrarCodigo = new System.Windows.Forms.ToolStripButton();
            this.tsbAddCategoria = new System.Windows.Forms.ToolStripButton();
            this.treeVistaCarpetas = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcArboles = new System.Windows.Forms.TabControl();
            this.tpagUsuarios = new System.Windows.Forms.TabPage();
            this.tpagCategorias = new System.Windows.Forms.TabPage();
            this.tvCategorias = new System.Windows.Forms.TreeView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcArboles.SuspendLayout();
            this.tpagUsuarios.SuspendLayout();
            this.tpagCategorias.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbActualizarArbol,
            this.tsbAnadirCarpeta,
            this.tsbCambiarNombreCarpeta,
            this.tsbBorrarCarpeta,
            this.tsbAnadirCodigo,
            this.tsbBorrarCodigo,
            this.tsbAddCategoria});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1202, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbActualizarArbol
            // 
            this.tsbActualizarArbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizarArbol.Image = ((System.Drawing.Image)(resources.GetObject("tsbActualizarArbol.Image")));
            this.tsbActualizarArbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizarArbol.Name = "tsbActualizarArbol";
            this.tsbActualizarArbol.Size = new System.Drawing.Size(23, 22);
            this.tsbActualizarArbol.Text = "Actualizar carpetas";
            this.tsbActualizarArbol.Click += new System.EventHandler(this.tsbActualizarArbol_Click);
            // 
            // tsbAnadirCarpeta
            // 
            this.tsbAnadirCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnadirCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnadirCarpeta.Image")));
            this.tsbAnadirCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnadirCarpeta.Name = "tsbAnadirCarpeta";
            this.tsbAnadirCarpeta.Size = new System.Drawing.Size(23, 22);
            this.tsbAnadirCarpeta.Text = "Añadir carpeta";
            this.tsbAnadirCarpeta.Click += new System.EventHandler(this.tsbAnadirCarpeta_Click);
            // 
            // tsbCambiarNombreCarpeta
            // 
            this.tsbCambiarNombreCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCambiarNombreCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("tsbCambiarNombreCarpeta.Image")));
            this.tsbCambiarNombreCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCambiarNombreCarpeta.Name = "tsbCambiarNombreCarpeta";
            this.tsbCambiarNombreCarpeta.Size = new System.Drawing.Size(23, 22);
            this.tsbCambiarNombreCarpeta.Text = "Cambiar nombre carpeta";
            this.tsbCambiarNombreCarpeta.Click += new System.EventHandler(this.tsbCambiarNombreCarpeta_Click);
            // 
            // tsbBorrarCarpeta
            // 
            this.tsbBorrarCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBorrarCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrarCarpeta.Image")));
            this.tsbBorrarCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrarCarpeta.Name = "tsbBorrarCarpeta";
            this.tsbBorrarCarpeta.Size = new System.Drawing.Size(23, 22);
            this.tsbBorrarCarpeta.Text = "Borrar carpeta";
            this.tsbBorrarCarpeta.Click += new System.EventHandler(this.tsbBorrarCarpeta_Click);
            // 
            // tsbAnadirCodigo
            // 
            this.tsbAnadirCodigo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnadirCodigo.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnadirCodigo.Image")));
            this.tsbAnadirCodigo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnadirCodigo.Name = "tsbAnadirCodigo";
            this.tsbAnadirCodigo.Size = new System.Drawing.Size(23, 22);
            this.tsbAnadirCodigo.Text = "Añadir código";
            this.tsbAnadirCodigo.Click += new System.EventHandler(this.tsbAnadirCodigo_Click);
            // 
            // tsbBorrarCodigo
            // 
            this.tsbBorrarCodigo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBorrarCodigo.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrarCodigo.Image")));
            this.tsbBorrarCodigo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrarCodigo.Name = "tsbBorrarCodigo";
            this.tsbBorrarCodigo.Size = new System.Drawing.Size(23, 22);
            this.tsbBorrarCodigo.Text = "Borrar código";
            this.tsbBorrarCodigo.Click += new System.EventHandler(this.tsbBorrarCodigo_Click);
            // 
            // tsbAddCategoria
            // 
            this.tsbAddCategoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddCategoria.Image = global::MiniGestorCodigo.UI.Properties.Resources.gear_add;
            this.tsbAddCategoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddCategoria.Name = "tsbAddCategoria";
            this.tsbAddCategoria.Size = new System.Drawing.Size(23, 22);
            this.tsbAddCategoria.Text = "Añadir categoria";
            this.tsbAddCategoria.Click += new System.EventHandler(this.tsbAddCategoria_Click);
            // 
            // treeVistaCarpetas
            // 
            this.treeVistaCarpetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeVistaCarpetas.Location = new System.Drawing.Point(3, 3);
            this.treeVistaCarpetas.Name = "treeVistaCarpetas";
            this.treeVistaCarpetas.Size = new System.Drawing.Size(381, 622);
            this.treeVistaCarpetas.TabIndex = 0;
            this.treeVistaCarpetas.TabStop = false;
            this.treeVistaCarpetas.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeVistaCarpetas_BeforeCollapse);
            this.treeVistaCarpetas.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeVistaCarpetas_BeforeExpand);
            this.treeVistaCarpetas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeVistaCarpetas_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcArboles);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscar);
            this.splitContainer1.Panel1.Controls.Add(this.txtBuscar);
            this.splitContainer1.Size = new System.Drawing.Size(1202, 690);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // tcArboles
            // 
            this.tcArboles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcArboles.Controls.Add(this.tpagUsuarios);
            this.tcArboles.Controls.Add(this.tpagCategorias);
            this.tcArboles.Location = new System.Drawing.Point(0, 36);
            this.tcArboles.Name = "tcArboles";
            this.tcArboles.SelectedIndex = 0;
            this.tcArboles.Size = new System.Drawing.Size(395, 654);
            this.tcArboles.TabIndex = 3;
            // 
            // tpagUsuarios
            // 
            this.tpagUsuarios.Controls.Add(this.treeVistaCarpetas);
            this.tpagUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tpagUsuarios.Name = "tpagUsuarios";
            this.tpagUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tpagUsuarios.Size = new System.Drawing.Size(387, 628);
            this.tpagUsuarios.TabIndex = 0;
            this.tpagUsuarios.Text = "Usuarios";
            this.tpagUsuarios.UseVisualStyleBackColor = true;
            // 
            // tpagCategorias
            // 
            this.tpagCategorias.Controls.Add(this.tvCategorias);
            this.tpagCategorias.Location = new System.Drawing.Point(4, 22);
            this.tpagCategorias.Name = "tpagCategorias";
            this.tpagCategorias.Padding = new System.Windows.Forms.Padding(3);
            this.tpagCategorias.Size = new System.Drawing.Size(387, 628);
            this.tpagCategorias.TabIndex = 1;
            this.tpagCategorias.Text = "Categorias";
            this.tpagCategorias.UseVisualStyleBackColor = true;
            // 
            // tvCategorias
            // 
            this.tvCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCategorias.Location = new System.Drawing.Point(3, 3);
            this.tvCategorias.Name = "tvCategorias";
            this.tvCategorias.Size = new System.Drawing.Size(381, 622);
            this.tvCategorias.TabIndex = 0;
            this.tvCategorias.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvCategorias_BeforeExpand);
            this.tvCategorias.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvCategorias_BeforeSelect);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(365, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(12, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(347, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // frmGestorCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 715);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestorCodigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestor de codigo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Programa_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGestorCodigo_KeyUp);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcArboles.ResumeLayout(false);
            this.tpagUsuarios.ResumeLayout(false);
            this.tpagCategorias.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbActualizarArbol;
        private System.Windows.Forms.ToolStripButton tsbAnadirCarpeta;
        private System.Windows.Forms.ToolStripButton tsbBorrarCarpeta;
        private System.Windows.Forms.ToolStripButton tsbAnadirCodigo;
        private System.Windows.Forms.ToolStripButton tsbBorrarCodigo;
        private System.Windows.Forms.ToolStripButton tsbCambiarNombreCarpeta;
        private System.Windows.Forms.TreeView treeVistaCarpetas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TabControl tcArboles;
        private System.Windows.Forms.TabPage tpagUsuarios;
        private System.Windows.Forms.TabPage tpagCategorias;
        private System.Windows.Forms.TreeView tvCategorias;
        private System.Windows.Forms.ToolStripButton tsbAddCategoria;
    }
}