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

            calc = new Core.Calc();
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
            var values = tbInput.Text
                .Split(' ')
                .Select(Convert.ToDouble)
                .ToArray();

            var operation = cbOperation.Text;

            var result = calc.Execute(operation, values, 2);

            lResult.Text = $"{result}";
        }
    }
}
