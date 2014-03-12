using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    public class CPU
    {
        private Register4B A = new Register4B();
        private Register4B B = new Register4B();
        private Register4B IC = new Register4B();
        private Register4B SP = new Register4B();
        private Register4B PR = new Register4B();
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

        private void addRegisterMemory(ref Register4B register, Word word)
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

        private void addRegisters(ref Register4B register1, Register4B register2)
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

        private void subRegisterMemory(ref Register4B register, Word word)
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

        private void subRegisters(ref Register4B register1, Register4B register2)
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

        private void mulRegisterMemory(ref Register4B register, Word word)
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

        private void mulRegisters(ref Register4B register1, Register4B register2)
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

        private void input()
        {

        }

        private void output()
        {

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

        private void slave()
        {

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

        private void exchange()
        {

        }

        private void test()
        {

        }
    }
}
