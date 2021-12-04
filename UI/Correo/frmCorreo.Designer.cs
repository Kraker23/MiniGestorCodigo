namespace MiniGestorCodigo.UI
{
    partial class frmCorreo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorreo));
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.rtxtMensaje = new System.Windows.Forms.RichTextBox();
            this.txtEmisor = new System.Windows.Forms.TextBox();
            this.btnCc = new System.Windows.Forms.Button();
            this.lAsunto = new System.Windows.Forms.Label();
            this.lEmisor = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lbArchivosAdjuntos = new System.Windows.Forms.ListBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.lbCC = new System.Windows.Forms.ListBox();
            this.lbCCO = new System.Windows.Forms.ListBox();
            this.txtCCO = new System.Windows.Forms.TextBox();
            this.btnCCO = new System.Windows.Forms.Button();
            this.btnAddCCO = new System.Windows.Forms.Button();
            this.btnAddCC = new System.Windows.Forms.Button();
            this.btnArchivosAdjuntos = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAsunto
            // 
            this.txtAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsunto.Location = new System.Drawing.Point(90, 38);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(694, 20);
            this.txtAsunto.TabIndex = 0;
            // 
            // rtxtMensaje
            // 
            this.rtxtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMensaje.Location = new System.Drawing.Point(11, 208);
            this.rtxtMensaje.Name = "rtxtMensaje";
            this.rtxtMensaje.Size = new System.Drawing.Size(773, 253);
            this.rtxtMensaje.TabIndex = 3;
            this.rtxtMensaje.Text = "";
            // 
            // txtEmisor
            // 
            this.txtEmisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmisor.Location = new System.Drawing.Point(90, 12);
            this.txtEmisor.Name = "txtEmisor";
            this.txtEmisor.Size = new System.Drawing.Size(660, 20);
            this.txtEmisor.TabIndex = 1;
            // 
            // btnCc
            // 
            this.btnCc.Location = new System.Drawing.Point(3, 7);
            this.btnCc.Name = "btnCc";
            this.btnCc.Size = new System.Drawing.Size(78, 23);
            this.btnCc.TabIndex = 2;
            this.btnCc.Text = "CC ";
            this.btnCc.UseVisualStyleBackColor = true;
            this.btnCc.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // lAsunto
            // 
            this.lAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lAsunto.AutoSize = true;
            this.lAsunto.Location = new System.Drawing.Point(7, 41);
            this.lAsunto.Name = "lAsunto";
            this.lAsunto.Size = new System.Drawing.Size(43, 13);
            this.lAsunto.TabIndex = 4;
            this.lAsunto.Text = "Asunto:";
            // 
            // lEmisor
            // 
            this.lEmisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lEmisor.AutoSize = true;
            this.lEmisor.Location = new System.Drawing.Point(7, 15);
            this.lEmisor.Name = "lEmisor";
            this.lEmisor.Size = new System.Drawing.Size(32, 13);
            this.lEmisor.TabIndex = 5;
            this.lEmisor.Text = "Para:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(707, 513);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(78, 23);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(579, 513);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lbArchivosAdjuntos
            // 
            this.lbArchivosAdjuntos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbArchivosAdjuntos.FormattingEnabled = true;
            this.lbArchivosAdjuntos.Location = new System.Drawing.Point(136, 480);
            this.lbArchivosAdjuntos.Name = "lbArchivosAdjuntos";
            this.lbArchivosAdjuntos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbArchivosAdjuntos.Size = new System.Drawing.Size(429, 56);
            this.lbArchivosAdjuntos.TabIndex = 9;
            // 
            // txtCC
            // 
            this.txtCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCC.Location = new System.Drawing.Point(3, 36);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(319, 20);
            this.txtCC.TabIndex = 10;
            this.txtCC.Visible = false;
            // 
            // lbCC
            // 
            this.lbCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCC.FormattingEnabled = true;
            this.lbCC.Location = new System.Drawing.Point(3, 63);
            this.lbCC.Name = "lbCC";
            this.lbCC.Size = new System.Drawing.Size(353, 69);
            this.lbCC.TabIndex = 11;
            this.lbCC.Visible = false;
            // 
            // lbCCO
            // 
            this.lbCCO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCCO.FormattingEnabled = true;
            this.lbCCO.Location = new System.Drawing.Point(3, 62);
            this.lbCCO.Name = "lbCCO";
            this.lbCCO.Size = new System.Drawing.Size(399, 69);
            this.lbCCO.TabIndex = 14;
            this.lbCCO.Visible = false;
            // 
            // txtCCO
            // 
            this.txtCCO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCCO.Location = new System.Drawing.Point(3, 36);
            this.txtCCO.Name = "txtCCO";
            this.txtCCO.Size = new System.Drawing.Size(365, 20);
            this.txtCCO.TabIndex = 13;
            // 
            // btnCCO
            // 
            this.btnCCO.Location = new System.Drawing.Point(3, 7);
            this.btnCCO.Name = "btnCCO";
            this.btnCCO.Size = new System.Drawing.Size(78, 23);
            this.btnCCO.TabIndex = 12;
            this.btnCCO.Text = "CCO";
            this.btnCCO.UseVisualStyleBackColor = true;
            this.btnCCO.Click += new System.EventHandler(this.btnCCO_Click);
            // 
            // btnAddCCO
            // 
            this.btnAddCCO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCCO.Image = global::MiniGestorCodigo.UI.Properties.Resources.add2;
            this.btnAddCCO.Location = new System.Drawing.Point(374, 34);
            this.btnAddCCO.Name = "btnAddCCO";
            this.btnAddCCO.Size = new System.Drawing.Size(28, 23);
            this.btnAddCCO.TabIndex = 16;
            this.btnAddCCO.UseVisualStyleBackColor = true;
            this.btnAddCCO.Visible = false;
            this.btnAddCCO.Click += new System.EventHandler(this.btnAddCCO_Click);
            // 
            // btnAddCC
            // 
            this.btnAddCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCC.Image = global::MiniGestorCodigo.UI.Properties.Resources.add2;
            this.btnAddCC.Location = new System.Drawing.Point(328, 33);
            this.btnAddCC.Name = "btnAddCC";
            this.btnAddCC.Size = new System.Drawing.Size(28, 23);
            this.btnAddCC.TabIndex = 15;
            this.btnAddCC.UseVisualStyleBackColor = true;
            this.btnAddCC.Visible = false;
            this.btnAddCC.Click += new System.EventHandler(this.btnAddCC_Click);
            // 
            // btnArchivosAdjuntos
            // 
            this.btnArchivosAdjuntos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchivosAdjuntos.Image = global::MiniGestorCodigo.UI.Properties.Resources.mail_attachment;
            this.btnArchivosAdjuntos.Location = new System.Drawing.Point(15, 481);
            this.btnArchivosAdjuntos.Name = "btnArchivosAdjuntos";
            this.btnArchivosAdjuntos.Size = new System.Drawing.Size(78, 55);
            this.btnArchivosAdjuntos.TabIndex = 7;
            this.btnArchivosAdjuntos.UseVisualStyleBackColor = true;
            this.btnArchivosAdjuntos.Click += new System.EventHandler(this.btnArchivosAdjuntos_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(11, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCc);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddCC);
            this.splitContainer1.Panel1.Controls.Add(this.txtCC);
            this.splitContainer1.Panel1.Controls.Add(this.lbCC);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtCCO);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddCCO);
            this.splitContainer1.Panel2.Controls.Add(this.btnCCO);
            this.splitContainer1.Panel2.Controls.Add(this.lbCCO);
            this.splitContainer1.Size = new System.Drawing.Size(780, 138);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 17;
            // 
            // frmCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(798, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbArchivosAdjuntos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnArchivosAdjuntos);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lEmisor);
            this.Controls.Add(this.lAsunto);
            this.Controls.Add(this.txtEmisor);
            this.Controls.Add(this.rtxtMensaje);
            this.Controls.Add(this.txtAsunto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCorreo";
            this.Text = "Correo electrónico";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.RichTextBox rtxtMensaje;
        private System.Windows.Forms.TextBox txtEmisor;
        private System.Windows.Forms.Button btnCc;
        private System.Windows.Forms.Label lAsunto;
        private System.Windows.Forms.Label lEmisor;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnArchivosAdjuntos;
        private System.Windows.Forms.Button btnCancelar;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ListBox lbArchivosAdjuntos;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.ListBox lbCCO;
        private System.Windows.Forms.TextBox txtCCO;
        private System.Windows.Forms.Button btnCCO;
        private System.Windows.Forms.ListBox lbCC;
        private System.Windows.Forms.Button btnAddCC;
        private System.Windows.Forms.Button btnAddCCO;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}