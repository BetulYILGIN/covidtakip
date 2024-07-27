using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;



namespace covid_takip
{
        public partial class Form1 : Form

    {


        double X = 0, Y = 0, Z = 0, T = 0;
        double ates = 0, kusma = 0, halsizlik = 0, oksuruk = 0, akinti = 0, tkkaybi = 0, bagri = 0, ndarligi = 0,
            ishal = 0, gagri = 0, balgam = 0, hsolunum = 0, titreme = 0, terleme = 0;
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            string.Format("{0:dd/mm/yyy}", DateTime.Now);
            label4.Text = DateTime.Now.ToShortDateString();

        }
        public string hatırlat = " ";


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;


            timer1.Start();
            string ADSOY = textBox1.Text;
            textBox1.Text = "";
            string TC = textBox2.Text;
            textBox2.Text = "";
            bool tcExists = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text == TC)
                {
                    tcExists = true;
                    MessageBox.Show(TC + " Nolu TC Zaten Mevcut. Aynı Kimlik Numarası ile Tekrar Kayıt Yapamazsın!!");
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    cbates.Checked = false;
                    cbkusma.Checked = false;
                    cbhalsizlik.Checked = false;
                    cboksuruk.Checked = false;
                    cbakinti.Checked = false;
                    cbkayip.Checked = false;
                    cbbagrisi.Checked = false;
                    cbnefes.Checked = false;
                    cbbalgam.Checked = false;
                    cbgagri.Checked = false;
                    cbhızlısolunum.Checked = false;
                    cbishal.Checked = false;
                    cbterleme.Checked = false;
                    cbtitreme.Checked = false;
                    cmbılac.SelectedIndex = -1;
                    maskedTextBox1.Text = "";
                    maskedTextBox2.Text = "";
                    return;
                }
            }
            string TLF = maskedTextBox1.Text;
            maskedTextBox1.Text = "";
            string YAS = "";
            if (radioButton1.Checked == true)
            {
                YAS = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                YAS = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                YAS = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                YAS = radioButton4.Text;
            }
            List<string> belirti = new List<string>();
            if (cbates.Checked) belirti.Add(cbates.Text);
            if (cbkusma.Checked) belirti.Add(cbkusma.Text);
            if (cbhalsizlik.Checked) belirti.Add(cbhalsizlik.Text);
            if (cboksuruk.Checked) belirti.Add(cboksuruk.Text);
            if (cbakinti.Checked) belirti.Add(cbakinti.Text);
            if (cbkayip.Checked) belirti.Add(cbkayip.Text);
            if (cbbagrisi.Checked) belirti.Add(cbbagrisi.Text);
            if (cbnefes.Checked) belirti.Add(cbnefes.Text);
            if (cbterleme.Checked) belirti.Add(cbterleme.Text);
            if (cbishal.Checked) belirti.Add(cbishal.Text);
            if (cbgagri.Checked) belirti.Add(cbgagri.Text);
            if (cbhızlısolunum.Checked) belirti.Add(cbhızlısolunum.Text);
            if (cbbalgam.Checked) belirti.Add(cbbalgam.Text);
            if (cbtitreme.Checked) belirti.Add(cbtitreme.Text);         

            string belirtiText = string.Join(", ", belirti.ToArray());
            string CİNSİYET = cmbılac.Text;
            cmbılac.Text = "";
            string KGUN = maskedTextBox2.Text;
            maskedTextBox2.Text = "";
            string[] kişibil = { ADSOY, TC, TLF, YAS, CİNSİYET, KGUN, belirtiText };
            bool aranantc = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text == textBox2.Text)
                {
                    aranantc = true;
                    MessageBox.Show(textBox2.Text + "tc kimlik numarası mevcuttur!!");
                    return;
                }
            }
            if (aranantc == false)
            {
                ListViewItem lst = new ListViewItem(kişibil);
                if (ADSOY != "" && TC != "" && TLF != "" && YAS != "" && CİNSİYET != "")
                    listView1.Items.Add(lst);
                else
                    MessageBox.Show("Bilgileri eksiksiz giriniz!!");
                kytsysyaz();
            }

            if (radioButton1.Checked)
            {
                chart1.Series["YAS"].Points.AddXY("0-18", X);
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                X++;
                chart1.Series["YAS"].Points.AddXY("0-18", X);
                chart1.Series["YAS"].Points.AddXY("19-30", Y);
                chart1.Series["YAS"].Points.AddXY("31-50", Z);
                chart1.Series["YAS"].Points.AddXY("51 VE ÜSTÜ", T);
            }
            else if (radioButton2.Checked)
            {
                chart1.Series["YAS"].Points.AddXY("19-30", Y);
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                Y++;
                chart1.Series["YAS"].Points.AddXY("19-30", Y);
                chart1.Series["YAS"].Points.AddXY("0-18", X);
                chart1.Series["YAS"].Points.AddXY("31-50", Z);
                chart1.Series["YAS"].Points.AddXY("51 VE ÜSTÜ", T);
            }
            else if (radioButton3.Checked)
            {
                chart1.Series["YAS"].Points.AddXY("31-50", Z);
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                Z++;
                chart1.Series["YAS"].Points.AddXY("31-50", Z);
                chart1.Series["YAS"].Points.AddXY("0-18", X);
                chart1.Series["YAS"].Points.AddXY("19-30", Y);
                chart1.Series["YAS"].Points.AddXY("51 VE ÜSTÜ", T);
            }
            else if (radioButton4.Checked)
            {
                chart1.Series["YAS"].Points.AddXY("51 VE ÜSTÜ", T);
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                T++;
                chart1.Series["YAS"].Points.AddXY("51 VE ÜSTÜ", T);
                chart1.Series["YAS"].Points.AddXY("0-18", X);
                chart1.Series["YAS"].Points.AddXY("19-30", Y);
                chart1.Series["YAS"].Points.AddXY("31-50", Z);
            }
            ekle();
            klinikkarardestek();
            string connectionString = "Data Source=BETUL;Initial Catalog=klinikkarardestek;Integrated Security=True";
            string insertQuery = "INSERT INTO veritbll (ADSOYAD, TC, TELEFON,YAS,CINSIYET,GÜN,BELİRTİLER) " +
                                "VALUES (@ADSOY, @TC,@TLF,@YAS,@CNSYT,@GUN,@BELIRTI)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@ADSOY", ADSOY);
                    cmd.Parameters.AddWithValue("@TC", TC);
                    cmd.Parameters.AddWithValue("@TLF", TLF);
                    cmd.Parameters.AddWithValue("@YAS", YAS);
                    cmd.Parameters.AddWithValue("@CNSYT", CİNSİYET);
                    cmd.Parameters.AddWithValue("@GUN", KGUN);
                    cmd.Parameters.AddWithValue("@BELIRTI", belirtiText);
                    cmd.ExecuteNonQuery();
                }
            }

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            cbates.Checked = false;
            cbkusma.Checked = false;
            cbhalsizlik.Checked = false;
            cboksuruk.Checked = false;
            cbakinti.Checked = false;
            cbkayip.Checked = false;
            cbbagrisi.Checked = false;
            cbnefes.Checked = false;
            cbbalgam.Checked = false;
            cbgagri.Checked = false;
            cbhızlısolunum.Checked = false;
            cbishal.Checked = false;
            cbterleme.Checked = false;
            cbtitreme.Checked = false;
            cmbılac.SelectedIndex = -1;
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }
        private void getir()
        {
            string connectionString = "Data Source=BETUL;Initial Catalog=klinikkarardestek;Integrated Security=True";
            string selectQuery = "SELECT ADSOYAD, TC, TELEFON, YAS, CINSIYET, GÜN, BELİRTİLER FROM veritbll";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] rowData = {
                        reader["ADSOYAD"].ToString(),
                        reader["TC"].ToString(),
                        reader["TELEFON"].ToString(),
                        reader["YAS"].ToString(),
                        reader["CINSIYET"].ToString(),
                        reader["GÜN"].ToString(),
                        reader["BELİRTİLER"].ToString()
                    };

                            ListViewItem item = new ListViewItem(rowData);
                            listView1.Items.Add(item);
                        }
                    }
                }
            }

            kytsysyaz();
        }

        private void ekle()
        {
            chart2.Series["BELİRTİLER"].Points.Clear();
            if (cbates.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("ATEŞ", ates);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                ates++;
                tablo();
            }
            if (cbkusma.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("KUSMA", kusma);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                kusma++;
                tablo();
            }
            if (cbhalsizlik.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("HALSİZLİK", halsizlik);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                halsizlik++;
                tablo();
            }

            if (cboksuruk.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("ÖKSÜRÜK", oksuruk);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                oksuruk++;
                tablo();
            }

            if (cbakinti.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("AKINTI", akinti);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                akinti++;
                tablo();
            }
            if (cbkayip.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("TAT VE KOKU KAYBI", tkkaybi);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                tkkaybi++;
                tablo();
            }
            if (cbbagrisi.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("BOĞAZ AĞRISI", bagri);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                bagri++;
                tablo();
            }
            if (cbnefes.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("NEFES DARLIĞI", ndarligi);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                ndarligi++;
                tablo();
            }
            if (cbterleme.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("TERLEME", terleme);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                terleme++;
                tablo();
            }
            if (cbishal.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("İSHAL", ishal);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                ishal++;
                tablo();
            }
            if (cbgagri.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("BOĞAZ AĞRISI", gagri);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                gagri++;
                tablo();
            }
            if (cbhızlısolunum.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("HIZLI SOLUNUM", hsolunum);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                hsolunum++;
                tablo();
            }
            if (cbbalgam.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("BALGAM", balgam);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                balgam++;
                tablo();
            }
            if (cbtitreme.Checked)
            {
                chart2.Series["BELİRTİLER"].Points.AddXY("TİTREME", titreme);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                titreme++;
                tablo();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tablo();
            getir();
            string ageGroupQuery = "SELECT YAS, COUNT(*) as Count FROM veritbll GROUP BY YAS";
            guncelle(chart1, "YAS", ageGroupQuery);
            string symptomsQuery = "SELECT BELİRTİLER, COUNT(*) as Count FROM veritbll GROUP BY BELİRTİLER";
            guncelle(chart2, "BELİRTİLER", symptomsQuery);

            listView1.Columns.Add("AD SOYAD", 150);
            listView1.Columns.Add("TC", 100);
            listView1.Columns.Add("TELEFON", 120);
            listView1.Columns.Add("YAS", 80);
            listView1.Columns.Add("CİNSİYET", 110);
            listView1.Columns.Add("GÜN", 110);
            listView1.Columns.Add("BELİRTİLER", 350);

            cmbılac.Items.Add("KADIN");
            cmbılac.Items.Add("ERKEK");
            cmbılac.Items.Add("BELİRTMEMEYİ TERCİH EDİYORUM");

            kytsysyaz();
            timer1.Start();

        }
        private void guncelle(System.Windows.Forms.DataVisualization.Charting.Chart chart2, string seriesName, string query)
        {
            chart2.Series[seriesName].Points.Clear();

            string connectionString = "Data Source=BETUL;Initial Catalog=klinikkarardestek;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader[0].ToString();
                            int count = Convert.ToInt32(reader[1]);

                            chart2.Series[seriesName].Points.AddXY(category, count);
                        }
                    }
                }
            }
        }

        private void tablo()
        {
            chart2.Series["BELİRTİLER"].Points.AddXY("ATEŞ", ates);
            chart2.Series["BELİRTİLER"].Points.AddXY("KUSMA", kusma);
            chart2.Series["BELİRTİLER"].Points.AddXY("HALSİZLİK", halsizlik);
            chart2.Series["BELİRTİLER"].Points.AddXY("ÖKSÜRÜK", oksuruk);
            chart2.Series["BELİRTİLER"].Points.AddXY("AKINTI", akinti);
            chart2.Series["BELİRTİLER"].Points.AddXY("TAT VE KOKU KAYBI", tkkaybi);
            chart2.Series["BELİRTİLER"].Points.AddXY("BOĞAZ AĞRISI", bagri);
            chart2.Series["BELİRTİLER"].Points.AddXY("NEFES DARLIĞI", ndarligi);
            chart2.Series["BELİRTİLER"].Points.AddXY("İSHAL", ishal);
            chart2.Series["BELİRTİLER"].Points.AddXY("HIZLI SOLUNUM", hsolunum);
            chart2.Series["BELİRTİLER"].Points.AddXY("GÖĞÜS AĞRISI", gagri);
            chart2.Series["BELİRTİLER"].Points.AddXY("TERLEME", terleme);
            chart2.Series["BELİRTİLER"].Points.AddXY("TİTREME", titreme);
            chart2.Series["BELİRTİLER"].Points.AddXY("BALGAM", balgam);
        }
        private void kytsysyaz()
        {
            int kytsys = listView1.Items.Count;
            label8.Text = Convert.ToString(kytsys);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilen = listView1.CheckedItems.Count;

            foreach (ListViewItem secilenkayıt in listView1.CheckedItems)
            {
                string tcToDelete = secilenkayıt.SubItems[1].Text;
                sil(tcToDelete);
                secilenkayıt.Remove();
            }
            MessageBox.Show(secilen.ToString() + "Adet kayıt silindi");
            kytsysyaz();
        }
        private void sil(string tc)
        {
            string connectionString = "Data Source=BETUL;Initial Catalog=klinikkarardestek;Integrated Security=True";
            string deleteQuery = "DELETE FROM veritbll WHERE TC = @TC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TC", tc);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool aranantc = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text == textBox2.Text)
                {
                    aranantc = true;
                    textBox1.Text = listView1.Items[i].SubItems[0].Text;
                    maskedTextBox1.Text = listView1.Items[i].SubItems[2].Text;

                    if (listView1.Items[i].SubItems[3].Text == "0-18")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[3].Text == "19-30")
                    {
                        radioButton2.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[3].Text == "31-50")
                    {
                        radioButton3.Checked = true;
                    }
                }
                maskedTextBox2.Text = listView1.Items[i].SubItems[5].Text;
                cmbılac.Text = listView1.Items[i].SubItems[4].Text;
                textBox1.Enabled = false;
                maskedTextBox1.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                maskedTextBox2.Enabled = false;
                cmbılac.Enabled = false;
            }
        
                kytsysyaz();
                if (aranantc == false)
                {
                    MessageBox.Show(textBox2.Text + "numaralı TC kayıtlarımızda bulunamadı...");
                }
                else
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                }
            
        }
        //******************************************************************************************************************

        private void klinikkarardestek()
        {
            //yaş grubuna göre risk degerlendirmesi
            int toplamrisk = 0;
            if (radioButton1.Checked == true)
                toplamrisk += 5;
            else if (radioButton2.Checked == true)
                toplamrisk += 10;
            else if (radioButton3.Checked == true)
                toplamrisk += 10;
            else if (radioButton4.Checked == true)
                toplamrisk += 15;

            //belirtilere göre risk degerlendirmesi
            if (cbates.Checked) toplamrisk += 20;
            if (cbkusma.Checked) toplamrisk += 10;
            if (cbhalsizlik.Checked) toplamrisk += 15;
            if (cboksuruk.Checked) toplamrisk += 15;
            if (cbakinti.Checked) toplamrisk += 5;
            if (cbkayip.Checked) toplamrisk += 25;
            if (cbbagrisi.Checked) toplamrisk += 5;
            if (cbishal.Checked) toplamrisk += 20;
            if (cbtitreme.Checked) toplamrisk -= 15;
            if (cbterleme.Checked) toplamrisk -= 10;
            if (cbbalgam.Checked) toplamrisk -= 10;
            if (cbnefes.Checked) toplamrisk += 15;
            if (cbhızlısolunum.Checked) toplamrisk -= 20;
            if (cbgagri.Checked) toplamrisk -= 5;

            //belirti süresine göre risk değerlendire
            if (maskedTextBox2.Text == DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy")) toplamrisk += 15;
            else if (maskedTextBox2.Text == DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy")) toplamrisk += 10;

            // Belirtilerin birlikte ortaya çıkması durumunda risk puanlarını artır
            if (cbates.Checked && cbnefes.Checked) toplamrisk+= 5;
            if (cbates.Checked && cbkayip.Checked) toplamrisk += 10;
            if (cbates.Checked && cbhalsizlik.Checked) toplamrisk += 5;
            if (cbnefes.Checked && cbhalsizlik.Checked) toplamrisk += 10;

            //zatüreyle karıştırılması durumunda zatüre belirtilerinden varsa covid oranını azaltmak için
            if (cbhızlısolunum.Checked && cbtitreme.Checked) toplamrisk -= 15;
            if (cbbalgam.Checked && cbtitreme.Checked) toplamrisk -= 10;

            double hesapla = (toplamrisk / 100.0) * 100;
            if (hesapla <= 20)
            {
                // Düşük risk
                MessageBox.Show("Covid'e yakalanmış olma olasılığınız düşüktür. Covid'e yakalanmış olma olasılığı: "
                    + hesapla.ToString("0.0") + "%");
            }
            else if (hesapla <= 50)
            {
                // orta risk
                MessageBox.Show("Covid'e yakalanmış olma olasılığınız orta düzeydedir. Bir doktora görünmenizi öneririz.." +
                    " Covid'e yakalanmış olma olasılığı: " + hesapla.ToString("0.0") + "%");
            }
            else if (hesapla <= 90)
            {
                // yüksek risk
                MessageBox.Show("Covid'e yakalanmış olma olasılığınız yüksektir. Acil olarak bir doktora görünmenizi öneririz." +
                    " Covid'e yakalanmış olma olasılığı: " + hesapla.ToString("0.0") + "%");
            }
            else if (hesapla <= 150)
            {
                // yüksek risk
                timer1.Stop();
                SoundPlayer ses = new SoundPlayer();
                string alarm = Application.StartupPath + "//TF032.WAV";
                ses.SoundLocation = alarm;
                ses.Play();
                MessageBox.Show("Covid'e yakalanmış olma olasılığınız çok yüksektir. Acil olarak hastaneye başvurmanız gerekmektedir!!." +
                    " Covid'e yakalanmış olma olasılığı: " + hesapla.ToString("0.0") + "%");
                    
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {          
            textBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            groupBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            cmbılac.Enabled = true;
        }
    }
}
