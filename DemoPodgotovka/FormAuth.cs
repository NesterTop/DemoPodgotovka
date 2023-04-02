using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPodgotovka
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            using(DataBase db = new DataBase())
            {
                var dt = db.ExecuteSql($"select * from Users where UserLogin = '{login}' and UserPassword = '{password}'");

                if(dt.Rows.Count != 0)
                {
                    Form1 form = new Form1();
                    if((int)dt.Rows[0].ItemArray[1] == 1)
                    {
                        form.BackColor = Color.Red;
                    }
                    else
                    {
                        form.BackColor = Color.Green;
                    }

                    form.Show();
                    this.Hide();
                }
            }
        }
    }
}
