using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using MathematicalRESTTest.Models;

namespace MathematicalRESTTest.Business
{
    public class CacheService
    {
        private readonly MemoryCache _memCache = MemoryCache.Default;

        public List<Question> GetQuestionSetFromCache(string id)
        {
            var cachedQuestions = _memCache.Get(id);

            return (List<Question>) cachedQuestions;
        }
        public void AddUpdateQuestionSetInCache(QuestionSet questionSet)
        {
            var existingSet = GetQuestionSetFromCache(questionSet.Id);

            if (existingSet != null)
            {
                _memCache.Remove(questionSet.Id);
            }

            _memCache.Add(questionSet.Id, questionSet.Questions, DateTimeOffset.Now.AddDays(1));
        }
    }
}