namespace EncryptionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxAlgorithms = new System.Windows.Forms.ComboBox();
            this.textBoxPlainText = new System.Windows.Forms.TextBox();
            this.textBoxEncryptedAscii = new System.Windows.Forms.TextBox();
            this.textBoxEncryptedHex = new System.Windows.Forms.TextBox();
            this.textBoxDecryptedText = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.labelEncryptionTime = new System.Windows.Forms.Label();
            this.labelDecryptionTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(12, 12);
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(360, 21);
            this.comboBoxAlgorithms.TabIndex = 0;
            // 
            // textBoxPlainText
            // 
            this.textBoxPlainText.Location = new System.Drawing.Point(12, 39);
            this.textBoxPlainText.Multiline = true;
            this.textBoxPlainText.Name = "textBoxPlainText";
            this.textBoxPlainText.Size = new System.Drawing.Size(360, 50);
            this.textBoxPlainText.TabIndex = 1;
            // 
            // textBoxEncryptedAscii
            // 
            this.textBoxEncryptedAscii.Location = new System.Drawing.Point(12, 95);
            this.textBoxEncryptedAscii.Multiline = true;
            this.textBoxEncryptedAscii.Name = "textBoxEncryptedAscii";
            this.textBoxEncryptedAscii.Size = new System.Drawing.Size(360, 50);
            this.textBoxEncryptedAscii.TabIndex = 2;
            // 
            // textBoxEncryptedHex
            // 
            this.textBoxEncryptedHex.Location = new System.Drawing.Point(12, 151);
            this.textBoxEncryptedHex.Multiline = true;
            this.textBoxEncryptedHex.Name = "textBoxEncryptedHex";
            this.textBoxEncryptedHex.Size = new System.Drawing.Size(360, 50);
            this.textBoxEncryptedHex.TabIndex = 3;
            // 
            // textBoxDecryptedText
            // 
            this.textBoxDecryptedText.Location = new System.Drawing.Point(12, 263);
            this.textBoxDecryptedText.Multiline = true;
            this.textBoxDecryptedText.Name = "textBoxDecryptedText";
            this.textBoxDecryptedText.Size = new System.Drawing.Size(360, 50);
            this.textBoxDecryptedText.TabIndex = 5;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(12, 207);
            this.textBoxKey.Multiline = true;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(360, 20);
            this.textBoxKey.TabIndex = 6;
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(12, 233);
            this.textBoxIV.Multiline = true;
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(360, 20);
            this.textBoxIV.TabIndex = 7;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(12, 319);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonEncrypt.TabIndex = 8;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(297, 319);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrypt.TabIndex = 9;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // labelEncryptionTime
            // 
            this.labelEncryptionTime.AutoSize = true;
            this.labelEncryptionTime.Location = new System.Drawing.Point(12, 345);
            this.labelEncryptionTime.Name = "labelEncryptionTime";
            this.labelEncryptionTime.Size = new System.Drawing.Size(89, 13);
            this.labelEncryptionTime.TabIndex = 10;
            this.labelEncryptionTime.Text = "Encryption Time: ";
            // 
            // labelDecryptionTime
            // 
            this.labelDecryptionTime.AutoSize = true;
            this.labelDecryptionTime.Location = new System.Drawing.Point(282, 345);
            this.labelDecryptionTime.Name = "labelDecryptionTime";
            this.labelDecryptionTime.Size = new System.Drawing.Size(90, 13);
            this.labelDecryptionTime.TabIndex = 11;
            this.labelDecryptionTime.Text = "Decryption Time: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Hash algorythm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Plain text";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Encrypted ASCII";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Encrypted  HEX";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Key";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "IV";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Decrypted text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 381);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDecryptionTime);
            this.Controls.Add(this.labelEncryptionTime);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.textBoxIV);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxDecryptedText);
            this.Controls.Add(this.textBoxEncryptedHex);
            this.Controls.Add(this.textBoxEncryptedAscii);
            this.Controls.Add(this.textBoxPlainText);
            this.Controls.Add(this.comboBoxAlgorithms);
            this.Name = "Form1";
            this.Text = "Encryption App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBoxAlgorithms;
        private System.Windows.Forms.TextBox textBoxPlainText;
        private System.Windows.Forms.TextBox textBoxEncryptedAscii;
        private System.Windows.Forms.TextBox textBoxEncryptedHex;
        private System.Windows.Forms.TextBox textBoxDecryptedText;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label labelEncryptionTime;
        private System.Windows.Forms.Label labelDecryptionTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
