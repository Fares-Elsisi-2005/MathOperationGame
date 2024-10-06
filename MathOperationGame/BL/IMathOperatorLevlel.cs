using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame.BL
{
    public enum LevelStatus
    {
        inprograss = 1,
        pormoted = 2,
        gameover = 3,
    }

    internal interface IMathOperatorLevlel
    {
        public int nLevel { get; }
        public int levelStart { get;}
        public int levelEnd { get;}
        public int noperatorCount { get;}
        public int RightAnswerCount { get;}
        public int WrongAnswerCount { get;}

        public MathOperator GetNextNumber();

        public LevelStatus CheckAnswerCount(int nWrongAnswerCount, int nRightAnswerCount,  int levelNumber);
        

        public IMathOperatorLevlel GetNextLevel();

    }
}
