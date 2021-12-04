namespace MiniGestorCodigo.UI
{
    partial class frmCompartirNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompartirNota));
            this.clbListaUsuarios = new System.Windows.Forms.CheckedListBox();
            this.lbCompartir = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbListaUsuarios
            // 
            this.clbListaUsuarios.FormattingEnabled = true;
            this.clbListaUsuarios.Location = new System.Drawing.Point(15, 51);
            this.clbListaUsuarios.Name = "clbListaUsuarios";
            this.clbListaUsuarios.Size = new System.Drawing.Size(225, 94);
            this.clbListaUsuarios.TabIndex = 0;
            this.clbListaUsuarios.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbListaUsuarios_ItemCheck);
            // 
            // lbCompartir
            // 
            this.lbCompartir.AutoSize = true;
            this.lbCompartir.Location = new System.Drawing.Point(12, 22);
            this.lbCompartir.Name = "lbCompartir";
            this.lbCompartir.Size = new System.Drawing.Size(105, 13);
            this.lbCompartir.TabIndex = 1;
            this.lbCompartir.Text = "Compartir nota con...";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(55, 173);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(166, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmCompartirNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(252, 206);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbCompartir);
            this.Controls.Add(this.clbListaUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompartirNota";
            this.Text = "Compartir notas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbListaUsuarios;
        private System.Windows.Forms.Label lbCompartir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancel;
    }
}