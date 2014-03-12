using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class Register1B
    {
        private char value;

        public void setValue(char c)
        {
            value = c;
        }

        public char getValue()
        {
            return value;
        }
    }
}
