﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathematicalRESTTest.Models;

namespace MathematicalRESTTest.Business
{
    public interface IGenerateQuestions
    {
        List<Question> GenerateQuestions(int numberOfQuestions);
        void ScoreQuestions(IEnumerable<Question> questions);
    }
}
