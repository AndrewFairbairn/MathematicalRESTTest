using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathematicalRESTTest.Models;

namespace MathematicalRESTTest.Business
{
    public class DivisionRemainderService : IGenerateQuestions
    {
        private readonly Random _randomiser = new Random();
        public List<Question> GenerateQuestions(int numberOfQuestions)
        {
            var questions = new List<Question>();

            for (int i = 1; i <= numberOfQuestions; i++)
            {
                questions.Add(GenerateQuestion());
            }

            return questions;
        }

        public void ScoreQuestions(IEnumerable<Question> questions)
        {
            //Only look at the questions relevant to this service
            foreach (var question in questions.Where(a => a.QuestionType == QuestionType.DivisionWithRemainder))
            {
                var questionState = QuestionState.NotScored;

                if (question.Answer.HasValue)
                {
                    var expectedResult = question.SecondNumber > 0 ? question.FirstNumber / question.SecondNumber : 0;
                    var expectedRemainder = question.SecondNumber > 0 ? question.FirstNumber % question.SecondNumber : 0;

                    if (expectedResult == question.Answer && expectedRemainder == question.Remainder)
                    {
                        questionState = QuestionState.Correct;   
                    }
                    else
                    {
                        questionState = QuestionState.Incorrect;
                    }
                }

                question.QuestionState = questionState;
            }
        }

        private Question GenerateQuestion()
        {
            var isValidQuestion = false;
            var question = new Question();

            while (!isValidQuestion)
            {
                var firstNumber = _randomiser.Next(1, 100);
                var secondNumber = _randomiser.Next(1, 100);

                //Catch accidental DivideByZero if above code is changed
                if (secondNumber == 0)
                {
                    continue;
                }

                var result = firstNumber / secondNumber;

                if (result <= 100 && result > 0 && firstNumber % secondNumber != 0)
                {
                    isValidQuestion = true;

                    question = new Question
                    {
                        FirstNumber = firstNumber,
                        SecondNumber = secondNumber,
                        QuestionType = QuestionType.DivisionWithRemainder
                    };
                }
            }

            return question;
        }
    }
}