namespace XML_Projekt
{
    partial class Form2
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
            this.input_doc_titel = new System.Windows.Forms.TextBox();
            this.input_doc_kuerzel = new System.Windows.Forms.TextBox();
            this.input_doc_name = new System.Windows.Forms.TextBox();
            this.input_doc_beschreibung = new System.Windows.Forms.RichTextBox();
            this.input_header2 = new System.Windows.Forms.Label();
            this.doc_input_beschreibung = new System.Windows.Forms.Label();
            this.doc_input_titel = new System.Windows.Forms.Label();
            this.doc_input_kuerzel = new System.Windows.Forms.Label();
            this.doc_input_name = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doc_input_enter
            // 
            this.doc_input_enter.Location = new System.Drawing.Point(158, 306);
            this.doc_input_enter.Name = "doc_input_enter";
            this.doc_input_enter.Size = new System.Drawing.Size(97, 28);
            this.doc_input_enter.TabIndex = 30;
            this.doc_input_enter.Text = "Bestätigen";
            this.doc_input_enter.UseVisualStyleBackColor = true;
            this.doc_input_enter.Click += new System.EventHandler(this.doc_input_enter_Click);
            // 
            // input_doc_titel
            // 
            this.input_doc_titel.BackColor = System.Drawing.SystemColors.Info;
            this.input_doc_titel.Location = new System.Drawing.Point(98, 140);
            this.input_doc_titel.Name = "input_doc_titel";
            this.input_doc_titel.Size = new System.Drawing.Size(264, 22);
            this.input_doc_titel.TabIndex = 29;
            // 
            // input_doc_kuerzel
            // 
            this.input_doc_kuerzel.BackColor = System.Drawing.SystemColors.Info;
            this.input_doc_kuerzel.Location = new System.Drawing.Point(98, 102);
            this.input_doc_kuerzel.Name = "input_doc_kuerzel";
            this.input_doc_kuerzel.Size = new System.Drawing.Size(264, 22);
            this.input_doc_kuerzel.TabIndex = 28;
            // 
            // input_doc_name
            // 
            this.input_doc_name.BackColor = System.Drawing.SystemColors.Info;
            this.input_doc_name.Location = new System.Drawing.Point(98, 61);
            this.input_doc_name.Name = "input_doc_name";
            this.input_doc_name.Size = new System.Drawing.Size(265, 22);
            this.input_doc_name.TabIndex = 27;
            // 
            // input_doc_beschreibung
            // 
            this.input_doc_beschreibung.Location = new System.Drawing.Point(41, 204);
            this.input_doc_beschreibung.Name = "input_doc_beschreibung";
            this.input_doc_beschreibung.Size = new System.Drawing.Size(314, 96);
            this.input_doc_beschreibung.TabIndex = 26;
            this.input_doc_beschreibung.Text = "";
            // 
            // input_header2
            // 
            this.input_header2.AutoSize = true;
            this.input_header2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_header2.Location = new System.Drawing.Point(36, 21);
            this.input_header2.Name = "input_header2";
            this.input_header2.Size = new System.Drawing.Size(313, 25);
            this.input_header2.TabIndex = 25;
            this.input_header2.Text = "Bitte geben Sie folgende Werte ein";
            // 
            // doc_input_beschreibung
            // 
            this.doc_input_beschreibung.AutoSize = true;
            this.doc_input_beschreibung.Location = new System.Drawing.Point(38, 184);
            this.doc_input_beschreibung.Name = "doc_input_beschreibung";
            this.doc_input_beschreibung.Size = new System.Drawing.Size(95, 17);
            this.doc_input_beschreibung.TabIndex = 24;
            this.doc_input_beschreibung.Text = "Beschreibung";
            // 
            // doc_input_titel
            // 
            this.doc_input_titel.AutoSize = true;
            this.doc_input_titel.Location = new System.Drawing.Point(38, 145);
            this.doc_input_titel.Name = "doc_input_titel";
            this.doc_input_titel.Size = new System.Drawing.Size(44, 17);
            this.doc_input_titel.TabIndex = 23;
            this.doc_input_titel.Text = "Titel *";
            // 
            // doc_input_kuerzel
            // 
            this.doc_input_kuerzel.AutoSize = true;
            this.doc_input_kuerzel.Location = new System.Drawing.Point(38, 107);
            this.doc_input_kuerzel.Name = "doc_input_kuerzel";
            this.doc_input_kuerzel.Size = new System.Drawing.Size(57, 17);
            this.doc_input_kuerzel.TabIndex = 22;
            this.doc_input_kuerzel.Text = "Kürzel *";
            // 
            // doc_input_name
            // 
            this.doc_input_name.AutoSize = true;
            this.doc_input_name.Location = new System.Drawing.Point(38, 66);
            this.doc_input_name.Name = "doc_input_name";
            this.doc_input_name.Size = new System.Drawing.Size(54, 17);
            this.doc_input_name.TabIndex = 21;
            this.doc_input_name.Text = "Name *";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.PapayaWhip;
            this.label46.Location = new System.Drawing.Point(271, 184);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(78, 17);
            this.label46.TabIndex = 38;
            this.label46.Text = "* Pflichtfeld";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 354);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.doc_input_enter);
            this.Controls.Add(this.input_doc_titel);
            this.Controls.Add(this.input_doc_kuerzel);
            this.Controls.Add(this.input_doc_name);
            this.Controls.Add(this.input_doc_beschreibung);
            this.Controls.Add(this.input_header2);
            this.Controls.Add(this.doc_input_beschreibung);
            this.Controls.Add(this.doc_input_titel);
            this.Controls.Add(this.doc_input_kuerzel);
            this.Controls.Add(this.doc_input_name);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doc_input_enter;
        private System.Windows.Forms.TextBox input_doc_titel;
        private System.Windows.Forms.TextBox input_doc_kuerzel;
        private System.Windows.Forms.TextBox input_doc_name;
        private System.Windows.Forms.RichTextBox input_doc_beschreibung;
        private System.Windows.Forms.Label input_header2;
        private System.Windows.Forms.Label doc_input_beschreibung;
        private System.Windows.Forms.Label doc_input_titel;
        private System.Windows.Forms.Label doc_input_kuerzel;
        private System.Windows.Forms.Label doc_input_name;
        private System.Windows.Forms.Label label46;
    }
}