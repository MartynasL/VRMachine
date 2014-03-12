using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class Register2B
    {
        private char[] value = new char[2];

        public void setValue(string value)
        {
            if (value.Length <= Word.WORD_LENGTH)
            {
                value.CopyTo(value.Length - 2, this.value, 2 - value.Length, value.Length);
            }
            else
            {
                throw new FormatException("Valid value cannot be set!");
            }
        }

        public char[] getValue()
        {
            return value;
        }


    }
}
