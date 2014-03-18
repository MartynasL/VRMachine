using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class Interpretator
    {
        private CPU cpu;
        private Memory memory;

        public Interpretator(ref CPU cpu, ref Memory memory)
        {
            this.cpu = cpu;
            this.memory = memory;
        }

        public void interpretate(Word word)
        {
            char ch1 = word.getWordByte(1);
            char ch2 = word.getWordByte(2);
            char ch3 = word.getWordByte(3);
            char ch4 = word.getWordByte(4);

            switch (ch1)
            {
                case '+': 
                    casePlus(ch2, ch3, ch4);
                    break;
                case '-':
                    caseMinus(ch2, ch3, ch4);
                    break;
                case '*':
                    caseMul(ch2, ch3, ch4);
                    break;
                case '/':
                    caseDiv(ch2, ch3, ch4);
                    break;
                case 'I':
                    caseI(ch2, ch3, ch4);
                    break;
                case 'D':
                    caseD(ch2, ch3, ch4);
                    break;
                case 'L':
                    caseL(ch2, ch3, ch4);
                    break;
                case 'S':
                    caseS(ch2, ch3, ch4);
                    break;
                case 'C':
                    caseC(ch2, ch3, ch4);
                    break;
                case 'J':
                    caseJ(ch2, ch3, ch4);
                    break;
                case 'O':
                    caseO(ch2, ch3, ch4);
                    break;
                case 'P':
                    caseP(ch2, ch3, ch4);
                    break;
                case 'G':
                    caseG(ch2, ch3, ch4);
                    break;
                case 'H':
                    caseH(ch2, ch3, ch4);
                    break;
                case 'M':
                    caseM(ch2, ch3, ch4);
                    break;
                case 'X':
                    caseX(ch2, ch3, ch4);
                    break;
                case 'T':
                    caseT(ch2, ch3, ch4);
                    break;
                default:
                    notFound();
                    break;

            }
            //IC increment
        }

        private Register4B whichWorkRegister(char ch)
        {
            if (ch == 'A')
                return cpu.A;
            else if (ch == 'B')
                return cpu.B;
            else
                return null;
        }

        private Boolean isOtherRegister(char ch)
        {
            return false;
        }

        private Boolean isAdress(char ch3, char ch4)
        {
            if ((ch3 <= '9') && (ch3 >= '0'))
            {
                if ((ch4 <= '9') && (ch4 >= '0'))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void casePlus(char ch2, char ch3, char ch4)
        {
            //+rx1x2
            if (isAdress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.addRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.addRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            //+r1r20
            else
            {
                if (ch4 == '0')
                {
                    if (ch2 == 'A')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.addRegisters(ref cpu.A, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.addRegisters(ref cpu.A, cpu.B);
                        else
                            notFound();
                    }
                    else if (ch2 == 'B')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.addRegisters(ref cpu.B, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.addRegisters(ref cpu.B, cpu.B);
                        else
                            notFound();
                    }
                    else
                        notFound();
                }
                else
                    notFound();
            }            
        }

        private void caseMinus(char ch2, char ch3, char ch4)
        {
            //+rx1x2
            if (isAdress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.subRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.subRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            //+r1r20
            else
            {
                if (ch4 == '0')
                {
                    if (ch2 == 'A')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.subRegisters(ref cpu.A, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.subRegisters(ref cpu.A, cpu.B);
                        else
                            notFound();
                    }
                    else if (ch2 == 'B')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.subRegisters(ref cpu.B, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.subRegisters(ref cpu.B, cpu.B);
                        else
                            notFound();
                    }
                    else
                        notFound();
                }
                else
                    notFound();
            }            
        }

        private void caseMul(char ch2, char ch3, char ch4)
        {
            //+rx1x2
            if (isAdress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.mulRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.mulRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            //+r1r20
            else
            {
                if (ch4 == '0')
                {
                    if (ch2 == 'A')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.mulRegisters(ref cpu.A, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.mulRegisters(ref cpu.A, cpu.B);
                        else
                            notFound();
                    }
                    else if (ch2 == 'B')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.mulRegisters(ref cpu.B, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.mulRegisters(ref cpu.B, cpu.B);
                        else
                            notFound();
                    }
                    else
                        notFound();
                }
                else
                    notFound();
            }            
        }

        private void caseDiv(char ch2, char ch3, char ch4)
        {
            //+rx1x2
            if (isAdress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.divRegisterMemory(cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.divRegisterMemory(cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            //+r1r20
            else
            {
                if (ch4 == '0')
                {
                    if (ch2 == 'A')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.divRegisters(cpu.A, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.divRegisters(cpu.A, cpu.B);
                        else
                            notFound();
                    }
                    else if (ch2 == 'B')
                    {
                        if (ch3 == 'A')
                        {
                            cpu.divRegisters(cpu.B, cpu.A);
                        }
                        else if (ch3 == 'B')
                            cpu.divRegisters(cpu.B, cpu.B);
                        else
                            notFound();
                    }
                    else
                        notFound();
                }
                else
                    notFound();
            }            
        }

        private void caseI(char ch2, char ch3, char ch4)
        {

        }

        private void caseD(char ch2, char ch3, char ch4)
        {
            if ((ch2 == 'E') && (ch3 == 'C'))
            {
                if (ch4 == 'A')
                    cpu.decRegister(ref cpu.A);
                else if (ch4 == 'B')
                    cpu.decRegister(ref cpu.B);
                else
                    notFound();
            }
            else
                notFound();
        }

        private void caseL(char ch2, char ch3, char ch4)
        {
            if (isAdress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                {
                    cpu.loadRegister(ref cpu.A, memory.getWordAtAddress(address));
                }
                else if (ch2 == 'B')
                {
                    cpu.loadRegister(ref cpu.B, memory.getWordAtAddress(address));
                }
                else if (ch3 == 'I')
                {
                    cpu.loadRegister(ref cpu.IC, memory.getWordAtAddress(address));
                }
                else
                    notFound();
            }
            else
                notFound();
        }

        private void caseS(char ch2, char ch3, char ch4)
        {

        }

        private void caseC(char ch2, char ch3, char ch4)
        {

        }

        private void caseJ(char ch2, char ch3, char ch4)
        {

        }

        private void caseO(char ch2, char ch3, char ch4)
        {

        }

        private void caseP(char ch2, char ch3, char ch4)
        {

        }

        private void caseG(char ch2, char ch3, char ch4)
        {

        }

        private void caseH(char ch2, char ch3, char ch4)
        {
            if ((ch2 == 'A') && (ch3 == 'L') && (ch4 == 'T'))
                cpu.halt();
            else
                notFound();
        }

        private void caseM(char ch2, char ch3, char ch4)
        {
            if (isAdress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'O')
                {
                    cpu.changeMode(address, memory);
                }                
                else
                    notFound();
            }
            else
                notFound();
        }
////???
//        private void caseX(char ch2, char ch3, char ch4)
//        {
//            if ((ch2 == 'C') && (ch3 == 'H') && (ch4 == 'G'))
//                cpu.exchange();
//            else
//                notFound();
//        }

        //private void caseT(char ch2, char ch3, char ch4)
        //{
        //    if ((ch2 == 'E') && (ch3 == 'S') && (ch4 == 'T'))
        //        cpu.test();
        //    else
        //        notFound();
        //}

        private void notFound()
        {
            cpu.PI.setValue('1');
        }
    }
}
