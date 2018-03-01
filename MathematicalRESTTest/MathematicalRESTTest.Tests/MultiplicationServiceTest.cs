using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MathematicalRESTTest.Business;
using MathematicalRESTTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathematicalRESTTest.Tests
{
    [TestClass]
    public class MultiplicationServiceTest
    {
        [TestMethod]
        public void GenerateMultiplcationQuestionsTest()
        {
            var multiplicationService = new MultiplicationService();

            var numberOfQuestions = 10;

            var generatedQuestions = multiplicationService.GenerateQuestions(numberOfQuestions);

            Assert.AreEqual(numberOfQuestions, generatedQuestions.Count);

            foreach (var question in generatedQuestions)
            {
                var result = question.FirstNumber * question.SecondNumber;

                Assert.IsTrue(result >= 0 && result <= 100);
            }
        }
        
        [TestMethod]
        public void ScoreMultiplcationQuestionsTest()
        {
            var multiplicationService = new MultiplicationService();
            
            var generatedQuestions = Helper.GetQuestionSetForScoring(); ;

            multiplicationService.ScoreQuestions(generatedQuestions.Questions);

            //Split the questions after scoring into two lists
            //One is the multiplication questions which we can individually check to ensure they were scored properly
            var multiplicationQuestions = generatedQuestions.Questions.Where(a => a.QuestionType == QuestionType.Multiplication).ToList();

            Assert.AreEqual(QuestionState.Correct, multiplicationQuestions[0].QuestionState);
            Assert.AreEqual(QuestionState.Incorrect, multiplicationQuestions[1].QuestionState);
            Assert.AreEqual(QuestionState.NotScored, multiplicationQuestions[2].QuestionState);

            //This list is everything that isn't a multplication question and so should not have been scored
            var otherQuestions = generatedQuestions.Questions.Where(a => a.QuestionType != QuestionType.Multiplication);

            Assert.IsTrue(otherQuestions.All(a => a.QuestionState == QuestionState.NotScored));
        }
    }
}
