using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorkem_KimMilyonerOlmakIster.Classes
{
    class FileOperations : IOperations
    {
        string _path = Application.StartupPath.Replace(@"\bin\Debug", "") + @"\Files\Sorular.txt";

        public void AddSoruBilgileri(SoruCevap soruCevap)
        {
            soruCevap.ID = File.ReadAllLines(_path).Length + 1;
            string line = "\n" + soruCevap.ID + ";" + soruCevap.Soru + ";" + soruCevap.Cevap1 + ";" + soruCevap.Cevap2 + ";" + soruCevap.Cevap3 + ";" + soruCevap.Cevap4 + ";" + soruCevap.DogruSecenek;
            File.AppendAllText(_path, line);
        }

        public SoruCevap[] GetSoruBilgileri()
        {
            SoruCevap soruCevap;
            string[] lines = File.ReadAllLines(_path);
            SoruCevap[] sorular = new SoruCevap[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                soruCevap = new SoruCevap()
                {
                    ID = Convert.ToInt32(lines[i].Split(';')[0]),
                    Soru = lines[i].Split(';')[1],
                    Cevap1 = lines[i].Split(';')[2],
                    Cevap2 = lines[i].Split(';')[3],
                    Cevap3 = lines[i].Split(';')[4],
                    Cevap4 = lines[i].Split(';')[5],
                    DogruSecenek = lines[i].Split(';')[6]
                };
                sorular[i] = soruCevap;
            }

            return sorular;
        }
    }
}
