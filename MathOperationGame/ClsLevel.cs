using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame
{
    internal class ClsLevel
    {
        public int levelStart { get; set; }
        public int levelEnd { get; set; }
        public int noperatorCount { get; set; }
        public int RightAnswerCount { get; set; }
        public int WrongAnswerCount { get; set; }


        public MathOperator GetNextNumber()
        {
            Random random = new Random();
            MathOperator currentNumber;
            currentNumber.nFirstNumber = random.Next(levelStart, levelEnd);
            currentNumber.nSecondNumber = random.Next(levelStart, levelEnd);
            currentNumber.nOperator = random.Next(1, noperatorCount);
             
            return currentNumber;
        }

    }
}
