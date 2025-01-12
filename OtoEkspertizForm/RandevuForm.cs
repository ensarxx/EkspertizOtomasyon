using DevExpress.XtraEditors;
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
    public partial class RandevuForm : XtraForm
    {
        private MySqlConnection baglanti;

        public RandevuForm()
        {
            InitializeComponent();
            VeritabaniBaglantisiOlustur();
            RandevulariYukle();
        }

        

        private void VeritabaniBaglantisiOlustur()
        {
            string baglantiString = "Server=localhost;Database=otoekspertiz;Uid=root;Pwd=root;";
            baglanti = new MySqlConnection(baglantiString);
        }

        

        private bool RandevuKontrol()
        {
            // Seçilen tarih ve saatte başka randevu var mı kontrol et
            string sorgu = @"SELECT COUNT(*) FROM randevular 
                        WHERE randevu_tarihi = @tarih 
                        AND randevu_saati = @saat ";

            using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
            {
                cmd.Parameters.AddWithValue("@tarih", dateRandevuTarihi.DateTime.Date);
                cmd.Parameters.AddWithValue("@saat", timeRandevuSaati.Time);
                

                baglanti.Open();
                int randevuSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                baglanti.Close();

                if (randevuSayisi > 0)
                {
                    XtraMessageBox.Show("Bu tarih ve saatte başka bir randevu bulunmaktadır.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void RandevuKaydet()
        {
            string sorgu = @"INSERT INTO randevular 
                        (musteri_ad, musteri_tel, arac_plaka, randevu_tarihi, 
                         randevu_saati) 
                        VALUES 
                        (@musteri_ad, @musteri_tel, @arac_plaka, @randevu_tarihi, 
                         @randevu_saati)";

            using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
            {
                cmd.Parameters.AddWithValue("@musteri_ad", txtMusteriAd.Text);
                cmd.Parameters.AddWithValue("@musteri_tel", txtMusteriTel.Text);
                cmd.Parameters.AddWithValue("@arac_plaka", txtAracPlaka.Text);
                cmd.Parameters.AddWithValue("@randevu_tarihi", dateRandevuTarihi.DateTime.Date);
                cmd.Parameters.AddWithValue("@randevu_saati", timeRandevuSaati.Time);

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }
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


                AddCancelButtonColumn();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.Columns["Müşteri Adı"].Width = 400;
            dataGridView1.Columns["Telefon"].Width = 300;
            dataGridView1.Columns["Plaka"].Width = 240;
            dataGridView1.Columns["Randevu Tarihi"].Width = 300;
            dataGridView1.Columns["Randevu Saati"].Width = 300;
        }

        private void AddCancelButtonColumn()
        {
            // Eğer "İptal" sütunu zaten varsa, tekrar ekleme
            if (dataGridView1.Columns.Contains("İptal"))
                return;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İptal",             // Sütun başlığı
                Text = "İptal",                   // Buton üzerinde görünen yazı
                UseColumnTextForButtonValue = true, // Tüm hücrelerde aynı metin gösterilir
                Width = 100,                      // Sütun genişliği
                Name = "İptal"                    // Sütun adı
            };

            // Buton sütununu DataGridView'e ekle
            dataGridView1.Columns.Add(buttonColumn);
        }



        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (RandevuKontrol())
                {
                    RandevuKaydet();
                    XtraMessageBox.Show("Randevu başarıyla kaydedildi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RandevulariYukle();
        }

        

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            // Eğer tıklanan sütun "İptal" butonu sütunuysa
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string musteri_ad = dataGridView1.Rows[e.RowIndex].Cells["Müşteri Adı"].Value?.ToString();

                // İptal butonuna tıklama işlemi
                DialogResult result = MessageBox.Show(
                    $"{musteri_ad} plakalı aracın randevusunu iptal etmek istiyor musunuz?",
                    "Randevu İptal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Veritabanından randevuyu sil
                        string silSorgusu = "DELETE FROM randevular WHERE musteri_ad = @musteri_ad";

                        using (MySqlCommand cmd = new MySqlCommand(silSorgusu, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@musteri_ad", musteri_ad);

                            baglanti.Open();
                            int etkilenenSatir = cmd.ExecuteNonQuery();
                            baglanti.Close();

                            if (etkilenenSatir > 0)
                            {
                                // Seçili satırı DataGridView'den kaldır
                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("Randevu iptal edildi ve veritabanından silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Randevu veritabanından silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Randevu silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close(); // Her ihtimale karşı bağlantıyı kapat
                    }
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracListesiForm aracListesiForm = new AracListesiForm();
            aracListesiForm.Show();
            this.Hide();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracEkleForm form1 = new AracEkleForm();
            form1.Show();
            this.Hide();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Hide();
        }
    }


}
