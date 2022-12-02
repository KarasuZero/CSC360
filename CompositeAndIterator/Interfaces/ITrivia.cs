using System.Collections.Generic;

namespace CompositeAndIterator.Interfaces
{
    public interface ITrivia
    {
        string Title();
        string TheAnswer();
        
        IIterator CreateIterator();

        
            // void addOption(string option);
            // void addQuestion(ITrivia question);
            // void addQuestionGroup(ITrivia question);
            // void removeOption(string option);
            // void removeQuestion(ITrivia question);
            // void removeQuestionGroup(ITrivia question);
        
    }
}