using MiniGestorCodigo.BL;

namespace MiniGestorCodigo.UI
{
    partial class frmAddCarpeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCarpeta));
            this.labNombre = new System.Windows.Forms.Label();
            this.txtNombreCarpeta = new System.Windows.Forms.TextBox();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.Location = new System.Drawing.Point(12, 23);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(142, 13);
            this.labNombre.TabIndex = 0;
            this.labNombre.Text = "Nombre de la nueva carpeta";
            this.labNombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNombreCarpeta
            // 
            this.txtNombreCarpeta.Location = new System.Drawing.Point(160, 20);
            this.txtNombreCarpeta.Name = "txtNombreCarpeta";
            this.txtNombreCarpeta.Size = new System.Drawing.Size(197, 20);
            this.txtNombreCarpeta.TabIndex = 1;
            this.txtNombreCarpeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCarpeta_KeyPress);
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(282, 55);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(75, 23);
            this.btnAnadir.TabIndex = 5;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(176, 55);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAddCarpeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 92);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.txtNombreCarpeta);
            this.Controls.Add(this.labNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddCarpeta";
            this.Text = "Añadir nueva carpeta";
            this.Load += new System.EventHandler(this.addCarpeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.TextBox txtNombreCarpeta;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.Button btnCancelar;
    }
}