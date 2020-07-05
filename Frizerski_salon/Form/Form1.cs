using Frizerski_salon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frizerski_salon
{
    public partial class Form1 : Form
    {
        private FrizerskiContext context;
        private UnitOfWork unit;
        public Form1()
        {
            InitializeComponent();
            context = new FrizerskiContext();
            unit = new UnitOfWork(context);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var korisnicko = textBox4.Text;
            var sifra = textBox3.Text;
            string allowedchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            try
            {
                if (textBox4.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("You must fill in all fields");

                }
                else if (!textBox2.Text.All(allowedchar.Contains))
                {
                    MessageBox.Show("Check password");
                }
                else if (this.unit.Zaposlenii.CombinationExists(korisnicko, sifra, 'A'.ToString()) == true)
                {
                    this.Hide();
                    Addingstaff a = new Addingstaff();
                    a.Show();
                }
                else if (this.unit.Zaposlenii.CombinationExists(korisnicko, sifra, 'F'.ToString()) == true)
                {
                    this.Hide();
                    Salon s = new Salon();
                    s.Show();
                }
                else if (this.unit.Zaposlenii.CombinationExists(korisnicko, sifra, 'P'.ToString()) == true)
                {
                    this.Hide();
                    Salon s = new Salon();
                    s.Show();
                }
                else
                {
                    MessageBox.Show("User does not exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
    }
}
