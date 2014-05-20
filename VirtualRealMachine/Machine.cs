using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class Machine
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

            //initialize();
        }

        private void initialize()
        {
            //cpu.MODE.setValue('S');
            cpu.TIMER.setValue("99");
            cpu.PR.setValue(new Word("0010"));
            cpu.IC.setValue(new Word("0000"));
            cpu.SP.setValue(new Word("0090"));

            //INHA
            //cpu.MODE.setValue('S');
            //supervisorMemory.setWordAtAddress(0, new Word("LA04"));
            //supervisorMemory.setWordAtAddress(1, new Word("LB03"));
            //supervisorMemory.setWordAtAddress(2, new Word("INHA"));
            //supervisorMemory.setWordAtAddress(4, new Word("0030"));

            //OUHA
            //cpu.MODE.setValue('S');
            //supervisorMemory.setWordAtAddress(0, new Word("LA04"));
            //supervisorMemory.setWordAtAddress(1, new Word("LB03"));
            //supervisorMemory.setWordAtAddress(2, new Word("OUHA"));

            //IN70
            //cpu.MODE.setValue('V');
            //memory.setWordAtAddress(0, new Word("IN70"));
            //supervisorMemory.setWordAtAddress(190, new Word("STM0"));
            //supervisorMemory.setWordAtAddress(191, new Word("XCHG"));

            //INT dalyba is 0 PI=2
            //cpu.MODE.setValue('V');
            //memory.setWordAtAddress(0, new Word("/AB0"));
            //supervisorMemory.setWordAtAddress(150, new Word("INCA"));

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

            cpu.MODE.setValue('V');
            cpu.IC.setValue(new Word("0020"));
            memory.setWordAtAddress(0, new Word("0008"));
            memory.setWordAtAddress(1, new Word("0005"));

            memory.setWordAtAddress(10, new Word("ATSA"));
            memory.setWordAtAddress(11, new Word("KYMA"));
            memory.setWordAtAddress(12, new Word("S:  "));

            memory.setWordAtAddress(20, new Word("LA00"));
            memory.setWordAtAddress(21, new Word("LB01"));
            memory.setWordAtAddress(22, new Word("+AB0"));
            memory.setWordAtAddress(23, new Word("SA13"));
            memory.setWordAtAddress(24, new Word("OU10"));
            memory.setWordAtAddress(25, new Word("HALT"));
            supervisorMemory.setWordAtAddress(210, new Word("HALT"));

            supervisorMemory.setWordAtAddress(200, new Word("XCHG"));
            supervisorMemory.setWordAtAddress(201, new Word("MO05"));
            supervisorMemory.setWordAtAddress(25, new Word("0024"));
            supervisorMemory.setWordAtAddress(140, new Word("HALT"));

        }
    }
}
