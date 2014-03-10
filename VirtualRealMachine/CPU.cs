using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class CPU
    {
        private Register A = new Register4B();
        private Register B = new Register4B();
        private Register IC = new Register4B();
        private Register SP = new Register4B();
        private Register PR = new Register4B();
        private Register TIMER = new Register2B();
        private Register RC = new Register1B();
        private Register M = new Register1B();
        private Register PI = new Register1B();
        private Register SI = new Register1B();
        private Register IOI = new Register1B();
        private Register TI = new Register1B();
        private Register MODE = new Register1B();
        private Register K1 = new Register1B();
        private Register K2 = new Register1B();
        private Register K3 = new Register1B();
        private Register C = new Register1B();
    }
}
