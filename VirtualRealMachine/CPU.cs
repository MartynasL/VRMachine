using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class CPU
    {
        private Register A = new Register4B();
        private Register B = new Register4B();
        private Register IC = new Register4B();
        private Register SP = new Register4B();
        private Register PR = new Register4B();
        private Register TIMER = new Register2B();
        private Register RC = new Register1B();
        private Register M = new Register1B();
        private Register PI = new Register1B();
        private Register SI = new Register1B();
        private Register IOI = new Register1B();
        private Register TI = new Register1B();
        private Register MODE = new Register1B();
        private Register K1 = new Register1B();
        private Register K2 = new Register1B();
        private Register K3 = new Register1B();
        private Register C = new Register1B();

        private void addRegisterMemory(Register4B register, Word word)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register.getValue().getIntValue();
            op2 = word.getIntValue();
            op1 = op1 + op2;
            if (op1 > 9999)
                C.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register.setValue(tempWord);
            }
        }

        private void addRegisters(Register4B register1, Register4B register2)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().getIntValue();
            op2 = register2.getValue().getIntValue();
            op1 = op1 + op2;
            if (op1 > 9999)
                C.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register1.setValue(tempWord);
            }
        }

        private void subRegisterMemory(Register4B register, Word word)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register.getValue().getIntValue();
            op2 = word.getIntValue();
            if (op1 >= op2)
            {
                op1 = op1 - op2;
                tempWord.setWord(op1.ToString());
                register.setValue(tempWord);
            }
            else C.setValue('4');                
        }

        private void subRegisters(Register4B register1, Register4B register2)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().getIntValue();
            op2 = register2.getValue().getIntValue();
            if (op1 >= op2)
            {
                op1 = op1 - op2;
                tempWord.setWord(op1.ToString());
                register1.setValue(tempWord);
            }
            else C.setValue('4');
        }

        private void mulRegisterMemory(Register4B register, Word word)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register.getValue().getIntValue();
            op2 = word.getIntValue();
            op1 = op1 * op2;
            if (op1 > 9999)
                C.setValue('3');
            else
            {
                tempWord.setWord(op1.ToString());
                register.setValue(tempWord);
            }
        }

        private void mulRegisters(Register4B register1, Register4B register2)
        {
            int op1, op2;
            Word tempWord = new Word("0000");

            op1 = register1.getValue().getIntValue();
            op2 = register2.getValue().getIntValue();
            op1 = op1 * op2;
            if (op1 > 9999)
                C.setValue('3');
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

            op1 = register.getValue().getIntValue();
            op2 = word.getIntValue();
            if (op1 == 0)
                C.setValue('2');
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

            op1 = register1.getValue().getIntValue();
            op2 = register2.getValue().getIntValue();
            if (op1 == 0)
                C.setValue('2');
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

        private void incRegister(Register4B register)
        {
            Word tempWord = new Word("0000");
            int op = register.getValue().getIntValue();
            if (op == 9999)
                C.setValue('3');
            else
            {
                op++;
                tempWord.setWord(op.ToString());
                register.setValue(tempWord);
            }
        }

        private void decRegister(Register4B register)
        {
            Word tempWord = new Word("0000");
            int op = register.getValue().getIntValue();
            if (op == 0)
                C.setValue('4');
            else
            {
                op--;
                tempWord.setWord(op.ToString());
                register.setValue(tempWord);
            }
        }

        private void loadRegister()
        {

        }

        private void saveRegister()
        {

        }

        private void copyRegister()
        {

        }

        private void compRegisterMemory()
        {

        }

        private void compRegisters()
        {

        }

        private void jump()
        {

        }

        private void input()
        {

        }

        private void output()
        {

        }

        private void push()
        {

        }

        private void pop()
        {

        }

        private void getRegister()
        {

        }

        private void setRegister()
        {

        }

        private void slave()
        {

        }

        private void halt()
        {

        }

        private void changeMode()
        {

        }

        private void exchange()
        {

        }

        private void test()
        {

        }
    }
}
