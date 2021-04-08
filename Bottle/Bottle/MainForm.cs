using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using BottleNew;

namespace Bottle
{
    public partial class MainForm : Form
    {

        private readonly KompasConnector _kompasConnector;

        private readonly Dictionary<TextBox, string> _oldValues;

        public MainForm(KompasConnector kompasConnector)
        {
            _kompasConnector = kompasConnector;
            _oldValues = new Dictionary<TextBox, string>();
            InitializeComponent();
            SetData();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LengthFullBottleTextBox.Text = "";
            BaseLengthTextBox.Text = "";
            BottleneckLengthTextBox.Text = "";
            BaseDiameterTextBox.Text = "";
            BottleneckDiameterTextBox.Text = "";
        }

        private void SetDataButton_Click(object sender, EventArgs e)
        {
            SetData();
        }

        private void SetData()
        {
            LengthFullBottleTextBox.Text = "135";
            BaseLengthTextBox.Text = "77";
            BottleneckLengthTextBox.Text = "22";
            BaseDiameterTextBox.Text = "60";
            BottleneckDiameterTextBox.Text = "20";
        }

        private void StartKompasButton_Click(object sender, EventArgs e)
        {
            _kompasConnector.Start();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                var baseDiametr = double.Parse(BaseDiameterTextBox.Text);
                var baseLength = double.Parse(BaseLengthTextBox.Text);
                var bottleneckDiameter = double.Parse(BottleneckDiameterTextBox.Text);
                var bottleneckLength = double.Parse(BottleneckLengthTextBox.Text);
                var lengthFullBottle = double.Parse(LengthFullBottleTextBox.Text);

                var bottleParametrs = new BottleParameters(baseDiametr, baseLength, bottleneckDiameter,
                    bottleneckLength, lengthFullBottle);
                _kompasConnector.Start();
                var document3D = _kompasConnector.CreateDocument3D();

                var bottleBuilder = new BottleBuilder(document3D, bottleParametrs);

                bottleBuilder.BuildBottle();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Построение бутылки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Построение бутылки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!CheckDoubleString(textBox.Text))
                textBox.Text = _oldValues[textBox];

            _oldValues[textBox] = textBox.Text;
            textBox.SelectionStart = textBox.Text.Length;
        }

        private static bool CheckDoubleString(string doubleString)
        {
            if (double.TryParse(doubleString, out _))
                return true;

            if (doubleString.LastOrDefault().ToString() ==
                CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator &&
                doubleString.Count(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.First().Equals) <=
                1)
                return true;

            if (string.IsNullOrWhiteSpace(doubleString))
                return true;

            return false;
        }
    }
}
