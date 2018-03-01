using System;
using System.Collections.Generic;
using MathematicalRESTTest.Models;

namespace MathematicalRESTTest.Tests
{
    public static class Helper
    {
        public static QuestionSet GetQuestionSetForScoring()
        {
            return new QuestionSet
            {
                Id = Guid.NewGuid().ToString(),
                Questions = new List<Question>
                {
                    new Question
                    {
                        FirstNumber = 5,
                        SecondNumber = 2,
                        Answer = 10,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.Multiplication
                    },
                    new Question
                    {
                        FirstNumber = 5,
                        SecondNumber = 2,
                        Answer = 999,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.Multiplication
                    },
                    new Question
                    {
                        FirstNumber = 5,
                        SecondNumber = 2,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.Multiplication
                    },
                    new Question
                    {
                        FirstNumber = 10,
                        SecondNumber = 2,
                        Answer = 5,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.Division
                    },
                    new Question
                    {
                        FirstNumber = 10,
                        SecondNumber = 2,
                        Answer = 999,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.Division
                    },
                    new Question
                    {
                        FirstNumber = 10,
                        SecondNumber = 2,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.Division
                    },
                    new Question
                    {
                        FirstNumber = 20,
                        SecondNumber = 12,
                        Answer = 1,
                        Remainder = 8,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.DivisionWithRemainder
                    },
                    new Question
                    {
                        FirstNumber = 20,
                        SecondNumber = 12,
                        Answer = 999,
                        Remainder = 1,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.DivisionWithRemainder
                    },
                    new Question
                    {
                        FirstNumber = 20,
                        SecondNumber = 12,
                        QuestionState = QuestionState.NotScored,
                        QuestionType = QuestionType.DivisionWithRemainder
                    }
                }
            };
        }
    }
}