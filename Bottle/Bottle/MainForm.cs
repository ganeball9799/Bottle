using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using BottleNew;
using BottleParametrs;

namespace Bottle
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр конектора
        /// </summary>
        private KompasConnector _kompasConnector;

        /// <summary>
        /// Словарь данных
        /// </summary>
        private Dictionary<TextBox, string> _inputValues;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="kompasConnector"></param>
        public MainForm(KompasConnector kompasConnector)
        {
            _kompasConnector = kompasConnector;
            _inputValues = new Dictionary<TextBox, string>();
            InitializeComponent();
            SetData();
        }

        /// <summary>
        /// Очистка полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            LengthFullBottleTextBox.Text = "";
            BaseLengthTextBox.Text = "";
            BottleneckLengthTextBox.Text = "";
            BaseDiameterTextBox.Text = "";
            BottleneckDiameterTextBox.Text = "";
        }

        /// <summary>
        /// Кнопка заполнения полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDataButton_Click(object sender, EventArgs e)
        {
            SetData();
        }

        /// <summary>
        /// Заполение полей
        /// </summary>
        private void SetData()
        {
            LengthFullBottleTextBox.Text = "135";
            BaseLengthTextBox.Text = "77";
            BottleneckLengthTextBox.Text = "22";
            BaseDiameterTextBox.Text = "60";
            BottleneckDiameterTextBox.Text = "25";
        }

        /// <summary>
        /// Запуск Компаса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartKompasButton_Click(object sender, EventArgs e)
        {
            _kompasConnector.Start();
        }

        /// <summary>
        /// Строит бутылку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                var baseDiametr = double.Parse(BaseDiameterTextBox.Text);
                var baseLength = double.Parse(BaseLengthTextBox.Text);
                var bottleneckDiameter = double.Parse(BottleneckDiameterTextBox.Text);
                var bottleneckLength = double.Parse(BottleneckLengthTextBox.Text);
                var lengthFullBottle = double.Parse(LengthFullBottleTextBox.Text);

                var bottleParametrs = new BottleParameters(baseDiametr, baseLength, 
                    bottleneckDiameter, bottleneckLength, lengthFullBottle);
                _kompasConnector.Start();
                var document3D = _kompasConnector.CreateDocument3D();

                var bottleBuilder = new BottleBuilder(document3D, bottleParametrs,_kompasConnector);

                bottleBuilder.BuildBottle();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Построение бутылки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Свойство обработки полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

             if (!CheckDoubleString(textBox.Text))
             {
                 textBox.Text = _inputValues[textBox];
             }

             _inputValues[textBox] = textBox.Text;
            textBox.SelectionStart = textBox.Text.Length;
        }

        /// <summary>
        /// Проверка введных данных
        /// </summary>
        /// <param name="doubleString"></param>
        /// <returns></returns>
        private static bool CheckDoubleString(string doubleString)
        {
             if (double.TryParse(doubleString, out _))
             {
                 return true;
             }

             var separatorSymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

             if (doubleString.LastOrDefault().ToString() == separatorSymbol
                  && doubleString.Count(separatorSymbol.First().Equals) <= 1)
             {
                 return true;
             }

             return string.IsNullOrWhiteSpace(doubleString);
        }
    }
}
