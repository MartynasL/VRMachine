using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class VirtualCPU
    {
        private Register A = new Register4B();
        private Register B = new Register4B();
        private Register IC = new Register4B();
        private Register SP = new Register4B();
        private Register C = new Register1B();
    }
}
