using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frizerski_salon.Data;

namespace Frizerski_salon.User_controls
{
    public partial class receivingClientsUC : UserControl
    {
        private FrizerskiContext context;
        private UnitOfWork unit;

        public receivingClientsUC()
        {
            InitializeComponent();
            context = new FrizerskiContext();
            unit = new UnitOfWork(context);
            var klijenti = this.unit.Klijentt.GetAllKlijent();
            dataGridView1.DataSource = (from a in klijenti
                                        select new
                                        {
                                            ID = a.IDKlijent,
                                            Name = a.ime,
                                            Surname = a.prezime,
                                            JMBG = a.JMBG,
                                            Mobile_number = a.brTel,                                        
                                            Hair_type = a.tipKose,
                                            Hair_length = a.duzinaKose,
                                            Hair_washing_preparations = a.preparatiZaPranje,
                                            Hair_styling_preparations = a.oblikovanjeKose
                                        }).ToList();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("You must fill in all fields.");
                }
                else
                {
                    var novi = new Klijent
                    {
                        ime = textBox1.Text,
                        prezime = textBox2.Text,
                        JMBG = textBox3.Text,
                        brTel = textBox4.Text,
                        tipKose = textBox5.Text,
                        duzinaKose = int.Parse(textBox6.Text),
                        preparatiZaPranje = textBox7.Text,
                        oblikovanjeKose = comboBox1.Text
                    };
                    this.unit.Klijentt.AddKlijent(novi);
                    this.unit.Complete();
                    MessageBox.Show("A new client has been added.");
                }
            }
            catch(Exception ex)
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
            comboBox1.Text = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("You must select a client or fill in the blanks.");
                }
                else
                {
                    DialogResult Brisi;
                    Brisi = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if(Brisi == DialogResult.Yes)
                    {
                          int IDKlijenta = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                          var klijent = this.unit.Klijentt.GetKlijentByIDKlijent(IDKlijenta);
                          this.unit.Klijentt.DeleteKlijent(klijent);
                          this.unit.Complete();
                          MessageBox.Show("You have deleted the client.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred, please check the information entered.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ime = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string prezime = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string JMBG = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string brTel = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                string tipKose = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                string duzinaKose = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                string preparatiZaPranje = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                string oblikovanjeKose = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;


                textBox1.Text = ime;
                textBox2.Text = prezime;
                textBox3.Text = JMBG;
                textBox4.Text = brTel;
                textBox5.Text = tipKose;
                textBox6.Text = duzinaKose;
                textBox7.Text = preparatiZaPranje;
                comboBox1.Text = oblikovanjeKose;
            }
        }     
    }
}
