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
namespace covid_takip
{
    public partial class Form1 : Form
    {
        double bay = 0, bayan = 0;
        double diyabet = 0, koah = 0, kanser = 0, astım = 0, kalp = 0, yuktansiyon = 0, depresyon = 0, diger = 0;

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
            if (maskedTextBox2.Text == label4.Text)
            {
                timer1.Stop();
                SoundPlayer ses = new SoundPlayer();
                string alarm = Application.StartupPath + "//TF032.WAV";
                ses.SoundLocation = alarm;
                ses.Play();
            }
            timer1.Start();
            MessageBox.Show("Sayın" + "\t" + textBox1.Text + "\tKarantinanız  " + maskedTextBox2.Text + "\t" + "tarihinde  bitiyor!!\nSaglıklı günler dileriz...");


            string ADSOY = textBox1.Text;
            textBox1.Text = "";
            string TC = textBox2.Text;
            textBox2.Text = "";
            string TLF = maskedTextBox1.Text;
            maskedTextBox1.Text = "";
            string CNSYT = "";
            if (radioButton1.Checked == true)
            {
                CNSYT = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                CNSYT = radioButton2.Text;
            }
            //burdayız
            string ILAC = cmbılac.Text;
            cmbılac.Text = "";
            string KGUN = maskedTextBox2.Text;
            maskedTextBox2.Text = "";
            string[] kişibil = { ADSOY, TC, TLF, CNSYT, ILAC, KGUN };
            bool aranantc = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text == textBox2.Text)
                {
                    aranantc = true;
                    MessageBox.Show(textBox2.Text + "tc kimlik numarası mevcuttur!!");
                }
            }
            if (aranantc == false)
            {
                ListViewItem lst = new ListViewItem(kişibil);
                if (ADSOY != "" && TC != "" && TLF != "" && CNSYT != "" && ILAC != "")
                    listView1.Items.Add(lst);
                else
                    MessageBox.Show("Bilgileri eksiksiz giriniz!!");
                kytsysyaz();
            }

            if (radioButton1.Checked)
            {
                chart1.Series["CİNSİYET"].Points.AddXY("BAY", bay);
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                bay++;
                chart1.Series["CİNSİYET"].Points.AddXY("BAY", bay);
                chart1.Series["CİNSİYET"].Points.AddXY("BAYAN", bayan);
            }
            else if (radioButton2.Checked)
            {
                chart1.Series["CİNSİYET"].Points.AddXY("BAYAN", bayan);
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                bayan++;
                chart1.Series["CİNSİYET"].Points.AddXY("BAYAN", bayan);
                chart1.Series["CİNSİYET"].Points.AddXY("BAY", bay);
            }
            // diger chart
            if (checkBox1.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("diyabet", diyabet);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                diyabet++;
                tablo();
            }
            else if (checkBox2.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("koah", kooh);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                koah++;
                tablo();
            }
            else if (checkBox3.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("kanser", kanser);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                kanser++;
                tablo();
            }
            else if (checkBox4.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("astım", astim);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                astim++;
                tablo();
            }
            else if (checkBox5.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("kalp", kalp);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                kalp++;
                tablo();
            }
            else if (checkBox6.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("y.tans", yuktansiyon);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                yuktansiyon++;
                tablo();
            }
            else if (checkBox7.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("depresyon", depresyon);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                depresyon++;
                tablo();
            }
            else if (checkBox8.Checked)
            {
                chart2.Series["HASTALIKLAR"].Points.AddXY("diger", diger);
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                diger++;
                tablo();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("AD SOYAD", 150);
            listView1.Columns.Add("TC", 100);
            listView1.Columns.Add("TELEFON", 100);
            listView1.Columns.Add("CİNSİYET", 70);
            listView1.Columns.Add("İLAÇ", 110);
            listView1.Columns.Add("KRNT GÜNÜ", 120);

            cmbılac.Items.Add("oseltamivir");
            cmbılac.Items.Add("hidrpksiklorokin");
            cmbılac.Items.Add("lopivanir");
            cmbılac.Items.Add("favipiravir");
            cmbılac.Items.Add("favicovir");
            cmbılac.Items.Add("loqular");
            cmbılac.Items.Add("favira");
            cmbılac.Items.Add("raviran");

            kytsysyaz();
            timer1.Start();

        }
        private void tablo()
        {
            chart2.Series["HASTALIKLAR"].Points.AddXY("diyabet", diyabet);
            chart2.Series["HASTALIKLAR"].Points.AddXY("koah", koak);
            chart2.Series["HASTALIKLAR"].Points.AddXY("kanser", kanser);
            chart2.Series["HASTALIKLAR"].Points.AddXY("astım", astim);
            chart2.Series["HASTALIKLAR"].Points.AddXY("kalp", kalp);
            chart2.Series["HASTALIKLAR"].Points.AddXY("y.tans", yuktansiyon);
            chart2.Series["HASTALIKLAR"].Points.AddXY("depresyon", depresyon);
            chart2.Series["HASTALIKLAR"].Points.AddXY("diger", diger);
        }
        private void kytsysyaz()
        {
            int kytsys = listView1.Items.Count;
            label8.Text = Convert.ToString(kytsys);
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {            
            int secilen = listView1.CheckedItems.Count;
            foreach (ListViewItem secilenkayıt in listView1.CheckedItems)
            {
                secilenkayıt.Remove();
            }
            MessageBox.Show(secilen.ToString()+"Adet kayıt silindi");
            kytsysyaz();            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool aranantc = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text==textBox2.Text)
                {
                    aranantc = true;
                    textBox1.Text = listView1.Items[i].SubItems[0].Text;
                    maskedTextBox1.Text = listView1.Items[i].SubItems[2].Text;
                    if(listView1.Items[i].SubItems[3].Text=="BAY")
                    {
                        radioButton1.Checked =true;
                    }
                    if (listView1.Items[i].SubItems[3].Text == "BAYAN")
                    {
                        radioButton2.Checked = true;
                    }
                    maskedTextBox2.Text = listView1.Items[i].SubItems[5].Text;
                    cmbılac.Text = listView1.Items[i].SubItems[4].Text;
                    textBox1.Enabled=false;
                    maskedTextBox1.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    maskedTextBox2.Enabled = false;
                    cmbılac.Enabled = false;
                }
                kytsysyaz();
            }
            if (aranantc == false)
                MessageBox.Show(textBox2.Text + "numaralı TC kayıtlarımızda bulunamadı...");
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
