using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using MathematicalRESTTest.Controllers;
using MathematicalRESTTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathematicalRESTTest.Tests
{
    [TestClass]
    public class MathsControllerTests
    {
        [TestMethod]
        public void GetNewQuestionSetTestCreatedResult()
        {
            var controller = new MathsController();

            var response = controller.GetquestionSet();
            var contentResult = response as CreatedNegotiatedContentResult<QuestionSet>;

            Assert.IsNotNull(contentResult);
            Assert.IsTrue(contentResult.Content.Questions.Count > 0);
        }

        [TestMethod]
        public void GetExistingQuestionSetTestNotFoundResult()
        {
            var controller = new MathsController();

            var response = controller.GetquestionSet("A Made Up Id");
            var contentResult = response as NotFoundResult;

            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void GetExistingQuestionSetTestOkResult()
        {
            var controller = new MathsController();

            var response = controller.GetquestionSet();
            var createdQuestionSet = response as CreatedNegotiatedContentResult<QuestionSet>;

            Assert.IsNotNull(createdQuestionSet);

            var secondResponse = controller.GetquestionSet(createdQuestionSet.Content.Id);
            var reloadedQuestionSet = secondResponse as OkNegotiatedContentResult<QuestionSet>;

            Assert.IsNotNull(reloadedQuestionSet);

            Assert.AreEqual(createdQuestionSet.Content.Id, reloadedQuestionSet.Content.Id);

            for (int i = 0; i <= createdQuestionSet.Content.Questions.Count - 1; i++)
            {
                var createdQuestion = createdQuestionSet.Content.Questions[i];
                var reloadedQuestion = reloadedQuestionSet.Content.Questions[i];

                Assert.AreEqual(createdQuestion.FirstNumber, reloadedQuestion.FirstNumber);
                Assert.AreEqual(createdQuestion.SecondNumber, reloadedQuestion.SecondNumber);
                Assert.AreEqual(createdQuestion.Answer, reloadedQuestion.Answer);
                Assert.AreEqual(createdQuestion.Remainder, reloadedQuestion.Remainder);
                Assert.AreEqual(createdQuestion.QuestionType, reloadedQuestion.QuestionType);
                Assert.AreEqual(createdQuestion.QuestionState, reloadedQuestion.QuestionState);
            }
        }

        [TestMethod]
        public void ScoreQuestionSetOkResult()
        {
            var controller = new MathsController();

            var suppliedQuestionSet = Helper.GetQuestionSetForScoring();

            var response = controller.PutquestionSet(suppliedQuestionSet);
            var contentResult = response as OkNegotiatedContentResult<QuestionSet>;

            Assert.IsNotNull(contentResult);
            
            var returnedQuestionSet = contentResult.Content;

            Assert.AreEqual(suppliedQuestionSet.Id, returnedQuestionSet.Id);

            Assert.AreEqual(QuestionState.Correct, returnedQuestionSet.Questions[0].QuestionState);
            Assert.AreEqual(QuestionState.Incorrect, returnedQuestionSet.Questions[1].QuestionState);
            Assert.AreEqual(QuestionState.NotScored, returnedQuestionSet.Questions[2].QuestionState);
            Assert.AreEqual(QuestionState.Correct, returnedQuestionSet.Questions[3].QuestionState);
            Assert.AreEqual(QuestionState.Incorrect, returnedQuestionSet.Questions[4].QuestionState);
            Assert.AreEqual(QuestionState.NotScored, returnedQuestionSet.Questions[5].QuestionState);
            Assert.AreEqual(QuestionState.Correct, returnedQuestionSet.Questions[6].QuestionState);
            Assert.AreEqual(QuestionState.Incorrect, returnedQuestionSet.Questions[7].QuestionState);
            Assert.AreEqual(QuestionState.NotScored, returnedQuestionSet.Questions[8].QuestionState);
        }
    }
}
