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
                    notFound();
                    break;

            }
        }

        private void casePlus(Word word)
        {
            char ch1 = word.getWordByte(2);
            char ch2 = word.getWordByte(3);


            if ((ch2 < 58) && (ch2 > 47))
            {
                char ch3 = word.getWordByte(4);
                int address = Convert.ToInt32(String.Concat(ch2, ch3));

                if (ch1 == 65)
                {
                    
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
