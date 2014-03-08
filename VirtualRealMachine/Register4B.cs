using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class Register4B : Register
    {
        private Word value = new Word("0000");

        public void setValue(Word word)
        {
            value = word;
        }

        public Word getValue()
        {
            return value;
        }
    }
}
