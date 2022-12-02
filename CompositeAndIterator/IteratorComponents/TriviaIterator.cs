using System.Collections.Generic;
using CompositeAndIterator.Interfaces;

namespace CompositeAndIterator.IteratorComponents
{
    public class TriviaIterator : IIterator
    {
        private readonly List<ITrivia> _questions;
        private int _current;

        public TriviaIterator(List<ITrivia> theList)
        {
            _questions = theList;
            _current = 0;
        }
        public void First()
        {
            _current = 0;
        }
        
        public ITrivia Current()
        {
            return _questions[_current];
        }
        
        public ITrivia Next()
        {
            return _questions[_current++];
        }       
        
        public bool IsDone()
        {
            return (_current >= _questions.Count);
        }
    }
}