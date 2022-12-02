using System;
using System.Collections.Generic;
using CompositeAndIterator.Interfaces;

namespace CompositeAndIterator.QuestionComponents
{
    public class Option : ITrivia

    {
        private string _title;
        
        public string Title()
        {
            return _title;
        }
        
        public IIterator CreateIterator()
        {
            throw new NotImplementedException();
        }
        
        public string TheAnswer()
        {
            throw new NotImplementedException();
        }

        public Option(string title)
        {
            _title = title;
        }
        
    }
}