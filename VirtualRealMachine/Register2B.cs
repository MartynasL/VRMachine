﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class Register2B : Register
    {
        private char[] value = new char[2];

        public void setValue(string value)
        {
            if (value.Length == 2)
            {
                this.value = value.ToCharArray();
            }
            else
            {
                throw new FormatException("Valid value cannot be set!");
            }
        }

        public char[] getValue()
        {
            return value;
        }
    }
}