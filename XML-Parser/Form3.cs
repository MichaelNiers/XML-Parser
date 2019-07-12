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
    public partial class Form3 : Form
    {
        Form1 frm11;
        private int update = 0;
        private xmlTable tblPanel;
        public Form3(Form1 frm1, xmlTable tblPanel)
        {
            frm11 = frm1;

            this.tblPanel = tblPanel;

            InitializeComponent();
        }
        public Form3(Form1 frm1, string[] felder, xmlTable tblPanel)
        {
            frm11 = frm1;
            this.tblPanel = tblPanel;
            update = 1;

            InitializeComponent();

            input_ea_name.Text = felder[0];
            input_ea_dbposition.Text = felder[1];
            input_ea_titel.Text = felder[2];
            input_ea_beschreibung.Text = felder[3];
        }
        private void doc_input_enter_Click(object sender, EventArgs e)
        {
            string name = input_ea_name.Text;
            string dbpposition = input_ea_dbposition.Text;
            string titel = input_ea_titel.Text;
            string beschreibung = input_ea_beschreibung.Text;
            if (update == 0) { 

                frm11.fuelleEA(name, dbpposition, titel, beschreibung, tblPanel);
            }
            else if(update == 1)
            {
                frm11.setFelder(tblPanel, new[] {name, dbpposition,titel,beschreibung});

            }

            if (input_ea_name.Text.Equals("") || input_ea_dbposition.Text.Equals("") || input_ea_titel.Text.Equals(""))
            {
                MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                throw new System.ArgumentException("Parameter cannot be null", "original");
            }

            this.Close();
        }
    }
}
