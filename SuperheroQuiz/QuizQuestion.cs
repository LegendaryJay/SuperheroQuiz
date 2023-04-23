using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroQuiz
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string YesString { get; set; }
        public string NoString { get; set; }
        public AnswerKey AnswerKey { get; set; }

        public QuizQuestion(int id, string title, AnswerKey answerKey, string yesString = "Yes", string noString = "No")
        {
            Id = id;
            Title = title;
            YesString = yesString;
            NoString = noString;
            AnswerKey = answerKey;
        }

        public List<Hero> Evaluate(bool answer)
        {
            var result = AnswerKey.getResult(answer);
            result.ForEach(hero => hero.Score += 1);
            return result;
        }
    }
}