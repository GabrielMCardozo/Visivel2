namespace Visivel
{
    partial class frmConfig
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
            this.chkAutoHide = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAimX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAimY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBackToText = new System.Windows.Forms.CheckBox();
            this.chkSalvarLocalizacao = new System.Windows.Forms.CheckBox();
            this.chkSalvarTamanho = new System.Windows.Forms.CheckBox();
            this.chkSalvarConteudo = new System.Windows.Forms.CheckBox();
            this.chkFuga = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoHide
            // 
            this.chkAutoHide.AutoSize = true;
            this.chkAutoHide.Location = new System.Drawing.Point(12, 12);
            this.chkAutoHide.Name = "chkAutoHide";
            this.chkAutoHide.Size = new System.Drawing.Size(73, 17);
            this.chkAutoHide.TabIndex = 1;
            this.chkAutoHide.Text = "Auto-Hide";
            this.chkAutoHide.UseVisualStyleBackColor = true;
            this.chkAutoHide.CheckedChanged += new System.EventHandler(this.chkAutoHide_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAimX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAimY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Foto";
            // 
            // txtAimX
            // 
            this.txtAimX.Location = new System.Drawing.Point(64, 16);
            this.txtAimX.MaxLength = 2;
            this.txtAimX.Name = "txtAimX";
            this.txtAimX.Size = new System.Drawing.Size(23, 20);
            this.txtAimX.TabIndex = 2;
            this.txtAimX.TextChanged += new System.EventHandler(this.txtAimX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y:";
            // 
            // txtAimY
            // 
            this.txtAimY.Location = new System.Drawing.Point(115, 16);
            this.txtAimY.MaxLength = 2;
            this.txtAimY.Name = "txtAimY";
            this.txtAimY.Size = new System.Drawing.Size(23, 20);
            this.txtAimY.TabIndex = 3;
            this.txtAimY.TextChanged += new System.EventHandler(this.txtAimY_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajuste:";
            // 
            // chkBackToText
            // 
            this.chkBackToText.AutoSize = true;
            this.chkBackToText.Location = new System.Drawing.Point(12, 58);
            this.chkBackToText.Name = "chkBackToText";
            this.chkBackToText.Size = new System.Drawing.Size(179, 17);
            this.chkBackToText.TabIndex = 2;
            this.chkBackToText.Text = "Duplo clique para voltar ao texto";
            this.chkBackToText.UseVisualStyleBackColor = true;
            this.chkBackToText.CheckedChanged += new System.EventHandler(this.chkBackToText_CheckedChanged);
            // 
            // chkSalvarLocalizacao
            // 
            this.chkSalvarLocalizacao.AutoSize = true;
            this.chkSalvarLocalizacao.Location = new System.Drawing.Point(12, 81);
            this.chkSalvarLocalizacao.Name = "chkSalvarLocalizacao";
            this.chkSalvarLocalizacao.Size = new System.Drawing.Size(142, 17);
            this.chkSalvarLocalizacao.TabIndex = 3;
            this.chkSalvarLocalizacao.Text = "Salvar ultima localização";
            this.chkSalvarLocalizacao.UseVisualStyleBackColor = true;
            this.chkSalvarLocalizacao.CheckedChanged += new System.EventHandler(this.chkSalvarLocalizacao_CheckedChanged);
            // 
            // chkSalvarTamanho
            // 
            this.chkSalvarTamanho.AutoSize = true;
            this.chkSalvarTamanho.Location = new System.Drawing.Point(12, 104);
            this.chkSalvarTamanho.Name = "chkSalvarTamanho";
            this.chkSalvarTamanho.Size = new System.Drawing.Size(130, 17);
            this.chkSalvarTamanho.TabIndex = 4;
            this.chkSalvarTamanho.Text = "Salvar ultimo tamanho";
            this.chkSalvarTamanho.UseVisualStyleBackColor = true;
            this.chkSalvarTamanho.CheckedChanged += new System.EventHandler(this.chkSalvarTamanho_CheckedChanged);
            // 
            // chkSalvarConteudo
            // 
            this.chkSalvarConteudo.AutoSize = true;
            this.chkSalvarConteudo.Location = new System.Drawing.Point(12, 127);
            this.chkSalvarConteudo.Name = "chkSalvarConteudo";
            this.chkSalvarConteudo.Size = new System.Drawing.Size(183, 17);
            this.chkSalvarConteudo.TabIndex = 5;
            this.chkSalvarConteudo.Text = "Salvar ultimo conteúdo( só texto )";
            this.chkSalvarConteudo.UseVisualStyleBackColor = true;
            this.chkSalvarConteudo.CheckedChanged += new System.EventHandler(this.chkSalvarConteudo_CheckedChanged);
            // 
            // chkFuga
            // 
            this.chkFuga.AutoSize = true;
            this.chkFuga.Location = new System.Drawing.Point(12, 35);
            this.chkFuga.Name = "chkFuga";
            this.chkFuga.Size = new System.Drawing.Size(50, 17);
            this.chkFuga.TabIndex = 6;
            this.chkFuga.Text = "Fuga";
            this.chkFuga.UseVisualStyleBackColor = true;
            this.chkFuga.CheckedChanged += new System.EventHandler(this.chkFuga_CheckedChanged);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 207);
            this.Controls.Add(this.chkFuga);
            this.Controls.Add(this.chkSalvarConteudo);
            this.Controls.Add(this.chkSalvarTamanho);
            this.Controls.Add(this.chkSalvarLocalizacao);
            this.Controls.Add(this.chkBackToText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAutoHide);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 414);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(210, 214);
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoHide;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAimX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAimY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBackToText;
        private System.Windows.Forms.CheckBox chkSalvarLocalizacao;
        private System.Windows.Forms.CheckBox chkSalvarTamanho;
        private System.Windows.Forms.CheckBox chkSalvarConteudo;
        private System.Windows.Forms.CheckBox chkFuga;
    }
}