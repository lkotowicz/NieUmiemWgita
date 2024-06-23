namespace DzielenieLiczb
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
            TextBox1 = new TextBox();
            TextBox2 = new TextBox();
            TextBox3 = new TextBox();
            Podziel = new Button();
            SuspendLayout();
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(117, 35);
            TextBox1.Margin = new Padding(4, 3, 4, 3);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(116, 23);
            TextBox1.TabIndex = 0;
            TextBox1.Text = "Dzielna:";
            TextBox1.TextAlign = HorizontalAlignment.Center;
            TextBox1.UseWaitCursor = true;
            // 
            // TextBox2
            // 
            TextBox2.Location = new Point(117, 69);
            TextBox2.Margin = new Padding(4, 3, 4, 3);
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(116, 23);
            TextBox2.TabIndex = 1;
            TextBox2.Text = "Dzielnik";
            TextBox2.TextAlign = HorizontalAlignment.Center;
            TextBox2.UseWaitCursor = true;
            // 
            // TextBox3
            // 
            TextBox3.Location = new Point(117, 104);
            TextBox3.Margin = new Padding(4, 3, 4, 3);
            TextBox3.Name = "TextBox3";
            TextBox3.ReadOnly = true;
            TextBox3.Size = new Size(116, 23);
            TextBox3.TabIndex = 2;
            TextBox3.Text = "Wynik:";
            TextBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // Podziel
            // 
            Podziel.Location = new Point(117, 138);
            Podziel.Margin = new Padding(4, 3, 4, 3);
            Podziel.Name = "Podziel";
            Podziel.Size = new Size(117, 27);
            Podziel.TabIndex = 3;
            Podziel.Text = "Podziel";
            Podziel.UseVisualStyleBackColor = true;
            Podziel.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 186);
            Controls.Add(Podziel);
            Controls.Add(TextBox3);
            Controls.Add(TextBox2);
            Controls.Add(TextBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Dzielenie Liczb";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Button Podziel;
    }
}
