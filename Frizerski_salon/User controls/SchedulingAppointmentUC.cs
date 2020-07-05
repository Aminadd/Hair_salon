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
    public partial class SchedulingAppointmentUC : UserControl
    {
        private FrizerskiContext context;
        private UnitOfWork unit;
        public SchedulingAppointmentUC()
        {
            InitializeComponent();
            context = new FrizerskiContext();
            unit = new UnitOfWork(context);
            var termin = this.unit.Terminn.GetAllTermin();
            var klijent = this.unit.Klijentt.GetAllKlijent();
            var usluga = this.unit.Uslugaa.GetAllUsluga();
            dataGridView1.DataSource = (from a in termin
                                        join b in klijent on a.KlijentID equals b.IDKlijent
                                        join c in usluga on a.UslugaID equals c.IDUsluga
                                        where a.KlijentID == b.IDKlijent
                                        where a.UslugaID == c.IDUsluga
                                        select new
                                        {
                                            Time = a.vreme,
                                            Name = a.imeiprezime,
                                            IDClient = b.IDKlijent,
                                            IDService = c.IDUsluga
                                        }).ToList();


            var klijentt = this.unit.Klijentt.GetAllKlijent();
            comboBox2.Items.Clear();
            foreach(var k in klijent)
            {
                comboBox2.Items.Add(k.ime.ToString());
                comboBox3.Items.Add(k.IDKlijent.ToString());
            }
            var uslugaa = this.unit.Uslugaa.GetAllUsluga();
            foreach(var u in usluga)
            {
                comboBox4.Items.Add(u.IDUsluga.ToString());
            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(comboBox1);
            try
            {
                var novi = new Termin
                {
                    vreme = comboBox1.Text,
                    imeiprezime = comboBox2.Text,
                    KlijentID = int.Parse(comboBox3.Text),
                    UslugaID =int.Parse(comboBox4.Text)
                };
                this.unit.Terminn.AddTermin(novi);
                this.unit.Complete();
                MessageBox.Show("You have added a new term.");
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
                string vreme = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                string imeiprezime = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;

                comboBox1.Text = vreme;
                comboBox2.Text = imeiprezime;
            }
        }
    }
}
