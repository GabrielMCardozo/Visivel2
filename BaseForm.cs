using System.Windows.Forms;

namespace Visivel
{
    public class BaseForm : Form
    {
        protected Config Configuracao
        {
            get { return Config.GetInstance(); }
        }
    }
}