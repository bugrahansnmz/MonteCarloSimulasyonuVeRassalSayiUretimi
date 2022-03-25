namespace SimulasyonModelleme
{
    partial class RassalSayilar
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
            this.radioOrtaKare = new System.Windows.Forms.RadioButton();
            this.radioDogrusalEslik = new System.Windows.Forms.RadioButton();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.tbSayi = new System.Windows.Forms.TextBox();
            this.lblAlinan = new System.Windows.Forms.Label();
            this.dataGridViewSayi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSayi)).BeginInit();
            this.SuspendLayout();
            // 
            // radioOrtaKare
            // 
            this.radioOrtaKare.AutoSize = true;
            this.radioOrtaKare.Location = new System.Drawing.Point(12, 23);
            this.radioOrtaKare.Name = "radioOrtaKare";
            this.radioOrtaKare.Size = new System.Drawing.Size(153, 20);
            this.radioOrtaKare.TabIndex = 0;
            this.radioOrtaKare.TabStop = true;
            this.radioOrtaKare.Text = "Orta Kare Yöntemi İle";
            this.radioOrtaKare.UseVisualStyleBackColor = true;
            this.radioOrtaKare.Click += new System.EventHandler(this.radioOrtaKare_Click);
            // 
            // radioDogrusalEslik
            // 
            this.radioDogrusalEslik.AutoSize = true;
            this.radioDogrusalEslik.Location = new System.Drawing.Point(217, 23);
            this.radioDogrusalEslik.Name = "radioDogrusalEslik";
            this.radioDogrusalEslik.Size = new System.Drawing.Size(184, 20);
            this.radioDogrusalEslik.TabIndex = 1;
            this.radioDogrusalEslik.TabStop = true;
            this.radioDogrusalEslik.Text = "Doğrusal Eşlik Yöntemi İle";
            this.radioDogrusalEslik.UseVisualStyleBackColor = true;
            this.radioDogrusalEslik.Click += new System.EventHandler(this.radioDogrusalEslik_Click);
            // 
            // btnHesapla
            // 
            this.btnHesapla.Location = new System.Drawing.Point(22, 315);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(379, 44);
            this.btnHesapla.TabIndex = 2;
            this.btnHesapla.Text = "Rastgele Sayı Üret";
            this.btnHesapla.UseVisualStyleBackColor = true;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // tbSayi
            // 
            this.tbSayi.Location = new System.Drawing.Point(142, 165);
            this.tbSayi.Name = "tbSayi";
            this.tbSayi.Size = new System.Drawing.Size(100, 22);
            this.tbSayi.TabIndex = 4;
            // 
            // lblAlinan
            // 
            this.lblAlinan.AutoSize = true;
            this.lblAlinan.Location = new System.Drawing.Point(116, 116);
            this.lblAlinan.Name = "lblAlinan";
            this.lblAlinan.Size = new System.Drawing.Size(11, 16);
            this.lblAlinan.TabIndex = 5;
            this.lblAlinan.Text = "-";
            // 
            // dataGridViewSayi
            // 
            this.dataGridViewSayi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSayi.Location = new System.Drawing.Point(444, 23);
            this.dataGridViewSayi.Name = "dataGridViewSayi";
            this.dataGridViewSayi.RowHeadersWidth = 51;
            this.dataGridViewSayi.RowTemplate.Height = 24;
            this.dataGridViewSayi.Size = new System.Drawing.Size(330, 336);
            this.dataGridViewSayi.TabIndex = 7;
            // 
            // RassalSayilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 414);
            this.Controls.Add(this.dataGridViewSayi);
            this.Controls.Add(this.lblAlinan);
            this.Controls.Add(this.tbSayi);
            this.Controls.Add(this.btnHesapla);
            this.Controls.Add(this.radioDogrusalEslik);
            this.Controls.Add(this.radioOrtaKare);
            this.Name = "RassalSayilar";
            this.Text = "RassalSayilar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSayi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioOrtaKare;
        private System.Windows.Forms.RadioButton radioDogrusalEslik;
        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.TextBox tbSayi;
        private System.Windows.Forms.Label lblAlinan;
        private System.Windows.Forms.DataGridView dataGridViewSayi;
    }
}