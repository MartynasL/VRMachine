using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class Memory
    {
        private MemoryBlock[] memoryBlocks;
        public const int NUMBER_OF_BLOCKS = 100;

        public Memory()
        {
            memoryBlocks = new MemoryBlock[NUMBER_OF_BLOCKS];
            for(int i = 0; i < NUMBER_OF_BLOCKS; i++)
            {
                memoryBlocks[i] = new MemoryBlock();
            }
        }

        public Word getWordAtAddress(int address)
        {
            try
            {
                return memoryBlocks[address / MemoryBlock.WORDS_IN_BLOCK].getBlockWord(address % MemoryBlock.WORDS_IN_BLOCK);
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("There is no such address in memory");
            }            
        }

        public void setWordAtAddress(int address, Word word)
        {
            try
            {
                memoryBlocks[address / MemoryBlock.WORDS_IN_BLOCK].setBlockWord(address % MemoryBlock.WORDS_IN_BLOCK, word);
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("There is no such address in memory");
            }   
        }
    }
}
