using SuperheroQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace SuperheroQuiz
{
    internal class SuperheroQuizViewModel
    {
        public List<QuizQuestion> Questions { get; set; }
        public SuperheroQuizViewModel()
        {
            Questions = new List<QuizQuestion> {
                new QuizQuestion(
                    1, 
                    "Would you rather work alone or as part of a team?",
                    new AnswerKey(
                        new List<Hero> { Icon.Batman, Icon.SpiderMan },
                        new List<Hero> { Icon.Superman, Icon.WonderWoman, Icon.CaptainAmerica }
                        ),
                    "Alone",
                    "Team"
                    ),

                new QuizQuestion(2, "Are you more comfortable in the city or in nature?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.SpiderMan },
                new List<Hero> { Icon.Superman, Icon.WonderWoman, Icon.CaptainAmerica }),
                    "City",
                    "Nature"
                ),

                new QuizQuestion(3, "Are you a naturally curious person?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.SpiderMan, Icon.WonderWoman },
                new List<Hero> { Icon.Superman, Icon.CaptainAmerica })),

                new QuizQuestion(4, "Do you value your privacy?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.SpiderMan, Icon.Superman, Icon.WonderWoman },
                new List<Hero> { Icon.CaptainAmerica })),

                new QuizQuestion(5, "Are you an optimist or a pessimist?",
                new AnswerKey(new List<Hero> { Icon.SpiderMan, Icon.Superman, Icon.CaptainAmerica },
                new List<Hero> { Icon.Batman, Icon.WonderWoman }),
                    "Optimist",
                    "Pessimist"
                ),

                new QuizQuestion(6, "Are you a rule follower or a rule breaker?",
                new AnswerKey(new List<Hero> { Icon.Superman, Icon.CaptainAmerica },
                new List<Hero> { Icon.Batman, Icon.SpiderMan, Icon.WonderWoman }),
                    "Follower",
                    "Breaker"
                ),
                

                new QuizQuestion(7, "Are you more analytical or intuitive?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.Superman },
                new List<Hero> { Icon.SpiderMan, Icon.WonderWoman, Icon.CaptainAmerica }),
                    "Analytical",
                    "Intuitive"
                    
                ),

                new QuizQuestion(8, "Do you have a tendency to be secretive?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.WonderWoman },
                new List<Hero> { Icon.SpiderMan, Icon.Superman, Icon.CaptainAmerica })),

                new QuizQuestion(9, "Do you have a strong sense of empathy?",
                new AnswerKey(new List<Hero> { Icon.SpiderMan, Icon.WonderWoman },
                new List<Hero> { Icon.Batman, Icon.Superman, Icon.CaptainAmerica })),

                new QuizQuestion(10, "Do you believe that the ends justify the means?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.WonderWoman },
                new List<Hero> { Icon.SpiderMan, Icon.Superman, Icon.CaptainAmerica })),

                new QuizQuestion(11, "Are you a bit of a rebel?",
                new AnswerKey(new List<Hero> { Icon.Batman, Icon.SpiderMan, Icon.WonderWoman },
                new List<Hero> { Icon.Superman, Icon.CaptainAmerica })),
            };
        }

        public Hero SelectWinner()
        {
            return Icon.Heroes.ToList().OrderByDescending(x => x.Score).First();
        }

        public void Reset()
        {
            Icon.Heroes.ToList().ForEach(x => x.Score = 0);
        }

        public List<Hero> GetHeroes()
        {
            return Icon.Heroes.ToList();
        }


            public class Icon
            {
                public static readonly Hero Batman = new Hero { Id = 1, Name = "Batman", Image = "batman.png" };
                public static readonly Hero SpiderMan = new Hero { Id = 2, Name = "Spider-Man", Image = "spiderman.png" };
                public static readonly Hero Superman = new Hero { Id = 3, Name = "Superman", Image = "superman.png" };
                public static readonly Hero WonderWoman = new Hero
                {
                    Id = 4,
                    Name = "Wonder Woman",
                    Image = "wonderwoman.png" 
                };
                public static readonly Hero CaptainAmerica = new Hero { Id = 5, Name = "Captain America", Image = "captainamerica.png" };

                public static readonly List<Hero> Heroes = new List<Hero> { Batman, SpiderMan, Superman, WonderWoman, CaptainAmerica };
            }
        }
    }