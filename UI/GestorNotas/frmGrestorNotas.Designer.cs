namespace MiniGestorCodigo.UI
{
    partial class frmGrestorNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrestorNotas));
            this.lvNotasUsuario = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnActualizarLista = new System.Windows.Forms.ToolStripButton();
            this.btnAnadirNota = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarNota = new System.Windows.Forms.ToolStripButton();
            this.tsbCompartirNota = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tcNotas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvNotasCompartidas = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tcNotas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvNotasUsuario
            // 
            this.lvNotasUsuario.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvNotasUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNotasUsuario.Location = new System.Drawing.Point(3, 3);
            this.lvNotasUsuario.Name = "lvNotasUsuario";
            this.lvNotasUsuario.Size = new System.Drawing.Size(226, 583);
            this.lvNotasUsuario.TabIndex = 0;
            this.lvNotasUsuario.UseCompatibleStateImageBehavior = false;
            this.lvNotasUsuario.View = System.Windows.Forms.View.List;
            this.lvNotasUsuario.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvNotasUsuario_ItemSelectionChanged);
            this.lvNotasUsuario.DoubleClick += new System.EventHandler(this.lvNotasUsuario_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizarLista,
            this.btnAnadirNota,
            this.btnEliminarNota,
            this.tsbCompartirNota});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(954, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizarLista.Image = global::MiniGestorCodigo.UI.Properties.Resources.document_refresh;
            this.btnActualizarLista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(23, 22);
            this.btnActualizarLista.Text = "Actualizar lista notas";
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // btnAnadirNota
            // 
            this.btnAnadirNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnadirNota.Image = global::MiniGestorCodigo.UI.Properties.Resources.document_new;
            this.btnAnadirNota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnadirNota.Name = "btnAnadirNota";
            this.btnAnadirNota.Size = new System.Drawing.Size(23, 22);
            this.btnAnadirNota.Text = "Añadir una nueva nota";
            this.btnAnadirNota.Click += new System.EventHandler(this.btnAnadirNota_Click);
            // 
            // btnEliminarNota
            // 
            this.btnEliminarNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarNota.Image = global::MiniGestorCodigo.UI.Properties.Resources.document_delete;
            this.btnEliminarNota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarNota.Name = "btnEliminarNota";
            this.btnEliminarNota.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarNota.Text = "Borrar nota";
            this.btnEliminarNota.Click += new System.EventHandler(this.btnEliminarNota_Click);
            // 
            // tsbCompartirNota
            // 
            this.tsbCompartirNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCompartirNota.Image = global::MiniGestorCodigo.UI.Properties.Resources.document_out;
            this.tsbCompartirNota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompartirNota.Name = "tsbCompartirNota";
            this.tsbCompartirNota.Size = new System.Drawing.Size(23, 22);
            this.tsbCompartirNota.Text = "Compartir nota";
            this.tsbCompartirNota.Click += new System.EventHandler(this.tsbCompartirNota_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tcNotas);
            this.splitContainer.Size = new System.Drawing.Size(954, 615);
            this.splitContainer.SplitterDistance = 240;
            this.splitContainer.TabIndex = 2;
            // 
            // tcNotas
            // 
            this.tcNotas.Controls.Add(this.tabPage1);
            this.tcNotas.Controls.Add(this.tabPage2);
            this.tcNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcNotas.Location = new System.Drawing.Point(0, 0);
            this.tcNotas.Name = "tcNotas";
            this.tcNotas.SelectedIndex = 0;
            this.tcNotas.Size = new System.Drawing.Size(240, 615);
            this.tcNotas.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvNotasUsuario);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(232, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mis notas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvNotasCompartidas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(232, 589);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compartidas conmigo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvNotasCompartidas
            // 
            this.lvNotasCompartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNotasCompartidas.Location = new System.Drawing.Point(3, 3);
            this.lvNotasCompartidas.Name = "lvNotasCompartidas";
            this.lvNotasCompartidas.Size = new System.Drawing.Size(226, 583);
            this.lvNotasCompartidas.TabIndex = 0;
            this.lvNotasCompartidas.UseCompatibleStateImageBehavior = false;
            this.lvNotasCompartidas.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvNotasCompartidas_ItemSelectionChanged);
            // 
            // frmGrestorNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 642);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGrestorNotas";
            this.Text = "Grestor de notas";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGrestorNotas_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tcNotas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvNotasUsuario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnActualizarLista;
        private System.Windows.Forms.ToolStripButton btnAnadirNota;
        private System.Windows.Forms.ToolStripButton btnEliminarNota;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tcNotas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvNotasCompartidas;
        private System.Windows.Forms.ToolStripButton tsbCompartirNota;
    }
}