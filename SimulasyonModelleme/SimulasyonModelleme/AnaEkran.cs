using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace SimulasyonModelleme
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void BtnVeriCek_Click(object sender, EventArgs e)
        {
            string DosyaYolu;
            string DosyaAdi;
            DataTable dt;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";

            if (file.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                if (excelApp == null)
                { //Excel Yüklümü Kontrolü Yapılmaktadır.
                    MessageBox.Show("Excel yüklü değil.");
                    return;
                }
                //Excel Dosyası Açılıyor.
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DosyaYolu);
                //Excel Dosyasının Sayfası Seçilir.
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
                ExcelApp.Range excelRange = excelSheet.UsedRange;
                int satirSayisi = excelRange.Rows.Count; //Sayfanın satır sayısını alır.
                int sutunSayisi = excelRange.Columns.Count;//Sayfanın sütun sayısını alır.
                dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Dosya Seçilemedi.");
            }
            int a = dataGridView1.RowCount;
            btnFrekans.Enabled = true;
        }

        private DataTable ToDataTable(ExcelApp.Range excelRange, int satirSayisi, int sutunSayisi)
        {
            DataTable table = new DataTable();
            for (int i = 1; i <= satirSayisi; i++)
            {
                if (i == 1)
                { // ilk satırı Sutun Adları olarak kullanıldığından
                  // bunları Sutün Adları Olarak Kaydediyoruz.
                    for (int j = 1; j <= sutunSayisi; j++)
                    {
                        //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                        if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            table.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                        else //Boş olduğunda Kaçınsı Sutünsa Adı veriliyor.
                            table.Columns.Add(j.ToString() + ".Sütun");
                    }
                    continue;
                }
                //Yukarıda Sütunlar eklendi
                // onun şemasına göre yeni bir satır oluşturuyoruz. 
                //Okunan verileri yan yana sıralamak için
                var yeniSatir = table.NewRow();
                for (int j = 1; j <= sutunSayisi; j++)
                {
                    //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        yeniSatir[j - 1] = excelRange.Cells[i, j].Value2.ToString();
                    else // İçeriği boş hücrede hata vermesini önlemek için
                        yeniSatir[j - 1] = String.Empty;
                }
                table.Rows.Add(yeniSatir);
            }
            return table;
        }

        private void btnFrekans_Click(object sender, EventArgs e)
        {
            int sabit3 = 0;
            int sabit4 = 0;
            int sabit5 = 0;
            int sabit6 = 0;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value?.ToString() == "3")
                {
                    sabit3++;
                }
                else if (dataGridView1.Rows[i].Cells[1].Value?.ToString() == "4")
                {
                    sabit4++;
                }
                else if (dataGridView1.Rows[i].Cells[1].Value?.ToString() == "5")
                {
                    sabit5++;
                }
                else if (dataGridView1.Rows[i].Cells[1].Value?.ToString() == "6")
                {
                    sabit6++;
                }


            }
            lbl3.Text = sabit3.ToString();
            lbl4.Text = sabit4.ToString();
            lbl5.Text = sabit5.ToString();
            lbl6.Text = sabit6.ToString();
            lblFrekansToplam.Text = (sabit3 + sabit4 + sabit5 + sabit6).ToString();
            btnFrekansOl.Enabled = true;
        }

        private void btnFrekansOl_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(lbl3.Text);
            double b = Convert.ToDouble(lbl4.Text);
            double c = Convert.ToDouble(lbl5.Text);
            double d = Convert.ToDouble(lbl6.Text);
            double f = a + b + c + d;

            lblFrekansOl3.Text = String.Format("{0:0.00}", a / f).ToString();
            lblFrekansOl4.Text = String.Format("{0:0.00}", b / f).ToString();
            lblFrekansOl5.Text = String.Format("{0:0.00}", c / f).ToString();
            lblFrekansOl6.Text = String.Format("{0:0.00}", d / f).ToString();
            lblFrekansOlToplam.Text = ((a / f) + (b / f) + (c / f) + (d / f)).ToString();
            btnKumulatifOlasilik.Enabled = true;
        }

        private void btnKumulatifOlasilik_Click(object sender, EventArgs e)
        {
            double k3 = 0;
            double k4 = Convert.ToDouble(lblFrekansOl3.Text) + k3;
            double k5 = Convert.ToDouble(lblFrekansOl4.Text) + k4;
            double k6 = Convert.ToDouble(lblFrekansOl5.Text) + k5;
            double ktoplam = Convert.ToDouble(lblFrekansOl6.Text) + k6;
            lblKumulatif3.Text = k3.ToString();
            lblKumulatif4.Text = k4.ToString();
            lblKumulatif5.Text = k5.ToString();
            lblKumulatif6.Text = k6.ToString();
            lblKumulatifToplam.Text = ktoplam.ToString();
            btnYeniTablo.Enabled = true;
        }

        private void btnYeniTablo_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            Random random = new Random();
            dataTable.Columns.Add("Aylar");
            dataTable.Columns.Add("Tahmini Miktar");
            dataTable.Columns.Add("Miktar");


            for (int i = 0; i < 12; i++)
            {
                double rs = random.NextDouble();

                if (rs > 0 && rs < 0.19)
                {
                    dataTable.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), rs, "3");
                }
                else if (rs > 0.19 && rs < 0.57)
                {
                    dataTable.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), rs, "4");
                }
                else if (rs > 0.57 && rs < 0.84)
                {
                    dataTable.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), rs, "5");
                }
                else if (rs > 0.84 && rs < 1)
                {
                    dataTable.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), rs, "6");
                }
            }

            dataGridView2.DataSource = dataTable;


            int sabit3 = 0;
            int sabit4 = 0;
            int sabit5 = 0;
            int sabit6 = 0;

            for (int i = 0; i <= dataGridView2.RowCount - 1; i++)
            {
                if (dataGridView2.Rows[i].Cells[2].Value?.ToString() == "3")
                {
                    sabit3++;
                }
                else if (dataGridView2.Rows[i].Cells[2].Value?.ToString() == "4")
                {
                    sabit4++;
                }
                else if (dataGridView2.Rows[i].Cells[2].Value?.ToString() == "5")
                {
                    sabit5++;
                }
                else if (dataGridView2.Rows[i].Cells[2].Value?.ToString() == "6")
                {
                    sabit6++;
                }
            }
            lblikinci3.Text = sabit3.ToString();
            lblikinci4.Text = sabit4.ToString();
            lblikinci5.Text = sabit5.ToString();
            lblikinci6.Text = sabit6.ToString();
            lblikinciToplam.Text = (sabit3 + sabit4 + sabit5 + sabit6).ToString();
        }

        private void btnRassalSayi_Click(object sender, EventArgs e)
        {
            RassalSayilar rassalSayilar = new RassalSayilar();
            rassalSayilar.ShowDialog();
        }

        private void btnbtnbtn_Click(object sender, EventArgs e)
        {
            int sabit3 = 0;
            int sabit4 = 0;
            int sabit5 = 0;
            int sabit6 = 0;
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < dataGridView2.RowCount - 1; j++)
                {
                    double rs = random.NextDouble();
                    if (rs > 0 && rs < 0.19)
                    {
                        dataGridView2.Rows[j].Cells[1].Value = rs;
                        dataGridView2.Rows[j].Cells[2].Value = 3;
                        sabit3++;
                    }
                    else if (rs > 0.19 && rs < 0.57)
                    {
                        dataGridView2.Rows[j].Cells[1].Value = rs;
                        dataGridView2.Rows[j].Cells[2].Value = 4;
                        sabit4++;
                    }
                    else if (rs > 0.57 && rs < 0.84)
                    {
                        dataGridView2.Rows[j].Cells[1].Value = rs;
                        dataGridView2.Rows[j].Cells[2].Value = 5;
                        sabit5++;
                    }
                    else if (rs > 0.84 && rs < 1)
                    {
                        dataGridView2.Rows[j].Cells[1].Value = rs;
                        dataGridView2.Rows[j].Cells[2].Value = 6;
                        sabit6++;
                    }
                }
            }
            lbl1003.Text = (sabit3/1000).ToString();
            lbl1004.Text = (sabit4/1000).ToString();
            lbl1005.Text = (sabit5/1000).ToString();
            lbl1006.Text = (sabit6/1000).ToString();

        }
    }
}


