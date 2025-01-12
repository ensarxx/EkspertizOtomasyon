using DevExpress.XtraEditors;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using IronPdf;
using static IronPdf.PdfPrintOptions;

namespace OtoEkspertizForm
{
    public partial class AracListesiForm : Form
    {


        private MySqlConnection conn;
        public AracListesiForm()
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



            AraclariYukle();
        }




        private void AraclariYukle()
        {
            try
            {
                // Veritabanı bağlantısını aç
                DbConnection.OpenConnection();

                // Araçları çekmek için SQL sorgusu
                string query = "SELECT plaka, marka, model FROM araclar";

                // Verileri almak için MySqlDataAdapter kullan
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();  // Verileri tutacak DataTable

                // Sorguyu çalıştır ve verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'a veri kaynağını atayın
                dataGridView1.DataSource = dt;




                // DataGridView düzenlemeleri
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



                // DataGridView'e buton sütunları ekleme
                if (!dataGridView1.Columns.Contains("SilButon"))
                {
                    DataGridViewButtonColumn silButtonColumn = new DataGridViewButtonColumn();
                    silButtonColumn.Name = "SilButon";
                    silButtonColumn.HeaderText = "Araç Sil";
                    silButtonColumn.Text = "Sil";
                    silButtonColumn.UseColumnTextForButtonValue = true; // Butonda "Sil" yazsın
                    dataGridView1.Columns.Add(silButtonColumn);
                }

                if (!dataGridView1.Columns.Contains("GoruntuleButon"))
                {
                    DataGridViewButtonColumn goruntuleButtonColumn = new DataGridViewButtonColumn();
                    goruntuleButtonColumn.Name = "GoruntuleButon";
                    goruntuleButtonColumn.HeaderText = "Aracı Görüntüle";
                    goruntuleButtonColumn.Text = "Görüntüle";
                    goruntuleButtonColumn.UseColumnTextForButtonValue = true; // Butonda "Görüntüle" yazsın
                    dataGridView1.Columns.Add(goruntuleButtonColumn);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                DbConnection.CloseConnection();
            }
        }

        private void ResmiGoruntule(String plaka)
        {
            try
            {

                string query = "SELECT resim_yolu FROM araclar WHERE plaka = @plaka";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@plaka", plaka);

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
                            aracResmi.Image = System.Drawing.Image.FromFile(tamYol);
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Geçerli hücrenin bir buton olup olmadığını kontrol edin
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string plaka = dataGridView1.Rows[e.RowIndex].Cells["plaka"].Value.ToString();
                string marka = dataGridView1.Rows[e.RowIndex].Cells["marka"].Value.ToString();
                string model = dataGridView1.Rows[e.RowIndex].Cells["model"].Value.ToString();


                if (dataGridView1.Columns[e.ColumnIndex].Name == "SilButon")
                {
                    // Araç Sil işlemi
                    DialogResult result = MessageBox.Show("Bu aracı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Veritabanından araç silme
                            string deleteQuery = "DELETE FROM araclar WHERE plaka = @plaka;" +
                                "DELETE FROM hasarlar WHERE plaka = @plaka;";

                            // Komut oluştur ve parametre ata
                            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@plaka", plaka);

                                // Veritabanı bağlantısını aç ve sorguyu çalıştır
                                DbConnection.OpenConnection();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                DbConnection.CloseConnection();

                                if (rowsAffected > 0)
                                {
                                    // DataGridView'den kaydı kaldır
                                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                                    MessageBox.Show("Araç başarıyla silindi.");
                                }
                                else
                                {
                                    MessageBox.Show("Silme işlemi başarısız. Araç bulunamadı.");
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
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "GoruntuleButon")
                {
                    // Aracı Görüntüle işlemi
                    //MessageBox.Show($"Aracı görüntüleme işlemi: {plaka}");
                    HasarlariTabloyaAktar(plaka);
                    ResmiGoruntule(plaka);
                    NotlariPaneldeGoster(plaka);
                    BilgiKartiniOlustur2(plaka, marka, model);
                }



            }
        }





        private void HasarlariTabloyaAktar(String plaka)
        {

            try
            {
                // Veritabanı bağlantısını aç
                DbConnection.OpenConnection();

                // SQL SELECT sorgusu
                string selectQuery = "SELECT solOnCamurluk, solOnKapi, solArkaKapi, solArkaCamurluk, bagajKapagi, tavan, sagOnCamurluk, sagOnKapi, sagArkaKapi, sagArkaCamurluk, onKaput " +
                                     "FROM hasarlar WHERE plaka = @plaka";

                // Komut oluştur
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@plaka", plaka); // Plaka değerini parametre olarak ekle

                    // Veriyi okumak için MySqlDataReader kullan
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Verileri combobox'lara doldur
                            String solOnCamurluk = reader["solOnCamurluk"].ToString();
                            String solOnKapi = reader["solOnKapi"].ToString();
                            String solArkaKapi = reader["solArkaKapi"].ToString();
                            String solArkaCamurluk = reader["solArkaCamurluk"].ToString();
                            String bagajKapagi = reader["bagajKapagi"].ToString();
                            String tavan = reader["tavan"].ToString();
                            String sagOnCamurluk = reader["sagOnCamurluk"].ToString();
                            String sagOnKapi = reader["sagOnKapi"].ToString();
                            String sagArkaKapi = reader["sagArkaKapi"].ToString();
                            String sagArkaCamurluk = reader["sagArkaCamurluk"].ToString();
                            String onKaput = reader["onKaput"].ToString();

                            switch (solOnCamurluk)
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
                            switch (solOnKapi)
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
                            switch (solArkaKapi)
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
                            switch (solArkaCamurluk)
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
                            switch (bagajKapagi)
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
                            switch (tavan)
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
                            switch (sagOnCamurluk)
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
                            switch (sagOnKapi)
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
                            switch (sagArkaKapi)
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

                            switch (sagArkaCamurluk)
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
                            switch (onKaput)
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
                        else
                        {
                            MessageBox.Show("Plaka için kayıt bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                DbConnection.CloseConnection();
            }
        }

        private string AracNotlariniGetir(string plaka)
        {
            string aracNotlar = string.Empty; // Varsayılan değer boş
            try
            {
                // Veritabanı bağlantısını aç
                DbConnection.OpenConnection();

                // SQL sorgusu
                string query = "SELECT aracNotlar FROM hasarlar WHERE plaka = @plaka";

                // Komut oluştur
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Plaka parametresini ekle
                    cmd.Parameters.AddWithValue("@plaka", plaka);

                    // Sorguyu çalıştır ve sonuç al
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        aracNotlar = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                DbConnection.CloseConnection();
            }

            return aracNotlar;
        }

        private void NotlariPaneldeGoster(string aracPlaka)
        {

            String aracNotlar = AracNotlariniGetir(aracPlaka);

            // Öncelikle PanelControl'ü temizle
            panelControl2.Controls.Clear();

            // Notlar LabelControl
            LabelControl notlarLabel = new LabelControl
            {
                Text = string.IsNullOrEmpty(aracNotlar) ? "Araç hakkında not bulunmamaktadır." : aracNotlar,
                Font = new Font("Arial", 12),
                ForeColor = Color.Black,
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical,
                LineVisible = true, // Çizgi ayırıcısı
                Location = new Point(10, 50), // Başlık altına yerleştir
                Size = new Size(panelControl2.Width - 20, panelControl2.Height - 70) // Panelin boyutuna uyacak şekilde ayarla
            };

            // Panelin boyutu değiştiğinde LabelControl'ün boyutunu güncellemek için Dock özelliğini kullanabilirsiniz.
            notlarLabel.Dock = DockStyle.Fill;

            // LabelControl'ü PanelControl'e ekle
            panelControl2.Controls.Add(notlarLabel);
        }




        private void BilgiKartiniOlustur2(string plaka, string marka, string model)
        {

            panelControl1.Controls.Clear();
            panelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left; // Sol üst köşeye sabitle

            // Başlık LabelControl
            LabelControl baslik = new LabelControl
            {
                Text = "Araç Bilgi Kartı",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(20, 20)
            };
            panelControl1.Controls.Add(baslik);

            // Plaka LabelControl
            LabelControl plakaLabel = new LabelControl
            {
                Text = $"Plaka: {plaka}",
                Font = new Font("Arial", 12),
                Location = new Point(20, 60)
            };
            panelControl1.Controls.Add(plakaLabel);

            // Marka LabelControl
            LabelControl markaLabel = new LabelControl
            {
                Text = $"Marka: {marka}",
                Font = new Font("Arial", 12),
                Location = new Point(20, 100)
            };
            panelControl1.Controls.Add(markaLabel);

            // Model LabelControl
            LabelControl modelLabel = new LabelControl
            {
                Text = $"Model: {model}",
                Font = new Font("Arial", 12),
                Location = new Point(20, 140)
            };
            panelControl1.Controls.Add(modelLabel);

            // panelControl1'i panel1'e ekle
            panel2.Controls.Add(panelControl1);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracEkleForm form1 = new AracEkleForm();
            form1.Show();
            this.Hide();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Rectangle region = new Rectangle(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "PDF olarak kaydet";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //CaptureRegionToPdf(this,region, saveFileDialog.FileName);
                    panel2.BackColor = Color.White;
                    CaptureFormToPdf(panel2, saveFileDialog.FileName);
                    panel2.BackColor = Color.DimGray;
                }
            }

        }




        public static void CaptureFormToPdf(Control control, string filePath)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(control.Width, control.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(control.BackColor); // Arka planı temizle

                        // Z sırasına göre kontrolleri çiz
                        foreach (Control child in GetControlsInZOrder(control))
                        {
                            Bitmap childBitmap = new Bitmap(child.Width, child.Height);
                            child.DrawToBitmap(childBitmap, new Rectangle(0, 0, child.Width, child.Height));
                            g.DrawImage(childBitmap, child.Location);
                        }
                    }

                    string tempImagePath = System.IO.Path.GetTempFileName() + ".png";
                    bitmap.Save(tempImagePath, ImageFormat.Png);

                    string html = $@"
            <html>
            <head>
                <style>
                    body {{
                        margin: 0;
                        padding: 0;
                        background-color: white;
                        width: {control.Width}px;
                        height: {control.Height}px;
                    }}
                    img {{
                        width: 100%;
                        height: 100%;
                        display: block;
                    }}
                </style>
            </head>
            <body>
                <img src='{tempImagePath}' />
            </body>
            </html>";

                    var renderer = new HtmlToPdf();
                    renderer.PrintOptions.MarginTop = 0;
                    renderer.PrintOptions.MarginBottom = 0;
                    renderer.PrintOptions.MarginLeft = 0;
                    renderer.PrintOptions.MarginRight = 0;

                    var pdf = renderer.RenderHtmlAsPdf(html);
                    pdf.SaveAs(filePath);

                    System.IO.File.Delete(tempImagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF oluşturulurken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IEnumerable<Control> GetControlsInZOrder(Control control)
        {
            List<Control> controls = new List<Control>();
            foreach (Control child in control.Controls)
            {
                controls.Add(child);
            }
            controls.Sort((c1, c2) => control.Controls.GetChildIndex(c2).CompareTo(control.Controls.GetChildIndex(c1)));
            return controls;
        }







        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RandevuForm randevuForm = new RandevuForm();
            randevuForm.Show();
            this.Hide();

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Hide();

        }

        private void AracListesiForm_Load(object sender, EventArgs e)
        {
            

        }
    }
}
