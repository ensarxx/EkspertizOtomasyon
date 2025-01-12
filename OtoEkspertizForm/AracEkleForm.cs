using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoEkspertizForm
{
    public partial class AracEkleForm : Form
    {



        private MySqlConnection conn;
        private string imageFolder;

        public AracEkleForm()
        {
            InitializeComponent();
            conn = DbConnection.GetConnection();            


            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            p9.Visible = false;
            p10.Visible = false;
            p11.Visible = false;


            

            btnResimGoster.Visible = false;
            btnResimYukle.Visible = false;

        }

       

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

       

        private void hasar_tablosuna_ekle_Click(object sender, EventArgs e)
        {
            switch (solOnCamurluk.Text)
            {
                case "Boyalı":
                    p1.Visible = true;
                    p1.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p1.Visible = true;
                    p1.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p1.Visible = true;
                    p1.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p1.Visible = true;
                    p1.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p1.Visible = true;
                    p1.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (solOnKapi.Text)
            {
                case "Boyalı":
                    p2.Visible = true;
                    p2.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p2.Visible = true;
                    p2.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p2.Visible = true;
                    p2.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p2.Visible = true;
                    p2.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p2.Visible = true;
                    p2.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (solArkaKapi.Text)
            {
                case "Boyalı":
                    p3.Visible = true;
                    p3.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p3.Visible = true;
                    p3.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p3.Visible = true;
                    p3.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p3.Visible = true;
                    p3.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p3.Visible = true;
                    p3.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (solArkaCamurluk.Text)
            {
                case "Boyalı":
                    p4.Visible = true;
                    p4.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p4.Visible = true;
                    p4.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p4.Visible = true;
                    p4.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p4.Visible = true;
                    p4.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p4.Visible = true;
                    p4.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (bagajKapagi.Text)
            {
                case "Boyalı":
                    p5.Visible = true;
                    p5.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p5.Visible = true;
                    p5.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p5.Visible = true;
                    p5.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p5.Visible = true;
                    p5.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p5.Visible = true;
                    p5.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (tavan.Text)
            {
                case "Boyalı":
                    p6.Visible = true;
                    p6.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p6.Visible = true;
                    p6.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p6.Visible = true;
                    p6.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p6.Visible = true;
                    p6.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p6.Visible = true;
                    p6.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (sagOnCamurluk.Text)
            {
                case "Boyalı":
                    p7.Visible = true;
                    p7.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p7.Visible = true;
                    p7.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p7.Visible = true;
                    p7.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p7.Visible = true;
                    p7.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p7.Visible = true;
                    p7.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (sagOnKapi.Text)
            {
                case "Boyalı":
                    p8.Visible = true;
                    p8.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p8.Visible = true;
                    p8.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p8.Visible = true;
                    p8.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p8.Visible = true;
                    p8.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p8.Visible = true;
                    p8.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (sagArkaKapi.Text)
            {
                case "Boyalı":
                    p9.Visible = true;
                    p9.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p9.Visible = true;
                    p9.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p9.Visible = true;
                    p9.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p9.Visible = true;
                    p9.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p9.Visible = true;
                    p9.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }

            switch (sagArkaCamurluk.Text)
            {
                case "Boyalı":
                    p10.Visible = true;
                    p10.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p10.Visible = true;
                    p10.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p10.Visible = true;
                    p10.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p10.Visible = true;
                    p10.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p10.Visible = true;
                    p10.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }
            switch (onKaput.Text)
            {
                case "Boyalı":
                    p11.Visible = true;
                    p11.Image = OtoEkspertizForm.Properties.Resources.B;
                    break;
                case "Hasarlı":
                    p11.Visible = true;
                    p11.Image = OtoEkspertizForm.Properties.Resources.H;
                    break;
                case "Düzeltilmiş":
                    p11.Visible = true;
                    p11.Image = OtoEkspertizForm.Properties.Resources.D;
                    break;
                case "Çizilmiş":
                    p11.Visible = true;
                    p11.Image = OtoEkspertizForm.Properties.Resources.Ç;
                    break;
                case "Değişmiş":
                    p11.Visible = true;
                    p11.Image = OtoEkspertizForm.Properties.Resources.X;
                    break;
                default:
                    break;
            }

        }

        private void arac_ekle_Click_1(object sender, EventArgs e)
        {

            HasarKaydet();

            if (checkResim.Checked)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Araç Resmi Seçin";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {

                            // Yeni dosya adı oluştur
                            string uzanti = Path.GetExtension(openFileDialog.FileName);

                            aracResmi.Image = Image.FromFile(openFileDialog.FileName);
                            aracResmi.SizeMode = PictureBoxSizeMode.Zoom;

                            DbConnection.OpenConnection();

                            string query = "INSERT INTO araclar (plaka, marka, model,resim_yolu) VALUES (@plaka, @marka, @model,@resim_yolu)";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                                cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                                cmd.Parameters.AddWithValue("@model", txtModel.Text);
                                cmd.Parameters.AddWithValue("@resim_yolu", openFileDialog.FileName);                            
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Araç başarıyla kaydedildi!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata oluştu: " + ex.Message);
                        }
                        finally
                        {
                            DbConnection.CloseConnection();
                        }
                    }
                }
            }
            else
            {
                try
                {
                    DbConnection.OpenConnection();
                    string query = "INSERT INTO araclar (plaka, marka, model) VALUES (@plaka, @marka, @model)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                        cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                        cmd.Parameters.AddWithValue("@model", txtModel.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Araç başarıyla kaydedildi!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    DbConnection.CloseConnection();
                }
            }

           
        }


        private void HasarKaydet()
        {
            try
            {
            

                // SQL sorgusu
                string insertQuery = @"
            INSERT INTO hasarlar (
                plaka, solOnCamurluk, solOnKapi, solArkaKapi, solArkaCamurluk,
                bagajKapagi, tavan, sagOnCamurluk, sagOnKapi, sagArkaKapi,
                sagArkaCamurluk, onKaput,aracNotlar
            ) VALUES (
                @plaka, @solOnCamurluk, @solOnKapi, @solArkaKapi, @solArkaCamurluk,
                @bagajKapagi, @tavan, @sagOnCamurluk, @sagOnKapi, @sagArkaKapi,
                @sagArkaCamurluk, @onKaput,@aracNotlar
            )";

                // MySQL komutunu oluştur
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    cmd.Parameters.AddWithValue("@solOnCamurluk", solOnCamurluk.Text);
                    cmd.Parameters.AddWithValue("@solOnKapi", solOnKapi.Text);
                    cmd.Parameters.AddWithValue("@solArkaKapi", solArkaKapi.Text);
                    cmd.Parameters.AddWithValue("@solArkaCamurluk", solArkaCamurluk.Text);
                    cmd.Parameters.AddWithValue("@bagajKapagi", bagajKapagi.Text);
                    cmd.Parameters.AddWithValue("@tavan", tavan.Text);
                    cmd.Parameters.AddWithValue("@sagOnCamurluk", sagOnCamurluk.Text);
                    cmd.Parameters.AddWithValue("@sagOnKapi", sagOnKapi.Text);
                    cmd.Parameters.AddWithValue("@sagArkaKapi", sagArkaKapi.Text);
                    cmd.Parameters.AddWithValue("@sagArkaCamurluk", sagArkaCamurluk.Text);
                    cmd.Parameters.AddWithValue("@onKaput", onKaput.Text);
                    cmd.Parameters.AddWithValue("@aracNotlar", txtAracNotlar.Text);

                    // Veritabanı bağlantısını aç ve sorguyu çalıştır
                    DbConnection.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    DbConnection.CloseConnection();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Hasar bilgileri başarıyla kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Hasar bilgileri kaydedilemedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                DbConnection.CloseConnection();
            }
        }


        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Araç Resmi Seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        // Yeni dosya adı oluştur
                        string uzanti = Path.GetExtension(openFileDialog.FileName);

                        aracResmi.Image = Image.FromFile(openFileDialog.FileName);
                        aracResmi.SizeMode = PictureBoxSizeMode.Zoom;

                        DbConnection.OpenConnection();
                        
                        string query = "INSERT INTO araclar (plaka, marka, model,resim_yolu) VALUES (@plaka, @marka, @model,@resim_yolu)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                            cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                            cmd.Parameters.AddWithValue("@model", txtModel.Text);
                            cmd.Parameters.AddWithValue("@resim_yolu", openFileDialog.FileName);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Araç başarıyla kaydedildi!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        DbConnection.CloseConnection();
                    }
                }
            }
        }

        private void btnResimGoster_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = "SELECT resim_yolu FROM araclar WHERE plaka = @plaka";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    if (result != null && result != DBNull.Value)
                    {
                        string resimYolu = result.ToString();
                        string tamYol = Path.Combine(Application.StartupPath, resimYolu);

                        if (File.Exists(tamYol))
                        {
                            // Eğer PictureBox'ta zaten bir resim varsa, dispose et
                            if (aracResmi.Image != null)
                            {
                                aracResmi.Image.Dispose();
                                aracResmi.Image = null;
                            }

                            // Yeni resmi yükle
                            aracResmi.Image = Image.FromFile(tamYol);
                            aracResmi.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            MessageBox.Show("Resim dosyası bulunamadı!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu araç için resim yolu bulunamadı!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracListesiForm araclistesi = new AracListesiForm();
            araclistesi.Show();
            this.Hide();
        }

      
             
     
        

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

      
      

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RandevuForm randevuForm = new RandevuForm();
            randevuForm.Show();
            this.Hide();
                
        }

       

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Hide();
        }
    }
    }

