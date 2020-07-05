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
using System.Drawing.Printing;

namespace Frizerski_salon.User_controls
{
    public partial class ServiceUC : UserControl
    {
        private FrizerskiContext context;
        private UnitOfWork unit;
        public ServiceUC()
        {
            InitializeComponent();
            context = new FrizerskiContext();
            unit = new UnitOfWork(context);
            var usluga = this.unit.Uslugaa.GetAllUsluga();

            var klijent = this.unit.Klijentt.GetAllKlijent();
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            foreach (var k in klijent)
            {
                comboBox1.Items.Add(k.ime.ToString());
                comboBox3.Items.Add(k.oblikovanjeKose.ToString());
            }

            var zaposleni = this.unit.Zaposlenii.GetAllZaposleni();
            comboBox4.Items.Clear();
            foreach(var z in zaposleni)
            {
                if(z.tipZaposlenog == "F")
                {
                    comboBox4.Items.Add(z.ime.ToString());
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string ime = "Name of client: " + comboBox1.Text;
            string vrsta_usluge = "Service description: " + comboBox3.Text;
            string cena = "Price: " + comboBox2.Text;
            string imeFrizera = "Name of hairdresser: " + comboBox4.Text;

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(imeFrizera + "\n" + ime + "\n" + vrsta_usluge + "\n" + cena, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }
                

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var novi = new Usluga
                {
                    imeiprezime = comboBox1.Text,
                    vrsta_usluge = comboBox3.Text,
                    cena = comboBox2.Text,
                    imeFrizera = comboBox4.Text                                   
                };
                this.unit.Uslugaa.AddUsluga(novi);
                this.unit.Complete();
                MessageBox.Show("You have added a new service.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred, please check the information entered.");
            }
        }    
    }
}
