using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;
using MathematicalRESTTest.Business;
using MathematicalRESTTest.Models;

namespace MathematicalRESTTest.Controllers
{
    public class MathsController : ApiController
    {
        private const int NumberOfQuestions = 5;
        private readonly CacheService _cacheService = new CacheService();
        private readonly DivisionService _divisionService = new DivisionService();
        private readonly DivisionRemainderService _divisionRemainderService = new DivisionRemainderService();
        private readonly MultiplicationService _multiplicationService = new MultiplicationService();

        //GET: api/Maths/
        [ResponseType(typeof(QuestionSet))]
        public IHttpActionResult GetQuestionSet()
        {
            var questions = new List<Question>();

            questions.AddRange(_multiplicationService.GetQuestions(NumberOfQuestions));
            questions.AddRange(_divisionService.GetQuestions(NumberOfQuestions));
            questions.AddRange(_divisionRemainderService.GetQuestions(NumberOfQuestions));

            var questionSet = new QuestionSet
            {
                Id = Guid.NewGuid().ToString(),
                Questions = questions
            };
            
            _cacheService.AddUpdateQuestionSetInCache(questionSet);

            return Created($"api/Maths/{questionSet.Id}",questionSet);
        }

        // GET: api/Maths/{Id} 
        [ResponseType(typeof(QuestionSet))]
        public IHttpActionResult GetquestionSet(string id)
        {
            var questions = _cacheService.GetQuestionSetFromCache(id);

            if (questions == null)
            {
                return NotFound();
            }

            var questionSet = new QuestionSet
            {
                Id = id,
                Questions = (List<Question>)questions
            };

            return Ok(questionSet);
        }

        [ResponseType(typeof(QuestionSet))]
        public IHttpActionResult PutquestionSet(QuestionSet questionSet)
        {
            _multiplicationService.ScoreQuestions(questionSet.Questions);
            _divisionService.ScoreQuestions(questionSet.Questions);

            _cacheService.AddUpdateQuestionSetInCache(questionSet);
            return Ok(questionSet);
        }

        
    }
}
