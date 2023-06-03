using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lotniska
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public string Label1Text { get; set; }
        public string Label2Text { get; set; }
        public string Label3Text { get; set; }
        public string Label4Text { get; set; }
        public string Label5Text { get; set; }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Przypisanie wartości labeli do właściwości
            Label1Text = label1.Text;
            Label2Text = label2.Text;
            Label3Text = label3.Text;
            Label4Text = label4.Text;
            Label5Text = label5.Text;

            // Zamknięcie Form2 z wynikiem OK
            DialogResult = DialogResult.OK;
            Close();
            this.Hide();
        }
    }
}
