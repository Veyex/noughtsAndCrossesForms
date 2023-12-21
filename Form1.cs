using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noughtsAndCrossesForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateGrid(ref this.buttonGrid, this.gridWidth, this.gridHeight);
        }

        public void GenerateGrid(ref Button[,] buttons, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Name = $"({i},{j})",
                        Width = 50,
                        Height = 50,
                        Location = new Point(i * 55 + 16, j * 55 + 45),
                        BackColor = Color.White,
                        Size = new Size(50, 50),
                        Visible = true
                    };
                    buttons[i, j].BringToFront();
                    buttons[i, j].Click += ButtonClick;
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            if (WinCheck(buttonGrid) == 0)
            {
                if (turnLabel.Text == "Turn: Noughts" && ctrl.Text == "")
                {
                    ctrl.Text = "O";
                    turnLabel.Text = "Turn: Crosses";
                }
                else if (turnLabel.Text == "Turn: Crosses" && ctrl.Text == "")
                {
                    ctrl.Text = "X";
                    turnLabel.Text = "Turn: Noughts";
                }
                buttonLabel.Text = $"Prior Move: {ctrl.Name}";
            }
            if (WinCheck(buttonGrid) == 1)
            {
                if (turnLabel.Text == "Turn: Noughts")
                {
                    winLabel.Text = "CROSSES WIN";
                }
                else if (turnLabel.Text == "Turn: Crosses")
                {
                    winLabel.Text = "NOUGHTS WIN";
                }
            }
            if (WinCheck(buttonGrid) == 2)
            {
                winLabel.Text = "DRAW";
            }
        }

        private int WinCheck(Button[,] grid)
        {
            int c = 0;
            for (int i = 0; i < gridWidth; i++)
            {
                if (grid[i,0].Text != "" && grid[i, 0].Text == grid[i, 1].Text && grid[i, 1].Text == grid[i, 2].Text){ return 1; }
                if (grid[0, i].Text != "" && grid[0, i].Text == grid[1, i].Text && grid[1, i].Text == grid[2, i].Text) { return 1; }
                if (grid[0, 0].Text != "" && grid[0, 0].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 2].Text) { return 1; }
                if (grid[0, 2].Text != "" && grid[0, 2].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 0].Text) { return 1; }
                for (int j = 0; j < gridWidth; j++)
                {
                    if (grid[i,j].Text != "")
                    {
                        c++;
                    }
                }
            }
            if (c == 9)
            {
                return 2;
            }
            return 0;
        }
    }
}
