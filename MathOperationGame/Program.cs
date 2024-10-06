using MathOperationGame.BL;
using System;

namespace MathOperationGame
{
    public struct MathOperator
    {
       public MathOperator()
        {

        }
       public int nFirstNumber = 0;
       public int nSecondNumber = 0;
       public int nOperator = 0;
    }



    internal class Program
    {
        #region MyMethods

        public static IMathOperatorLevlel GetLevelObject(int nlevel)
        {
            IMathOperatorLevlel oImathOperatorLevel = new LevelOne();

            switch (nlevel)
            {
                case 1:
                    oImathOperatorLevel = new LevelOne();
                    break;
                case 2:
                    oImathOperatorLevel = new LevelTwo();
                    break;
                case 3:
                    oImathOperatorLevel = new LevelThree();
                    break;
                case 4:
                    oImathOperatorLevel = new LevelFour();
                    break;
            }
            return oImathOperatorLevel;

        }

        //public static MathOperator GetNextNumber(int nlevel, out ClsLevel oClsLevel)
        //{
        //    Random random = new Random();
        //    MathOperator currentNumber;
        //    oClsLevel = new ClsLevel();

        //    switch (nlevel)
        //    {
        //        case 1:
        //            oClsLevel.levelStart = 0;
        //            oClsLevel.levelEnd = 10;
        //            oClsLevel.noperatorCount = 1;
        //            oClsLevel.RightAnswerCount = 5;
        //            oClsLevel.WrongAnswerCount = 3;
        //            break;
        //        case 2:
        //            oClsLevel.levelStart = 0;
        //            oClsLevel.levelEnd = 20;
        //            oClsLevel.noperatorCount = 2;
        //            oClsLevel.RightAnswerCount = 10;
        //            oClsLevel.WrongAnswerCount = 3;
        //            break;
        //        case 3:
        //            oClsLevel.levelStart = 0;
        //            oClsLevel.levelEnd = 20;
        //            oClsLevel.noperatorCount = 3;
        //            oClsLevel.RightAnswerCount = 15;
        //            oClsLevel.WrongAnswerCount = 10;
        //            break;
        //        case 4:
        //            oClsLevel.levelStart = 0;
        //            oClsLevel.levelEnd = 30;
        //            oClsLevel.noperatorCount = 4;
        //            oClsLevel.RightAnswerCount = 15;
        //            oClsLevel.WrongAnswerCount = 10;
        //            break;
        //    }
        //    return oClsLevel.GetNextNumber();
        //}
        public static string GetOperator(MathOperator currentNumber)
        {
            string soperator = "+";
            switch (currentNumber.nOperator)
            {
                case 1:
                    soperator = "+";
                    break;
                case 2:
                    soperator = "-";
                    break;
                case 3:
                    soperator = "x";
                    break;
            }
            return soperator;
        }

        public static bool CheckAnswer(int result, MathOperator currentNumber)
        {
            bool isRightAnswer = false;
            switch (currentNumber.nOperator)
            {
                case 1:
                    isRightAnswer = (result == (currentNumber.nFirstNumber + currentNumber.nSecondNumber));
                    break;
                case 2:
                    isRightAnswer = (result == (currentNumber.nFirstNumber - currentNumber.nSecondNumber));
                    break;
                case 3:
                    isRightAnswer = (result == (currentNumber.nFirstNumber * currentNumber.nSecondNumber));
                    break;
            }
            return isRightAnswer;
        }

        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to math operator test");
            #region MyVariables

            char exit = 'a';
            int Qnumber = 1;
            int nRightAnswerCount = 0;
            int nWrongAnswerCount = 0;
           
            int levelNumber = 2;
            #endregion

            IMathOperatorLevlel MyCurrentLecvel = GetLevelObject(1);

            while (exit != 'e')
            {
                if (MyCurrentLecvel.GetNextLevel() == null)
                {
                    Console.WriteLine("Congratulation you finshed all levels");
                    break;

                }


                MathOperator currentNumber =  MyCurrentLecvel.GetNextNumber();
                
                // choosing the operator
                string soperator = GetOperator(currentNumber);

                // ask the user and get its result
                Console.WriteLine($"{Qnumber} - " +
                    $"Enter the answer of this question: " +
                    $"{currentNumber.nFirstNumber} {soperator} {currentNumber.nSecondNumber} = ");
                int result = Convert.ToInt32(Console.ReadLine());
                Qnumber++;



                // checking the result

                bool isRightAnswer = CheckAnswer(result, currentNumber);

                if (isRightAnswer == true)
                {
                    Console.WriteLine("Right answer");
                    nRightAnswerCount++;
                }
                else
                {
                    Console.WriteLine("wrong answer");
                    nWrongAnswerCount++;
                }


                LevelStatus status= MyCurrentLecvel.CheckAnswerCount(nWrongAnswerCount,nRightAnswerCount,levelNumber);
                 
                 
                if (status == LevelStatus.gameover)
                    break;
                if (status == LevelStatus.pormoted)
                {
                    nWrongAnswerCount = nRightAnswerCount = 0;
                    levelNumber++;
                    MyCurrentLecvel = MyCurrentLecvel.GetNextLevel() ;
                }

                // Exit or continue
                Console.WriteLine("click 'e' to Exit or andy key to continue:  ");
                exit = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
