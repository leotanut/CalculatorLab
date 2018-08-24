using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        float num, num1;
        int y=0;
        string Operation;
        float ans;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }



        private void btn0_Click(object sender, EventArgs e)
        {
            lblDisplay.Text += "0";
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length<8)
            {
            if (lblDisplay.Text == "0" && lblDisplay.Text != null)
            {
                lblDisplay.Text = ((Button)sender).Text;
            }
            else
            {
                lblDisplay.Text += ((Button)sender).Text;

            }
            }
            
        }
        private void btnOperator_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            Operation = ((Button)sender).Text;

        }


        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Contains('.') == false)
            {
                lblDisplay.Text += ".";
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
           float x;
            num1 = float.Parse(lblDisplay.Text);
            x = num1 /100;
            num1 = x * num;
            y = 1;
        }

        private void btnEqual_Click_1(object sender, EventArgs e)
        {
            if (y != 1) { num1= float.Parse(lblDisplay.Text); }
            
            if (Operation == "+")
            {
                ans = num + num1;
            }
           else if (Operation == "-")
            {
                ans = num - num1;
            }
           else if (Operation == "X")
            {
                ans = num * num1;
            }
           else if (Operation == "÷")
            {
                ans = num / num1;
            }

            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = Convert.ToString(ans);
            }
            else
            {
               lblDisplay.Text = "ERROR";
            }
            y = 0;
        }


    }
}