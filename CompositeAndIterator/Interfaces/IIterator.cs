namespace CompositeAndIterator.Interfaces
{
    public interface IIterator
        {
            void First(); // setting current to first element
            ITrivia Current(); // getting current element
            ITrivia Next(); // getting next element
            bool IsDone();
        }
}