using Frizerski_salon.User_controls;
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
    public partial class Salon : Form
    {
        public Salon()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelstuff.Visible = false;
            panelhairdresser.Visible = false;        
        }

        private void hideStuff()
        {
            if (panelstuff.Visible == true)
                panelstuff.Visible = false;
            if (panelhairdresser.Visible == true)
                panelhairdresser.Visible = false;
        }

        private void showPanelStuff(Panel panelstuff)
        {
            if (panelstuff.Visible == false)
            {
                hideStuff();
                panelstuff.Visible = true;
            }
            else
                panelstuff.Visible = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            showPanelStuff(panelstuff);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receivingClientsUC r = new receivingClientsUC();
            r.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(r);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SchedulingAppointmentUC s = new SchedulingAppointmentUC();
            s.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(s);
        }

        private void showPanelHairdresser(Panel panelhairdresser)
        {
            if (panelhairdresser.Visible == false)
            {
                hideStuff();
                panelhairdresser.Visible = true;
            }
            else
                panelhairdresser.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            showPanelHairdresser(panelhairdresser);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceUC s = new ServiceUC();
            s.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(s);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();         
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton4_Click(object sender, EventArgs e)
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
    }
}
