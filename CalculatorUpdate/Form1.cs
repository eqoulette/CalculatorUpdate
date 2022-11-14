#pragma warning disable CS8604

namespace CalculatorUpdate
{
    public partial class Form1 : Form
    {
        public string? action;
        public string? number1;
        public bool flag;

        public Form1()
        {
            flag = false;
            InitializeComponent();
        }


        /// <summary>
        /// Method for entering a number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Input(object sender, EventArgs e)
        {
            try
            {
                if (flag)
                {
                    flag = false;
                    textBox1.Text = "";
                }
                Button button = (Button)sender;
                textBox1.Text += button.Text;
                label1.Focus();
            }
            catch
            {
                MessageBox.Show("Error");
                textBox1.Text = "";
            }
        }

        /// <summary>
        /// Clear textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear(object sender, EventArgs e)
        {
            textBox1.Text = "";
            flag = true;
        }


        /// <summary>
        /// Operation sign button selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operation(object sender, EventArgs e)
        {
            if (!flag)
            {
                Button button = (Button)sender;
                action = button.Text;
                number1 = textBox1.Text;
                textBox1.Text += $" {action}";
                flag = true;
            }
        }

        /// <summary>
        /// The method calculates the result and output it to textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equal(object sender, EventArgs e)
        {
            try
            {
                if ((int.TryParse(number1 as string, out int value1)) && (int.TryParse(textBox1.Text as String, out int value2)))
                {
                    int result = 0;
                    switch (action)
                    {
                        case "+":
                            result = Calculate.Sum(value1, value2);
                            break;
                        case "-":
                            result = Calculate.Minus(value1, value2);
                            break;
                        case "*":
                            result = Calculate.Multiple(value1, value2);
                            break;
                        case "/":
                            if (value2 != 0) result = Calculate.Devide(value1, value2);
                            else
                            {
                                MessageBox.Show("NOT / 0", "Error");
                                Clear(sender, e);
                            }

                            break;
                        default:
                            break;
                    }
                    textBox1.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Length exceeds 9 characters", "EXCEEDED");
                    Clear(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        /// <summary>
        /// Changes the sign of a number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Swap(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = (int.Parse(textBox1.Text) * (-1)).ToString();
            }
        }

        /// <summary>
        /// Method for keyboard input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.NumPad1) || e.KeyData.Equals(Keys.D1))
            {
                button1.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad2) || e.KeyData.Equals(Keys.D2))
            {
                button2.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad3) || e.KeyData.Equals(Keys.D3))
            {
                button3.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad4) || e.KeyData.Equals(Keys.D4))
            {
                button4.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad5) || e.KeyData.Equals(Keys.D5))
            {
                button5.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad6) || e.KeyData.Equals(Keys.D6))
            {
                button6.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad7) || e.KeyData.Equals(Keys.D7))
            {
                button7.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad8) || e.KeyData.Equals(Keys.D8))
            {
                button8.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad9) || e.KeyData.Equals(Keys.D9))
            {
                button9.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.D0) || e.KeyData.Equals(Keys.D0))
            {
                button10.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Enter))
            {
                Equal(sender, e);
            }

            if (e.KeyCode.Equals(Keys.Subtract))
            {
                SubstractButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Add))
            {
                SumButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Multiply))
            {
                MultiplyButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Divide))
            {
                DivideButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Back))
            {
                if (!flag)
                {
                    if (textBox1.TextLength != 1)
                    {
                        textBox1.Text = textBox1.Text[..^1];
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }

                }
            }
        }
    }
}