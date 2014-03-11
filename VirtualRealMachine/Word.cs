﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class Word
    {
        private char[] value;
        public const int WORD_LENGTH = 4;

        public Word(string stringWord)
        {
            value = new char[WORD_LENGTH];
            setWord(stringWord);
        }

        public void setWord(string stringWord)
        {
            if (stringWord.Length == WORD_LENGTH)
            {
                value = stringWord.ToCharArray();
            }
            else
            {
                throw new FormatException("Valid word cannot be created!");
            }
        }

        //byte number from 1 to 4. 1st is eldest byte.
        public char getWordByte(int byteNumber)
        {
            try
            {
                return value[byteNumber-1];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("Byte number must be from 1 to 4!");
            }
        }

        public int getIntValue()
        {
            try
            {
                int intValue = Convert.ToInt32(value);
                return intValue;
            }
            catch (FormatException e)
            {
                throw new FormatException("Word cannot be converted into integer!");
            }            
        }

    }
}
