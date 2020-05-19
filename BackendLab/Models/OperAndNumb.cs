using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendLab.Models
{
    public class OperAndNumb
    {
        public double First { get; set; }
        public double Second { get; set; }
        public string Operand { get; set; }
        public double CorrectAnswer { get; private set; }
        
       
        [Range(-100, 100)]
        [Required]
        public double YourAnswer { get; set; }

        public OperAndNumb()
        {
            Random random = new Random();
            this.First = random.Next(11);
            this.Second = random.Next(11);
            string[] Operands = { "+", "-", "*", "/" };
            this.Operand = Operands[random.Next(4)];
            
        }
        public void Solution()
        {

            StringToOper(Operand, First, Second);
        }
        private void  StringToOper(string oper, double First, double Second)
        {
            switch (oper)
            {
                case "+":
                    CorrectAnswer =First + Second;
                    break;
                case "-":
                    CorrectAnswer = First - Second;
                    break;
                case "*":
                    CorrectAnswer = First * Second;
                    break;
                case "/":
                    CorrectAnswer = First / Second;
                    break;
            }
        }
        public bool RightOrWrong()
        {
            double AnswerDouble = Math.Abs(YourAnswer - CorrectAnswer);
            if (Operand == "/" & AnswerDouble < 0.1)
            {
                return true;
            }
            if (YourAnswer == CorrectAnswer)
                return true;
            return false;
        }
    }

    public sealed class TotalAndCorrectAns
    {
        private TotalAndCorrectAns()
        {
            Reset();
        }

        public void Reset()
        {
            Number = 0;
            Correct = 0;
            Total = 0;
            Answers = new List<OperAndNumb>();
        }
        public List<OperAndNumb> Answers;
        public int Correct { get; set; }
        public int Total { get; set; }
        public int Number { get; set; }

        public static TotalAndCorrectAns Instance { get; } = new TotalAndCorrectAns();

    }
}
