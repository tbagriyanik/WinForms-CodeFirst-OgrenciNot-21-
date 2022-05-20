using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitaptanVT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        vtModel _bagla = new vtModel();

        private void Form1_Load(object sender, EventArgs e)
        {
            yukle();
        }

        private void yukle()
        {
            dataGridView2.DataSource = _bagla.OgrenciBilgileri.ToList();
            dataGridView3.DataSource = _bagla.OgrenciNotlar.ToList();
            dataGridView3.Columns["Yazili1"].HeaderText = "1.Yazılı";
            dataGridView3.Columns["Yazili2"].HeaderText = "2.Yazılı";
            dataGridView3.Columns["Yazili3"].HeaderText = "3.Yazılı";
            dataGridView3.Columns["Uygulama1"].HeaderText = "1.Uygulama";
            dataGridView3.Columns["Uygulama2"].HeaderText = "2.Uygulama";
            dataGridView3.Columns["Performans1"].HeaderText = "1.Performans";
            dataGridView3.Columns["Performans2"].HeaderText = "2.Performans";
            dataGridView3.Columns["Ortalama"].HeaderText = "Ortalama";

            dataGridView3.Columns["DersID"].Visible = false;
            dataGridView3.Columns["OgrencID"].Visible = false;
            dataGridView3.Columns["ders"].Visible = false;
            dataGridView3.Columns["ogrenciBilgi"].Visible = false;

            dataGridView4.DataSource = _bagla.Dersler.ToList();
            comboBox1.DataSource = _bagla.OgrenciBilgileri.ToList();
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "OgrencID";
            comboBox2.DataSource = _bagla.Dersler.ToList();
            comboBox2.DisplayMember = "Ad";
            comboBox2.ValueMember = "DersID";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            yukle();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //ARAMA
            var arama = _bagla.OgrenciBilgileri.Where(x => x.Ad.Contains(toolStripTextBox1.Text)).ToList();
            dataGridView2.DataSource = arama;
            tabControl1.SelectedIndex = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //ders ekle
            Ders ders = new Ders();
            ders.Ad = textBox15.Text;
            _bagla.Dersler.Add(ders);
            _bagla.SaveChanges();
            yukle();
            textBox15.Text = "";
            textBox16.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //ders sil
            if (MessageBox.Show("Sil", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int secili = (int)dataGridView4.CurrentRow.Cells[0].Value;

                Ders kayit = _bagla.Dersler.Where(x => x.DersID == secili).FirstOrDefault();
                _bagla.Dersler.Remove(kayit);
                _bagla.SaveChanges();
                yukle();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //ders Güncelle
            int secili = (int)dataGridView4.CurrentRow.Cells[0].Value;
            Ders kayit = _bagla.Dersler.Where(x => x.DersID == secili).FirstOrDefault();
            kayit.Ad = textBox15.Text;
            _bagla.SaveChanges();
            yukle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ogr ekle
            OgrenciBilgi ogrenci = new OgrenciBilgi();
            ogrenci.Ad = textBox7.Text;
            ogrenci.Bolum = textBox6.Text;
            ogrenci.Sinif = textBox5.Text;
            ogrenci.DogumTarihi = dateTimePicker2.Value;
            _bagla.OgrenciBilgileri.Add(ogrenci);
            _bagla.SaveChanges();
            yukle();
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ogr sil
            if (MessageBox.Show("Sil", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int secili = (int)dataGridView2.CurrentRow.Cells[0].Value;

                OgrenciBilgi kayit = _bagla.OgrenciBilgileri.Where(x => x.OgrencID == secili).FirstOrDefault();
                _bagla.OgrenciBilgileri.Remove(kayit);
                _bagla.SaveChanges();
                yukle();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ogr güncelle
            int secili = (int)dataGridView2.CurrentRow.Cells[0].Value;

            OgrenciBilgi kayit = _bagla.OgrenciBilgileri.Where(x => x.OgrencID == secili).FirstOrDefault();
            kayit.Ad = textBox7.Text;
            kayit.Bolum = textBox6.Text;
            kayit.Sinif = textBox5.Text;
            kayit.DogumTarihi = dateTimePicker2.Value;
            _bagla.SaveChanges();
            yukle();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //not ekle
            OgrenciNot ogrenciNot = new OgrenciNot();
            ogrenciNot.OgrencID = (int)comboBox1.SelectedValue;
            ogrenciNot.DersID = (int)comboBox2.SelectedValue;
            ogrenciNot.Yazili1 = Convert.ToInt32(textBox9.Text);
            ogrenciNot.Yazili2 = Convert.ToInt32(textBox13.Text);
            ogrenciNot.Yazili3 = Convert.ToInt32(textBox14.Text);
            ogrenciNot.Uygulama1 = Convert.ToInt32(textBox17.Text);
            ogrenciNot.Uygulama2 = Convert.ToInt32(textBox18.Text);
            ogrenciNot.Performans1 = Convert.ToInt32(textBox19.Text);
            ogrenciNot.Performans2 = Convert.ToInt32(textBox20.Text);
            ogrenciNot.Ortalama = (ogrenciNot.Yazili1 + ogrenciNot.Yazili2 + ogrenciNot.Yazili3 + ogrenciNot.Uygulama1 + ogrenciNot.Uygulama2 + ogrenciNot.Performans1 + ogrenciNot.Performans2) / 7;
            _bagla.OgrenciNotlar.Add(ogrenciNot);
            _bagla.SaveChanges();
            yukle();

            textBox12.Text = "";
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            textBox9.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";
            textBox21.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //not sil
            if (MessageBox.Show("Sil", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int secili = (int)dataGridView3.CurrentRow.Cells[0].Value;

                OgrenciNot kayit = _bagla.OgrenciNotlar.Where(x => x.Id == secili).FirstOrDefault();
                _bagla.OgrenciNotlar.Remove(kayit);
                _bagla.SaveChanges();
                yukle();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //not güncelle
            int secili = (int)dataGridView3.CurrentRow.Cells[0].Value;

            OgrenciNot ogrenciNot = _bagla.OgrenciNotlar.Where(x => x.Id == secili).FirstOrDefault();
            ogrenciNot.OgrencID = (int)comboBox1.SelectedValue;
            ogrenciNot.DersID = (int)comboBox2.SelectedValue;
            ogrenciNot.Yazili1 = Convert.ToInt32(textBox9.Text);
            ogrenciNot.Yazili2 = Convert.ToInt32(textBox13.Text);
            ogrenciNot.Yazili3 = Convert.ToInt32(textBox14.Text);
            ogrenciNot.Uygulama1 = Convert.ToInt32(textBox17.Text);
            ogrenciNot.Uygulama2 = Convert.ToInt32(textBox18.Text);
            ogrenciNot.Performans1 = Convert.ToInt32(textBox19.Text);
            ogrenciNot.Performans2 = Convert.ToInt32(textBox20.Text);
            ogrenciNot.Ortalama = (ogrenciNot.Yazili1 + ogrenciNot.Yazili2 + ogrenciNot.Yazili3 + ogrenciNot.Uygulama1 + ogrenciNot.Uygulama2 + ogrenciNot.Performans1 + ogrenciNot.Performans2) / 7;
            _bagla.SaveChanges();
            yukle();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //notlar
            int secili = (int)dataGridView3.CurrentRow.Cells[0].Value;

            OgrenciNot ogrenciNot = _bagla.OgrenciNotlar.Where(x => x.Id == secili).FirstOrDefault();

            textBox12.Text = ogrenciNot.Id.ToString();
            comboBox1.SelectedIndex = ogrenciNot.OgrencID - 1;
            comboBox2.SelectedIndex = ogrenciNot.DersID - 1;
            textBox9.Text = ogrenciNot.Yazili1.ToString();
            textBox13.Text = ogrenciNot.Yazili2.ToString();
            textBox14.Text = ogrenciNot.Yazili3.ToString();
            textBox17.Text = ogrenciNot.Uygulama1.ToString();
            textBox18.Text = ogrenciNot.Uygulama2.ToString();
            textBox19.Text = ogrenciNot.Performans1.ToString();
            textBox20.Text = ogrenciNot.Performans2.ToString();
            textBox21.Text = ogrenciNot.Ortalama.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = (int)dataGridView2.CurrentRow.Cells[0].Value;

            OgrenciBilgi ogrenci = _bagla.OgrenciBilgileri.Where(x => x.OgrencID == secili).FirstOrDefault();

            textBox8.Text = ogrenci.OgrencID.ToString();
            textBox7.Text = ogrenci.Ad.ToString();
            textBox6.Text = ogrenci.Bolum.ToString();
            textBox5.Text = ogrenci.Sinif.ToString();
            dateTimePicker2.Value = ogrenci.DogumTarihi;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = (int)dataGridView4.CurrentRow.Cells[0].Value;

            Ders ders = _bagla.Dersler.Where(x => x.DersID == secili).FirstOrDefault();

            textBox16.Text = ders.DersID.ToString();
            textBox15.Text = ders.Ad.ToString();
        }
    }

}
