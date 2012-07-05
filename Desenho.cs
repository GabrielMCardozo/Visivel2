using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visivel
{
    public class Desenho
    {
        #region propriedades

        //Private
        private Pen caneta;
        private PictureBox picBox;

        private List<PointF[]> lineList;
        private List<PointF> line;
        private MouseState mouse;

        //Public
        public Color PenColor
        {
            get { return caneta.Color; }
            set { caneta.Color = value; }
        }

        public float PenSize
        {
            get { return caneta.Width; }
            set { caneta.Width = value; }
        }

        public MouseButtons ChangeColorButton { get; set; }

        public MouseButtons DrawButton { get; set; }

        #endregion

        #region Construtores/Destruidores

        /// <summary>
        /// Construtor
        /// </summary>
        public Desenho(ref PictureBox pb)
        {
            caneta = new Pen(Color.Red, 5);
            lineList = new List<PointF[]>();
            line = new List<PointF>();

            mouse = MouseState.up;
            DrawButton = MouseButtons.Left;
            ChangeColorButton = MouseButtons.Right;

            picBox = pb;
            picBox.MouseDown += PicBoxMouseDown;
            picBox.MouseUp += PicBoxMouseUp;
            picBox.MouseMove += PicBoxMouseMove;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// pega o ponto da tela onde o mouse está para desenhar na imagem
        /// </summary>
        /// <param name="p">ponto onde o mouse está</param>
        /// <returns>imagem desenhada</returns>
        private PictureBox canetar(Point p)
        {
            var point = new PointF();

            point = p;

            point.X = (p.X * picBox.Image.Size.Width) / picBox.Size.Width;
            point.Y = (p.Y * picBox.Image.Size.Height) / picBox.Size.Height;

            line.Add(point);

            if (line.Count > 3)
            {
                picBox.Image = reDrawImage(line, picBox.Image);
            }
            return picBox;
        }

        private Image reDrawImage(List<PointF> points, Image bmp)
        {
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawLines(caneta, points.ToArray());

            return bmp;
        }

        private Color InverteCor(Color c)
        {
            int r, g, b;

            r = 255 - ((int)c.R);
            g = 255 - ((int)c.G);
            b = 255 - ((int)c.B);

            return Color.FromArgb(r, g, b);
        }

        #endregion

        #region Eventos

        private void PicBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == DrawButton)
                this.mouse = MouseState.down;
            if (e.Button == ChangeColorButton)
                caneta.Color = InverteCor(caneta.Color);
        }

        private void PicBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == DrawButton)
            {
                this.mouse = MouseState.up;
                lineList.Add(line.ToArray());
                line = new List<PointF>();
            }
        }

        private void PicBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouse == MouseState.down)
            {
                canetar(e.Location);
            }
        }

        #endregion
    }
}