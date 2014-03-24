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
            hddManager = new HDDManager("hdd.xml", 100, 10);
            interpretator = new Interpretator(ref cpu, ref memory, ref supervisorMemory, ref inputDevice,
                ref outputDevice, ref hddManager);

            initialize();
        }

        private void initialize()
        {
            cpu.MODE.setValue('V');
            cpu.TIMER.setValue("99");
            cpu.PR.setValue(new Word("0010"));

            supervisorMemory.setWordAtAddress(0, new Word("LA08"));
            supervisorMemory.setWordAtAddress(1, new Word("LB09"));

            supervisorMemory.setWordAtAddress(8, new Word("0388"));
            supervisorMemory.setWordAtAddress(9, new Word("0009"));

            memory.setWordAtAddress(0, new Word("LA08"));
            memory.setWordAtAddress(1, new Word("LB09"));

            memory.setWordAtAddress(8, new Word("0014"));
            memory.setWordAtAddress(9, new Word("0009"));

            //vykdoma komanda
            supervisorMemory.setWordAtAddress(2, new Word("SLAV"));
            memory.setWordAtAddress(2, new Word("SLAV"));
            //------
            supervisorMemory.setWordAtAddress(10, new Word("AAAA"));
            supervisorMemory.setWordAtAddress(140, new Word("HALT"));
        }
    }
}
