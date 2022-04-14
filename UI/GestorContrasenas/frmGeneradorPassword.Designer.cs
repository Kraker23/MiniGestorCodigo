namespace MiniGestorCodigo.UI.GestorContrasenas
{
    partial class frmGeneradorPassword
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.btGenerar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkSimbolos = new System.Windows.Forms.CheckBox();
            this.gbOpciones = new System.Windows.Forms.GroupBox();
            this.chkNumeros = new System.Windows.Forms.CheckBox();
            this.chkMayusculas = new System.Windows.Forms.CheckBox();
            this.chkMinusculas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.gbOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar.Location = new System.Drawing.Point(17, 46);
            this.trackBar.Maximum = 75;
            this.trackBar.Minimum = 5;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(242, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Value = 5;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // lblLongitud
            // 
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblLongitud.Location = new System.Drawing.Point(12, 9);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(205, 25);
            this.lblLongitud.TabIndex = 1;
            this.lblLongitud.Text = "Longitud Password : 5";
            // 
            // btGenerar
            // 
            this.btGenerar.Image = global::MiniGestorCodigo.UI.Properties.Resources.key1_add;
            this.btGenerar.Location = new System.Drawing.Point(184, 97);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(75, 116);
            this.btGenerar.TabIndex = 2;
            this.btGenerar.Text = "Generar";
            this.btGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(17, 219);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(242, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // chkSimbolos
            // 
            this.chkSimbolos.AutoSize = true;
            this.chkSimbolos.Checked = true;
            this.chkSimbolos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSimbolos.Location = new System.Drawing.Point(15, 19);
            this.chkSimbolos.Name = "chkSimbolos";
            this.chkSimbolos.Size = new System.Drawing.Size(68, 17);
            this.chkSimbolos.TabIndex = 4;
            this.chkSimbolos.Text = "Simbolos";
            this.chkSimbolos.UseVisualStyleBackColor = true;
            // 
            // gbOpciones
            // 
            this.gbOpciones.Controls.Add(this.chkMinusculas);
            this.gbOpciones.Controls.Add(this.chkMayusculas);
            this.gbOpciones.Controls.Add(this.chkNumeros);
            this.gbOpciones.Controls.Add(this.chkSimbolos);
            this.gbOpciones.Location = new System.Drawing.Point(17, 97);
            this.gbOpciones.Name = "gbOpciones";
            this.gbOpciones.Size = new System.Drawing.Size(166, 116);
            this.gbOpciones.TabIndex = 5;
            this.gbOpciones.TabStop = false;
            this.gbOpciones.Text = "Opciones";
            // 
            // chkNumeros
            // 
            this.chkNumeros.AutoSize = true;
            this.chkNumeros.Checked = true;
            this.chkNumeros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNumeros.Location = new System.Drawing.Point(15, 42);
            this.chkNumeros.Name = "chkNumeros";
            this.chkNumeros.Size = new System.Drawing.Size(68, 17);
            this.chkNumeros.TabIndex = 5;
            this.chkNumeros.Text = "Numeros";
            this.chkNumeros.UseVisualStyleBackColor = true;
            // 
            // chkMayusculas
            // 
            this.chkMayusculas.AutoSize = true;
            this.chkMayusculas.Checked = true;
            this.chkMayusculas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMayusculas.Location = new System.Drawing.Point(15, 65);
            this.chkMayusculas.Name = "chkMayusculas";
            this.chkMayusculas.Size = new System.Drawing.Size(82, 17);
            this.chkMayusculas.TabIndex = 6;
            this.chkMayusculas.Text = "Mayusculas";
            this.chkMayusculas.UseVisualStyleBackColor = true;
            // 
            // chkMinusculas
            // 
            this.chkMinusculas.AutoSize = true;
            this.chkMinusculas.Checked = true;
            this.chkMinusculas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinusculas.Location = new System.Drawing.Point(15, 88);
            this.chkMinusculas.Name = "chkMinusculas";
            this.chkMinusculas.Size = new System.Drawing.Size(79, 17);
            this.chkMinusculas.TabIndex = 7;
            this.chkMinusculas.Text = "Minusculas";
            this.chkMinusculas.UseVisualStyleBackColor = true;
            // 
            // frmGenerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 252);
            this.Controls.Add(this.gbOpciones);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btGenerar);
            this.Controls.Add(this.lblLongitud);
            this.Controls.Add(this.trackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(298, 291);
            this.MinimumSize = new System.Drawing.Size(298, 291);
            this.Name = "frmGenerador";
            this.Text = "Generador Password";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.gbOpciones.ResumeLayout(false);
            this.gbOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Button btGenerar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkSimbolos;
        private System.Windows.Forms.GroupBox gbOpciones;
        private System.Windows.Forms.CheckBox chkMinusculas;
        private System.Windows.Forms.CheckBox chkMayusculas;
        private System.Windows.Forms.CheckBox chkNumeros;
    }
}