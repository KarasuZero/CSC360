using System;
using System.Collections.Generic;
using System.Globalization;

namespace composite_test
{
    internal class Program
    {
        //Iterator interface
        public interface IIterator
        {
            void First(); // setting current to first element
            IQuestion CurrentQuestion(); // getting current element
            IQuestion Next();   // getting next element
            string CurrentOption();
            string NextOption();

            bool IsDone();
        }

        //Section Iterator
        public class SectionIterator : IIterator
        {
            private List<IQuestion> _questionGroup;
            private int _current = 0;

            public void First()
            {
                _current = 0;
            }

            public IQuestion CurrentQuestion()
            {
                try
                {
                    return _questionGroup[_current];
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public IQuestion Next()
            {
                return _questionGroup[_current++];
            }

            public bool IsDone()
            {
                return _current >= _questionGroup.Count;
            }

            public SectionIterator(List<IQuestion> questionGroup)
            {
                _questionGroup = questionGroup;
            }

            //unimportant

            public string CurrentOption()
            {
                throw new NotImplementedException();
            }

            public string NextOption()
            {
                throw new NotImplementedException();
            }
        }

        //Questions Iterator
        public class QuestionIterator : IIterator
        {
            private List<string> _Options;
            private int _current = 0;

            public void First()
            {
                _current = 0;
            }

            public string CurrentOption()
            {
                return _Options[_current];
            }

            public string NextOption()
            {
                return _Options[_current++];
            }

            public bool IsDone()
            {
                return _current >= _Options.Count;
            }

            public QuestionIterator(List<string> options)
            {
                _Options = options;
            }

            //unimportant
            public IQuestion CurrentQuestion()
            {
                throw new NotImplementedException();
            }

            public IQuestion Next()
            {
                throw new NotImplementedException();
            }
        }

        //Question Interface
        public interface IQuestion
        {
            string Tittle { get; set; }
            string TheAnswer { get; set; }
            List<string> Options { get; set; }
            List<IQuestion> Questions { get; set; }
            List<IQuestion> QuestionGroups { get; set; }

            void addOption(string option);
            void addQuestion(IQuestion question);
            void addQuestionGroup(IQuestion question);
            void removeOption(string option);
            void removeQuestion(IQuestion question);
            void removeQuestionGroup(IQuestion question);
            IIterator CreateIterator();

        }

        //Question Class - Leaf
        public class Question : IQuestion
        {
            public string Tittle { get; set; }
            public string TheAnswer { get; set; }
            public List<string> Options { get; set; }
            public List<IQuestion> Questions { get; set; }
            public List<IQuestion> QuestionGroups { get; set; }

            public void addOption(string option)
            {
                Options.Add(option);
            }

            public void addQuestion(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public void addQuestionGroup(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public void removeOption(string option)
            {
                Options.Remove(option);
            }

            public void removeQuestion(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public void removeQuestionGroup(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public IIterator CreateIterator()
            {
                return new QuestionIterator(Options);
            }

            public Question(string question, string answer, List<string> options)
            {
                Tittle = question;
                TheAnswer = answer;
                Options = options;
            }
        }

        //Question Class - Composite - Collection of Questions
        public class QuestionGroup : IQuestion
        {
            public string Tittle { get; set; }
            public string TheAnswer { get; set; }
            public List<string> Options { get; set; }
            public List<IQuestion> Questions { get; set; }
            public List<IQuestion> QuestionGroups { get; set; }

            public void addOption(string option)
            {
                throw new NotImplementedException();
            }

            public void addQuestion(IQuestion question)
            {
                Questions.Add(question);
            }

            public void addQuestionGroup(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public void removeOption(string option)
            {
                throw new NotImplementedException();
            }

            public void removeQuestion(IQuestion question)
            {
                Questions.Remove(question);
            }

            public void removeQuestionGroup(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public IIterator CreateIterator()
            {
                return new SectionIterator(Questions);
            }

            public QuestionGroup(string tittle, List<IQuestion> questions)
            {
                Tittle = tittle;
                Questions = questions;
            }

        }

        //Question Class - Composite - Collection of QuestionGroups
        public class Section : IQuestion
        {
            public string Tittle { get; set; }
            public string TheAnswer { get; set; }
            public List<string> Options { get; set; }
            public List<IQuestion> Questions { get; set; }
            public List<IQuestion> QuestionGroups { get; set; }

            public void addOption(string option)
            {
                throw new NotImplementedException();
            }

            public void addQuestion(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public void addQuestionGroup(IQuestion questionGroup)
            {
                QuestionGroups.Add(questionGroup);
            }

            public void removeOption(string option)
            {
                throw new NotImplementedException();
            }

            public void removeQuestion(IQuestion questionGroup)
            {
                throw new NotImplementedException();
            }

            public void removeQuestionGroup(IQuestion question)
            {
                throw new NotImplementedException();
            }

            public IIterator CreateIterator()
            {
                return new SectionIterator(QuestionGroups);
            }

            public Section(string tittle, List<IQuestion> questionGroups)
            {
                Tittle = tittle;
                QuestionGroups = questionGroups;
            }
        }

        public static void Main(string[] args)
        {
            //Create Questions
            IQuestion question = new Question("What is the capital of France?", "Paris",
                new List<string> { "London", "Paris", "Berlin" });
            IQuestion question2 = new Question("What is the capital of Germany?", "Berlin",
                new List<string> { "London", "Paris", "Berlin" });
            IQuestion question3 = new Question("What is the capital of England?", "London",
                new List<string> { "London", "Paris", "Berlin" });

            //Create QuestionGroups
            IQuestion questionGroup =
                new QuestionGroup("Europe", new List<IQuestion> { question, question2, question3 });

            //Create Questions
            IQuestion question4 = new Question("What is 2 + 2?", "4", new List<string> { "2", "4", "6" });
            IQuestion question5 = new Question("What is 2 + 3?", "5", new List<string> { "2", "5", "6" });
            IQuestion question6 = new Question("What is 2 + 4?", "6", new List<string> { "2", "4", "6" });

            // Create QuestionGroups
            IQuestion questionGroup2 =
                new QuestionGroup("Maths", new List<IQuestion> { question4, question5, question6 });
            
            //create Section
            IQuestion Section = new Section("Trivia", new List<IQuestion> { questionGroup, questionGroup2 });
            //Section.addQuestionGroup(questionGroup2);
            
            //create Iterator
            IIterator QuestionGroupIterator = Section.CreateIterator();
            IIterator SubsectionIterator = questionGroup.CreateIterator();
            IIterator QuestionIterator = question.CreateIterator();

            Console.WriteLine("Section: " + Section.Tittle);

            QuestionGroupIterator.First();
            while (!QuestionGroupIterator.IsDone())
            {
                
                Console.WriteLine("Question Group: " + QuestionGroupIterator.CurrentQuestion().Tittle);
                SubsectionIterator.First();
                while (!SubsectionIterator.IsDone())
                {
                    QuestionIterator.First();
                    Console.WriteLine("");
                    Console.WriteLine("Question: " + SubsectionIterator.CurrentQuestion().Tittle);
                    Console.WriteLine("Next Question: next");
                    while (!QuestionIterator.IsDone())
                    {
                        Console.WriteLine("Option: " + QuestionIterator.CurrentOption());
                        QuestionIterator.NextOption();
                    }

                    //Answer handling
                    string answer = Console.ReadLine(); //Get console input

                    if(answer != null && !answer.ToLower().Equals("next"))
                    {
                        if (answer != null && answer.ToLower().Equals(SubsectionIterator.CurrentQuestion().TheAnswer.ToLower()))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Answer Correct!");
                        }
                        else if(answer != null)
                        {
                            Console.WriteLine("Incorrect!");
                        }
                    }
                    
                    SubsectionIterator.Next();
                }
                try
                {
                    QuestionGroupIterator.Next();
                    SubsectionIterator = QuestionGroupIterator.CurrentQuestion().CreateIterator();
                    QuestionIterator = SubsectionIterator.CurrentQuestion().CreateIterator();
                } catch(NullReferenceException nre)
                {
                    Console.WriteLine(nre.Message);
                }
                
            }
        }

    }
}
    
    