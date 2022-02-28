using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeNew
{
    public partial class Form1 : Form
    {
        bool direita, esquerda, cima, baixo;
        PictureBox[] lsnake = new PictureBox[50];
        PictureBox comida = new PictureBox();
        int ncorpo = 0;
        int pontos = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            lsnake[0] = snake;
            Comida();
            snake.Location = new Point(200,300);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    cima = true; baixo = false; direita = false; esquerda = false;
                    break;
                case Keys.Down:
                    cima = false; baixo = true; direita = false; esquerda = false;
                    break;
                case Keys.Left:
                    cima = false; baixo = false; direita = false; esquerda = true;
                    break;
                case Keys.Right:
                    cima = false; baixo = false; direita = true; esquerda = false;
                    break;
            }
        }
        void Comida()
        {
            Random rand = new Random();
            comida.BackColor = Color.Green;
            comida.Size = new Size(10,10);
            comida.Location = new Point(rand.Next(1, 80) * 10, rand.Next(1, 60) * 10);
            this.Controls.Add(comida);
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = ncorpo; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (cima)
                        lsnake[0].Location = new Point(lsnake[0].Location.X, lsnake[0].Location.Y - 10);
                    if (baixo)
                        lsnake[0].Location = new Point(lsnake[0].Location.X, lsnake[0].Location.Y + 10);
                    if (esquerda)
                        lsnake[0].Location = new Point(lsnake[0].Location.X - 10, lsnake[0].Location.Y);
                    if (direita)
                        lsnake[0].Location = new Point(lsnake[0].Location.X + 10, lsnake[0].Location.Y);

                }
                else if (ncorpo > 0)
                {
                    lsnake[i].Location = new Point(lsnake[i - 1].Location.X, lsnake[i - 1].Location.Y);
                }
            }
            if (comida.Location.X == snake.Location.X && comida.Location.Y == snake.Location.Y)
            {
                Comida();
                ncorpo += 1;
                PictureBox corpo = new PictureBox();
                lsnake[ncorpo] = corpo;
                corpo.Location = new Point(lsnake[ncorpo].Location.X, lsnake[ncorpo].Location.Y);
                corpo.Width = 10;
                corpo.Height = 10;
                corpo.BackColor = Color.Blue;
                this.Controls.Add(corpo);
                pontos += 10;
                label1.Text = "Pontos: " + pontos;
            }
        }
    }
}
