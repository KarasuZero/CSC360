using System;
using System.Collections.Generic;
using CompositeAndIterator.Interfaces;
using CompositeAndIterator.QuestionComponents;

namespace CompositeAndIterator
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            ITrivia option1 = new Option("Paris");
            ITrivia option2 = new Option("London");
            ITrivia option3 = new Option("New York");
            ITrivia option4 = new Option("Tokyo");
            ITrivia option5 = new Option("1");
            ITrivia option6 = new Option("2");
            ITrivia option7 = new Option("3");
            ITrivia option8 = new Option("4");

            ITrivia question1 = new Question("What is the Capital of Japan?", "Tokyo",new List<ITrivia> {option1, option2, option3, option4});
            ITrivia question2 = new Question("What is the Capital of France?", "Paris",new List<ITrivia> {option1, option2, option3, option4});
            
            ITrivia question3 = new Question("What is 1 + 1 = ?", "2",new List<ITrivia> {option5, option6, option7, option8});
            ITrivia question4 = new Question("What is 1 + 2 = ?", "3",new List<ITrivia> {option5, option6, option7, option8});
            
            ITrivia SSSection = new Section("Capital Quiz", new List<ITrivia> {question1, question2});
            ITrivia MSection = new Section("Math Quiz", new List<ITrivia> {question3, question4});
            
            ITrivia quiz = new Section("Trivia", new List<ITrivia> {SSSection, MSection});

            IIterator TriviaIterator = quiz.CreateIterator();
            
            Console.WriteLine("-----------------Starting the Quiz------------------\n\n");
            // Start at the beginning of the quiz
            TriviaIterator.First(); 
         
            //while the trivia iterator is not done
            while (!TriviaIterator.IsDone())
            {
                //print the current trivia title
                Console.WriteLine(TriviaIterator.Current().Title());
                
                //creating a iterator for the question
                IIterator questionIterator = TriviaIterator.Current().CreateIterator();
                questionIterator.First();//start at the beginning of the question list
                
                //while the question iterator is not done
                while (!questionIterator.IsDone())
                {
                    //print the current question title
                    Console.WriteLine("Question: " + questionIterator.Current().Title() + "\n Options: \n");
                    IIterator optionIterator = questionIterator.Current().CreateIterator();
                    
                    optionIterator.First();//start at the beginning of the option
                    
                    //while the option iterator is not done
                    while (!optionIterator.IsDone())
                    {
                        Console.WriteLine(optionIterator.Current().Title());
                        optionIterator.Next();
                    }
                    //getting the answer for current quesiton
                    string _answer = questionIterator.Current().TheAnswer();
                    //Console.WriteLine("_answer = " + _answer);
                    
                    //getting the user input
                    Console.WriteLine("\nEnter your answer: ");
                    string userInput = Console.ReadLine();
                    
                    //checking if the user input is correct
                    if (userInput.ToLower().Equals(_answer.ToLower()))
                    {
                        Console.WriteLine("\n Correct! \n");
                    }
                    else
                    {
                        Console.WriteLine("\n Incorrect! \n The correct answer is: " + _answer + "\n");
                    }
                    
                    //next question
                    questionIterator.Next();
                }
                TriviaIterator.Next();
            }
            
            Console.WriteLine("\n\n-------------------------Ending the Quiz----------------------------");
        }
    }
}
