using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0vsX
{

    public partial class Form1 : Form
    {
        int x = 101; int y = 31;
        private Button[,] btns = new Button[3, 3];
        private int player;

        public Form1()
        {
            InitializeComponent();
            player = 1;
            label1.Text = "Player 1";
            for (int i = 0; i < btns.Length / 3; i++)
            {
                for (int j = 0; j < btns.Length / 3; j++)
                {
                    btns[i, j] = new Button();
                    btns[i, j].Size = new Size(100, 100);
                    btns[i, j].Click += button1_Click;
                }
                y += 106;

            }
            SetBut();

        }
        private void SetBut()
        {
            for (int i = 0; i < btns.Length / 3; i++)
            {
                for (int j = 0; j < btns.Length / 3; j++)
                {
                    btns[i, j].Location = new Point(16 + 101 * j, 15 + 101 * i);

                    btns[i, j].Font = new Font(FontFamily.GenericSansSerif, 50);
                    this.Controls.Add(btns[i, j]);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SetBut();
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "X");

                    player = 0;
                    label1.Text = "Player 2";
                    break;

                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "O");

                    player = 1;
                    label1.Text = "Player 1";
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            WinCheck();
        }
        public void WinCheck()
        {
            for (int i = 0; i < 3; i++)
            {
                int cw = 0;
                int rw = 0;
                for (int j = 0; j < 3; j++)
                {

                    if (btns[i, j].Text == "X")
                    {
                        cw++;
                        if (cw == 3)
                        {
                            msg();
                        }

                    }
                    if (btns[i, j].Text == "O")
                    {
                        cw--;
                        if (cw == -3)
                        {
                            msg();
                        }
                    }

                }
                for (int j = 0; j < 3; j++)
                {

                    if (btns[j, i].Text == "X")
                    {
                        rw++;
                        if (rw == 3)
                        {
                            msg();
                        }
                    }
                    if ((btns[j, i].Text == "O"))
                    {

                        rw--;
                        if (rw == -3)
                        {
                            msg();
                        }
                    }
                }
            }
            if (btns[0, 0].Text == btns[1, 1].Text && btns[1, 1].Text == btns[2, 2].Text && btns[1,1].Text != "")
            {
                msg();
            }
            if (btns[0, 2].Text == btns[1, 1].Text && btns[1, 1].Text == btns[2, 0].Text && btns[1, 1].Text != "")
            {
                msg();
            }

        }

            public void msg()
            {
                MessageBox.Show("WINNER");
                for (int o = 0; o < 3; o++)
                {
                    for (int p = 0; p < 3; p++)
                    {
                        btns[p, o].Enabled = false;
                    }
                }
            }

          

        private void button1_Click_2(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btns[i, j].Text = "";
                    btns[i, j].Enabled = true;
                }
            }
        }
    }
    }

