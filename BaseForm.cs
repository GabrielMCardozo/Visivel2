﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Visivel
{
    public class BaseForm:Form
    {    
        protected Config Configuracao
        {
            get { return Config.GetInstance(); }
        }


        
    }
}
