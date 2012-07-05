using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Visivel
{
    public static class SaveFiles
    {
        public static void SaveText(string text, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
                        
            TextWriter writer =  fileInfo.CreateText();
            writer.Write(text);
            writer.Close();
        }

        public static void SaveImage(Image img,string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);            
            img.Save(filePath, ImageFormat.Jpeg); 

        }

    }
}
