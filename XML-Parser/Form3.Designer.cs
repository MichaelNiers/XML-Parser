namespace XML_Projekt
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doc_input_enter = new System.Windows.Forms.Button();
            this.input_ea_titel = new System.Windows.Forms.TextBox();
            this.input_ea_dbposition = new System.Windows.Forms.TextBox();
            this.input_ea_name = new System.Windows.Forms.TextBox();
            this.input_ea_beschreibung = new System.Windows.Forms.RichTextBox();
            this.input_header3 = new System.Windows.Forms.Label();
            this.ea_input_beschreibung = new System.Windows.Forms.Label();
            this.ea_input_titel = new System.Windows.Forms.Label();
            this.ea_input_dbposition = new System.Windows.Forms.Label();
            this.ea_input_name = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doc_input_enter
            // 
            this.doc_input_enter.Location = new System.Drawing.Point(180, 294);
            this.doc_input_enter.Name = "doc_input_enter";
            this.doc_input_enter.Size = new System.Drawing.Size(97, 28);
            this.doc_input_enter.TabIndex = 40;
            this.doc_input_enter.Text = "Bestätigen";
            this.doc_input_enter.UseVisualStyleBackColor = true;
            this.doc_input_enter.Click += new System.EventHandler(this.doc_input_enter_Click);
            // 
            // input_ea_titel
            // 
            this.input_ea_titel.BackColor = System.Drawing.SystemColors.Info;
            this.input_ea_titel.Location = new System.Drawing.Point(125, 128);
            this.input_ea_titel.Name = "input_ea_titel";
            this.input_ea_titel.Size = new System.Drawing.Size(228, 22);
            this.input_ea_titel.TabIndex = 39;
            // 
            // input_ea_dbposition
            // 
            this.input_ea_dbposition.BackColor = System.Drawing.SystemColors.Info;
            this.input_ea_dbposition.Location = new System.Drawing.Point(125, 90);
            this.input_ea_dbposition.Name = "input_ea_dbposition";
            this.input_ea_dbposition.Size = new System.Drawing.Size(228, 22);
            this.input_ea_dbposition.TabIndex = 38;
            // 
            // input_ea_name
            // 
            this.input_ea_name.BackColor = System.Drawing.SystemColors.Info;
            this.input_ea_name.Location = new System.Drawing.Point(125, 49);
            this.input_ea_name.Name = "input_ea_name";
            this.input_ea_name.Size = new System.Drawing.Size(228, 22);
            this.input_ea_name.TabIndex = 37;
            // 
            // input_ea_beschreibung
            // 
            this.input_ea_beschreibung.Location = new System.Drawing.Point(39, 192);
            this.input_ea_beschreibung.Name = "input_ea_beschreibung";
            this.input_ea_beschreibung.Size = new System.Drawing.Size(314, 96);
            this.input_ea_beschreibung.TabIndex = 36;
            this.input_ea_beschreibung.Text = "";
            // 
            // input_header3
            // 
            this.input_header3.AutoSize = true;
            this.input_header3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_header3.Location = new System.Drawing.Point(34, 9);
            this.input_header3.Name = "input_header3";
            this.input_header3.Size = new System.Drawing.Size(313, 25);
            this.input_header3.TabIndex = 35;
            this.input_header3.Text = "Bitte geben Sie folgende Werte ein";
            // 
            // ea_input_beschreibung
            // 
            this.ea_input_beschreibung.AutoSize = true;
            this.ea_input_beschreibung.Location = new System.Drawing.Point(36, 172);
            this.ea_input_beschreibung.Name = "ea_input_beschreibung";
            this.ea_input_beschreibung.Size = new System.Drawing.Size(95, 17);
            this.ea_input_beschreibung.TabIndex = 34;
            this.ea_input_beschreibung.Text = "Beschreibung";
            // 
            // ea_input_titel
            // 
            this.ea_input_titel.AutoSize = true;
            this.ea_input_titel.Location = new System.Drawing.Point(36, 133);
            this.ea_input_titel.Name = "ea_input_titel";
            this.ea_input_titel.Size = new System.Drawing.Size(44, 17);
            this.ea_input_titel.TabIndex = 33;
            this.ea_input_titel.Text = "Titel *";
            // 
            // ea_input_dbposition
            // 
            this.ea_input_dbposition.AutoSize = true;
            this.ea_input_dbposition.Location = new System.Drawing.Point(36, 95);
            this.ea_input_dbposition.Name = "ea_input_dbposition";
            this.ea_input_dbposition.Size = new System.Drawing.Size(91, 17);
            this.ea_input_dbposition.TabIndex = 32;
            this.ea_input_dbposition.Text = "DB-Position *";
            // 
            // ea_input_name
            // 
            this.ea_input_name.AutoSize = true;
            this.ea_input_name.Location = new System.Drawing.Point(36, 54);
            this.ea_input_name.Name = "ea_input_name";
            this.ea_input_name.Size = new System.Drawing.Size(54, 17);
            this.ea_input_name.TabIndex = 31;
            this.ea_input_name.Text = "Name *";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.PapayaWhip;
            this.label46.Location = new System.Drawing.Point(269, 172);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(78, 17);
            this.label46.TabIndex = 41;
            this.label46.Text = "* Pflichtfeld";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 336);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.doc_input_enter);
            this.Controls.Add(this.input_ea_titel);
            this.Controls.Add(this.input_ea_dbposition);
            this.Controls.Add(this.input_ea_name);
            this.Controls.Add(this.input_ea_beschreibung);
            this.Controls.Add(this.input_header3);
            this.Controls.Add(this.ea_input_beschreibung);
            this.Controls.Add(this.ea_input_titel);
            this.Controls.Add(this.ea_input_dbposition);
            this.Controls.Add(this.ea_input_name);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doc_input_enter;
        private System.Windows.Forms.TextBox input_ea_titel;
        private System.Windows.Forms.TextBox input_ea_dbposition;
        private System.Windows.Forms.TextBox input_ea_name;
        private System.Windows.Forms.RichTextBox input_ea_beschreibung;
        private System.Windows.Forms.Label input_header3;
        private System.Windows.Forms.Label ea_input_beschreibung;
        private System.Windows.Forms.Label ea_input_titel;
        private System.Windows.Forms.Label ea_input_dbposition;
        private System.Windows.Forms.Label ea_input_name;
        private System.Windows.Forms.Label label46;
    }
}