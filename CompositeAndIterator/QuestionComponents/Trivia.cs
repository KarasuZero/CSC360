using System;
using System.Collections.Generic;
using CompositeAndIterator.Interfaces;
using CompositeAndIterator.IteratorComponents;

namespace CompositeAndIterator.QuestionComponents
{
// "Composite"
    public class Trivia : ITrivia
    {
        private string _quizTitle;
        private List<ITrivia>_sections = new List<ITrivia>();
        
        public string Title()
        {
           return _quizTitle;
        }
        public IIterator CreateIterator()
        {
            return new TriviaIterator(_sections);
        }
        
        public string TheAnswer()
        {
            throw new NotImplementedException();
        }
        
        public Trivia(string quizTitle, List<ITrivia>sections)
        {
            _quizTitle = quizTitle;
            _sections = sections;
        }
    }
}
