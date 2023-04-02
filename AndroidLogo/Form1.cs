using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidLogo
{
    public partial class Form1 : Form
    {

        private Graphics graphics = null;
        private int centralHorizontalLine;
        private int centralVerticalLine;
        private float size = 600.0F;

        public Form1()
        {
            InitializeComponent();
            // Obtém a segunda tela do sistema
            Screen screen = Screen.AllScreens[0];

            // Define a posição da janela na segunda tela
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = screen.Bounds.Location;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            graphics = this.CreateGraphics();
            graphics.Clear(Color.Black);
            centralHorizontalLine = (this.Width / 2) - 8;
            centralVerticalLine = (this.Height / 2) - 7;
            //
            //DrawVerticalLine(Color.Red, centralHorizontalLine, 0, this.Height);// -- MARCAÇÃO VERTICAL VERTICAL USO NOS TESTES
            //DrawHorizontalLine(Color.Red, 0, this.Width, centralVerticalLine);//-7 --- MARCAÇÃO HORIZONTAL VERTICAL USO NOS TESTES
            //
            DrawPie(centralHorizontalLine - (size / 2), centralVerticalLine - (size / (float)3.5), size, size, 0.0F, -180.0F);//HEAD
            //
            int eyeDistance = 140;//Distance between the eyes
            DrawCircle(Color.Black, centralHorizontalLine - eyeDistance, centralVerticalLine - 30);//LEFT EYE
            DrawCircle(Color.Black, centralHorizontalLine + eyeDistance, centralVerticalLine - 30);//RIGHT EYE
            //
            DrawAntenna(Color.LimeGreen, centralHorizontalLine - 257, (centralVerticalLine - 215), centralHorizontalLine, centralVerticalLine + 125);//LEFT ANTENNA
            DrawAntenna(Color.LimeGreen, centralHorizontalLine + 257, (centralVerticalLine - 215), centralHorizontalLine, centralVerticalLine + 125);//RIGHT ANTENNA
        }

        private void DrawHorizontalLine(Color color, int x1, int x2, int y)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), 2), x1, y, x2, y);
        }

        private void DrawVerticalLine(Color color, int x, int y1, int y2)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), 2), x, y1, x, y2);
        }

        private void DrawAntenna(Color color, int x1, int y1, int x2, int y2)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), 12), x1, y1, x2, y2);
        }

        private void DrawPie(float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            graphics.FillPie(new SolidBrush(Color.LimeGreen), x, y, width, height, startAngle, sweepAngle);
        }

        private void DrawCircle(Color color, int x, int y)
        {
            graphics = this.CreateGraphics();
            int size = 60;
            Rectangle rectangle = new Rectangle((x - (size / 2)), y, size, size);
            graphics.FillEllipse(new SolidBrush(color), rectangle);
        }
    }
}
