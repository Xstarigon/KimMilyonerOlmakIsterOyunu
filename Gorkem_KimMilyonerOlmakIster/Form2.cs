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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SoruService service = new SoruService();
        SoruCevap soruBilgileri;
        private int lastcheckeditem;
        private void Form2_Load(object sender, EventArgs e)
        {
            clbPara.Items.Add("12 : 1.000.000 TL");
            clbPara.Items.Add("11 : 250.000 TL");
            clbPara.Items.Add("10 : 125.000 TL");
            clbPara.Items.Add("9 : 60.000 TL");
            clbPara.Items.Add("8 : 30.000 TL");
            clbPara.Items.Add("7 : 15.000 TL");
            clbPara.Items.Add("6 : 7.500 TL");
            clbPara.Items.Add("5 : 5.000 TL");
            clbPara.Items.Add("4 : 3.000 TL");
            clbPara.Items.Add("3 : 2.000 TL");
            clbPara.Items.Add("2 : 1.000 TL");
            clbPara.Items.Add("1 : 500 TL");
            clbPara.SetItemChecked(11,true);
            service.SoruAyarla();
            soruBilgileri = service.SoruAl();
            lastcheckeditem = 11;
            Doldur();

        }

        void Doldur()
        {
            lSoru.Text = soruBilgileri.Soru;
            rbA.Text = "A: " + soruBilgileri.Cevap1;
            rbB.Text = "B: " + soruBilgileri.Cevap2;
            rbC.Text = "C: " + soruBilgileri.Cevap3;
            rbD.Text = "D: " + soruBilgileri.Cevap4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string cevap = "";
            if (rbA.Checked == true)
            {
                cevap = "A";
            }
            if (rbB.Checked == true)
            {
                cevap = "B";
            }
            if (rbC.Checked == true)
            {
                cevap = "C";
            }
            if (rbD.Checked == true)
            {
                cevap = "D";
            }

            if (lastcheckeditem == 0 && cevap == soruBilgileri.DogruSecenek)
            {
                MessageBox.Show("Tam 1.000.000 TL kazandınız. Tebrikler!", "Kazandınız!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Application.Restart();
            }

            if (cevap == soruBilgileri.DogruSecenek)
            {
                MessageBox.Show("Soruyu doğru bildiniz, yarışmaya devam edebilirsin.", "Doğru Cevap", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lastcheckeditem--;
                clbPara.SetItemChecked(lastcheckeditem, true);
                soruBilgileri = service.SoruAl();
                Doldur();
            }
            else
            {
                MessageBox.Show("Soruyu yanlış bildiniz. Oyun sona erdi! Sadece " + clbPara.Items[lastcheckeditem].ToString().Split(':')[1].Trim() + " kazandınız.", "Kaybettin", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Application.Restart();
            }
        }
    }
}
