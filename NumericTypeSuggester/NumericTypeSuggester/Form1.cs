using System.Numerics;
using System.Text.RegularExpressions;

namespace NumericTypeSuggester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isInputValid((TextBox)sender, e.KeyChar))
            {
                e.Handled = true;
            }
            //update result
        }

        private bool isInputValid(TextBox textBox, char input)
        {
            if (textBox.Text.Length == 0 && input == '-')
            {
                return true;
            }
            else if (char.IsControl(input) || char.IsDigit(input))
            {
                return true;
            }

            return false;
        }

        private void IntegralCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreciseLabel.Visible = !IntegralCheckBox.Checked;
            PreciseCheckBox.Visible = !IntegralCheckBox.Checked;
            PreciseCheckBox.Checked = false;

            //update result;
            ResultLabel.Text = "Cheked?" + IntegralCheckBox.Checked;
            UpdateResult();
        }

        private void PreciseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //update result;
            UpdateResult();
        }

        private void UpdateResult()
        {
            bool isIntegral = IntegralCheckBox.Checked;
            MaxValueTextBox.BackColor = Color.White;

            if (!IsNumber(MinValueTextBox.Text) || !IsNumber(MaxValueTextBox.Text))
            {
                ResultLabel.Text = "Suggested Type: not enough data";
                return;
            }

            if (isIntegral)
            {
                CheckIntegral();
            }
            else
            {
                CheckNonIntegral();
            }

        }

        private void CheckIntegral()
        {
            string result = "";

            if (IsSigned(MinValueTextBox.Text) || IsSigned(MaxValueTextBox.Text))
            {
                bool minSuccess = long.TryParse(MinValueTextBox.Text, out long minValue);
                bool maxSuccess = long.TryParse(MaxValueTextBox.Text, out long maxValue);

                //signed sbyte, short, int, long
                if (!minSuccess || !maxSuccess)
                {
                    result = "BigInteger";
                }
                else if (maxValue < minValue)
                {
                    result = "Invalid Max Value";
                    MaxValueTextBox.BackColor = Color.Red;
                }
                else if (sbyte.MinValue <= minValue && sbyte.MaxValue >= maxValue)
                {
                    result = "sbyte";
                }
                else if (short.MinValue <= minValue && short.MaxValue >= maxValue)
                {
                    result = "short";
                }
                else if (int.MinValue <= minValue && int.MaxValue >= maxValue)
                {
                    result = "int";
                }
                else if (long.MinValue <= minValue && long.MaxValue >= maxValue)
                {
                    result = "long";
                }
            }
            else
            {
                bool minSuccess = ulong.TryParse(MinValueTextBox.Text, out ulong minValue);
                bool maxSuccess = ulong.TryParse(MaxValueTextBox.Text, out ulong maxValue);

                //signed byte, ushort, uint, ulong
                if (!minSuccess || !maxSuccess)
                {
                    result = "BigInteger";
                }
                else if (maxValue < minValue)
                {
                    result = "Invalid Max Value";
                    MaxValueTextBox.BackColor = Color.Red;
                }
                else if (byte.MinValue <= minValue && byte.MaxValue >= maxValue)
                {
                    result = "sbyte";
                }
                else if (ushort.MinValue <= minValue && ushort.MaxValue >= maxValue)
                {
                    result = "short";
                }
                else if (uint.MinValue <= minValue && uint.MaxValue >= maxValue)
                {
                    result = "int";
                }
                else if (ulong.MinValue <= minValue && ulong.MaxValue >= maxValue)
                {
                    result = "long";
                }
            }

            ResultLabel.Text = "Suggested Type: " + result;

        }

        private void CheckNonIntegral()
        {
            bool isPrecise = PreciseCheckBox.Checked;
            string result = "";

            if (isPrecise)
            {
                bool minSuccess = decimal.TryParse(MinValueTextBox.Text, out decimal minValue);
                bool maxSuccess = decimal.TryParse(MaxValueTextBox.Text, out decimal maxValue);

                //signed float, double
                if (!minSuccess || !maxSuccess)
                {
                    result = "Impossible representation";
                }
                else if (maxValue < minValue)
                {
                    result = "Invalid Max Value";
                    MaxValueTextBox.BackColor = Color.Red;
                }
                else if (decimal.MinValue <= minValue && decimal.MaxValue >= maxValue)
                {
                    result = "decimal";
                }
            }
            else
            {
                bool minSuccess = double.TryParse(MinValueTextBox.Text, out double minValue);
                bool maxSuccess = double.TryParse(MaxValueTextBox.Text, out double maxValue);

                //signed float, double
                if (double.IsInfinity(minValue) || double.IsInfinity(maxValue))
                {
                    result = "Impossible representation";
                }
                else if (maxValue < minValue)
                {
                    result = "Invalid Max Value";
                    MaxValueTextBox.BackColor = Color.Red;
                }
                else if (float.MinValue <= minValue && float.MaxValue >= maxValue)
                {
                    result = "float";
                }
                else if (double.MinValue <= minValue && double.MaxValue >= maxValue)
                {
                    result = "double";
                }
            }

            ResultLabel.Text = "Suggested Type: " + result;
        }

        private bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^-?\d+$");

            return regex.IsMatch(text);
        }

        private bool IsSigned(string text)
        {
            return text[0] == '-';
        }

        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }
    }
}