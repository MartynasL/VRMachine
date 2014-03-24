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
            cpu.C.setValue('1');
            memory.setWordAtAddress(100, new Word("0000"));
            memory.setWordAtAddress(101, new Word("0001"));
            memory.setWordAtAddress(102, new Word("0002"));
            memory.setWordAtAddress(103, new Word("0003"));
            memory.setWordAtAddress(104, new Word("0004"));
            memory.setWordAtAddress(105, new Word("0005"));
            memory.setWordAtAddress(106, new Word("0006"));
            memory.setWordAtAddress(107, new Word("0007"));
            memory.setWordAtAddress(108, new Word("0008"));
            memory.setWordAtAddress(109, new Word("0009"));

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
            memory.setWordAtAddress(2, new Word("JG13"));
            //------
            supervisorMemory.setWordAtAddress(10, new Word("AAAA"));
            supervisorMemory.setWordAtAddress(140, new Word("HALT"));
        }
    }
}
