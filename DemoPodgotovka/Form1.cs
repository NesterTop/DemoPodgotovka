using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPodgotovka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(DataBase db = new DataBase())
            {
               dataGridView1.DataSource =  db.ExecuteSql("select * from TipRashoda");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";

            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if(dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        str += dataGridView1.Rows[i].Cells[j].Value.ToString() + " ";
                    }
                }
                
                str += Environment.NewLine;
            }

            using(SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.FileName = "Log";
                fileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Файл формата csv (*.csv)|*.csv";
                fileDialog.ShowDialog();
                File.WriteAllText(fileDialog.FileName, str);
            }
        }
    }
}
