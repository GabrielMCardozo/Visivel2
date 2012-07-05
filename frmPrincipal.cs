using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visivel
{
    public partial class frmVisivel : BaseForm
    {
        private Mode modo = Mode.text;
        private Desenho rabisco;
        private double lastOpacity;

        public frmVisivel()
        {
            InitializeComponent();
            lastOpacity = Opacity;
            toolStripComboBoxVisibilidade.SelectedIndex = Convert.ToInt32(Opacity * 10 - 4);
            rabisco = new Desenho(ref pictureBody1);
            rabisco.ChangeColorButton = MouseButtons.Middle;

            InitEventHandles();
            if (Configuracao.autoHide)
                Opacity = 0.2;
            
            CarregarUltimoConteudo();
        }

        #region AllEvents

        private void InitEventHandles()
        {
            txtBody.MouseEnter += new EventHandler(MouseEnterEvent);
            txtBody.MouseLeave += new EventHandler(MouseLeaveEvent);
            txtBody.MouseMove += new MouseEventHandler(MouseMoveEvent);


            pictureBody1.MouseEnter += new EventHandler(MouseEnterEvent);
            pictureBody1.MouseLeave += new EventHandler(MouseLeaveEvent);
            pictureBody1.MouseMove += new MouseEventHandler(MouseMoveEvent);

            this.MouseEnter += new EventHandler(MouseEnterEvent);
            this.MouseLeave += new EventHandler(MouseLeaveEvent);
            this.MouseMove += new MouseEventHandler(MouseMoveEvent);


            //Fuga
            txtBody.MouseEnter += FugaMouseEnter;
            txtBody.MouseLeave += FugaMouseLeave;
            pictureBody1.MouseEnter += FugaMouseEnter;
            pictureBody1.MouseLeave += FugaMouseLeave;

            txtBody.DragDrop += txtBody_DragDrop;
            txtBody.DragEnter += txtBody_DragEnter;
            txtBody.KeyDown += all_KeyDown;
        }

        private void frmVisivel_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
            else
            {
                notifyIcon1.Visible = false;
                Show();
            }

        }

        private void frmVisivel_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarUltimoConteudo();
        }

        private void all_KeyDown(object sender, KeyEventArgs e)
        {
            keyDown(e.KeyCode);
        }

        private void all_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            keyDown(e.KeyCode);
        }

        private void MouseEnterEvent(object sender, EventArgs e)
        {

            if (Configuracao.autoHide)
                Opacity = lastOpacity;
            else
                if (Opacity < 0.4)
                    Opacity = 0.8;
        }

        private void MouseLeaveEvent(object sender, EventArgs e)
        {
            if (ActiveForm == null)
            {
                if (Configuracao.autoHide)
                {
                    if (Opacity > 0.2)
                    {
                        lastOpacity = Opacity;
                        Opacity = 0.2;
                    }
                }
                else
                    if (Opacity < 0.4)
                        Opacity = 0.8;
            }
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {


        }

        #endregion

        #region AllFunctions

        /// <summary>
        /// Shortcuts
        /// </summary>
        /// <param name="key">shotcut key</param>
        private void keyDown(Keys key)
        {
            switch (key)
            {
                case Keys.F9:
                    if (Opacity > 0.4)
                    {
                        Opacity = Opacity - 0.1;
                    }
                    break;
                case Keys.F10:
                    if (Opacity < 1.1)
                    {
                        Opacity = Opacity + 0.1;
                    }
                    break;
                case Keys.F11:
                    if (modo == Mode.picture)
                    {
                        Clipboard.SetImage(pictureBody1.Image);
                    }
                    else
                    {
                        if (txtBody.Text != "")
                        {
                            Clipboard.SetText(txtBody.Text);
                        }
                    }
                    break;
                case Keys.F12:
                    takeAPic();
                    break;
            }
        }

        private void takeAPic()
        {
            goToImage();
            double lastOpacity = Opacity;
            int x = Math.Abs(pictureBody1.Margin.Left + Location.X);
            int y = Math.Abs(pictureBody1.Margin.Horizontal + Location.Y);

            Opacity = 0;
            pictureBody1.Image = Foto.getScreen(pictureBody1.Size, x, y, Configuracao.screemAimX, Configuracao.screemAimY);
            Opacity = lastOpacity;
        }

        private void goToImage()
        {
            mudarModoToolStripMenuItem.Text = "Texto";
            txtBody.Hide();
            pictureBody1.Show();
            modo = Mode.picture;
        }

        private void backToText()
        {
            mudarModoToolStripMenuItem.Text = "Foto";
            txtBody.Show();
            pictureBody1.Hide();
            modo = Mode.text;
        }

        #endregion

        #region NotifyIconEvents

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

            Show();
            WindowState = FormWindowState.Normal;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region textBoxEvents

        private void txtBody_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void txtBody_DragDrop(object sender, DragEventArgs e)
        {
            int i;
            String s;

            // Get start position to drop the text.
            i = txtBody.SelectionStart;
            s = txtBody.Text.Substring(i);
            txtBody.Text = txtBody.Text.Substring(0, i);

            // Drop the text on to the RichTextBox.
            txtBody.Text = txtBody.Text +
            e.Data.GetData(DataFormats.Text).ToString();
            txtBody.Text = txtBody.Text + s;

        }

        private void txtBody_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '§' && txtBody.Text.IndexOf("foto") > -1)
            {
                takeAPic();
            }
        }

        #endregion

        #region ImageEvents

        private void pictureBody1_DoubleClick(object sender, EventArgs e)
        {
            if (Configuracao.BackToText)
                backToText();
        }

        #endregion

        #region ContextMenuStripEvents

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modo == Mode.text)
            {
                Clipboard.SetText(txtBody.SelectedText + "");
            }
            else
            {
                Clipboard.SetImage(pictureBody1.Image);
            }
        }

        private void copyAllF11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modo == Mode.picture)
            {
                Clipboard.SetImage(pictureBody1.Image);
            }
            else
            {
                Clipboard.SetText(txtBody.Text + "");
            }
        }

        private void fotografarF12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takeAPic();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modo == Mode.picture)
            {
                pictureBody1.Image = Clipboard.GetImage();
            }
            else
            {
                if (txtBody.Text.Length == 0)
                    txtBody.Text = Clipboard.GetText();
                else
                    txtBody.SelectedText = Clipboard.GetText();


            }
        }

        private void toolStripComboBoxVisibilidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox combo = (ToolStripComboBox)sender;
            Opacity = (combo.SelectedIndex + 4) * 0.1;
        }

        private void configuracoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowConfig();
        }

        private void mudarModoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modo == Mode.text)
            {
                if (pictureBody1.Image == null)
                    takeAPic();
                else
                    goToImage();
            }
            else
            {
                backToText();
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Title = "Onde você deseja salvar o arquivo?";
            saveFileDialog1.InitialDirectory = @"C:/";
            saveFileDialog1.FileName = "";
            if (modo == Mode.picture)
            {
                saveFileDialog1.DefaultExt = "jpeg";
                saveFileDialog1.Filter = "Jpeg file (*.jpeg)|*.jpeg";
            }
            else
            {
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text file (*.txt)|*.txt";
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (modo == Mode.picture)
                {
                    SaveFiles.SaveImage(pictureBody1.Image, saveFileDialog1.FileName);
                }
                else
                {
                    SaveFiles.SaveText(txtBody.Text, saveFileDialog1.FileName);
                }
            }
        }

        #endregion

        #region Config

        private void SalvarUltimoConteudo()
        {
            if (Configuracao.salvarLocal)
            {
                Configuracao.lastLocationX = this.Location.X;
                Configuracao.lastLocationY = this.Location.Y;
            }
            if (Configuracao.salvarTamanho)
            {
                Configuracao.lastWidth = this.Width;
                Configuracao.lastHeight = this.Height;
            }
            if (Configuracao.salvarConteudo)
                Configuracao.SalvarConteudo(modo, txtBody.Text, pictureBody1.Image);
        }

        private void CarregarUltimoConteudo()
        {
            if (Configuracao.salvarLocal)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.SetDesktopLocation(Configuracao.lastLocationX, Configuracao.lastLocationY);
            }
            if (Configuracao.salvarTamanho)
                this.SetClientSizeCore(Configuracao.lastWidth, Configuracao.lastHeight);


            if (Configuracao.salvarConteudo)
            {
                modo = Configuracao.lastModo;

                txtBody.Text = Configuracao.lastText;

                pictureBody1.Image = Configuracao.lastImage;
                if (modo == Mode.picture)
                {
                    goToImage();
                }
                else
                {
                    txtBody.SelectionStart = 0;
                    txtBody.SelectionLength = txtBody.Text.Length;
                }

            }
        }

        private void ShowConfig()
        {
            Opacity = lastOpacity;

            var conf = frmConfig.GetInstance();

            conf.FormClosed += new FormClosedEventHandler(ApplyConfig);
            conf.ShowDialog(this);
        }

        private void ApplyConfig(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Fuga"

        #region "Propriedades"

        private DateTime tempo { get; set; }
        private Point plim
        {
            get
            {
                return new Point(SystemInformation.VirtualScreen.Width - this.Width - 50, SystemInformation.VirtualScreen.Height - this.Height - 50);
            }
        }

        #endregion

        #region Eventos

        private void FugaMouseEnter(object sender, EventArgs e)
        {
            tempo = DateTime.Now;
        }

        private void FugaMouseLeave(object sender, EventArgs e)
        {
            TimeSpan dif = DateTime.Now - tempo;
            if (dif.Seconds == 0 && dif.Milliseconds < 150 && !txtBody.Focused && !pictureBody1.Focused && Configuracao.fuga)
            {
                Fugir();
            }

        }

        #endregion

        #region "Fuga"

        public void Fugir()
        {
            Random r = new Random();

            switch (r.Next(3))
            {
                case 0://NO
                    MoveForm(new Point(50, 50));
                    break;
                case 1://NE
                    MoveForm(new Point(plim.X, 50));
                    break;
                case 2://SO
                    MoveForm(new Point(50, plim.Y));
                    break;
                case 3://SE
                    MoveForm(new Point(plim.X, plim.Y));
                    break;
            }

        }

        public void MoveForm(Point pDest)
        {
            Point pCurr = this.Location;

            while (this.Location != pDest)
            {
                if (pCurr.X > pDest.X)
                    pCurr.X--;
                else if (pCurr.X < pDest.X)
                    pCurr.X++;

                if (pCurr.Y > pDest.Y)
                    pCurr.Y--;
                else if (pCurr.Y < pDest.Y)
                    pCurr.Y++;

                this.SetDesktopLocation(pCurr.X, pCurr.Y);
            }
            ShrinkForm();
        }

        public void ShrinkForm()
        {
            if (Opacity > 0.2)
            {
                lastOpacity = Opacity;
                Opacity = 0.2;
            }
            this.SetClientSizeCore(150, 150);
        }

        #endregion

        #endregion

    }
}
