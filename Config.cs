using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Visivel
{
    public class Config
    {
        #region SingleTon

        private static Config instance;

        public static Config GetInstance()
        {
            if (instance == null)
                instance = new Config();
            return instance;
        }

        #endregion

        #region Construtor

        private Config()
        {
            CarregarConteudo();
        }

        #endregion

        #region Constantes

        private const string FILE_NAME = "config.xml";
        private const string IMAGE_NAME = "lastImage.jpg";

        #endregion

        #region Propriedades no Registro

        private RegistryKey keys
        {
            get { return Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("Visivel"); }
        }

        /// <summary>
        ///     Bool que identifica se a janela vai se esconder automaticamente
        /// </summary>
        public bool autoHide
        {
            get { return bool.Parse(keys.GetValue("autoHide", false).ToString()); }
            set { keys.SetValue("autoHide", value); }
        }

        /// <summary>
        ///     Bool que identifica se a janela vai fugir do mouse
        /// </summary>
        public bool fuga
        {
            get { return bool.Parse(keys.GetValue("fuga", false).ToString()); }
            set { keys.SetValue("fuga", value); }
        }

        /// <summary>
        ///     Valor utilizado para ajustar a foto a tela do visível pelo eixo x
        /// </summary>
        public int screemAimX
        {
            get { return Int32.Parse(keys.GetValue("screenAimX", GetScreenAimValue(PointReference.X)).ToString()); }
            set { keys.SetValue("screenAimX", value); }
        }

        /// <summary>
        ///     Valor utilizado para ajustar a foto a tela do visível pelo eixo y
        /// </summary>
        public int screemAimY
        {
            get { return Int32.Parse(keys.GetValue("screenAimY", GetScreenAimValue(PointReference.Y)).ToString()); }
            set { keys.SetValue("screenAimY", value); }
        }

        /// <summary>
        ///     Valor que identifica a ultima posição x
        /// </summary>
        public int lastLocationX
        {
            get { return int.Parse(keys.GetValue("lastLocationX", 0).ToString()); }
            set { keys.SetValue("lastLocationX", value); }
        }

        /// <summary>
        ///     Valor que identifica a ultima posição y
        /// </summary>
        public int lastLocationY
        {
            get { return int.Parse(keys.GetValue("lastLocationY", 0).ToString()); }
            set { keys.SetValue("lastLocationY", value); }
        }

        /// <summary>
        ///     Valor que identifica a largura da janela
        /// </summary>
        public int lastWidth
        {
            get { return int.Parse(keys.GetValue("lastWidth", 300).ToString()); }
            set { keys.SetValue("lastWidth", value); }
        }

        /// <summary>
        ///     Valor que identifica a altura da janela
        /// </summary>
        public int lastHeight
        {
            get { return int.Parse(keys.GetValue("lastHeight", 300).ToString()); }
            set { keys.SetValue("lastHeight", value); }
        }

        /// <summary>
        ///     Bool que habilita o duplo clique, no modo foto, para voltar ao modo texto.
        /// </summary>
        public bool BackToText
        {
            get { return bool.Parse(keys.GetValue("backToText", false).ToString()); }
            set { keys.SetValue("backToText", value); }
        }

        /// <summary>
        ///     Bool que define se o visível deve ou ñ salvar o seu conteudo.
        /// </summary>
        public bool salvarConteudo
        {
            get { return bool.Parse(keys.GetValue("salvarConteudo", false).ToString()); }
            set { keys.SetValue("salvarConteudo", value); }
        }

        /// <summary>
        ///     Bool que define se o visível deve ou ñ salvar o seu tamanho.
        /// </summary>
        public bool salvarTamanho
        {
            get { return bool.Parse(keys.GetValue("salvarTamanho", false).ToString()); }
            set { keys.SetValue("salvarTamanho", value); }
        }

        /// <summary>
        ///     Bool que define se o visível deve ou ñ salvar sua localização.
        /// </summary>
        public bool salvarLocal
        {
            get { return bool.Parse(keys.GetValue("salvarLocal", false).ToString()); }
            set { keys.SetValue("salvarLocal", value); }
        }

        #endregion

        #region Propriedades no Arquivo

        /// <summary>
        ///     Guarda o ultimo modo em que o visível se encontrava
        /// </summary>
        public Mode lastModo { get; set; }

        /// <summary>
        ///     Guarda o ultimo texto no visível
        /// </summary>
        public string lastText { get; set; }

        /// <summary>
        ///     Pega a ultima imagem salva no diretório
        /// </summary>
        public Image lastImage
        {
            get
            {
                Bitmap bmp = null;
                if (!String.IsNullOrEmpty(lastImageLocation))
                    bmp = new Bitmap(lastImageLocation);

                return bmp;
            }
        }

        /// <summary>
        ///     Localização do arquivo da ultima imagem salva no visível
        /// </summary>
        private string lastImageLocation { get; set; }

        #endregion

        #region Propriedades 

        private string fullFileName
        {
            get { return GetSaveFolder() + FILE_NAME; }
        }

        private string fullImageName
        {
            get { return GetSaveFolder() + IMAGE_NAME; }
        }

        #endregion

        #region Carregar/Salvar

        private void CarregarConteudo()
        {
            if (salvarConteudo)
            {
                FileInfo file = GetSaveFile();
                if (file.Exists)
                {
                    FileStream fileStream = null;
                    try
                    {
                        var xml = new XmlDocument();
                        fileStream = file.OpenRead();
                        xml.Load(fileStream);
                        if (!xml.HasChildNodes)
                        {
                            lastModo = Mode.text;
                            lastText = "";
                            lastImageLocation = "";
                        }

                        if (!String.IsNullOrEmpty(xml.SelectSingleNode("//modo").InnerText))
                            lastModo = (Mode) Convert.ToInt32(xml.SelectSingleNode("//modo").InnerText);
                        else
                            lastModo = Mode.text;

                        if (!String.IsNullOrEmpty(xml.SelectSingleNode("//text").InnerText))
                            lastText = xml.SelectSingleNode("//text").InnerText;
                        else
                            lastText = "";

                        if (!String.IsNullOrEmpty(xml.SelectSingleNode("//imageLocation").InnerText))
                            lastImageLocation = xml.SelectSingleNode("//imageLocation").InnerText;
                        else
                            lastImageLocation = "";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            fileStream.Close();
                            file.Delete();
                        }
                    }
                }
            }
        }

        public void SalvarConteudo(Mode modo, string text, Image img)
        {
            if (salvarConteudo)
            {
                FileInfo file = GetSaveFile();
                FileStream fileStream = null;
                try
                {
                    XmlDocument xml = BuildXml();

                    modo = Mode.text;
                    xml.SelectSingleNode("//modo").InnerText = Convert.ToInt32(modo).ToString();
                    xml.SelectSingleNode("//text").InnerText = text;
                    //if (img != null)                
                    //{
                    //    SaveFiles.SaveImage(img, fullImageName);
                    //    xml.SelectSingleNode("//imageLocation").InnerText = fullImageName;
                    //}

                    file.Delete();
                    fileStream = file.OpenWrite();
                    xml.Save(fileStream);
                }
                catch (Exception ex)
                {
                    fileStream.Close();
                    throw ex;
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Close();
                }
            }
        }

        #endregion

        #region Uteis

        private static XmlDocument BuildXml()
        {
            var strXml = new StringBuilder();

            strXml.Append("<config>");
            strXml.Append("<modo/>");
            strXml.Append("<text/>");
            strXml.Append("<imageLocation/>");
            strXml.Append("</config>");

            var xdoc = new XmlDocument();

            xdoc.LoadXml(strXml.ToString());

            return xdoc;
        }

        private FileInfo GetSaveFile()
        {
            var file = new FileInfo(fullFileName);
            //if (!file.Exists)
            //{
            //    FileStream fileStream = file.Create();
            //    fileStream.Close();
            //}

            return file;
        }

        private static string GetSaveFolder()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Visivel\\";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            return dir;
        }

        private static int GetScreenAimValue(PointReference p)
        {
            int ret;
            Rectangle screen = SystemInformation.VirtualScreen;

            if ((screen.Width/screen.Height) < 1.4)
                if (p == PointReference.X)
                    ret = 5;
                else
                    ret = 22;
            else if (p == PointReference.X)
                ret = 1;
            else
                ret = 24;

            return ret;
        }

        #endregion
    }
}