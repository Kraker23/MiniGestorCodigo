namespace MiniGestorCodigo.UI
{
    partial class frmNota
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
            this.txtDescripcionNota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTituloNota = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDescripcionNota
            // 
            this.txtDescripcionNota.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtDescripcionNota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionNota.Location = new System.Drawing.Point(1, 46);
            this.txtDescripcionNota.Multiline = true;
            this.txtDescripcionNota.Name = "txtDescripcionNota";
            this.txtDescripcionNota.Size = new System.Drawing.Size(302, 255);
            this.txtDescripcionNota.TabIndex = 2;
            this.txtDescripcionNota.Text = "Nota...";
            this.txtDescripcionNota.TextChanged += new System.EventHandler(this.txtDescripcionNota_TextChanged);
            this.txtDescripcionNota.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(101, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "-----------------------------------------------____";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTituloNota
            // 
            this.txtTituloNota.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTituloNota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTituloNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTituloNota.Location = new System.Drawing.Point(1, 7);
            this.txtTituloNota.Name = "txtTituloNota";
            this.txtTituloNota.Size = new System.Drawing.Size(302, 14);
            this.txtTituloNota.TabIndex = 1;
            this.txtTituloNota.Text = "Titulo...";
            this.txtTituloNota.TextChanged += new System.EventHandler(this.txtTituloNota_TextChanged);
            this.txtTituloNota.Enter += new System.EventHandler(this.txtTituloNota_Enter);
            // 
            // frmNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(303, 302);
            this.Controls.Add(this.txtTituloNota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcionNota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmNota";
            this.ShowIcon = false;
            this.Text = "Nota";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNota_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcionNota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTituloNota;
    }
}