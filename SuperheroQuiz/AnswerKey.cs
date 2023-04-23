using System.Collections.Generic;

namespace SuperheroQuiz
{
    public class AnswerKey
    {
        public List<Hero> YesList { get; set; }
        public List<Hero> NoList { get; set; }
        public AnswerKey(List<Hero> yesList, List<Hero> noList)
        {
            YesList = yesList;
            NoList = noList;
        }

        public List<Hero> getResult(bool answer)
        {
            return answer ? YesList : NoList;
        }
    }
}