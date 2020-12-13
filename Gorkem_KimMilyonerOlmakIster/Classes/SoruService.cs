using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorkem_KimMilyonerOlmakIster.Classes
{
    class SoruService
    {
        string _path = Application.StartupPath.Replace(@"\bin\Debug", "") + @"\Files\Sorular.txt";
        Random random = new Random();
        private int secilenSoruNo = 0;
        private List<SoruCevap> tmpSoruCevapUpdated;
        private SoruCevap[] tmpSoruCevap;

        public void SoruAyarla()
        {
            string[] lines = File.ReadAllLines(_path);
            tmpSoruCevapUpdated = new List<SoruCevap>();
            tmpSoruCevap = new SoruCevap[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                tmpSoruCevap[i] = new SoruCevap()
                {
                    ID = Convert.ToInt32(lines[i].Split(';')[0]),
                    Soru = lines[i].Split(';')[1],
                    Cevap1 = lines[i].Split(';')[2],
                    Cevap2 = lines[i].Split(';')[3],
                    Cevap3 = lines[i].Split(';')[4],
                    Cevap4 = lines[i].Split(';')[5],
                    DogruSecenek = lines[i].Split(';')[6]
                };
            }
            tmpSoruCevapUpdated.AddRange(tmpSoruCevap);
        }
        public SoruCevap SoruAl()
        {
            secilenSoruNo = random.Next(1, tmpSoruCevapUpdated.Count);
            SoruCevap gonderilecekSoru = tmpSoruCevapUpdated[secilenSoruNo - 1];
            tmpSoruCevapUpdated.RemoveAt(secilenSoruNo - 1);

            return gonderilecekSoru;
        }
    }
}
