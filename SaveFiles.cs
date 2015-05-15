using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Visivel
{
    public static class SaveFiles
    {
        public static void SaveText(string text, string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            TextWriter writer = fileInfo.CreateText();
            writer.Write(text);
            writer.Close();
        }

        public static void SaveImage(Image img, string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            img.Save(filePath, ImageFormat.Jpeg);
        }
    }
}