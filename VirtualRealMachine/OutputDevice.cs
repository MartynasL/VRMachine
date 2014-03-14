using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class OutputDevice
    {
        Queue<MemoryBlock> outputQueue;

        public void setOutput(MemoryBlock block)
        {
            outputQueue.Enqueue(block);
        }
    }
}
