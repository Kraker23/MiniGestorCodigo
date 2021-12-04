namespace MiniGestorCodigo.UI
{
    partial class cCodigo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cCodigo));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbDescripcion = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.gbNombreCodigo = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.gbCodigo = new System.Windows.Forms.GroupBox();
            this.btnPortapapeles = new System.Windows.Forms.Button();
            this.rtxtCodigo = new System.Windows.Forms.RichTextBox();
            this.btnGuardarCodigo = new System.Windows.Forms.Button();
            this.lAutor = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.lUltimaModificacion = new System.Windows.Forms.Label();
            this.txtUltimaModificacion = new System.Windows.Forms.TextBox();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.lCategoria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbDescripcion.SuspendLayout();
            this.gbNombreCodigo.SuspendLayout();
            this.gbCodigo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.gbNombreCodigo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbCodigo);
            this.splitContainer1.Size = new System.Drawing.Size(861, 657);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // gbDescripcion
            // 
            this.gbDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescripcion.Controls.Add(this.txtDescripcion);
            this.gbDescripcion.Location = new System.Drawing.Point(3, 63);
            this.gbDescripcion.Name = "gbDescripcion";
            this.gbDescripcion.Size = new System.Drawing.Size(855, 245);
            this.gbDescripcion.TabIndex = 99;
            this.gbDescripcion.TabStop = false;
            this.gbDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(7, 19);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(842, 220);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // gbNombreCodigo
            // 
            this.gbNombreCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNombreCodigo.Controls.Add(this.txtNombre);
            this.gbNombreCodigo.Location = new System.Drawing.Point(3, 3);
            this.gbNombreCodigo.Name = "gbNombreCodigo";
            this.gbNombreCodigo.Size = new System.Drawing.Size(855, 54);
            this.gbNombreCodigo.TabIndex = 0;
            this.gbNombreCodigo.TabStop = false;
            this.gbNombreCodigo.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(7, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(842, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // gbCodigo
            // 
            this.gbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCodigo.Controls.Add(this.btnPortapapeles);
            this.gbCodigo.Controls.Add(this.rtxtCodigo);
            this.gbCodigo.Controls.Add(this.btnGuardarCodigo);
            this.gbCodigo.Controls.Add(this.lAutor);
            this.gbCodigo.Controls.Add(this.txtAutor);
            this.gbCodigo.Controls.Add(this.lUltimaModificacion);
            this.gbCodigo.Controls.Add(this.txtUltimaModificacion);
            this.gbCodigo.Controls.Add(this.cbCategorias);
            this.gbCodigo.Controls.Add(this.lCategoria);
            this.gbCodigo.Location = new System.Drawing.Point(3, 3);
            this.gbCodigo.Name = "gbCodigo";
            this.gbCodigo.Size = new System.Drawing.Size(855, 336);
            this.gbCodigo.TabIndex = 99;
            this.gbCodigo.TabStop = false;
            this.gbCodigo.Text = "Código";
            // 
            // btnPortapapeles
            // 
            this.btnPortapapeles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPortapapeles.Image = global::MiniGestorCodigo.UI.Properties.Resources.clipboard;
            this.btnPortapapeles.Location = new System.Drawing.Point(788, 27);
            this.btnPortapapeles.MaximumSize = new System.Drawing.Size(30, 30);
            this.btnPortapapeles.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnPortapapeles.Name = "btnPortapapeles";
            this.btnPortapapeles.Size = new System.Drawing.Size(30, 30);
            this.btnPortapapeles.TabIndex = 100;
            this.btnPortapapeles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPortapapeles.UseVisualStyleBackColor = true;
            this.btnPortapapeles.Click += new System.EventHandler(this.btnPortapapeles_Click);
            // 
            // rtxtCodigo
            // 
            this.rtxtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCodigo.Location = new System.Drawing.Point(6, 84);
            this.rtxtCodigo.Name = "rtxtCodigo";
            this.rtxtCodigo.Size = new System.Drawing.Size(842, 252);
            this.rtxtCodigo.TabIndex = 4;
            this.rtxtCodigo.Text = "";
            this.rtxtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // btnGuardarCodigo
            // 
            this.btnGuardarCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarCodigo.AutoSize = true;
            this.btnGuardarCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardarCodigo.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarCodigo.Image")));
            this.btnGuardarCodigo.Location = new System.Drawing.Point(725, 27);
            this.btnGuardarCodigo.MaximumSize = new System.Drawing.Size(30, 30);
            this.btnGuardarCodigo.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnGuardarCodigo.Name = "btnGuardarCodigo";
            this.btnGuardarCodigo.Size = new System.Drawing.Size(30, 30);
            this.btnGuardarCodigo.TabIndex = 5;
            this.btnGuardarCodigo.UseVisualStyleBackColor = true;
            this.btnGuardarCodigo.Click += new System.EventHandler(this.btnGuardarCodigo_Click);
            this.btnGuardarCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // lAutor
            // 
            this.lAutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lAutor.AutoSize = true;
            this.lAutor.Location = new System.Drawing.Point(484, 27);
            this.lAutor.Name = "lAutor";
            this.lAutor.Size = new System.Drawing.Size(46, 13);
            this.lAutor.TabIndex = 99;
            this.lAutor.Text = "Autor/a:";
            // 
            // txtAutor
            // 
            this.txtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAutor.Location = new System.Drawing.Point(487, 54);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.ReadOnly = true;
            this.txtAutor.Size = new System.Drawing.Size(130, 20);
            this.txtAutor.TabIndex = 0;
            this.txtAutor.TabStop = false;
            // 
            // lUltimaModificacion
            // 
            this.lUltimaModificacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lUltimaModificacion.AutoSize = true;
            this.lUltimaModificacion.Location = new System.Drawing.Point(249, 27);
            this.lUltimaModificacion.Name = "lUltimaModificacion";
            this.lUltimaModificacion.Size = new System.Drawing.Size(132, 13);
            this.lUltimaModificacion.TabIndex = 99;
            this.lUltimaModificacion.Text = "Fecha ultima modificación:";
            // 
            // txtUltimaModificacion
            // 
            this.txtUltimaModificacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUltimaModificacion.Location = new System.Drawing.Point(252, 54);
            this.txtUltimaModificacion.Name = "txtUltimaModificacion";
            this.txtUltimaModificacion.ReadOnly = true;
            this.txtUltimaModificacion.Size = new System.Drawing.Size(130, 20);
            this.txtUltimaModificacion.TabIndex = 0;
            this.txtUltimaModificacion.TabStop = false;
            // 
            // cbCategorias
            // 
            this.cbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(34, 54);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(130, 21);
            this.cbCategorias.TabIndex = 3;
            this.cbCategorias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // lCategoria
            // 
            this.lCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lCategoria.AutoSize = true;
            this.lCategoria.Location = new System.Drawing.Point(31, 27);
            this.lCategoria.Name = "lCategoria";
            this.lCategoria.Size = new System.Drawing.Size(52, 13);
            this.lCategoria.TabIndex = 99;
            this.lCategoria.Text = "Categoria";
            // 
            // cCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "cCodigo";
            this.Size = new System.Drawing.Size(864, 663);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cCodigo_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbDescripcion.ResumeLayout(false);
            this.gbDescripcion.PerformLayout();
            this.gbNombreCodigo.ResumeLayout(false);
            this.gbNombreCodigo.PerformLayout();
            this.gbCodigo.ResumeLayout(false);
            this.gbCodigo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbDescripcion;
        private System.Windows.Forms.GroupBox gbNombreCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox gbCodigo;
        private System.Windows.Forms.TextBox txtUltimaModificacion;
        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.Label lCategoria;
        private System.Windows.Forms.Label lUltimaModificacion;
        private System.Windows.Forms.Button btnGuardarCodigo;
        private System.Windows.Forms.Label lAutor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.RichTextBox rtxtCodigo;
        private System.Windows.Forms.Button btnPortapapeles;
    }
}
