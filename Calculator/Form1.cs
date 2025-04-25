using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isClearing = false;
        private bool suppressError = false;
        double num;
        double result;

        private void button1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "1"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ".";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "+";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ":";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "*";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out num) && num != 0)
                txtDisplay.Text = (Math.Sqrt(num)).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "%";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out num)) 
            {
                num = -num;
                txtDisplay.Text = num.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out num) && num != 0)
            {
                txtDisplay.Text = (1 / num).ToString();
            }
            else
            {
                txtDisplay.Text = "Cannot divided by zero";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CalculateExpression(txtDisplay.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == result.ToString())
            {
                return;
            }

            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                if (txtDisplay.Text.Length == 0)
                {
                    txtDisplay.Clear();
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void txtDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateExpression(txtDisplay.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CalculateExpression(string expression)
        {
            try
            {
                if (Regex.IsMatch(expression, @"/\s*0+(\.0+)?\s*(?!\d)"))
                {
                    txtDisplay.Text = "Cannot divide by zero";
                    return;
                }
                var result = new System.Data.DataTable().Compute(expression, null);
                txtDisplay.Text = result.ToString();
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            if (isClearing || suppressError) return;

            if (Regex.IsMatch(txtDisplay.Text, @"\p{L}"))
            {
                suppressError = true;
                txtDisplay.Text = null;
                MessageBox.Show("Enter the correct number value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                suppressError = false;
            }
        }
    }
}
