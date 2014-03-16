using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealMachine
{
    class Interpretator
    {
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
                    caseDefault();
                    break;

            }
        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }

        private void casePlus(Word word)
        {

        }
    }
}
