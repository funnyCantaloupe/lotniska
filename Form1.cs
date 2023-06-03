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
        public Form1()
        {
            InitializeComponent();
        }

        private void WczytajDaneZCSV(string sciezkaDoPliku)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();

            using (StreamReader sr = new StreamReader(sciezkaDoPliku))
            {
                string linia;
                bool pierwszyWiersz = true;

                while ((linia = sr.ReadLine()) != null)
                {
                    string[] elementy = linia.Split(',');

                    if (pierwszyWiersz)
                    {
                        foreach (var element in elementy)
                        {
                            listView1.Columns.Add(element);
                        }
                        pierwszyWiersz = false;
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(elementy[0]);

                        for (int i = 1; i < elementy.Length; i++)
                        {
                            item.SubItems.Add(elementy[i]);
                        }

                        listView1.Items.Add(item);
                    }
                }
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WczytajDaneZCSV("C:/Users/Administrator/source/repos/lotniska/DaneTestowe.csv");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
