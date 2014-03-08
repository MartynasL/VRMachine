﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class Word
    {
        private char[] word = new char[4];

        public Word(string stringWord)
        {
            setWord(stringWord);
        }

        public void setWord(string stringWord)
        {
            if (stringWord.Length == 4)
            {
                word = stringWord.ToCharArray();
            }
            else
            {
                throw new FormatException("Valid word cannot be created");
            }
        }

        //byte number from 1 to 4. 1st is eldest byte.
        public char getWordByte(int byteNumber)
        {
            try
            {
                return word[byteNumber-1];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("Byte number must be from 1 to 4");
            }
        }

    }
}
