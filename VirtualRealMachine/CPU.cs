﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class CPU
    {        
        public Register4B A = new Register4B();
        public Register4B B = new Register4B();
        public Register4B IC = new Register4B();
        public Register4B SP = new Register4B();
        public Register4B PR = new Register4B();
        private Register2B TIMER = new Register2B();
        private Register1B RC = new Register1B();
        private Register1B M = new Register1B();
        private Register1B PI = new Register1B();
        private Register1B SI = new Register1B();
        private Register1B IOI = new Register1B();
        private Register1B TI = new Register1B();
        private Register1B MODE = new Register1B();
        private Register1B K1 = new Register1B();
        private Register1B K2 = new Register1B();
        private Register1B K3 = new Register1B();
        private Register1B C = new Register1B();

        public void addRegisterMemory(ref Register4B register, Word word)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register.getValue().toInt();
            op2 = word.toInt();
            op1 = op1 + op2;
            if (op1 > 9999)
                PI.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register.setValue(tempWord);
            }
        }

        public void addRegisters(ref Register4B register1, Register4B register2)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().toInt();
            op2 = register2.getValue().toInt();
            op1 = op1 + op2;
            if (op1 > 9999)
                PI.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register1.setValue(tempWord);
            }
        }

        public void subRegisterMemory(ref Register4B register, Word word)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register.getValue().toInt();
            op2 = word.toInt();
            if (op1 >= op2)
            {
                op1 = op1 - op2;
                tempWord.setWord(op1.ToString());
                register.setValue(tempWord);
            }
            else 
                PI.setValue('4');                
        }

        public void subRegisters(ref Register4B register1, Register4B register2)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().toInt();
            op2 = register2.getValue().toInt();
            if (op1 >= op2)
            {
                op1 = op1 - op2;
                tempWord.setWord(op1.ToString());
                register1.setValue(tempWord);
            }
            else 
                PI.setValue('4');
        }

        public void mulRegisterMemory(ref Register4B register, Word word)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register.getValue().toInt();
            op2 = word.toInt();
            op1 = op1 * op2;
            if (op1 > 9999)
                PI.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register.setValue(tempWord);
            }
        }

        public void mulRegisters(ref Register4B register1, Register4B register2)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().toInt();
            op2 = register2.getValue().toInt();
            op1 = op1 * op2;
            if (op1 > 9999)
                PI.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register1.setValue(tempWord);
            }
        }

        private void divRegisterMemory(Register4B register, Word word)
        {
            int op1, op2, op3;
            Word tempWord = new Word("0000");

            op1 = register.getValue().toInt();
            op2 = word.toInt();
            if (op1 == 0)
                PI.setValue('2');
            else
            {
                op3 = op1 % op2;
                op1 = op1 / op2;
                tempWord.setWord(op1.ToString());
                A.setValue(tempWord);
                tempWord.setWord(op3.ToString());
                B.setValue(tempWord);
            }
        }

        private void divRegisters(Register4B register1, Register4B register2)
        {
            int op1, op2, op3;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().toInt();
            op2 = register2.getValue().toInt();
            if (op1 == 0)
                PI.setValue('2');
            else
            {
                op3 = op1 % op2;
                op1 = op1 / op2;
                tempWord.setWord(op1.ToString());
                A.setValue(tempWord);
                tempWord.setWord(op3.ToString());
                B.setValue(tempWord);
            }
        }

        private void incRegister(ref Register4B register)
        {
            Word tempWord = new Word("0000");
            int op = register.getValue().toInt();
            if (op == 9999)
                PI.setValue('3');
            else
            {
                op++;
                tempWord.setWord(op.ToString());
                register.setValue(tempWord);
            }
        }

        private void decRegister(ref Register4B register)
        {
            Word tempWord = new Word("0000");
            int op = register.getValue().toInt();
            if (op == 0)
                PI.setValue('4');
            else
            {
                op--;
                tempWord.setWord(op.ToString());
                register.setValue(tempWord);
            }
        }

        private void loadRegister(ref Register4B register, Word word)
        {
            register.setValue(word);
        }

        private void saveRegister(Register4B register, ref Memory memory, int address)
        {
            memory.setWordAtAddress(address, register.getValue());
        }

        private void copyRegister(ref Register4B register1, Register4B register2)
        {
            register1.setValue(register2.getValue());
        }

        private void compRegisterMemory(ref Register4B register, Word word)
        {
            int op1, op2;

            op1 = register.getValue().toInt();
            op2 = word.toInt();
            if (op1 > op2)
                C.setValue('1');
            else
                if (op1 < op2)
                    C.setValue('2');
                else
                    C.setValue('0');
            
        }

        private void compRegisters(Register4B register1, Register4B register2)
        {
            int op1, op2;

            op1 = register1.getValue().toInt();
            op2 = register2.getValue().toInt();
            if (op1 > op2)
                C.setValue('1');
            else
                if (op1 < op2)
                    C.setValue('2');
                else
                    C.setValue('0');
        }

        private void jump(int address)
        {
            Word word = new Word(address.ToString());
            IC.setValue(word);
        }

        private void input(Memory memory, InputDevice inputDevice, int blockNumber)
        {
            try
            {
                if (exchange(K1) == true)
                {
                    K1.setValue('1');
                    memory.setBlock(blockNumber, inputDevice.getInput());
                    K1.setValue('0');
                }
            }
            catch (Exception)
            {
                IOI.setValue((char)(IOI.getIntValue() + 1 + '0')); 
            }
        }

        private void output(Memory memory, OutputDevice outputDevice, int blockNumber)
        {
            try
            {
                if (exchange(K2) == true)
                {
                    K2.setValue('1');
                    outputDevice.setOutput(memory.getBlock(blockNumber));
                    K2.setValue('0');
                }
            }
            catch(Exception)
            {
                IOI.setValue((char)(IOI.getIntValue() + 2 + '0')); 
            }
        }

        private void input(Memory memory, HDDManager hddManager, int memoryWordAddress, int hddWordAddress)
        {
            try
            {
                if (exchange(K3) == true)
                {
                    K3.setValue('1');
                    memory.setWordAtAddress(memoryWordAddress, hddManager.getWordAtAddress(hddWordAddress));
                    K3.setValue('0');
                }
            }
            catch (Exception)
            {
                IOI.setValue((char)(IOI.getIntValue() + 4 + '0')); 
            }
        }

        private void output(Memory memory, HDDManager hddManager, int memoryWordAddress, int hddWordAddress)
        {
            try
            {
                if (exchange(K3) == true)
                {
                    K3.setValue('1');
                    hddManager.setWordAtAddress(hddWordAddress, memory.getWordAtAddress(memoryWordAddress));
                    K3.setValue('0');
                }
            }
            catch (Exception)
            {
                IOI.setValue((char)(IOI.getIntValue() + 4 + '0')); 
            }
        }

        private void push(Register4B register, ref Memory memory)
        {
            saveRegister(register, ref memory, SP.getValue().toInt());
            incRegister(ref SP);
        }

        private void push(Register2B register, ref Memory memory)
        {
            memory.setWordAtAddress(SP.getValue().toInt(), new Word(register.getValue().ToString()));
            incRegister(ref SP);
        }

        private void push(Register1B register, ref Memory memory)
        {
            memory.setWordAtAddress(SP.getValue().toInt(), new Word(register.getValue().ToString()));
            incRegister(ref SP);
        }

        private void pop(ref Register4B register, ref Memory memory)
        {
            decRegister(ref SP);
            loadRegister(ref register, memory.getWordAtAddress(SP.getValue().toInt()));
        }

        private void pop(ref Register2B register, ref Memory memory)
        {
            decRegister(ref SP);
            register.setValue(memory.getWordAtAddress(SP.getValue().toInt()).ToString());
        }

        private void pop(ref Register1B register, ref Memory memory)
        {
            decRegister(ref SP);
            register.setValue(memory.getWordAtAddress(SP.getValue().toInt()).getWordByte(4));
        }

        private void getRegister4B(Register4B register)
        {
            A.setValue(register.getValue());
        }

        private void setRegister4B(ref Register4B register)
        {
            register.setValue(A.getValue());
        }

        private void getRegister2B(Register2B register)
        {
            Word word = new Word(register.getValue().ToString());
            A.setValue(word);
        }

        private void setRegister2B(ref Register2B register)
        {
            string str = A.getValue().getWordByte(3).ToString() + A.getValue().getWordByte(4);
            register.setValue(str);

        }

        private void getRegister1B(Register1B register)
        {
            Word word = new Word(register.getValue().ToString());
            A.setValue(word);
        }

        private void setRegister1B(ref Register1B register)
        {
            char ch = A.getValue().getWordByte(4);
            register.setValue(ch);
        }

        private void slave(ref Memory memory)
        {
            memory.setWordAtAddress(M.getIntValue() * 10, A.getValue());
            memory.setWordAtAddress(M.getIntValue() * 10 + 1, B.getValue());
            memory.setWordAtAddress(M.getIntValue() * 10 + 2, new Word(C.getValue().ToString()));
            memory.setWordAtAddress(M.getIntValue() * 10 + 3, PR.getValue());
            memory.setWordAtAddress(M.getIntValue() * 10 + 4, SP.getValue());

            Word increasedIC = new Word((IC.getValue().toInt() + 1).ToString()); 

            memory.setWordAtAddress(M.getIntValue() * 10 + 5, increasedIC);
        }

        private void halt()
        {
            SI.setValue('3');
        }

        private void changeMode(int address)
        {
            if (MODE.getValue() == 'S')
                MODE.setValue('V');
            else
                MODE.setValue('S');
        }

        private bool exchange(Register1B channel)
        {
            if (channel.getIntValue() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void test()
        {
            if (PI.getValue() != '0')
            {
                handlePI();
                PI.setValue('0');
            }
            if (SI.getValue() != '0')
            {
                handleSI();
                SI.setValue('0');
            }
            if (IOI.getValue() != '0')
            {
                handleIOI();
                IOI.setValue('0');
            }
            if (TI.getValue() != '0')
            {
                handleTI();
                TI.setValue('0');
            }
        }

        private void handleInterrupt(int address)
        {
            Word tempWord = new Word("0000");
            if (MODE.getValue() != 'S')
            {
                changeMode(address);
            }
            else
            {
                tempWord.setWord(address.ToString());
                IC.setValue(tempWord);
            }
        }

        private void handlePI()
        {
            char ch = PI.getValue();

            switch (ch)
            {
                case '1':
                    handleInterrupt(140);
                    break;
                case '2':
                    handleInterrupt(150);
                    break;
                case '3':
                    handleInterrupt(160);
                    break;
                case '4':
                    handleInterrupt(170);
                    break;
                case '5':
                    handleInterrupt(180);
                    break;
            }
        }

        private void handleSI()
        {
            Word word = new Word("0000");
            char ch = SI.getValue();

            switch (ch)
            {
                case '1':
                    handleInterrupt(190);
                    break;
                case '2':
                    handleInterrupt(200);
                    break;
                case '3':
                    handleInterrupt(210);
                    break;
            }
        }

        private void handleIOI()
        {
            Word word = new Word("0000");
            char ch = IOI.getValue();

            switch (ch)
            {
                case '1':
                    handleInterrupt(220);
                    break;
                case '2':
                    handleInterrupt(220);
                    break;
                case '3':
                    handleInterrupt(240);
                    break;
                case '4':
                    handleInterrupt(250);
                    break;
                case '5':
                    handleInterrupt(260);
                    break;
                case '6':
                    handleInterrupt(270);
                    break;
                case '7':
                    handleInterrupt(280);
                    break;
            }
        }

        private void handleTI()
        {
            handleInterrupt(240);
        }
    }
}
