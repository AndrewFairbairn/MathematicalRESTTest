namespace MathematicalRESTTest.Models
{
    public class Question
    {
        public int FirstNumber { get; set; } 
        public int SecondNumber { get; set; }
        public decimal? Answer { get; set; }
        public decimal? Remainder { get; set; }
        public QuestionState QuestionState { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}