using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasyonModelleme
{
    public partial class RassalSayilar : Form
    {
        public RassalSayilar()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (radioOrtaKare.Checked == true)
            {
                int gelenSayi = Convert.ToInt32(tbSayi.Text);
                int basamakSayisi = 0;
                int girilenBasamakSayisi = 0;
                int karesi = gelenSayi * gelenSayi;
                int geciciGelen = gelenSayi;
                while (karesi > 0)
                {
                    karesi /= 10;
                    basamakSayisi++;
                }
                while (geciciGelen > 0)
                {
                    geciciGelen /= 10;
                    girilenBasamakSayisi++;
                }
                ortakareyontemi(gelenSayi, basamakSayisi, girilenBasamakSayisi);
            }
            if (radioDogrusalEslik.Checked == true)
            {
                DogrusalEslik(Convert.ToInt32(tbSayi.Text));
            }
        }
        public int OrtaKare(int a, int basamak, int girilenSayi)
        {
            int yeniSayi = 0;
            int aKare = a * a;
            int[] Sayilar = new int[basamak];
            int i = 0;
            while (aKare > 0)
            {
                yeniSayi = aKare % 10;
                aKare /= 10;
                Sayilar[i] = yeniSayi;
                i++;
            }
            string sonsayi = "";
            Array.Reverse(Sayilar);
            Array.Clear(Sayilar, 0, basamak / 4);
            Array.Clear(Sayilar, basamak - basamak / 4, basamak / 4);
            for (int j = 0; j < Sayilar.Length; j++)
            {
                sonsayi += Sayilar[j].ToString();
            }
            int OlusanSonSayi;
            if (sonsayi == "")
            {
                OlusanSonSayi = 0;
            }
            else if (sonsayi != "" && girilenSayi == 5)

            {

                OlusanSonSayi = (int)(Convert.ToInt32(sonsayi) / Math.Pow(10, 3));



            }
            else
            {
                OlusanSonSayi = (int)(Convert.ToInt32(sonsayi) / Math.Pow(10, 2));

            }

            return OlusanSonSayi;

        }
        public void ortakareyontemi(int num, int basamak, int girilen)
        {
            dataGridViewSayi.Columns.Add("AdimSayisi", "Adım Sayısı");
            dataGridViewSayi.Columns.Add("GirilenSayi", "Girilen Sayı");
            dataGridViewSayi.Columns.Add("Olusan", "Oluşan Random Sayı");
            int sayi = num;
            for (int i = 0; i < 100; i++)
            {
                dataGridViewSayi.Rows.Add();
                dataGridViewSayi.Rows[i].Cells[0].Value = i;
                dataGridViewSayi.Rows[i].Cells[1].Value = sayi;
                sayi = OrtaKare(sayi, basamak, girilen);
                double olusan = (Convert.ToDouble(sayi) / Math.Pow(10, girilen));
                dataGridViewSayi.Rows[i].Cells[2].Value = olusan;
            }
        }

        public void DogrusalEslik(int m)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("İ");
            dt.Columns.Add("X");
            dt.Columns.Add("U");
            double a = 5, c = 3, x = 7;

            double[] Sayilar = new double[16];
            double u = x / m;
            dt.Rows.Add(0, x, u);
            Sayilar[0] = u;
            for (int i = 1; i < m; i++)
            {
                x = ((a * x) + c) % 16;
                u = x / m;
                dt.Rows.Add(i, x, u);
            }
            dataGridViewSayi.DataSource = dt;
        }

        private void radioOrtaKare_Click(object sender, EventArgs e)
        {
            lblAlinan.Text = "Orta Kare için Sayı Giriniz";
        }

        private void radioDogrusalEslik_Click(object sender, EventArgs e)
        {
            lblAlinan.Text = "Doğrusal Eşlik için Adım Sayısı Giriniz.";
        }
    }
}
