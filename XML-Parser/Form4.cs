using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_Projekt
{
    public partial class Form4 : Form
    {
        Form1 frm11;
        private int update = 0;
        private xmlTable tblPanel;
        public Form4(Form1 frm1, xmlTable tblPanel)
        {
            frm11 = frm1;

            this.tblPanel = tblPanel;

            InitializeComponent();
        }

        public Form4(Form1 frm1, string[] felder, xmlTable tblPanel)
        {
            frm11 = frm1;
            this.tblPanel = tblPanel;
            update = 1;

            InitializeComponent();

            input_kv_key.Text = felder[0];
            input_kv_value.Text = felder[1];
            input_kv_verschluesselung.Text = felder[2];
            input_kv_beschreibung.Text = felder[3];
        }

        private void doc_input_enter_Click(object sender, EventArgs e)
        {
            string key = input_kv_key.Text;
            string value = input_kv_value.Text;
            string verschluesselung = input_kv_verschluesselung.Text;
            string beschreibung = input_kv_beschreibung.Text;
            if (update == 0)
            {

                frm11.fuelleKV(key, value, beschreibung, verschluesselung, tblPanel);
            }
            else if (update == 1)
            {
                frm11.setFelder(tblPanel, new[] { key, value, beschreibung, verschluesselung });

            }

            if (input_kv_key.Text.Equals("") || input_kv_value.Text.Equals("") || input_kv_verschluesselung.Text.Equals(""))
            {
                MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                throw new System.ArgumentException("Parameter cannot be null", "original");
            }

            this.Close();
        }
    }
}
