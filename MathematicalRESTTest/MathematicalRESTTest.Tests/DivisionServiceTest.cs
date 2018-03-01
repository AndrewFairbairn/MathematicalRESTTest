using System;
using System.Linq;
using MathematicalRESTTest.Business;
using MathematicalRESTTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathematicalRESTTest.Tests
{
    [TestClass]
    public class DivisionServiceTest
    {
        [TestMethod]
        public void GenerateDivisionQuestionsTest()
        {
            var divisionService = new DivisionService();

            var numberOfQuestions = 10;

            var generatedQuestions = divisionService.GenerateQuestions(numberOfQuestions);

            Assert.AreEqual(numberOfQuestions, generatedQuestions.Count);

            foreach (var question in generatedQuestions)
            {
                var result = question.FirstNumber / question.SecondNumber;

                Assert.IsTrue(result >= 0 && result <= 100);
            }
        }

        [TestMethod]
        public void ScoreDivisionQuestionsTest()
        {
            var divisionService = new DivisionService();

            var generatedQuestions = Helper.GetQuestionSetForScoring();

            divisionService.ScoreQuestions(generatedQuestions.Questions);

            //Split the questions after scoring into two lists
            //One is the division questions which we can individually check to ensure they were scored properly
            var divisionQuesions = generatedQuestions.Questions.Where(a => a.QuestionType == QuestionType.Division).ToList();

            Assert.AreEqual(QuestionState.Correct, divisionQuesions[0].QuestionState);
            Assert.AreEqual(QuestionState.Incorrect, divisionQuesions[1].QuestionState);
            Assert.AreEqual(QuestionState.NotScored, divisionQuesions[2].QuestionState);

            //This list is everything that isn't a division question and so should not have been scored
            var otherQuestions = generatedQuestions.Questions.Where(a => a.QuestionType != QuestionType.Division);

            Assert.IsTrue(otherQuestions.All(a => a.QuestionState == QuestionState.NotScored));
        }
    }
}
