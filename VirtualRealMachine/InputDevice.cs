using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class InputDevice
    {
        Queue<MemoryBlock> inputQueue;

        public void InputDevice()
        {
            inputQueue = new Queue<MemoryBlock>();
        }

        public MemoryBlock getInput()
        {
            try
            {
                return inputQueue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                //wait for input. Needs to be implemented when there will be GUI
                return null;
            }
        }
    }
}
