namespace XML_Projekt
{
    partial class Form4
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
            this.input_kv_verschluesselung = new System.Windows.Forms.TextBox();
            this.input_kv_value = new System.Windows.Forms.TextBox();
            this.input_kv_key = new System.Windows.Forms.TextBox();
            this.input_kv_beschreibung = new System.Windows.Forms.RichTextBox();
            this.input_header4 = new System.Windows.Forms.Label();
            this.kv_input_beschreibung = new System.Windows.Forms.Label();
            this.kv_input_verschluesselt = new System.Windows.Forms.Label();
            this.kv_input_value = new System.Windows.Forms.Label();
            this.kv_input_key = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doc_input_enter
            // 
            this.doc_input_enter.Location = new System.Drawing.Point(159, 288);
            this.doc_input_enter.Name = "doc_input_enter";
            this.doc_input_enter.Size = new System.Drawing.Size(97, 28);
            this.doc_input_enter.TabIndex = 40;
            this.doc_input_enter.Text = "Bestätigen";
            this.doc_input_enter.UseVisualStyleBackColor = true;
            this.doc_input_enter.Click += new System.EventHandler(this.doc_input_enter_Click);
            // 
            // input_kv_verschluesselung
            // 
            this.input_kv_verschluesselung.BackColor = System.Drawing.SystemColors.Info;
            this.input_kv_verschluesselung.Location = new System.Drawing.Point(141, 122);
            this.input_kv_verschluesselung.Name = "input_kv_verschluesselung";
            this.input_kv_verschluesselung.Size = new System.Drawing.Size(206, 22);
            this.input_kv_verschluesselung.TabIndex = 39;
            // 
            // input_kv_value
            // 
            this.input_kv_value.BackColor = System.Drawing.SystemColors.Info;
            this.input_kv_value.Location = new System.Drawing.Point(141, 84);
            this.input_kv_value.Name = "input_kv_value";
            this.input_kv_value.Size = new System.Drawing.Size(206, 22);
            this.input_kv_value.TabIndex = 38;
            // 
            // input_kv_key
            // 
            this.input_kv_key.BackColor = System.Drawing.SystemColors.Info;
            this.input_kv_key.Location = new System.Drawing.Point(141, 43);
            this.input_kv_key.Name = "input_kv_key";
            this.input_kv_key.Size = new System.Drawing.Size(206, 22);
            this.input_kv_key.TabIndex = 37;
            // 
            // input_kv_beschreibung
            // 
            this.input_kv_beschreibung.Location = new System.Drawing.Point(26, 186);
            this.input_kv_beschreibung.Name = "input_kv_beschreibung";
            this.input_kv_beschreibung.Size = new System.Drawing.Size(321, 96);
            this.input_kv_beschreibung.TabIndex = 36;
            this.input_kv_beschreibung.Text = "";
            // 
            // input_header4
            // 
            this.input_header4.AutoSize = true;
            this.input_header4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_header4.Location = new System.Drawing.Point(34, 9);
            this.input_header4.Name = "input_header4";
            this.input_header4.Size = new System.Drawing.Size(313, 25);
            this.input_header4.TabIndex = 35;
            this.input_header4.Text = "Bitte geben Sie folgende Werte ein";
            // 
            // kv_input_beschreibung
            // 
            this.kv_input_beschreibung.AutoSize = true;
            this.kv_input_beschreibung.Location = new System.Drawing.Point(23, 166);
            this.kv_input_beschreibung.Name = "kv_input_beschreibung";
            this.kv_input_beschreibung.Size = new System.Drawing.Size(95, 17);
            this.kv_input_beschreibung.TabIndex = 34;
            this.kv_input_beschreibung.Text = "Beschreibung";
            // 
            // kv_input_verschluesselt
            // 
            this.kv_input_verschluesselt.AutoSize = true;
            this.kv_input_verschluesselt.Location = new System.Drawing.Point(23, 127);
            this.kv_input_verschluesselt.Name = "kv_input_verschluesselt";
            this.kv_input_verschluesselt.Size = new System.Drawing.Size(121, 17);
            this.kv_input_verschluesselt.TabIndex = 33;
            this.kv_input_verschluesselt.Text = "Verschlüsselung *";
            // 
            // kv_input_value
            // 
            this.kv_input_value.AutoSize = true;
            this.kv_input_value.Location = new System.Drawing.Point(23, 89);
            this.kv_input_value.Name = "kv_input_value";
            this.kv_input_value.Size = new System.Drawing.Size(53, 17);
            this.kv_input_value.TabIndex = 32;
            this.kv_input_value.Text = "Value *";
            // 
            // kv_input_key
            // 
            this.kv_input_key.AutoSize = true;
            this.kv_input_key.Location = new System.Drawing.Point(23, 48);
            this.kv_input_key.Name = "kv_input_key";
            this.kv_input_key.Size = new System.Drawing.Size(41, 17);
            this.kv_input_key.TabIndex = 31;
            this.kv_input_key.Text = "Key *";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.PapayaWhip;
            this.label46.Location = new System.Drawing.Point(269, 166);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(78, 17);
            this.label46.TabIndex = 41;
            this.label46.Text = "* Pflichtfeld";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 328);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.doc_input_enter);
            this.Controls.Add(this.input_kv_verschluesselung);
            this.Controls.Add(this.input_kv_value);
            this.Controls.Add(this.input_kv_key);
            this.Controls.Add(this.input_kv_beschreibung);
            this.Controls.Add(this.input_header4);
            this.Controls.Add(this.kv_input_beschreibung);
            this.Controls.Add(this.kv_input_verschluesselt);
            this.Controls.Add(this.kv_input_value);
            this.Controls.Add(this.kv_input_key);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doc_input_enter;
        private System.Windows.Forms.TextBox input_kv_verschluesselung;
        private System.Windows.Forms.TextBox input_kv_value;
        private System.Windows.Forms.TextBox input_kv_key;
        private System.Windows.Forms.RichTextBox input_kv_beschreibung;
        private System.Windows.Forms.Label input_header4;
        private System.Windows.Forms.Label kv_input_beschreibung;
        private System.Windows.Forms.Label kv_input_verschluesselt;
        private System.Windows.Forms.Label kv_input_value;
        private System.Windows.Forms.Label kv_input_key;
        private System.Windows.Forms.Label label46;
    }
}