using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegFarm
{
    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        Money money = new Money();
        int timeSec = 0, timeMin = 0;
        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in tableLayoutPanel1.Controls)
                field[cb] = new Cell();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
            foreach (CheckBox cb in tableLayoutPanel1.Controls)
            {
                if(field[cb].GetState() != CellState.Empty)
                {
                    field[cb].NextTick();
                    UpdateBox(cb);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                field[cb].Plant();
                money.Deposit();
            }
            else
            {
                money.Income(field[cb].GetState());
                field[cb].Harvest();
            }
            UpdateBox(cb);
            UpdateMoney();
        }
        
        private void UpdateTime()
        {
            timeSec++;
            if (timeSec >= 60)
            {
                timeSec = 0;
                timeMin++;
            }
            secondsLabel.Text = timeSec.ToString();
            if(timeMin >= 60)
            {
                timeMin = 0;
            }
            minutes2Label.Text = timeMin.ToString();
        }

        private void UpdateMoney()
        {
            moneyLabel.Text = money.GetCurrentMoney().ToString();
        }
        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;
            switch (field[cb].GetState())
            {
                case CellState.Planted:
                    c = Color.Black;
                    break;
                case CellState.Green:               
                    c = Color.Green;
                    break;
                case CellState.Immature:
                    c = Color.Yellow;
                    break;
                case CellState.Mature:
                    c = Color.Red;
                    break;
                case CellState.Overgrow:
                    c = Color.Brown;
                    break;
            }
            cb.BackColor = c;
        }

        private void Button05X(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
        }

        private void Button1X(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void Button2X(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }

        private void Button4X(object sender, EventArgs e)
        {
            timer1.Interval = 250;
        }
    }

    enum CellState
    {
        Empty,
        Planted,
        Green,
        Immature,
        Mature, 
        Overgrow
    }
}
