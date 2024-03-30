using System;
using System.Windows.Forms;

namespace GuiFractionCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Set the tab order
            SetTabOrder();
            // Add event handlers
            AddEventHandlers();
        }

        private void SetTabOrder()
        {
            textBox1.TabIndex = 0;
            textBox2.TabIndex = 1;
            textBox3.TabIndex = 2;
            textBox4.TabIndex = 3;
            textBox5.TabIndex = 4;
            textBox6.TabIndex = 5;
            radioButton1.TabIndex = 6;
            radioButton2.TabIndex = 7;
            radioButton3.TabIndex = 8;
            radioButton4.TabIndex = 9;
            button1.TabIndex = 10;
            button2.TabIndex = 11;
            button3.TabIndex = 12;
        }

        private void AddEventHandlers()
        {
            // Button click event handler
            button1.Click += Button1_Click;
            button2.Click += Button2_Click; // Clear button
            button3.Click += Button3_Click; // Simplify button
            // Textbox key press event handler
            textBox1.KeyPress += TextBox_KeyPress;
            textBox2.KeyPress += TextBox_KeyPress;
            textBox3.KeyPress += TextBox_KeyPress;
            textBox4.KeyPress += TextBox_KeyPress;
            textBox5.KeyPress += TextBox_KeyPress;
            textBox6.KeyPress += TextBox_KeyPress;
            // Radio button check changed event handler
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            radioButton4.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Allow digits and backspace
                e.Handled = true; // discard the non-digit entries
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Invoke calculation when radio button changes
            DoCalculation();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Invoke calculation when button is clicked
            DoCalculation();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Simplify the result
            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                int numerator = int.Parse(textBox5.Text);
                int denominator = int.Parse(textBox6.Text);
                int gcd = GCD(numerator, denominator);
                textBox5.Text = (numerator / gcd).ToString();
                textBox6.Text = (denominator / gcd).ToString();
            }
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void DoCalculation()
        {
            // Determine operation based on checked radio button
            string operation = "";
            if (radioButton1.Checked)
                operation = "-";
            else if (radioButton2.Checked)
                operation = "*";
            else if (radioButton3.Checked)
                operation = "+";
            else if (radioButton4.Checked)
                operation = "/";

            // Get operands
            int num1 = int.Parse(textBox1.Text);
            int denom1 = int.Parse(textBox2.Text);
            int num2 = int.Parse(textBox3.Text);
            int denom2 = int.Parse(textBox4.Text);

            // Perform operation
            Fraction result = new Fraction(num1, denom1);
            switch (operation)
            {
                case "+":
                    result += new Fraction(num2, denom2);
                    break;
                case "-":
                    result -= new Fraction(num2, denom2);
                    break;
                case "*":
                    result *= new Fraction(num2, denom2);
                    break;
                case "/":
                    result /= new Fraction(num2, denom2);
                    break;
            }

            // Display result
            textBox5.Text = result.Top.ToString();
            textBox6.Text = result.Bottom.ToString();
        }
    }
}
