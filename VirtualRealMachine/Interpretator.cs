using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class Interpretator
    {
        public Interpretator(ref CPU cpu, ref Memory memory)
        {
            this.cpu = cpu;
            this.memory = memory;
        }

        CPU cpu;
        Memory memory;

        public void interpretate(Word word)
        {
            char ch = word.getWordByte(1);

            switch (ch)
            {
                case '+': 
                    casePlus(word);
                    break;
                case '-':
                    caseMinus(word);
                    break;
                case '*':
                    caseMul(word);
                    break;
                case '/':
                    caseDiv(word);
                    break;
                case 'I':
                    caseI(word);
                    break;
                case 'D':
                    caseD(word);
                    break;
                case 'L':
                    caseL(word);
                    break;
                case 'S':
                    caseS(word);
                    break;
                case 'C':
                    caseC(word);
                    break;
                case 'J':
                    caseJ(word);
                    break;
                case 'O':
                    caseO(word);
                    break;
                case 'P':
                    caseP(word);
                    break;
                case 'G':
                    caseG(word);
                    break;
                case 'H':
                    caseH(word);
                    break;
                case 'M':
                    caseM(word);
                    break;
                case 'X':
                    caseX(word);
                    break;
                case 'T':
                    caseT(word);
                    break;
                default:
                    notFound();
                    break;

            }
        }

        private Boolean isWorkRegister(char ch)
        {
            if (ch == 65)
                return true;
            else if (ch == 66)
                return true;
            else
                return false;
        }

        private Boolean isOtherRegister(char ch)
        {

        }

        private Boolean isAdress(char ch3, char ch4)
        {
            if ((ch3 < 58) && (ch3 > 47))
            {
                if ((ch4 < 58) && (ch4 > 47))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void casePlus(Word word)
        {
            char ch2 = word.getWordByte(2);
            char ch3 = word.getWordByte(3);
            char ch4 = word.getWordByte(4);

            //+rx1x2
            if ((ch3 < 58) && (ch3 > 47))
            {
                if ((ch4 < 58) && (ch4 > 47))
                {
                    int address = Convert.ToInt32(String.Concat(ch3, ch4));

                    if (ch2 == 65)
                        cpu.addRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                    else if (ch2 == 66)
                        cpu.addRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                    else
                        notFound();
                }
                else
                    notFound();
            }
            //+r1r20
            else
            {
                if (ch4 == 0)
                {
                    if (ch2 == 65)
                    {
                        if (ch3 == 65) 
                        { 
                        }
                    }
                    else if (ch2 == 66)
                    {

                    }
                    else
                        notFound();

                }
            }
            
        }

        private void caseMinus(Word word)
        {

        }

        private void caseMul(Word word)
        {

        }

        private void caseDiv(Word word)
        {

        }

        private void caseI(Word word)
        {

        }

        private void caseD(Word word)
        {

        }

        private void caseL(Word word)
        {

        }

        private void caseS(Word word)
        {

        }

        private void caseC(Word word)
        {

        }

        private void caseJ(Word word)
        {

        }

        private void caseO(Word word)
        {

        }

        private void caseP(Word word)
        {

        }

        private void caseG(Word word)
        {

        }

        private void caseH(Word word)
        {

        }

        private void caseM(Word word)
        {

        }

        private void caseX(Word word)
        {

        }

        private void caseT(Word word)
        {

        }

        private void notFound()
        {

        }
    }
}
