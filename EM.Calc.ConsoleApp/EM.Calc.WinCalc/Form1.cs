using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM.Calc.WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            helpText();

            calc = new Core.Calc();
        }

        private void helpText()
        {
            cbOperation.Text = "Выберите операцию";

            tbInput.Text = "Какие ваши аргументы";
            tbInput.ForeColor = Color.Gray;
        }

        private Core.Calc calc { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] operations = calc.Operations
                .Select(o => o.Name)
                .ToArray();

            cbOperation.Items.AddRange(operations);


        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            var str = System.Text.RegularExpressions.Regex.Replace(tbInput.Text, @"\s+", " ");

            try {
                var values = str.Split(' ')
                    .Select(Convert.ToDouble)
                    .ToArray();

                var operation = cbOperation.Text;

                var result = calc.Execute(operation, values);

                lResult.Text = $"{result}";
            }
            catch(Exception ex)
            {

            }
        }
        
        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            var symbol = e.KeyChar;

            // Проверка на ввод цифр и запятой
            if (char.IsDigit(symbol) == true || symbol != 43 || symbol != 45) return;

            // Доступ в Backspace и Space
            if (e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Space)) return;
            
            e.Handled = true;
        }
        
        private void tbInput_Enter(object sender, EventArgs e)
        {
                tbInput.Text = null;
                tbInput.ForeColor = Color.Black;
        }

        private void tbInput_Leave(object sender, EventArgs e)
        {
            if(tbInput.Text == "")
            {
                tbInput.Text = "Какие ваши аргументы";
                tbInput.ForeColor = Color.Gray;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cbOperation.Text = "sum";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbOperation.Text = "pow";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cbOperation.Text = "new";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cbOperation.Text = "ras";
        }

        private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operation = calc.Operations
                .OfType<IExtOperation>()
                .FirstOrDefault(o => o.Name == cbOperation.Text);

            if (operation != null)
            {
                toolTip1.SetToolTip(cbOperation, operation.Description);
            }
            else
            {
                toolTip1.SetToolTip(cbOperation, "Старая операция");
            }
        }
    }
}
