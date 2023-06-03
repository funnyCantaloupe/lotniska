using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lotniska
{
    public partial class Form1 : Form
    {
      
        public Form2 form2;
        public Form1()
        {
            InitializeComponent();
            WczytajDaneZCSV("C:/Users/Administrator/source/repos/lotniska/DaneTestowe.csv");
            form2 = new Form2(this);
            
        }

        private void WczytajDaneZCSV(string sciezkaDoPliku)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();

            using (StreamReader sr = new StreamReader(sciezkaDoPliku))
            {
                listView1.Items.Clear();
                listView1.Columns.Clear();

                string[] naglowki = sr.ReadLine().Split(',');

                foreach (var naglowek in naglowki)
                {
                    listView1.Columns.Add(naglowek);
                }

                int liczbaPasażerówIndex = Array.IndexOf(naglowki, "Ofic. liczba pasażerów (2019)[1]");

                while (!sr.EndOfStream)
                {
                    string[] elementy = sr.ReadLine().Split(',');

                    ListViewItem item = new ListViewItem(elementy[0]);

                    for (int i = 1; i < elementy.Length; i++)
                    {
                        string wartośćPola = elementy[i].Trim();

                        if (i == liczbaPasażerówIndex)
                        {
                            item.SubItems.Add(wartośćPola);
                            break; 
                        }

                        item.SubItems.Add(wartośćPola);
                    }

                    listView1.Items.Add(item);
                }
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string kodICAO = selectedItem.SubItems[2].Text;  
                string kodIATA = selectedItem.SubItems[3].Text;  
                string liczbaPasażerów = selectedItem.SubItems[6].Text;  
                string województwo = selectedItem.SubItems[1].Text;  
                string miasto = selectedItem.SubItems[0].Text;  

                if (checkBox1.Checked)
                {
                    form2.label1.Text = kodICAO;
                }
                if (checkBox2.Checked)
                {
                    form2.label2.Text = kodIATA;
                }
                if (checkBox3.Checked)
                {
                    form2.label3.Text = liczbaPasażerów;
                }
                if (checkBox4.Checked)
                {
                    form2.label4.Text = województwo;
                }
               if (checkBox5.Checked)
                {
                    form2.label5.Text = miasto;
                }
            }
            else
            {
                form2.label1.Text = "";
                form2.label2.Text = "";
                form2.label3.Text = "";
                form2.label4.Text = "";
                form2.label5.Text = "";
            }
        }

        


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2.label1.Text = "";
            form2.label2.Text = "";
            form2.label3.Text = "";
            form2.label4.Text = "";
            form2.label5.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = form2.ShowDialog();

            
            if (result == DialogResult.OK)
            {
                
                string label1Value = form2.Label1Text;
                string label2Value = form2.Label2Text;
                string label3Value = form2.Label3Text;
                string label4Value = form2.Label4Text;
                string label5Value = form2.Label5Text;

                

                
                string filePath = "C:/Users/Administrator/source/repos/lotniska/szczegoly.csv";

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{label1Value},{label2Value},{label3Value},{label4Value},{label5Value}");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
           
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
          
            
        }
    }
}
