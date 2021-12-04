namespace MiniGestorCodigo.UI.GestorGrupos
{
    partial class frmGestorGrupos
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
            this.tGrupos = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btAñadir = new System.Windows.Forms.ToolStripButton();
            this.tUsuarios = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tGrupos
            // 
            this.tGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGrupos.Location = new System.Drawing.Point(0, 25);
            this.tGrupos.Name = "tGrupos";
            this.tGrupos.Size = new System.Drawing.Size(266, 425);
            this.tGrupos.TabIndex = 0;
            this.tGrupos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tGrupos_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tGrupos);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tUsuarios);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAñadir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(266, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btAñadir
            // 
            this.btAñadir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAñadir.Image = global::MiniGestorCodigo.UI.Properties.Resources.add2;
            this.btAñadir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAñadir.Name = "btAñadir";
            this.btAñadir.Size = new System.Drawing.Size(23, 22);
            this.btAñadir.Text = "añadir";
            this.btAñadir.Click += new System.EventHandler(this.btAñadir_Click);
            // 
            // tUsuarios
            // 
            this.tUsuarios.CheckBoxes = true;
            this.tUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tUsuarios.Name = "tUsuarios";
            this.tUsuarios.Size = new System.Drawing.Size(530, 450);
            this.tUsuarios.TabIndex = 2;
            this.tUsuarios.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tUsuarios_BeforeCheck);
            this.tUsuarios.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tUsuarios_AfterCheck);
            // 
            // frmGestorGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGestorGrupos";
            this.Text = "Gestor de Grupos";
            this.Load += new System.EventHandler(this.frmGestorGrupos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tGrupos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btAñadir;
        private System.Windows.Forms.TreeView tUsuarios;
    }
}