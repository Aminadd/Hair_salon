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
    public partial class Addingstaff : Form
    {
        private FrizerskiContext context;
        private UnitOfWork unit;
        public Addingstaff()
        {
            InitializeComponent();
            context = new FrizerskiContext();
            unit = new UnitOfWork(context);
            var zaposleni = this.unit.Zaposlenii.GetAllZaposleni();
            dataGridView1.DataSource = (from a in zaposleni                                     
                                        select new
                                        {
                                            ID = a.IDZaposleni,
                                            Name = a.ime,
                                            Surname = a.prezime,
                                            Mobile_number = a.brTelefona,
                                            JMBG = a.JMBG,
                                            Username = a.korisnickoIme,
                                            Password = a.sifra,
                                            Type_of_employee = a.tipZaposlenog
                                        }).ToList();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("You must fill in all fields.");
                }
                else
                {
                    var novi = new Zaposleni
                    {
                        ime = textBox1.Text,
                        prezime = textBox2.Text,
                        brTelefona = textBox3.Text,
                        JMBG = textBox4.Text,
                        korisnickoIme = textBox5.Text,
                        sifra = textBox6.Text,
                        tipZaposlenog = textBox7.Text
                    };
                    this.unit.Zaposlenii.AddZaposleni(novi);
                    this.unit.Complete();
                    MessageBox.Show("A new staff has been added.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred, please check the information entered.");
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("You must select a client or fill in the blanks.");
                }
                else
                {
                    DialogResult Brisi;
                    Brisi = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Brisi == DialogResult.Yes)
                    {
                        int IDZaposleni = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        var zaposleni = this.unit.Zaposlenii.GetZaposleniByIDZaposleni(IDZaposleni);
                        this.unit.Zaposlenii.DeleteZaposleni(zaposleni);
                        this.unit.Complete();
                        MessageBox.Show("You have deleted the staff.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred, please check the information entered.");
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ime = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string prezime = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string brTelefona = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string JMBG = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                string korisnickoIme = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                string sifra = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                string tipZaposlenog = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;


                textBox1.Text = ime;
                textBox2.Text = prezime;
                textBox3.Text = brTelefona;
                textBox4.Text = JMBG;
                textBox5.Text = korisnickoIme;
                textBox6.Text = sifra;
                textBox7.Text = tipZaposlenog;
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
