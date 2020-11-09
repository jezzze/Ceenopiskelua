namespace c_koodia
{
    partial class Form1
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
            this.Nappi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tekstilaatikko = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Nappi
            // 
            this.Nappi.Location = new System.Drawing.Point(318, 246);
            this.Nappi.Name = "Nappi";
            this.Nappi.Size = new System.Drawing.Size(148, 37);
            this.Nappi.TabIndex = 0;
            this.Nappi.Text = "Nappi";
            this.Nappi.UseVisualStyleBackColor = true;
            this.Nappi.Click += new System.EventHandler(this.Nappi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Anna etunimesi:";
            // 
            // tekstilaatikko
            // 
            this.tekstilaatikko.Location = new System.Drawing.Point(366, 139);
            this.tekstilaatikko.Name = "tekstilaatikko";
            this.tekstilaatikko.Size = new System.Drawing.Size(100, 20);
            this.tekstilaatikko.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tähän tulee vastaus";
            this.label2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tekstilaatikko);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nappi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Nappi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tekstilaatikko;
        private System.Windows.Forms.Label label2;
    }
}

