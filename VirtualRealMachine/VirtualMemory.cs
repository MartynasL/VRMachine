using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class VirtualMemory
    {
        private Word[] memoryWords = new Word[100];

        public VirtualMemory()
        {
            for(int i = 0; i < 100; i++)
            {
                memoryWords[i] = new Word("0000");
            }
        }

        public Word getWordAtAddress(int address)
        {
            try
            {
                return memoryWords[address];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("There is no such address in memory");
            }            
        }

        public void setWordAtAddress(int address, Word word)
        {
            try
            {
                memoryWords[address] = word;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("There is no such address in memory");
            }   
        }
    }
}
