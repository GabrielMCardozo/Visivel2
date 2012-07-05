using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visivel
{
    public partial class frmConfig : BaseForm
    {
        private frmConfig()
        {
            InitializeComponent();          
        }

        private static frmConfig instance;

        public static frmConfig GetInstance()
        {
            if (instance == null)
                instance = new frmConfig();
            return instance;
        } 

        private void chkAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            Configuracao.autoHide = chkAutoHide.Checked;             
        }

        private void chkFuga_CheckedChanged(object sender, EventArgs e)
        {
            Configuracao.fuga = chkFuga.Checked;
        }  

        private void txtAimX_TextChanged(object sender, EventArgs e)
        {
            Configuracao.screemAimX = Int32.Parse(txtAimX.Text);
        }

        private void txtAimY_TextChanged(object sender, EventArgs e)
        {
            Configuracao.screemAimY = Int32.Parse(txtAimY.Text);
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            chkBackToText.Checked = Configuracao.BackToText;

            chkSalvarConteudo.Checked = Configuracao.salvarConteudo;
            chkSalvarLocalizacao.Checked = Configuracao.salvarLocal;
            chkSalvarTamanho.Checked = Configuracao.salvarTamanho;
               
            chkAutoHide.Checked = Configuracao.autoHide;
            txtAimX.Text = Configuracao.screemAimX.ToString();
            txtAimY.Text = Configuracao.screemAimY.ToString();
        }

        private void chkBackToText_CheckedChanged(object sender, EventArgs e)
        {
            Configuracao.BackToText = chkBackToText.Checked;
        }

        private void chkSalvarLocalizacao_CheckedChanged(object sender, EventArgs e)
        {
            Configuracao.salvarLocal = chkSalvarLocalizacao.Checked;
        }

        private void chkSalvarTamanho_CheckedChanged(object sender, EventArgs e)
        {
            Configuracao.salvarTamanho = chkSalvarTamanho.Checked;
        }

        private void chkSalvarConteudo_CheckedChanged(object sender, EventArgs e)
        {
            Configuracao.salvarConteudo = chkSalvarConteudo.Checked;
        }

    }
}
