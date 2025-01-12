using DevExpress.XtraGauges.Win.Gauges.Circular;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoEkspertizForm
{
    public partial class MainMenuForm : Form
    {

        private MySqlConnection baglanti;

        public MainMenuForm()
        {
            InitializeComponent();

            VeritabaniBaglantisiOlustur();
            RandevulariYukle();
            AraclariYukle();
            
            // Timer'ı başlat
            Timer timer1 = new Timer();
            timer1.Interval = 1000; // 1 saniye
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }


        private void VeritabaniBaglantisiOlustur()
        {
            string baglantiString = "Server=localhost;Database=otoekspertiz;Uid=root;Pwd=root;";
            baglanti = new MySqlConnection(baglantiString);
        }


        private void RandevulariYukle()
        {

            try
            {
                string sorgu = @"
                SELECT 
                    musteri_ad as 'Müşteri Adı',
                    musteri_tel as 'Telefon',
                    arac_plaka as 'Plaka',
                    DATE_FORMAT(randevu_tarihi, '%d.%m.%Y') as 'Randevu Tarihi',
                    DATE_FORMAT(randevu_saati, '%H:%i') as 'Randevu Saati'
                FROM randevular 
                ORDER BY randevu_tarihi DESC, randevu_saati DESC";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sorgu, baglanti))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Sütun başlıklarını özelleştir
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        column.DefaultCellStyle.ForeColor = Color.Black;
                    }

                    // Görünüm ayarları
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                    dataGridView1.BackgroundColor = Color.White;
                    dataGridView1.BorderStyle = BorderStyle.Fixed3D;
                }         

             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            dataGridView1.Columns["Müşteri Adı"].Width = 100;
            dataGridView1.Columns["Telefon"].Width = 75;
            dataGridView1.Columns["Plaka"].Width = 60;
            dataGridView1.Columns["Randevu Tarihi"].Width = 75;
            dataGridView1.Columns["Randevu Saati"].Width = 75;


        }





        private void AraclariYukle()
        {
            try
            {
                string sorgu = @"
                SELECT 
                    plaka as 'Plaka',
                    marka as 'Marka',
                    model as 'Model'                    
                FROM araclar ";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sorgu, baglanti))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;

                    // Sütun başlıklarını özelleştir
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        column.DefaultCellStyle.ForeColor = Color.Black;
                    }

                    // Görünüm ayarları
                    dataGridView2.RowHeadersVisible = false;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                    dataGridView2.BackgroundColor = Color.White;
                    dataGridView2.BorderStyle = BorderStyle.Fixed3D;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            dataGridView2.Columns["Plaka"].Width = 170;
            dataGridView2.Columns["Marka"].Width = 110;
            dataGridView2.Columns["Model"].Width = 100;
            



        }




        private void Timer1_Tick(object sender, EventArgs e)
        {
            // DigitalGauge üzerinde saat:dakika formatında saat gösterimi
            digitalGauge10.Text = DateTime.Now.ToString("HH:mm");
        }



       




    private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracEkleForm form1 = new AracEkleForm();

            form1.Show();
            this.Hide();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracListesiForm araclistesi = new AracListesiForm();
            araclistesi.Show();
            this.Hide();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RandevuForm randevuForm = new RandevuForm();
            randevuForm.Show();
            this.Hide();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
