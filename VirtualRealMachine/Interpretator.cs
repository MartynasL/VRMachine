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
        private InputDevice inputDevice;
        private OutputDevice outputDevice;
        private HDDManager hddManager;
        private int stackSize;
        private bool incIC = true;

        public Interpretator(ref CPU cpu, ref Memory memory,
            ref InputDevice inputDevice, ref OutputDevice outputDevice,
            ref HDDManager hddManager)
        {
            this.cpu = cpu;
            this.memory = memory;
            this.inputDevice = inputDevice;
            this.outputDevice = outputDevice;
            this.hddManager = hddManager;
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
                //case 'X':
                //    caseX(ch2, ch3, ch4);
                //    break;
                //case 'T':
                //    caseT(ch2, ch3, ch4);
                //    break;
                default:
                    notFound();
                    break;

            }
            //IC increment
        }

        private bool isAddress(char ch3, char ch4)
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
            if (isAddress(ch3, ch4))
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
            //-rx1x2
            if (isAddress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.subRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.subRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            //-r1r20
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
            //*rx1x2
            if (isAddress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.mulRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.mulRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            //*r1r20
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
            // /rx1x2
            if (isAddress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                if (ch2 == 'A')
                    cpu.divRegisterMemory(cpu.A, memory.getWordAtAddress(address));
                else if (ch2 == 'B')
                    cpu.divRegisterMemory(cpu.B, memory.getWordAtAddress(address));
                else
                    notFound();
            }
            // /r1r20
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
            if (ch2 == 'N')
            {
                if (ch3 == 'C')
                {
                    if (ch4 == 'A')
                    {
                        cpu.A.setValue(new Word((cpu.A.getValue().toInt() + 1).ToString()));
                    }
                    else if (ch4 == 'B')
                    {
                        cpu.A.setValue(new Word((cpu.B.getValue().toInt() + 1).ToString()));
                    }
                    else
                    {
                        notFound();
                    }
                }
                else if(isAddress(ch3, ch4))
                {
                    cpu.SI.setValue('1');
                    string address = new string(ch3, ch4);
                    cpu.B.setValue(new Word(address));
                }
                else if (ch3 == 'H' & ch4 == 'A')
                {
                    cpu.input(memory, hddManager, cpu.A.getValue().toInt() % 100, cpu.B.getValue().toInt() % 100);
                }
                else
                {
                    notFound();
                }
            }
            else
            {
                notFound();
            }
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
            if (isAddress(ch3, ch4))
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

        private void caseC(char ch2, char ch3, char ch4)
        {
            switch (ch2)
            {
                case 'P':
                    if (ch3 == 'Y')
                    {
                        if (ch4 == 'A')
                        {
                            cpu.copyRegister(ref cpu.A, cpu.B);
                        }
                        else if (ch4 == 'B')
                        {
                            cpu.copyRegister(ref cpu.B, cpu.A);
                        }
                        else
                            notFound();
                    }
                    else
                        notFound();
                    break;
                case 'A':
                    if (isAddress(ch3, ch4))
                    {
                        int address = Convert.ToInt32(String.Concat(ch3, ch4));
                        cpu.compRegisterMemory(ref cpu.A, memory.getWordAtAddress(address));
                    }
                    else if ((ch3 == 'A') && (ch4 == '0'))
                    {
                        cpu.compRegisters(cpu.A, cpu.A);
                    }
                    else if ((ch3 == 'B') && (ch4 == '0'))
                    {
                        cpu.compRegisters(cpu.A, cpu.B);
                    }
                    else 
                        notFound();
                    break;
                case 'B':
                    if (isAddress(ch3, ch4))
                    {
                        int address = Convert.ToInt32(String.Concat(ch3, ch4));
                        cpu.compRegisterMemory(ref cpu.B, memory.getWordAtAddress(address));
                    }
                    else if ((ch3 == 'A') && (ch4 == '0'))
                    {
                        cpu.compRegisters(cpu.B, cpu.A);
                    }
                    else if ((ch3 == 'B') && (ch4 == '0'))
                    {
                        cpu.compRegisters(cpu.B, cpu.B);
                    }
                    else 
                        notFound();
                    break;                    
                default:
                    notFound();
                    break;
            }
        }

        private void caseS(char ch2, char ch3, char ch4)
        {
            if (ch2 == 'T')
                switch (ch3)
                {
                    case 'I':
                        if (ch4 == 'C')
                        {
                            cpu.setRegister(ref cpu.IC);
                            incIC = false;
                        }
                        else if (ch4 == 'O')
                            cpu.setRegister(ref cpu.IOI);
                        else
                            notFound();
                        break;
                    case 'P':
                        if (ch4 == 'R')
                            cpu.setRegister(ref cpu.PR);
                        else if (ch4 == 'I')
                            cpu.setRegister(ref cpu.PI);
                        else
                            notFound();
                        break;
                    case 'S':
                        if (ch4 == 'P')
                            cpu.setRegister(ref cpu.SP);
                        else if (ch4 == 'I')
                            cpu.setRegister(ref cpu.SI);
                        else
                            notFound();
                        break;
                    case 'T':
                        if (ch4 == 'I')
                            cpu.setRegister(ref cpu.TI);
                        else if (ch4 == 'M')
                            cpu.setRegister(ref cpu.TIMER);
                        else
                            notFound();
                        break;
                    case 'M':
                        if (ch4 == '0')
                            cpu.setRegister(ref cpu.M);
                        else if (ch4 == 'O')
                            cpu.setRegister(ref cpu.MODE);
                        else
                            notFound();
                        break;
                    case 'R':
                        if (ch4 == 'C')
                            cpu.setRegister(ref cpu.RC);
                        else
                            notFound();
                        break;
                    case 'K':
                        if (ch4 == '1')
                            cpu.setRegister(ref cpu.K1);
                        else if (ch4 == '2')
                            cpu.setRegister(ref cpu.K2);
                        else if (ch4 == '3')
                            cpu.setRegister(ref cpu.K3);
                        else
                            notFound();
                        break;
                    case 'L':
                        if ((ch3 == 'A') && (ch4 == 'V'))
                            cpu.slave(ref memory);
                        else
                            notFound();
                        break;
                    default:
                        notFound();
                        break;
                }
            else
                notFound();
        }

        private void caseJ(char ch2, char ch3, char ch4)
        {
            if (isAddress(ch3, ch4))
            {
                int address = Convert.ToInt32(String.Concat(ch3, ch4));

                switch (ch2)
                {
                    case 'P':
                        cpu.jump(address);
                        incIC = false;
                        break;
                    case 'E':
                        cpu.conditionalJump(address, ch2);
                        incIC = false;
                        break;
                    case 'G':
                        cpu.conditionalJump(address, ch2);
                        incIC = false;
                        break;
                    case 'L':
                        cpu.conditionalJump(address, ch2);
                        incIC = false;
                        break;
                    default:
                        notFound();
                        break;
                }
            }
            else
                notFound();
        }

        private void caseO(char ch2, char ch3, char ch4)
        {
            if (ch2 == 'U')
            {
                if (isAddress(ch3, ch4))
                {
                    cpu.SI.setValue('2');
                }
                else if(ch3 == 'H' & ch4 == 'A') 
                {
                    cpu.output(memory, hddManager, cpu.B.getValue().toInt() % 100, cpu.A.getValue().toInt() % 100);
                }
                else
                {
                    notFound();
                }
            }
            else
            {
                notFound();
            }
        }

        private void caseP(char ch2, char ch3, char ch4)
        {
            if (ch2 == 'U')
            {
                switch (ch3)
                {
                    case 'A':
                        if (ch4 == '0')
                            if (stackSize != 20)
                                cpu.push(cpu.A, ref memory);
                            else
                                cpu.PI.setValue('3');
                        else
                            notFound();
                        stackSize++;
                        break;
                    case 'B':
                        if (ch4 == '0')
                            if (stackSize != 20)
                                cpu.push(cpu.B, ref memory);
                            else
                                cpu.PI.setValue('3');
                        else
                            notFound();
                        stackSize++;
                        break;
                    case 'C':
                        if (ch4 == '0')
                            if (stackSize != 20)
                                cpu.push(cpu.C, ref memory);
                            else
                                cpu.PI.setValue('3');
                        else
                            notFound();
                        stackSize++;
                        break;
                    case 'I':
                        if (ch4 == 'C')
                            if (stackSize != 20)
                                cpu.push(cpu.IC, ref memory);
                            else
                                cpu.PI.setValue('3');
                        else
                            notFound();
                        stackSize++;
                        break;
                    default:
                        notFound();
                        break;
                }
            }
            else if (ch2 == 'O')
            {
                switch (ch3)
                {
                    case 'A':
                        if (ch4 == '0')
                            if (stackSize != 0)
                                cpu.pop(ref cpu.A, ref memory);
                            else
                                cpu.PI.setValue('4');
                        else
                            notFound();
                        stackSize--;
                        break;
                    case 'B':
                        if (ch4 == '0')
                            if (stackSize != 0)
                                cpu.pop(ref cpu.B, ref memory);
                            else
                                cpu.PI.setValue('4');
                        else
                            notFound();
                        stackSize--;
                        break;
                    case 'C':
                        if (ch4 == '0')
                            if (stackSize != 0)
                                cpu.pop(ref cpu.C, ref memory);
                            else
                                cpu.PI.setValue('4');
                        else
                            notFound();
                        stackSize--;
                        break;
                    case 'I':
                        if (ch4 == 'C')
                            if (stackSize != 0)
                                cpu.pop(ref cpu.IC, ref memory);
                            else
                                cpu.PI.setValue('4');
                        else
                            notFound();
                        stackSize--;
                        break;
                    default:
                        notFound();
                        break;
                }
            }
            else
                notFound();
        }

        private void caseG(char ch2, char ch3, char ch4)
        {
            if (ch2 == 'T')
                switch (ch3)
                {
                    case 'I':
                        if (ch4 == 'C')
                            cpu.getRegister(cpu.IC);
                        else if (ch4 == 'O')
                            cpu.getRegister(cpu.IOI);
                        else
                            notFound();
                        break;
                    case 'P':
                        if (ch4 == 'R')
                            cpu.getRegister(cpu.PR);
                        else if (ch4 == 'I')
                            cpu.getRegister(cpu.PI);
                        else
                            notFound();
                        break;
                    case 'S':
                        if (ch4 == 'P')
                            cpu.getRegister(cpu.SP);
                        else if (ch4 == 'I')
                            cpu.getRegister(cpu.SI);
                        else
                            notFound();
                        break;
                    case 'T':
                        if (ch4 == 'I')
                            cpu.getRegister(cpu.TI);
                        else if (ch4 == 'M')
                            cpu.getRegister(cpu.TIMER);
                        else
                            notFound();
                        break;
                    case 'M':
                        if (ch4 == '0')
                            cpu.getRegister(cpu.M);
                        else if (ch4 == 'O')
                            cpu.getRegister(cpu.MODE);
                        else
                            notFound();
                        break;
                    case 'R':
                        if (ch4 == 'C')
                            cpu.getRegister(cpu.RC);
                        else
                            notFound();
                        break;
                    case 'K':
                        if (ch4 == '1')
                            cpu.getRegister(cpu.K1);
                        else if (ch4 == '2')
                            cpu.getRegister(cpu.K2);
                        else if (ch4 == '3')
                            cpu.getRegister(cpu.K3);
                        else
                            notFound();                        
                        break;
                    default:
                        notFound();
                        break;
                }
            else 
                notFound();

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
            if (isAddress(ch3, ch4))
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
        
        private void caseX(char ch2, char ch3, char ch4)
        {
            if ((ch2 == 'C') && (ch3 == 'H') && (ch4 == 'G'))
            {
                if (cpu.SI.getValue() == '1')
                {
                    cpu.input(memory, inputDevice, (int)(cpu.B.getValue().getWordByte(3) - '0')); 
                }
                else if (cpu.SI.getValue() == '2')
                {
                    cpu.output(memory, outputDevice, (int)(cpu.B.getValue().getWordByte(3) - '0')); 
                }
            }
            else
            {
                notFound();
            }
        }

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
