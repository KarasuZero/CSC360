using System;
using System.Collections.Generic;
using CompositeAndIterator.Interfaces;
using CompositeAndIterator.IteratorComponents;

namespace CompositeAndIterator.QuestionComponents
{
    //Question Class - Composite - Collection of Questions
            public class Section : ITrivia
            {
                private List<ITrivia>_questions = new List<ITrivia>();
                private string _title;

                public string Title()
                {
                    return _title;
                } 
                public IIterator CreateIterator()
                {
                    return new TriviaIterator(_questions);
                }
                
                public string TheAnswer()
                {
                    throw new NotImplementedException();
                }

                public Section(string title, List<ITrivia> questions)
                {
                    _title = title;
                    _questions = questions;
                }
            }
}