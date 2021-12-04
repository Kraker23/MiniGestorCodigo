namespace MiniGestorCodigo.UI
{
    partial class frmAddCategoria
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
            this.lbNombreCat = new System.Windows.Forms.Label();
            this.txtNombreCat = new System.Windows.Forms.TextBox();
            this.txtDescripcionCat = new System.Windows.Forms.TextBox();
            this.lbDescripcionCat = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNombreCat
            // 
            this.lbNombreCat.AutoSize = true;
            this.lbNombreCat.Location = new System.Drawing.Point(13, 13);
            this.lbNombreCat.Name = "lbNombreCat";
            this.lbNombreCat.Size = new System.Drawing.Size(47, 13);
            this.lbNombreCat.TabIndex = 99;
            this.lbNombreCat.Text = "Nombre:";
            // 
            // txtNombreCat
            // 
            this.txtNombreCat.Location = new System.Drawing.Point(96, 13);
            this.txtNombreCat.Name = "txtNombreCat";
            this.txtNombreCat.Size = new System.Drawing.Size(282, 20);
            this.txtNombreCat.TabIndex = 1;
            // 
            // txtDescripcionCat
            // 
            this.txtDescripcionCat.Location = new System.Drawing.Point(96, 59);
            this.txtDescripcionCat.Multiline = true;
            this.txtDescripcionCat.Name = "txtDescripcionCat";
            this.txtDescripcionCat.Size = new System.Drawing.Size(282, 95);
            this.txtDescripcionCat.TabIndex = 2;
            // 
            // lbDescripcionCat
            // 
            this.lbDescripcionCat.AutoSize = true;
            this.lbDescripcionCat.Location = new System.Drawing.Point(13, 59);
            this.lbDescripcionCat.Name = "lbDescripcionCat";
            this.lbDescripcionCat.Size = new System.Drawing.Size(66, 13);
            this.lbDescripcionCat.TabIndex = 99;
            this.lbDescripcionCat.Text = "Descripción:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(303, 172);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 100;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(175, 172);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 101;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAddCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(395, 207);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDescripcionCat);
            this.Controls.Add(this.lbDescripcionCat);
            this.Controls.Add(this.txtNombreCat);
            this.Controls.Add(this.lbNombreCat);
            this.Name = "frmAddCategoria";
            this.Text = "Añadir categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombreCat;
        private System.Windows.Forms.TextBox txtNombreCat;
        private System.Windows.Forms.TextBox txtDescripcionCat;
        private System.Windows.Forms.Label lbDescripcionCat;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}