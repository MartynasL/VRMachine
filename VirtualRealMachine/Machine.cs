using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class Machine
    {
        public CPU cpu;
        public Memory supervisorMemory;
        public Memory memory;
        public InputDevice inputDevice;
        public OutputDevice outputDevice;
        public Interpretator interpretator;
        public HDDManager hddManager;

        //public Machine(CPU cpu, Memory supervisorMemory,
        //    Memory ram, InputDevice inpuDevice,
        //    OutputDevice outputDevice, Interpretator interpretator,
        //    HDDManager hddManager)
        //{

        //}

        public Machine()
        {
            supervisorMemory = new Memory(40);
            cpu = new CPU(ref supervisorMemory);
            memory = new Memory(100);
            inputDevice = new InputDevice();
            outputDevice = new OutputDevice();
            hddManager = new HDDManager("hdd.txt", 100, 10);
            interpretator = new Interpretator(ref cpu, ref memory, ref supervisorMemory, ref inputDevice,
                ref outputDevice, ref hddManager);

            initialize();
        }

        private void initialize()
        {
            cpu.MODE.setValue('V');
            cpu.TIMER.setValue("99");
            cpu.PR.setValue(new Word("0010"));

            memory.setWordAtAddress(0, new Word("OU00"));
            supervisorMemory.setWordAtAddress(1, new Word("/A02"));
            supervisorMemory.setWordAtAddress(2, new Word("0003"));
            supervisorMemory.setWordAtAddress(3, new Word("0010"));
            supervisorMemory.setWordAtAddress(190, new Word("XCHG"));
            supervisorMemory.setWordAtAddress(200, new Word("XCHG"));
        }
    }
}
