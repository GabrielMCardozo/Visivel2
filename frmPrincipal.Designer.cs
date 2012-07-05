namespace Visivel
{
    partial class frmVisivel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisivel));
            this.cmsText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllF11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fotografarF12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visibilidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxVisibilidade = new System.Windows.Forms.ToolStripComboBox();
            this.mudarModoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.confguraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBody1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.cmsText.SuspendLayout();
            this.cmsNotifyIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBody1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsText
            // 
            this.cmsText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.copyAllF11ToolStripMenuItem,
            this.toolStripSeparator1,
            this.fotografarF12ToolStripMenuItem,
            this.visibilidadeToolStripMenuItem,
            this.mudarModoToolStripMenuItem,
            this.toolStripSeparator2,
            this.confguraçõesToolStripMenuItem,
            this.salvarToolStripMenuItem});
            this.cmsText.Name = "contextMenuStrip1";
            this.cmsText.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsText.ShowImageMargin = false;
            resources.ApplyResources(this.cmsText, "cmsText");
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // copyAllF11ToolStripMenuItem
            // 
            this.copyAllF11ToolStripMenuItem.Name = "copyAllF11ToolStripMenuItem";
            resources.ApplyResources(this.copyAllF11ToolStripMenuItem, "copyAllF11ToolStripMenuItem");
            this.copyAllF11ToolStripMenuItem.Click += new System.EventHandler(this.copyAllF11ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // fotografarF12ToolStripMenuItem
            // 
            this.fotografarF12ToolStripMenuItem.Name = "fotografarF12ToolStripMenuItem";
            resources.ApplyResources(this.fotografarF12ToolStripMenuItem, "fotografarF12ToolStripMenuItem");
            this.fotografarF12ToolStripMenuItem.Click += new System.EventHandler(this.fotografarF12ToolStripMenuItem_Click);
            // 
            // visibilidadeToolStripMenuItem
            // 
            this.visibilidadeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxVisibilidade});
            this.visibilidadeToolStripMenuItem.Name = "visibilidadeToolStripMenuItem";
            resources.ApplyResources(this.visibilidadeToolStripMenuItem, "visibilidadeToolStripMenuItem");
            // 
            // toolStripComboBoxVisibilidade
            // 
            this.toolStripComboBoxVisibilidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxVisibilidade.DropDownWidth = 30;
            this.toolStripComboBoxVisibilidade.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxVisibilidade.Items"),
            resources.GetString("toolStripComboBoxVisibilidade.Items1"),
            resources.GetString("toolStripComboBoxVisibilidade.Items2"),
            resources.GetString("toolStripComboBoxVisibilidade.Items3"),
            resources.GetString("toolStripComboBoxVisibilidade.Items4"),
            resources.GetString("toolStripComboBoxVisibilidade.Items5"),
            resources.GetString("toolStripComboBoxVisibilidade.Items6")});
            this.toolStripComboBoxVisibilidade.Name = "toolStripComboBoxVisibilidade";
            resources.ApplyResources(this.toolStripComboBoxVisibilidade, "toolStripComboBoxVisibilidade");
            this.toolStripComboBoxVisibilidade.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxVisibilidade_SelectedIndexChanged);
            // 
            // mudarModoToolStripMenuItem
            // 
            this.mudarModoToolStripMenuItem.Name = "mudarModoToolStripMenuItem";
            resources.ApplyResources(this.mudarModoToolStripMenuItem, "mudarModoToolStripMenuItem");
            this.mudarModoToolStripMenuItem.Click += new System.EventHandler(this.mudarModoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // confguraçõesToolStripMenuItem
            // 
            this.confguraçõesToolStripMenuItem.Name = "confguraçõesToolStripMenuItem";
            resources.ApplyResources(this.confguraçõesToolStripMenuItem, "confguraçõesToolStripMenuItem");
            this.confguraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuracoesToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            resources.ApplyResources(this.salvarToolStripMenuItem, "salvarToolStripMenuItem");
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.cmsNotifyIcon;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cmsNotifyIcon
            // 
            this.cmsNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharToolStripMenuItem});
            this.cmsNotifyIcon.Name = "notifyIconMenuStrip1";
            this.cmsNotifyIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsNotifyIcon.ShowImageMargin = false;
            resources.ApplyResources(this.cmsNotifyIcon, "cmsNotifyIcon");
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            resources.ApplyResources(this.fecharToolStripMenuItem, "fecharToolStripMenuItem");
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // pictureBody1
            // 
            this.pictureBody1.ContextMenuStrip = this.cmsText;
            resources.ApplyResources(this.pictureBody1, "pictureBody1");
            this.pictureBody1.Name = "pictureBody1";
            this.pictureBody1.TabStop = false;
            this.pictureBody1.DoubleClick += new System.EventHandler(this.pictureBody1_DoubleClick);
            this.pictureBody1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.all_KeyDown);
            // 
            // txtBody
            // 
            this.txtBody.ContextMenuStrip = this.cmsText;
            resources.ApplyResources(this.txtBody, "txtBody");
            this.txtBody.Name = "txtBody";
            this.txtBody.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBody_KeyPress);
            // 
            // frmVisivel
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.pictureBody1);
            this.Name = "frmVisivel";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisivel_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.all_KeyDown);
            this.Resize += new System.EventHandler(this.frmVisivel_Resize);
            this.cmsText.ResumeLayout(false);
            this.cmsNotifyIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBody1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBody1;
        private System.Windows.Forms.ContextMenuStrip cmsText;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllF11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fotografarF12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxVisibilidade;
        private System.Windows.Forms.ToolStripMenuItem visibilidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confguraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mudarModoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtBody;
    }
}

