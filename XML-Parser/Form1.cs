using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XML_Projekt
{

    public partial class Form1 : Form
    {
        private const string KEY = "1549863275845682";
        AesEncryptor Encryptor;
        int iConnection;
        public TableLayoutPanel tbl;
        private string fileName = "";
        dbconnection[] dbcon = new dbconnection[5];

        // Tab Control

        private void MyTabs()
        {
            this.tabControl1 = new TabControl();
            this.tabPage1 = new xmlTabPage();

            this.tabControl1.Controls.AddRange(new Control[] {
            this.tabPage1});
            this.tabControl1.Location = new Point(25, 25);
            this.tabControl1.Size = new Size(250, 250);

            // Displays a string, myTabPage, on tabPage1.
            this.tabPage1.Text = "myTabPage";

            this.ClientSize = new Size(300, 300);
            this.Controls.AddRange(new Control[] {
            this.tabControl1});
        }

        public Form1()
        {
            InitializeComponent();
            Encryptor = new AesEncryptor();

        }

        private void menü_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(menü, new Point(0, menü.Height));
            // Dropdown-Menü initialisieren 

            Point screenPoint = menü.PointToScreen(new Point(menü.Left, menü.Bottom));
            // XML auswählen 
            if (screenPoint.Y + contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {

                DialogResult result = openFileDialog1.ShowDialog();

            }
            else
            {
                contextMenuStrip1.Show(menü, new Point(0, menü.Height));
            }
        }

        // XML-Auswahlmenue
        private void xMLAuswählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            XmlDocument doc = new XmlDocument();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            fileName = openFileDialog1.FileName;
            if (result == DialogResult.OK) // Test result.
            {
                doc.Load(openFileDialog1.FileName);
                try
                {
                    iConnection = 0; // iConnection initialisieren (wie viele Connections)
                    string key = ""; // key initialisieren (key für kv-TLP)
                    string value; // value initialisieren (value für kv-TLP)
                    XmlNode root = doc.FirstChild; 
                    XmlTextReader reader = new XmlTextReader(openFileDialog1.FileName); // neuer Reader mit gewählter XML


                    while (reader.Read()) // XML durchgehen
                    {
                        //Console.WriteLine("NodeType: " + reader.NodeType.ToString());
                        if (reader.NodeType == XmlNodeType.Element) { key = ""; }

                        value = "";
                        switch (reader.NodeType) // Elemente auslesen
                        {
                            case XmlNodeType.Element:

                                key = reader.Name;
                                break;
                            case XmlNodeType.Text:
                                if (key == "info")
                                {
                                    value = reader.Value;
                                }
                                break;
                            default:
                                break;
                        }
                        if (key == "xmlsol" && reader.NodeType == XmlNodeType.Element) // noch mehr Elemente auslesen 
                        {

                            textBox1.Text = reader.GetAttribute("name");
                            textBox2.Text = reader.GetAttribute("version");
                            textBox3.Text = reader.GetAttribute("author");
                            textBox4.Text = reader.GetAttribute("date");

                        }
                        if (key == "info" && reader.NodeType == XmlNodeType.Text) // Value auslesen
                        {
                            richTextBox1.Text = reader.Value;
                        }
                        if (key == "field" && reader.NodeType == XmlNodeType.Element) // Elemente in EA-TLP einfügen 
                        {
                            fuelleEA(reader.GetAttribute("key"), reader.GetAttribute("value"), reader.GetAttribute("caption"), reader.GetAttribute("description"), tableLayoutPanel2);
                        }
                        if (key == "type" && reader.NodeType == XmlNodeType.Element) // Elemente in Doc-TLP einfügen 
                        {
                            fuelleDoc(reader.GetAttribute("key"), reader.GetAttribute("value"), reader.GetAttribute("caption"), reader.GetAttribute("description"), tableLayoutPanel1);
                        }
                        if (key == "property" && reader.NodeType == XmlNodeType.Element) // Elemente in KV-TLP einfügen 
                        {
                            fuelleKV(reader.GetAttribute("key"), reader.GetAttribute("value"), reader.GetAttribute("caption"), reader.GetAttribute("description"), tableLayoutPanel3);
                        }
                        if (key == "dbconnection" && reader.NodeType == XmlNodeType.Element) // Anzahl der dbconnections prüfen und einfügen 
                        {
                            iConnection += 1;
                            if (iConnection == 1)
                            {
                                dbcon[iConnection - 1] = new dbconnection();
                                textBox29.Text = reader.GetAttribute("name");
                                dbcon[iConnection - 1].name = reader.GetAttribute("name");
                            }
                            else if (iConnection == 2)
                            {
                                dbcon[iConnection - 1] = new dbconnection();
                                textBox26.Text = reader.GetAttribute("name");
                                dbcon[iConnection - 1].name = reader.GetAttribute("name");
                            }
                            else if (iConnection == 3)
                            {
                                dbcon[iConnection - 1] = new dbconnection();
                                textBox27.Text = reader.GetAttribute("name");
                                dbcon[iConnection - 1].name = reader.GetAttribute("name");
                            }
                            else if (iConnection == 4)
                            {
                                dbcon[iConnection - 1] = new dbconnection();
                                textBox28.Text = reader.GetAttribute("name");
                                dbcon[iConnection - 1].name = reader.GetAttribute("name");
                            }
                            else if (iConnection == 5)
                            {
                                dbcon[iConnection - 1] = new dbconnection();
                                textBox25.Text = reader.GetAttribute("name");
                                dbcon[iConnection - 1].name = reader.GetAttribute("name");
                            }
                        }
                        if (key == "constring" && reader.NodeType == XmlNodeType.Element) // Anzahl der constrings prüfen und einfügen 
                        {
                            if (iConnection == 1)
                            {

                                string[] neu;
                                string[] neu1;
                                string[] neu2;
                                string[] neu3;
                                string text = reader.GetAttribute("connect");
                                text = text.Replace(";", "|");
                                neu = text.Split('|');
                                Console.WriteLine("neu: " + neu.ToString());
                                neu1 = neu[1].Split(':');
                                neu2 = neu[0].Split(':');
                                neu3 = neu[2].Split('=');
                                Console.WriteLine("neu2: " + neu2);
                                string system = neu2[1];
                                Console.WriteLine("System: " + system);
                                    if (system == "sqlserver")
                                    {
                                        comboBox1.SelectedItem = (object)"MS SQL";
                                        Console.WriteLine("bin sqlserver: ");
                                    dbcon[iConnection-1].system = "MS SQL";
                                } else
                                {
                                    comboBox1.SelectedItem = (object)"Oracle";
                                    dbcon[iConnection - 1].system = "Oracle";
                                }
                                textBox10.Text = neu2[2] + ":" + neu2[3];
                                dbcon[iConnection - 1].server = neu2[2] + ":" + neu2[3];

                                string[] neu1f = neu1[0].Split('=');
                                textBox5.Text = neu1f[1];
                                dbcon[iConnection - 1].dsn = neu1f[1];

                                textBox6.Text = neu3[1];
                                dbcon[iConnection - 1].benutzer = neu3[1];

                            }
                            else if (iConnection == 2)
                            {
                                string[] neu;
                                string[] neu1;
                                string[] neu2;
                                string[] neu3;
                                string text = reader.GetAttribute("connect");
                                text = text.Replace(";", "|");
                                neu = text.Split('|');
                                Console.WriteLine("neu: " + neu.ToString());
                                neu1 = neu[1].Split(':');
                                neu2 = neu[0].Split(':');
                                neu3 = neu[2].Split('=');
                                Console.WriteLine("neu2: " + neu2);
                                string system = neu2[1];
                                Console.WriteLine("System: " + system);
                                if (system == "sqlserver")
                                {
                                    comboBox2.SelectedItem = (object)"MS SQL";
                                    Console.WriteLine("bin sqlserver: ");
                                    dbcon[iConnection - 1].system = "MS SQL";
                                }
                                else
                                {
                                    comboBox2.SelectedItem = (object)"Oracle";
                                    dbcon[iConnection - 1].system = "Oracle";
                                }
                                textBox8.Text = neu2[2] + ":" + neu2[3];
                                dbcon[iConnection - 1].server = neu2[2] + ":" + neu2[3];

                                string[] neu1f = neu1[0].Split('=');
                                textBox12.Text = neu1f[1];
                                dbcon[iConnection - 1].dsn = neu1f[1];

                                textBox11.Text = neu3[1];
                                dbcon[iConnection - 1].benutzer = neu3[1];
                            }
                            else if (iConnection == 3)
                            {
                                string[] neu;
                                string[] neu1;
                                string[] neu2;
                                string[] neu3;
                                string text = reader.GetAttribute("connect");
                                text = text.Replace(";", "|");
                                neu = text.Split('|');
                                Console.WriteLine("neu: " + neu.ToString());
                                neu1 = neu[1].Split(':');
                                neu2 = neu[0].Split(':');
                                neu3 = neu[2].Split('=');
                                Console.WriteLine("neu2: " + neu2);
                                string system = neu2[1];
                                Console.WriteLine("System: " + system);
                                if (system == "sqlserver")
                                {
                                    comboBox3.SelectedItem = (object)"MS SQL";
                                    Console.WriteLine("bin sqlserver: ");
                                    dbcon[iConnection - 1].system = "MS SQL";
                                }
                                else
                                {
                                    comboBox3.SelectedItem = (object)"Oracle";
                                    dbcon[iConnection - 1].system = "Oracle";
                                }
                                textBox13.Text = neu2[2] + ":" + neu2[3];
                                dbcon[iConnection - 1].server = neu2[2] + ":" + neu2[3];

                                string[] neu1f = neu1[0].Split('=');
                                textBox16.Text = neu1f[1];
                                dbcon[iConnection - 1].dsn = neu1f[1];

                                textBox15.Text = neu3[1];
                                dbcon[iConnection - 1].benutzer = neu3[1];
                            }
                            else if (iConnection == 4)
                            {
                                string[] neu;
                                string[] neu1;
                                string[] neu2;
                                string[] neu3;
                                string text = reader.GetAttribute("connect");
                                text = text.Replace(";", "|");
                                neu = text.Split('|');
                                Console.WriteLine("neu: " + neu.ToString());
                                neu1 = neu[1].Split(':');
                                neu2 = neu[0].Split(':');
                                neu3 = neu[2].Split('=');
                                Console.WriteLine("neu2: " + neu2);
                                string system = neu2[1];
                                Console.WriteLine("System: " + system);
                                if (system == "sqlserver")
                                {
                                    comboBox4.SelectedItem = (object)"MS SQL";
                                    Console.WriteLine("bin sqlserver: ");
                                    dbcon[iConnection - 1].system = "MS SQL";
                                }
                                else
                                {
                                    comboBox4.SelectedItem = (object)"Oracle";
                                    dbcon[iConnection - 1].system = "Oracle";
                                }
                                textBox17.Text = neu2[2] + ":" + neu2[3];
                                dbcon[iConnection - 1].server = neu2[2] + ":" + neu2[3];

                                string[] neu1f = neu1[0].Split('=');
                                textBox20.Text = neu1f[1];
                                dbcon[iConnection - 1].dsn = neu1f[1];

                                textBox19.Text = neu3[1];
                                dbcon[iConnection - 1].benutzer = neu3[1];

                            }
                            else if (iConnection == 5)
                            {
                                string[] neu;
                                string[] neu1;
                                string[] neu2;
                                string[] neu3;
                                string text = reader.GetAttribute("connect");
                                text = text.Replace(";", "|");
                                neu = text.Split('|');
                                Console.WriteLine("neu: " + neu.ToString());
                                neu1 = neu[1].Split(':');
                                neu2 = neu[0].Split(':');
                                neu3 = neu[2].Split('=');
                                Console.WriteLine("neu2: " + neu2);
                                string system = neu2[1];
                                Console.WriteLine("System: " + system);
                                if (system == "sqlserver")
                                {
                                    comboBox5.SelectedItem = (object)"MS SQL";
                                    Console.WriteLine("bin sqlserver: ");
                                    dbcon[iConnection - 1].system = "MS SQL";
                                }
                                else
                                {
                                    comboBox5.SelectedItem = (object)"Oracle";
                                    dbcon[iConnection - 1].system = "Oracle";
                                }
                                textBox21.Text = neu2[2] + ":" + neu2[3];
                                dbcon[iConnection - 1].server = neu2[2] + ":" + neu2[3];

                                string[] neu1f = neu1[0].Split('=');
                                textBox24.Text = neu1f[1];
                                dbcon[iConnection - 1].dsn = neu1f[1];

                                textBox23.Text = neu3[1];
                                dbcon[iConnection - 1].benutzer = neu3[1];
                            }
                        }
                        if (key == "password" && reader.NodeType == XmlNodeType.Element) // Anzahl der pw's prüfen, entschluesseln und einfügen 
                        {

                            string passwordVerschluesselt = reader.GetAttribute("value");
                            string passwordEntschluesselt = Entschluesseln(passwordVerschluesselt);
                            if (iConnection == 1)
                            {
                                textBox7.Text = passwordEntschluesselt;
                                dbcon[iConnection - 1].passwort = passwordEntschluesselt;
                            }
                            else if (iConnection == 2)
                            {
                                textBox9.Text = passwordEntschluesselt;
                                dbcon[iConnection - 1].passwort = passwordEntschluesselt;
                            }
                            else if (iConnection == 3)
                            {
                                textBox14.Text = passwordEntschluesselt;
                                dbcon[iConnection - 1].passwort = passwordEntschluesselt;
                            }
                            else if (iConnection == 4)
                            {
                                textBox18.Text = passwordEntschluesselt;
                                dbcon[iConnection - 1].passwort = passwordEntschluesselt;
                            }
                            else if (iConnection == 5)
                            {
                                textBox22.Text = passwordEntschluesselt;
                                dbcon[iConnection - 1].passwort = passwordEntschluesselt;
                            }
                        }
                    }
                    reader.Close(); // Reader schließen 

                    File.Move(openFileDialog1.FileName, openFileDialog1.FileName+".sicherung"); // Sicherung erstellen 
                }
                catch (IOException)
                {
                    // No file chosen
                }
            }

            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void delete_docs_Click(object sender, EventArgs e) // gewählte Doc-Zeile löschen 
        {
            xmlTabPage currentPage = (xmlTabPage)tabPage2;
            deleteFeld(currentPage.tablePanel);
        }

        private void delete_ee_Click(object sender, EventArgs e) // gewählte EA-Zeile löschen 
        {
            xmlTabPage currentPage = (xmlTabPage)tabPage3;
            deleteFeld(currentPage.tablePanel);
        }

        private void delete_kv_Click(object sender, EventArgs e) // gewählte KV-Zeile löschen 
        {
            xmlTabPage currentPage = (xmlTabPage)tabPage4;
            deleteFeld(currentPage.tablePanel);
        }

        private void new_docs_Click(object sender, EventArgs e) // neue Doc-Zeile einfügen 
        {
            xmlTabPage currentPage = (xmlTabPage)tabControl1.SelectedTab;
            Form2 frm2 = new Form2(this, currentPage.tablePanel);
            if (frm2.ShowDialog() == DialogResult.OK)
            {

            }
        }

        public void fuelleDoc(string input_doc_name, string input_doc_kuerzel, string input_doc_titel, string input_doc_beschreibung, xmlTable tableLayoutPanelMain)
        {  // Erst alle Zeilen löschen:

            int colCount = tableLayoutPanelMain.ColumnCount;
            foreach (var atribute in new[] { input_doc_name, input_doc_kuerzel, input_doc_titel, input_doc_beschreibung }) // Array mit doc-Atributen
            {
                var addAtribute = new xmlLabel { Row = tableLayoutPanelMain.iZelle++, Text = atribute.ToString(), Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, AutoSize = false }; // Atribute formatieren 
                addAtribute.MouseHover += (o, args) =>
                {
                    int zeile = ((xmlLabel)o).Row / colCount; // Durchnummerieren von Zeilen 
                    for (int j = 0; j < colCount; j++)
                    {
                        Control c = tableLayoutPanelMain.GetControlFromPosition(j, zeile); // Zeile bei Mouse-Hover einfärben 
                        if (c != null)
                        {
                            if (((xmlLabel)c).BackColor != Color.LightCyan)
                                ((xmlLabel)c).BackColor = Color.LightYellow;
                        }

                    }
                };
                addAtribute.MouseLeave += (o, args) => // Zeile bei Mouse-Leave entfärben
                {
                    int zeile = ((xmlLabel)o).Row / colCount;
                    for (int j = 0; j < colCount; j++)
                    {
                        Control c = tableLayoutPanelMain.GetControlFromPosition(j, zeile);
                        if (c != null)
                        {
                            if (((xmlLabel)c).BackColor != Color.LightCyan)
                                ((xmlLabel)c).BackColor = Color.White;
                        }

                    }

                };
                addAtribute.Click += (o, args) => // Zeile bei Klick einfärben und aktuelle Zeile speichern 
                {
                    tableLayoutPanelMain.aktuelleZeile = ((xmlLabel)o).Row / colCount;
                    Console.WriteLine("Anzahl Zeilen: " + tableLayoutPanelMain.anzahlZeilen);
                    Console.WriteLine("aktuelleZeile: " + tableLayoutPanelMain.aktuelleZeile);
                    for (int j = 0; j < colCount; j++)
                    {
                        for (int x = 1; x < tableLayoutPanelMain.anzahlZeilen / colCount; x++)
                        {
                            Control c = tableLayoutPanelMain.GetControlFromPosition(j, x);
                            if (c != null)
                                ((xmlLabel)c).BackColor = Color.White;
                        }
                    }

                    ((xmlLabel)o).BorderStyle = BorderStyle.Fixed3D;
                    ((xmlLabel)o).BorderStyle = BorderStyle.None;

                    for (int j = 0; j < colCount; j++)
                    {
                        Control c = tableLayoutPanelMain.GetControlFromPosition(j, tableLayoutPanelMain.aktuelleZeile);
                        if (c != null)
                        {
                            ((xmlLabel)c).BackColor = Color.LightCyan;
                        }
                    }

                    Console.WriteLine("ClickedRow: " + ((xmlLabel)o).Row);

                };
                tableLayoutPanelMain.anzahlZeilen++;
                tableLayoutPanelMain.Controls.Add(addAtribute);
            };

        }

        public void fuelleEA(string input_ea_name, string input_ea_dbposition, string input_ea_titel, string input_ea_beschreibung, xmlTable tableLayoutPanelMain)
        {  

            if (input_ea_name == null) // prüfen, ob Value == null ist, um Exception zu vermeiden 
            {
                input_ea_name = "";
            }
            if (input_ea_dbposition == null)
            {
                input_ea_dbposition = "";
            }
            if (input_ea_titel == null)
            {
                input_ea_titel = "";
            }
            if (input_ea_beschreibung == null)
            {
                input_ea_beschreibung = "";
            }

            int colCount = tableLayoutPanelMain.ColumnCount;
            foreach (var atribute in new[] { input_ea_name, input_ea_dbposition, input_ea_titel, input_ea_beschreibung }) // Array mit EA-Atributen
            {
                var addAtribute = new xmlLabel { Row = tableLayoutPanelMain.iZelle++, Text = atribute.ToString(), Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, AutoSize = false };
                addAtribute.MouseHover += (o, args) =>
                {
                    int zeile = ((xmlLabel)o).Row / colCount; // Durchnummerieren von Zeilen 
                    for (int j = 0; j < colCount; j++)
                    {
                        Control c = tableLayoutPanelMain.GetControlFromPosition(j, zeile);
                        if (c != null)
                        {
                            if (((Label)c).BackColor != Color.LightCyan)
                                ((Label)c).BackColor = Color.LightYellow;  // Zeile bei Mouse-Hover einfärben 
                        }

                    }
                };
                addAtribute.MouseLeave += (o, args) => // Zeile bei Mouse-Leave entfärben
                {
                    int zeile = ((xmlLabel)o).Row / colCount;
                    for (int j = 0; j < colCount; j++)
                    {
                        Control c = tableLayoutPanelMain.GetControlFromPosition(j, zeile);
                        if (c != null)
                        {
                            if (((xmlLabel)c).BackColor != Color.LightCyan)
                                ((xmlLabel)c).BackColor = Color.White;
                        }

                    }

                };
                addAtribute.Click += (o, args) => // Zeile bei Klick einfärben und aktuelle Zeile speichern 
                {
                    tableLayoutPanelMain.aktuelleZeile = ((xmlLabel)o).Row / colCount;
                    Console.WriteLine("Anzahl Zeilen: " + tableLayoutPanelMain.anzahlZeilen);
                    Console.WriteLine("aktuelleZeile: " + tableLayoutPanelMain.aktuelleZeile);
                    for (int j = 0; j < colCount; j++)
                    {
                        for (int x = 1; x < tableLayoutPanelMain.anzahlZeilen / colCount; x++)
                        {
                            Control c = tableLayoutPanelMain.GetControlFromPosition(j, x);
                            if (c != null)
                                ((xmlLabel)c).BackColor = Color.White;
                        }
                    }

                    ((xmlLabel)o).BorderStyle = BorderStyle.Fixed3D;

                    ((xmlLabel)o).BorderStyle = BorderStyle.None;
                    for (int j = 0; j < colCount; j++)
                    {
                        Control c = tableLayoutPanelMain.GetControlFromPosition(j, tableLayoutPanelMain.aktuelleZeile);
                        if (c != null)
                        {
                            ((xmlLabel)c).BackColor = Color.LightCyan;
                        }
                    }

                    Console.WriteLine("ClickedRow: " + ((xmlLabel)o).Row);

                };
                tableLayoutPanelMain.anzahlZeilen++;
                tableLayoutPanelMain.Controls.Add(addAtribute);

            }
        }

        public void fuelleKV(string input_kv_key, string input_kv_value, string input_kv_verschluesselung, string input_kv_beschreibung, xmlTable tableLayoutPanelMain)
        {

            int colCount = tableLayoutPanelMain.ColumnCount;

            foreach (var atribute in new[] { input_kv_key, input_kv_value, input_kv_verschluesselung, input_kv_beschreibung }) // Array mit KV-Atributen
            {
                if (atribute != null)
                {
                    var addAtribute = new xmlLabel { Row = tableLayoutPanelMain.iZelle++, Text = atribute.ToString(), Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, AutoSize = false };
                    addAtribute.MouseHover += (o, args) =>
                    {
                        int zeile = ((xmlLabel)o).Row / colCount; // Durchnummerieren von Zeilen 
                        for (int j = 0; j < colCount; j++)
                        {
                            Control c = tableLayoutPanelMain.GetControlFromPosition(j, zeile);
                            if (c != null)
                            {
                                if (((xmlLabel)c).BackColor != Color.LightCyan)
                                    ((xmlLabel)c).BackColor = Color.LightYellow; // Zeile bei Mouse-Hover einfärben 
                            }

                        }

                    };

                    addAtribute.MouseLeave += (o, args) => // Zeile bei Mouse-Leave entfärben
                    {
                        int zeile = ((xmlLabel)o).Row / colCount;
                        for (int j = 0; j < colCount; j++)
                        {
                            Control c = tableLayoutPanelMain.GetControlFromPosition(j, zeile);
                            if (c != null)
                            {
                                if (((xmlLabel)c).BackColor != Color.LightCyan)
                                    ((xmlLabel)c).BackColor = Color.White;
                            }

                        }

                    };
                    addAtribute.Click += (o, args) => // Zeile bei Klick einfärben und aktuelle Zeile speichern 
                    {
                        tableLayoutPanelMain.aktuelleZeile = ((xmlLabel)o).Row / colCount;
                        Console.WriteLine("Anzahl Zeilen: " + tableLayoutPanelMain.anzahlZeilen);
                        Console.WriteLine("aktuelleZeile: " + tableLayoutPanelMain.aktuelleZeile);
                        for (int j = 0; j < colCount; j++)
                        {
                            for (int x = 1; x < tableLayoutPanelMain.anzahlZeilen / colCount; x++)
                            {
                                Control c = tableLayoutPanelMain.GetControlFromPosition(j, x);
                                if (c != null)
                                    ((xmlLabel)c).BackColor = Color.White;
                            }
                        }

                        ((xmlLabel)o).BorderStyle = BorderStyle.Fixed3D;

                        ((xmlLabel)o).BorderStyle = BorderStyle.None;
                        for (int j = 0; j < colCount; j++)
                        {
                            Control c = tableLayoutPanelMain.GetControlFromPosition(j, tableLayoutPanelMain.aktuelleZeile);
                            if (c != null)
                            {
                                ((xmlLabel)c).BackColor = Color.LightCyan;
                            }
                        }

                        Console.WriteLine("ClickedRow: " + ((xmlLabel)o).Row);

                    };
                    tableLayoutPanelMain.anzahlZeilen++;
                    tableLayoutPanelMain.Controls.Add(addAtribute);
                }
            }
        }

        private void deleteFeld(xmlTable tableLayoutPanelMain) // Funktion zum Löschen von Zeilen 
        {
            int colCount = tableLayoutPanelMain.ColumnCount;
            int rowCount = tableLayoutPanelMain.anzahlZeilen;
            int deleteZeile = tableLayoutPanelMain.aktuelleZeile;

            for (int i = colCount - 1; i >= 0; i--)
            {
                Control c = tableLayoutPanelMain.GetControlFromPosition(i, deleteZeile);
                if (c != null)
                {
                    //c.Text = null;
                    tableLayoutPanelMain.Controls.Remove(c);
                    rowCount--;
                }

            }

            for (int j = deleteZeile; j < rowCount / colCount; j++)
            {

                for (int x = 0; x < colCount; x++)
                {
                    Control c = tableLayoutPanelMain.GetControlFromPosition(x, j);
                    if (c != null)
                    {

                        ((xmlLabel)c).Row -= colCount;
                    }
                }
            }
            tableLayoutPanelMain.anzahlZeilen = rowCount;
            tableLayoutPanelMain.iZelle -= colCount;
        }

        private string[,] getAlleFelder(xmlTable tableLayoutPanelMain) // Getter für XML-Beschriftung 
        {
            int colCount = tableLayoutPanelMain.ColumnCount;
            int rowCount = tableLayoutPanelMain.anzahlZeilen / colCount;

            string[,] list = new string[rowCount, colCount];
            for (int j = 0; j < rowCount; j++)
            {
                for (int i = 0; i < colCount; i++)
                {
                    Control c = tableLayoutPanelMain.GetControlFromPosition(i, j);
                    if (c != null)
                    {
                        list[j, i] = c.Text;
                    }

                }
            }


            return list;

        }

        private string[] getFelder(xmlTable tableLayoutPanelMain) // Getter
        {
            int colCount = tableLayoutPanelMain.ColumnCount;
            string[] list = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                Control c = tableLayoutPanelMain.GetControlFromPosition(i, tableLayoutPanelMain.aktuelleZeile);
                if (c != null)
                {
                    list[i] = c.Text;
                }

            }

            return list;

        }

        public void setFelder(xmlTable tableLayoutPanelMain, string[] felder) // Setter
        {
            int colCount = tableLayoutPanelMain.ColumnCount;
            for (int i = 0; i < colCount; i++)
            {
                Control c = tableLayoutPanelMain.GetControlFromPosition(i, tableLayoutPanelMain.aktuelleZeile);
                if (c != null)
                {
                    c.Text = felder[i];
                }

            }

        }
        private void new_ee_Click(object sender, EventArgs e) //  neue EA-Zeile erstellen 
        {
            xmlTabPage currentPage = (xmlTabPage)tabControl1.SelectedTab;
            Form3 frm3 = new Form3(this, currentPage.tablePanel);
            if (frm3.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void new_kv_Click(object sender, EventArgs e)  //  neue KV-Zeile erstellen 
        {
            xmlTabPage currentPage = (xmlTabPage)tabControl1.SelectedTab;
            Form4 frm4 = new Form4(this, currentPage.tablePanel);
            if (frm4.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void change_ee_Click(object sender, EventArgs e) // EA-Zeile ändern 
        {
            Form3 frm3 = new Form3(this, getFelder(tableLayoutPanel2), tableLayoutPanel2);
            if (frm3.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void change_docs_Click(object sender, EventArgs e) // Doc-Zeile ändern 
        {
            Form2 frm2 = new Form2(this, getFelder(tableLayoutPanel1), tableLayoutPanel1);
            if (frm2.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void change_kv_Click(object sender, EventArgs e) // KV-Zeile ändern 
        {
            Form4 frm4 = new Form4(this, getFelder(tableLayoutPanel3), tableLayoutPanel3);
            if (frm4.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button99_Click(object sender, EventArgs e) // Änderungen in aufgerufener XML speichern oder neue XML erstellen 
        {

            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("")) // Bei nicht gefüllten Pflichtfeldern Exception werfen 
            {
                MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                throw new System.ArgumentException("Parameter cannot be null", "original");
            }

            XmlWriter writer = null;

            try
            {
                // Create an XmlWriterSettings object with the correct options. 
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("\t");
                settings.Encoding = Encoding.UTF8;

                // Create the XmlWriter object and write some content.
                if (openFileDialog1.FileName != "")
                {
                    if (openFileDialog1.FileName == textBox1.Text)
                    {
                        writer = XmlWriter.Create(openFileDialog1.FileName, settings); 
                    } else if (openFileDialog1.FileName != textBox1.Text)
                    {
                        MessageBox.Show("Der Dateiname muss mit dem Namen der Lösung übereinstimmen.");
                        throw new System.ArgumentException();
                    }

                } else
                {
                    writer = XmlWriter.Create(textBox1.Text + ".xml", settings);
                }
                writer.WriteStartDocument(); // XML schreiben 

                writer.WriteStartElement("xmlsol");
                writer.WriteAttributeString("name", textBox1.Text);
                writer.WriteAttributeString("version", textBox2.Text);
                writer.WriteAttributeString("author", textBox3.Text);
                writer.WriteAttributeString("date", textBox4.Text);
                writer.WriteAttributeString("xmlns","xsi", null,"http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xsi", "noNamespaceSchemaLocation",null, "xml_config.xsd");

                writer.WriteStartElement("info");
                writer.WriteValue(richTextBox1.Text);
                writer.WriteEndElement();
                writer.WriteStartElement("fields");
                writer.WriteAttributeString("description", "erweiterte d.3 Eigenschaften");
                int colCount = tableLayoutPanel2.ColumnCount;
                int rowCount = tableLayoutPanel2.anzahlZeilen / colCount;
                string[,] felder = getAlleFelder(tableLayoutPanel2);
                Console.WriteLine(rowCount);
                for (int i = 1; i < rowCount; i++)
                {
                    writer.WriteStartElement("field");
                    writer.WriteAttributeString("key", felder[i, 0]);
                    writer.WriteAttributeString("value", felder[i, 1]);
                    writer.WriteAttributeString("caption", felder[i, 2]);
                    writer.WriteAttributeString("description", felder[i, 3]);
                    writer.WriteEndElement();
                                                                          
                }
                writer.WriteEndElement();
                writer.WriteStartElement("types");
                writer.WriteAttributeString("description", "d.3 Dokumentarten");
                int colCount2 = tableLayoutPanel1.ColumnCount;
                int rowCount2 = tableLayoutPanel1.anzahlZeilen / colCount2;
                string[,] felder2 = getAlleFelder(tableLayoutPanel1);
                Console.WriteLine(rowCount2);
                for (int j = 1; j < rowCount2; j++)
                {
                    writer.WriteStartElement("type");
                    writer.WriteAttributeString("key", felder2[j, 0]);
                    writer.WriteAttributeString("value", felder2[j, 1]);
                    writer.WriteAttributeString("caption", felder2[j, 2]);
                    writer.WriteAttributeString("description", felder2[j, 3]);
                    writer.WriteEndElement();
                                                                          
                }
                writer.WriteEndElement();
                writer.WriteStartElement("properties");
                writer.WriteAttributeString("description", "Definition von Datenbankverbindungen");
                int colCount3 = tableLayoutPanel3.ColumnCount;
                int rowCount3 = tableLayoutPanel3.anzahlZeilen / colCount3;
                string[,] felder3 = getAlleFelder(tableLayoutPanel3);
                Console.WriteLine(rowCount3);
                for (int k = 1; k < rowCount3; k++)
                {
                    writer.WriteStartElement("property");
                    writer.WriteAttributeString("key", felder3[k, 0]);
                    writer.WriteAttributeString("value", felder3[k, 1]);
                    writer.WriteAttributeString("encrypted", felder3[k, 2]);
                    writer.WriteAttributeString("description", felder3[k, 3]);
                    writer.WriteEndElement();
                                                                          
                }
                writer.WriteEndElement();

                writer.WriteStartElement("dbconnections");
                writer.WriteAttributeString("description", "Definition von Datenbankverbindungen");
                for (int i = 1; i <= iConnection; i++)
                {
                    if (i == 1)
                    {
                        writer.WriteStartElement("dbconnection");
                        writer.WriteAttributeString("name", dbcon[i-1].name);
                        writer.WriteAttributeString("description", "Datenbankverbindung für Archiv");
                        writer.WriteStartElement("constring");
                        writer.WriteAttributeString("connect", "jdbc:"+dbcon[i-1].system+":"+dbcon[i-1].server+";databaseName="+dbcon[i-1].dsn+";user="+dbcon[i-1].benutzer+";password=$$$$$$;");
                        writer.WriteAttributeString("classname", "com.microsoft.sqlserver.jdbc.SQLServerDriver");
                        writer.WriteAttributeString("description", "Verbindungsstring: $$$$$$ wird durch das entschlüsselte Passwort ersetzt");
                        writer.WriteEndElement();
                        writer.WriteStartElement("password");
                        writer.WriteAttributeString("value", Verschluesseln("password", dbcon[i-1].passwort));
                        writer.WriteAttributeString("description", "verschlüsseltes Passwort");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        if (textBox1.Text.Equals("") || textBox10.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals("") || textBox29.Text.Equals(""))
                        {
                            MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                            throw new System.ArgumentException("Parameter cannot be null", "original");
                        }
                    }
                    if (i == 2)
                    {
                        writer.WriteStartElement("dbconnection");
                        writer.WriteAttributeString("name", dbcon[i - 1].name);
                        writer.WriteAttributeString("description", "Datenbankverbindung für Archiv");
                        writer.WriteStartElement("constring");
                        writer.WriteAttributeString("connect", "jdbc:" + dbcon[i - 1].system + ":" + dbcon[i - 1].server + ";databaseName=" + dbcon[i - 1].dsn + ";user=" + dbcon[i - 1].benutzer + ";password=$$$$$$;");
                        writer.WriteAttributeString("classname", "com.microsoft.sqlserver.jdbc.SQLServerDriver");
                        writer.WriteAttributeString("description", "Verbindungsstring: $$$$$$ wird durch das entschlüsselte Passwort ersetzt");
                        writer.WriteEndElement();
                        writer.WriteStartElement("password");
                        writer.WriteAttributeString("value", Verschluesseln("password", dbcon[i - 1].passwort));
                        writer.WriteAttributeString("description", "verschlüsseltes Passwort");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        if (textBox2.Text.Equals("") || textBox8.Text.Equals("") || textBox12.Text.Equals("") || textBox11.Text.Equals("") || textBox9.Text.Equals("") || textBox26.Text.Equals(""))
                        {
                            MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                            throw new System.ArgumentException("Parameter cannot be null", "original");
                        }
                    }

                    if (i == 3)
                    {
                        writer.WriteStartElement("dbconnection");
                        writer.WriteAttributeString("name", dbcon[i - 1].name);
                        writer.WriteAttributeString("description", "Datenbankverbindung für Archiv");
                        writer.WriteStartElement("constring");
                        writer.WriteAttributeString("connect", "jdbc:" + dbcon[i - 1].system + ":" + dbcon[i - 1].server + ";databaseName=" + dbcon[i - 1].dsn + ";user=" + dbcon[i - 1].benutzer + ";password=$$$$$$;");
                        writer.WriteAttributeString("classname", "com.microsoft.sqlserver.jdbc.SQLServerDriver");
                        writer.WriteAttributeString("description", "Verbindungsstring: $$$$$$ wird durch das entschlüsselte Passwort ersetzt");
                        writer.WriteEndElement();
                        writer.WriteStartElement("password");
                        writer.WriteAttributeString("value", Verschluesseln("password", dbcon[i - 1].passwort));
                        writer.WriteAttributeString("description", "verschlüsseltes Passwort");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        if (textBox3.Text.Equals("") || textBox13.Text.Equals("") || textBox16.Text.Equals("") || textBox15.Text.Equals("") || textBox14.Text.Equals("") || textBox27.Text.Equals(""))
                        {
                            MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                            throw new System.ArgumentException("Parameter cannot be null", "original");
                        }
                    }

                    if (i == 4)
                    {
                        writer.WriteStartElement("dbconnection");
                        writer.WriteAttributeString("name", dbcon[i - 1].name);
                        writer.WriteAttributeString("description", "Datenbankverbindung für Archiv");
                        writer.WriteStartElement("constring");
                        writer.WriteAttributeString("connect", "jdbc:" + dbcon[i - 1].system + ":" + dbcon[i - 1].server + ";databaseName=" + dbcon[i - 1].dsn + ";user=" + dbcon[i - 1].benutzer + ";password=$$$$$$;");
                        writer.WriteAttributeString("classname", "com.microsoft.sqlserver.jdbc.SQLServerDriver");
                        writer.WriteAttributeString("description", "Verbindungsstring: $$$$$$ wird durch das entschlüsselte Passwort ersetzt");
                        writer.WriteEndElement();
                        writer.WriteStartElement("password");
                        writer.WriteAttributeString("value", Verschluesseln("password", dbcon[i - 1].passwort));
                        writer.WriteAttributeString("description", "verschlüsseltes Passwort");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        if (textBox4.Text.Equals("") || textBox17.Text.Equals("") || textBox20.Text.Equals("") || textBox19.Text.Equals("") || textBox18.Text.Equals("") || textBox28.Text.Equals(""))
                        {
                            MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                            throw new System.ArgumentException("Parameter cannot be null", "original");
                        }
                    }

                    if (i == 5)
                    {
                        writer.WriteStartElement("dbconnection");
                        writer.WriteAttributeString("name", dbcon[i - 1].name);
                        writer.WriteAttributeString("description", "Datenbankverbindung für Archiv");
                        writer.WriteStartElement("constring");
                        writer.WriteAttributeString("connect", "jdbc:" + dbcon[i - 1].system + ":" + dbcon[i - 1].server + ";databaseName=" + dbcon[i - 1].dsn + ";user=" + dbcon[i - 1].benutzer + ";password=$$$$$$;");
                        writer.WriteAttributeString("classname", "com.microsoft.sqlserver.jdbc.SQLServerDriver");
                        writer.WriteAttributeString("description", "Verbindungsstring: $$$$$$ wird durch das entschlüsselte Passwort ersetzt");
                        writer.WriteEndElement();
                        writer.WriteStartElement("password");
                        writer.WriteAttributeString("value", Verschluesseln("password", dbcon[i - 1].passwort));
                        writer.WriteAttributeString("description", "verschlüsseltes Passwort");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        if (textBox5.Text.Equals("") || textBox21.Text.Equals("") || textBox24.Text.Equals("") || textBox23.Text.Equals("") || textBox22.Text.Equals("") || textBox25.Text.Equals(""))
                        {
                            MessageBox.Show("Alle farbigen Felder müssen gefüllt sein.");
                            throw new System.ArgumentException("Parameter cannot be null", "original");
                        }
                    }


                }


                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();



                Close();


            }

            finally
            {
                if (writer != null)
                    writer.Close();
            }

        }


        //////////////////////////////////////////////////////////////////////////
        // Verschlüsselung eines Passwortes
        //
        // strProperty	Name des Attributes oder der Datenbank-Verbindung
        // strPasswd	zu verschlüsselndes Passwort
        //
        // Rückgabe:	verschlüsselter Text
        //////////////////////////////////////////////////////////////////////////
        public string Verschluesseln(string strProperty, string strPasswd)
        {
            // es wird nicht nur das Passwort verschlüsselt sondern:
            // <Name des Attributes oder der Datenbank-Verbindung> + "|" <Passwort>
            return Encryptor.Encrypt($"{strProperty}|{strPasswd}", KEY);
        }

        //////////////////////////////////////////////////////////////////////////
        // Entschlüsselt ein Passwort
        //
        // strPasswd	Verschlüsselter Text, der hinter dem letzten "|" das Passwort enthält
        //
        // Rückgabe:	entschlüsseltes Passwort
        public string Entschluesseln(string strPasswd)
        {
            // entschlüsseln
            string strW1 = Encryptor.Decrypt($"{strPasswd}", KEY);
            string[] strW2 = strW1.Split('|');
            int iSplit = strW2.Length;
            if (iSplit > 0)
            {
                // Text hinter dem letzten "|"
                return strW2[iSplit - 1];

            }
            // das sollte nicht passieren
            return "";
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label39_Click(object sender, EventArgs e)
        {

        }

        private void TextBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label42_Click(object sender, EventArgs e)
        {

        }

        private void TextBox25_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class xmlLabel : Label
    {
        public int Row { get; set; }
    }
    public class xmlTable : TableLayoutPanel
    {
        public int anzahlZeilen { get; set; }
        public int aktuelleZeile { get; set; }
        public int iZelle { get; set; }
    }

    public class xmlTabPage : TabPage
    {
        public xmlTable tablePanel { get; set; }
    }

    public class dbconnection
    {
        public string name { get; set; }
        public string system { get; set; }
        public string server { get; set; }
        public string dsn { get; set; }
        public string benutzer { get; set; }
        public string passwort { get; set; }


    }
}
