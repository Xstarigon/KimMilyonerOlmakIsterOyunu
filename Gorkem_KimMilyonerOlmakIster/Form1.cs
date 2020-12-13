using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gorkem_KimMilyonerOlmakIster.Classes;

namespace Gorkem_KimMilyonerOlmakIster
{
    public partial class BaslatForm : Form
    {
        SoruBilgiService service = new SoruBilgiService(new FileOperations());
        public BaslatForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                FillGrid();
            }
            else
            {
                panel1.Visible = false;
            }

        }

        void FillGrid()
        {
            SoruCevap[] soruCevap = service.List();
            dataGridView1.DataSource = soruCevap;
            dataGridView1.Columns[0].Visible = false;
        }

        private void BaslatForm_Load(object sender, EventArgs e)
        {
            
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbSoru.Text))
            {
                MessageBox.Show("Lütfen soru kısmını doldurunuz!", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbA.Text) || string.IsNullOrWhiteSpace(tbB.Text) || string.IsNullOrWhiteSpace(tbC.Text) || string.IsNullOrWhiteSpace(tbD.Text))
            {
                MessageBox.Show("Lütfen tüm cevapları doldurunuz!", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("Lütfen doğru cevabı seçiniz!", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string dogruCevap = "";
            if (radioButton1.Checked == true)
            {
                dogruCevap = "A";
            }
            if (radioButton2.Checked == true)
            {
                dogruCevap = "B";
            }
            if (radioButton3.Checked == true)
            {
                dogruCevap = "C";
            }
            if (radioButton4.Checked == true)
            {
                dogruCevap = "D";
            }

            SoruCevap soru = new SoruCevap()
            {
                Soru = rtbSoru.Text,
                Cevap1 = tbA.Text,
                Cevap2 = tbB.Text,
                Cevap3 = tbC.Text,
                Cevap4 = tbD.Text,
                DogruSecenek = dogruCevap
            };

            service.Add(soru);
            MessageBox.Show("Soru giriş işlemi tamamlandı.", "Başarılı", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            FillGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();

        }
    }
}
