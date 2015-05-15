using System.Drawing;

namespace Visivel
{
    internal class Foto
    {
        /// <summary>
        ///     Tira foto da tela
        /// </summary>
        /// <param name="size">tamanho da imagem</param>
        /// <param name="X">ponto X da imagem</param>
        /// <param name="Y">ponto Y da imagem</param>
        /// <returns>imagem</returns>
        public static Bitmap GetScreen(Size size, int X, int Y, int aimX, int aimY)
        {
            var bmpScreenShot = new Bitmap(size.Width, size.Height);
            Graphics gfx = Graphics.FromImage(bmpScreenShot);

            gfx.CopyFromScreen(X + aimX, Y + aimY, 0, 0, size);

            return bmpScreenShot;
        }
    }
}