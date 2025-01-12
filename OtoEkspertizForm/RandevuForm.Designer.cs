namespace OtoEkspertizForm
{
    partial class RandevuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevuForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtAracPlaka = new DevExpress.XtraEditors.TextEdit();
            this.txtMusteriTel = new DevExpress.XtraEditors.TextEdit();
            this.txtMusteriAd = new DevExpress.XtraEditors.TextEdit();
            this.timeRandevuSaati = new DevExpress.XtraEditors.TimeEdit();
            this.dateRandevuTarihi = new DevExpress.XtraEditors.DateEdit();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracPlaka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRandevuSaati.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevuTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevuTarihi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem5,
            this.barButtonItem4});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1904, 148);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Araç Ekle";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Araç Listesi";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Randevular";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Oto Ekspertiz Raporlama";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Araç Ekle";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnKaydet);
            this.panel1.Controls.Add(this.txtAracPlaka);
            this.panel1.Controls.Add(this.txtMusteriTel);
            this.panel1.Controls.Add(this.txtMusteriAd);
            this.panel1.Controls.Add(this.timeRandevuSaati);
            this.panel1.Controls.Add(this.dateRandevuTarihi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 893);
            this.panel1.TabIndex = 35;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(967, 119);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 23);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Saat";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(743, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 23);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Tarih";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(1131, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 23);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Araç Plaka";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(818, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 23);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Müşteri Telefon";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(523, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 23);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Müşteri Adı";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(151, 274);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(1627, 533);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(822, 214);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(112, 31);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click_1);
            // 
            // txtAracPlaka
            // 
            this.txtAracPlaka.Location = new System.Drawing.Point(1094, 65);
            this.txtAracPlaka.MenuManager = this.ribbonControl1;
            this.txtAracPlaka.Name = "txtAracPlaka";
            this.txtAracPlaka.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracPlaka.Properties.Appearance.Options.UseFont = true;
            this.txtAracPlaka.Size = new System.Drawing.Size(167, 32);
            this.txtAracPlaka.TabIndex = 4;
            // 
            // txtMusteriTel
            // 
            this.txtMusteriTel.Location = new System.Drawing.Point(797, 65);
            this.txtMusteriTel.MenuManager = this.ribbonControl1;
            this.txtMusteriTel.Name = "txtMusteriTel";
            this.txtMusteriTel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusteriTel.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriTel.Size = new System.Drawing.Size(180, 32);
            this.txtMusteriTel.TabIndex = 3;
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Location = new System.Drawing.Point(485, 65);
            this.txtMusteriAd.MenuManager = this.ribbonControl1;
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusteriAd.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriAd.Size = new System.Drawing.Size(176, 32);
            this.txtMusteriAd.TabIndex = 2;
            // 
            // timeRandevuSaati
            // 
            this.timeRandevuSaati.EditValue = new System.DateTime(2025, 1, 5, 0, 0, 0, 0);
            this.timeRandevuSaati.Location = new System.Drawing.Point(926, 148);
            this.timeRandevuSaati.MenuManager = this.ribbonControl1;
            this.timeRandevuSaati.Name = "timeRandevuSaati";
            this.timeRandevuSaati.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.timeRandevuSaati.Properties.Appearance.Options.UseFont = true;
            this.timeRandevuSaati.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeRandevuSaati.Size = new System.Drawing.Size(119, 32);
            this.timeRandevuSaati.TabIndex = 1;
            // 
            // dateRandevuTarihi
            // 
            this.dateRandevuTarihi.EditValue = null;
            this.dateRandevuTarihi.Location = new System.Drawing.Point(705, 148);
            this.dateRandevuTarihi.MenuManager = this.ribbonControl1;
            this.dateRandevuTarihi.Name = "dateRandevuTarihi";
            this.dateRandevuTarihi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateRandevuTarihi.Properties.Appearance.Options.UseFont = true;
            this.dateRandevuTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRandevuTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRandevuTarihi.Size = new System.Drawing.Size(125, 32);
            this.dateRandevuTarihi.TabIndex = 0;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Anasayfa";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // RandevuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "RandevuForm";
            this.Text = "RandevuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracPlaka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRandevuSaati.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevuTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevuTarihi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TimeEdit timeRandevuSaati;
        private DevExpress.XtraEditors.DateEdit dateRandevuTarihi;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtAracPlaka;
        private DevExpress.XtraEditors.TextEdit txtMusteriTel;
        private DevExpress.XtraEditors.TextEdit txtMusteriAd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
    }
}