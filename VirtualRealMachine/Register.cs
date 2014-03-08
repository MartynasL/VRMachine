using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    interface Register
    {
        public void setValue(Word word);
        public void setValue(char charackter);
        public void setValue(string charackters);
        public Word getValue();
    }
}
