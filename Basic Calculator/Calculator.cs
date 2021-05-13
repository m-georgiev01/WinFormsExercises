using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        List<double> numbers = new List<double> { 0, 0};
        string operation;
        double memory;
        public Calculator()
        {
            InitializeComponent();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            BtnClick("7");
        }
        private void BtnClick(string number)
        {
            if (tbInput.Text == "0")
            {
                tbInput.Text = number;
            }
            else
            {
                tbInput.Text = tbInput.Text + number;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            BtnClick("8");
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            BtnClick("9");
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            BtnClick("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            BtnClick("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            BtnClick("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            BtnClick("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            BtnClick("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            BtnClick("3");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            BtnClick("0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbInput.Text = "0";
            operation = null;
            lblStepenuvane.Visible = false;
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = 0;
            }
        }
        private void btnComa_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Contains(","))
            {
                return;
            }
            tbInput.Text += ",";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Operations("+");
        }
        private void Operations (string a)
        {
            numbers[0] = double.Parse(tbInput.Text);
            tbInput.Text = "0";
            operation = a;
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Operations("-");
        }
        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            Operations("*");
        }
        private void btnDivision_Click(object sender, EventArgs e)
        {
            Operations("/");
        }
        private void btnStepenuvane_Click(object sender, EventArgs e)
        {
            Operations("^");

            lblStepenuvane.Visible = true;
        }
        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            numbers[0] = double.Parse(tbInput.Text);
            tbInput.Text = (Math.Sqrt(Math.Abs(numbers[0]))).ToString();
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            numbers[1] = double.Parse(tbInput.Text);
 

            switch (operation)
            {
                case "+":
                    tbInput.Text = (numbers[0] + numbers[1]).ToString();
                    operation = null;
                    numbers[0] = 0;
                    break;
                case "-":
                    tbInput.Text = (numbers[0] - numbers[1]).ToString();
                    operation = null;
                    numbers[0] = 0;
                    break;
                case "*":
                    tbInput.Text = (numbers[0] * numbers[1]).ToString();
                    operation = null;
                    numbers[0] = 0;
                    break;
                case "/":
                    tbInput.Text = (numbers[0] / numbers[1]).ToString();
                    operation = null;
                    numbers[0] = 0;
                    break;
                case "^":
                    tbInput.Text = (Math.Pow(numbers[0], numbers[1])).ToString();
                    operation = null;
                    lblStepenuvane.Visible = false;
                    numbers[0] = 0;
                    break;
                default:
                    break;
            }
        }

        private void btnMClear_Click(object sender, EventArgs e)
        {
            memory = 0;
            tbInput.Text = "0";
            btnMClear.Enabled = false;
            btnMResult.Enabled = false;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            if (numbers[0] == 0)
            {
                MessageBox.Show("Invalid operation!");
                return;
            }
            btnResult_Click(sender,e);
            memory += double.Parse(tbInput.Text);
            tbInput.Text = "0";
            btnMClear.Enabled = true;
            btnMResult.Enabled = true;
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            if (numbers[0] == 0)
            {
                MessageBox.Show("Invalid operation!");
                return;
            }
            btnResult_Click(sender, e);
            memory -= double.Parse(tbInput.Text);
            tbInput.Text = "0";
            btnMClear.Enabled = true;
            btnMResult.Enabled = true;
        }

        private void btnMResult_Click(object sender, EventArgs e)
        {
            tbInput.Text = memory.ToString();
        }
    }
}
