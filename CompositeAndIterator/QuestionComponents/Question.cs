using System;
using System.Collections.Generic;
using CompositeAndIterator.Interfaces;
using CompositeAndIterator.IteratorComponents;

namespace CompositeAndIterator.QuestionComponents
{
 public class Question : ITrivia
        {
            private string _question;
            private string _answer;
            private List<ITrivia> _options = new List<ITrivia>();

            public string Title()
            {
                return _question;
            }
            
            public string TheAnswer()
            {
                return _answer;
            }
            
            public IIterator CreateIterator()
            {
                return new TriviaIterator(_options);
            }

            public Question(string question, string answer, List<ITrivia> options)
            {
                _question = question;
                _answer = answer;
                _options = options;
            }
        }
}