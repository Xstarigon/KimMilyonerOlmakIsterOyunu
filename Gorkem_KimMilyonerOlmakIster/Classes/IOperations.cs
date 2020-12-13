using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorkem_KimMilyonerOlmakIster.Classes
{
    interface IOperations
    {
         SoruCevap[] GetSoruBilgileri();
         void AddSoruBilgileri(SoruCevap soruCevap);
    }
}
