using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorkem_KimMilyonerOlmakIster.Classes
{
    class SoruBilgiService
    {
        private readonly IOperations _operations;
        public SoruBilgiService(IOperations operations)
        {
            _operations = operations;
        }

        public SoruCevap[] List()
        {
            return _operations.GetSoruBilgileri();
        }

        public void Add(SoruCevap soruCevap)
        {
            _operations.AddSoruBilgileri(soruCevap);
        }
    }
}
