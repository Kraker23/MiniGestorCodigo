namespace MiniGestorCodigo.UI
{
    partial class frmGestorUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestorUsuarios));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevoUsuario = new System.Windows.Forms.ToolStripButton();
            this.tsbModificarUsuario = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrarUsuario = new System.Windows.Forms.ToolStripButton();
            this.dgvListaUsuarios = new System.Windows.Forms.DataGridView();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoUsuario,
            this.tsbModificarUsuario,
            this.tsbBorrarUsuario});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1035, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevoUsuario
            // 
            this.tsbNuevoUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoUsuario.Image = global::MiniGestorCodigo.UI.Properties.Resources.user1_add;
            this.tsbNuevoUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoUsuario.Name = "tsbNuevoUsuario";
            this.tsbNuevoUsuario.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevoUsuario.Text = "Nuevo usuario";
            this.tsbNuevoUsuario.Click += new System.EventHandler(this.tsbNuevoUsuario_Click);
            // 
            // tsbModificarUsuario
            // 
            this.tsbModificarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModificarUsuario.Image = global::MiniGestorCodigo.UI.Properties.Resources.pencil;
            this.tsbModificarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificarUsuario.Name = "tsbModificarUsuario";
            this.tsbModificarUsuario.Size = new System.Drawing.Size(23, 22);
            this.tsbModificarUsuario.Text = "Modificar usuario";
            this.tsbModificarUsuario.Click += new System.EventHandler(this.tsbModificarUsuario_Click);
            // 
            // tsbBorrarUsuario
            // 
            this.tsbBorrarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBorrarUsuario.Image = global::MiniGestorCodigo.UI.Properties.Resources.user1_delete;
            this.tsbBorrarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrarUsuario.Name = "tsbBorrarUsuario";
            this.tsbBorrarUsuario.Size = new System.Drawing.Size(23, 22);
            this.tsbBorrarUsuario.Text = "Borrar usuario";
            this.tsbBorrarUsuario.Click += new System.EventHandler(this.tsbBorrarUsuario_Click);
            // 
            // dgvListaUsuarios
            // 
            this.dgvListaUsuarios.AllowUserToAddRows = false;
            this.dgvListaUsuarios.AllowUserToDeleteRows = false;
            this.dgvListaUsuarios.AllowUserToResizeColumns = false;
            this.dgvListaUsuarios.AllowUserToResizeRows = false;
            this.dgvListaUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNombre,
            this.cCorreo,
            this.cDepartamento});
            this.dgvListaUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaUsuarios.Location = new System.Drawing.Point(0, 25);
            this.dgvListaUsuarios.Name = "dgvListaUsuarios";
            this.dgvListaUsuarios.ReadOnly = true;
            this.dgvListaUsuarios.Size = new System.Drawing.Size(1035, 420);
            this.dgvListaUsuarios.TabIndex = 1;
            // 
            // cNombre
            // 
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cCorreo
            // 
            this.cCorreo.HeaderText = "Correo electrónico";
            this.cCorreo.Name = "cCorreo";
            this.cCorreo.ReadOnly = true;
            // 
            // cDepartamento
            // 
            this.cDepartamento.HeaderText = "Departamento";
            this.cDepartamento.Name = "cDepartamento";
            this.cDepartamento.ReadOnly = true;
            // 
            // frmGestorUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 445);
            this.Controls.Add(this.dgvListaUsuarios);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestorUsuarios";
            this.Text = "Gestor usuarios";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGestorUsuarios_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvListaUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartamento;
        private System.Windows.Forms.ToolStripButton tsbNuevoUsuario;
        private System.Windows.Forms.ToolStripButton tsbModificarUsuario;
        private System.Windows.Forms.ToolStripButton tsbBorrarUsuario;
    }
}