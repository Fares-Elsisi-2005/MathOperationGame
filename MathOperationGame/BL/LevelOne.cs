using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame.BL
{
    internal class LevelOne : IMathOperatorLevlel
    {
        public int levelStart { get; } = 0;

        public int levelEnd { get; } = 10;

        public int noperatorCount {get;} = 1;

        public int RightAnswerCount { get; } = 5;

        public int WrongAnswerCount {get;}= 3;
        public int nLevel { get ; } = 1;
        

        public LevelStatus CheckAnswerCount(int nWrongAnswerCount, int nRightAnswerCount,  int levelNumber)
        {
            LevelStatus status = LevelStatus.inprograss;
            if (nWrongAnswerCount == WrongAnswerCount)
            {
                Console.WriteLine("game over - you answer 3 question wrong");
                status = LevelStatus.gameover;
            }
            if (nRightAnswerCount == RightAnswerCount)
            {
                Console.Clear();
                Console.WriteLine($"level {levelNumber} -  you answer 5 question Right");

                status = LevelStatus.pormoted;

            }
            return status;
        }

        public IMathOperatorLevlel GetNextLevel()
        {
            return new LevelTwo();
        }

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
