using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Command_Pattern
{
    /// <summary>s
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetContent(Stack stack)
        {
            string output = "";
            
            foreach (string item in stack)
            {
                output += item + ", ";
            }
            return output;
        }
        
        private Stack _commandStack = new Stack();
        
        private void BtUp_OnClick(object sender, RoutedEventArgs e) //row operation
        {
            MoveUpCommand moveUpCommand = new MoveUpCommand();

            if (moveUpCommand.IsExecutable(TheImage))
            {
                moveUpCommand.Execute(TheImage);
                _commandStack.Push("Up");
                
                OutPutTB.Text = GetContent(_commandStack);
            }
            else
            {
                OutPutTB.Text = "Can't move up";
            }
            
        }

        private void BtDown_OnClick(object sender, RoutedEventArgs e) //row operation
        {
           MoveDownCommand moveDownCommand = new MoveDownCommand();

           if (moveDownCommand.IsExecutable(TheImage))
           {
               moveDownCommand.Execute(TheImage);
               _commandStack.Push("Down");
               
               OutPutTB.Text = GetContent(_commandStack);
           }
           else
           {
               OutPutTB.Text = "Can't move down";
           }
        }
        
        private void BtLeft_OnClick(object sender, RoutedEventArgs e)
        {
            MoveLeftCommand moveLeftCommand = new MoveLeftCommand();
            
            if (moveLeftCommand.IsExecutable(TheImage))
            {
                moveLeftCommand.Execute(TheImage);
                _commandStack.Push("Left");
                
                OutPutTB.Text = GetContent(_commandStack);
            }
            else
            {
                OutPutTB.Text = "Can't move Left";
            }
            
        }
        
        private void BtRight_OnClick(object sender, RoutedEventArgs e)
        {
            MoveRightCommand moveRightCommand = new MoveRightCommand();
            
            if (moveRightCommand.IsExecutable(TheImage))
            {
                moveRightCommand.Execute(TheImage);
                _commandStack.Push("Right");
                
                OutPutTB.Text = GetContent(_commandStack);
            }
            else
            {
                OutPutTB.Text = "Can't move down";
            }
        }

        private void BtRe_OnClick(object sender, RoutedEventArgs e)
        {
            if (_commandStack.Count > 0)
            {
                if (_commandStack.Peek().Equals("Up"))
                {
                    MoveUpCommand moveUpCommand = new MoveUpCommand();

                    if (moveUpCommand.IsUndoable(TheImage))
                    {
                        moveUpCommand.Undo(TheImage);
                        _commandStack.Pop();
                    }
                }
                else if (_commandStack.Peek().Equals("Down"))
                {
                    MoveDownCommand moveDownCommand = new MoveDownCommand();
                    
                    if (moveDownCommand.IsUndoable(TheImage))
                    {
                        moveDownCommand.Undo(TheImage);
                        _commandStack.Pop();
                    }
                }
                else if (_commandStack.Peek().Equals("Left"))
                {
                    MoveLeftCommand moveLeftCommand = new MoveLeftCommand();
                    
                    if (moveLeftCommand.IsUndoable(TheImage))
                    {
                        moveLeftCommand.Undo(TheImage);
                        _commandStack.Pop();
                    }
                }
                else if (_commandStack.Peek().Equals("Right"))
                {
                    MoveRightCommand moveRightCommand = new MoveRightCommand();
                    
                    if (moveRightCommand.IsUndoable(TheImage))
                    {
                        moveRightCommand.Undo(TheImage);
                        _commandStack.Pop();
                    }
                }
                else if (_commandStack.Peek().Equals("Change"))
                {
                    ChangeImageCommand changeImageCommand = new ChangeImageCommand();
                    
                    if (changeImageCommand.IsUndoable(TheImage,image1))
                    {
                        changeImageCommand.Undo(TheImage);
                        _commandStack.Pop();
                    }
                }
                    
                OutPutTB.Text = GetContent(_commandStack);
            }else
            {
                OutPutTB.Text = "No more commands to undo";
            }
        }
        
        private void BtBG_OnClick(object sender, RoutedEventArgs e)
        {
            ChangeImageCommand changeImageCommand = new ChangeImageCommand();
            
            if (changeImageCommand.IsExecutable(TheImage,image2))
            {
                changeImageCommand.Execute(TheImage);
                _commandStack.Push("Change");
            }
            else
            {
                OutPutTB.Text = "Can't change image";
            }
            
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
        bool isExecutable();
        bool isUndoable();
    }

    class Command : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
        
        public bool isExecutable()
        {
            throw new NotImplementedException();
        }
        
        public bool isUndoable()
        {
            throw new NotImplementedException();
        }
    }
    
    class MoveUpCommand : Command
    {
        //move the image 1 up the row
        public bool IsExecutable(Image image)
        {
            if (Grid.GetRow(image) >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move up");
                return false;
            }
        }
        
        public bool IsUndoable(Image image)
        {
            if (Grid.GetRow(image) <= 8)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move down");
                return false;
            }
        }

        public void Execute(Image image)
        {
            if (Grid.GetRow(image) >= 2)
            {
                Grid.SetRow(image, Grid.GetRow(image) - 1);
            }
            else
            {
                Console.WriteLine("Can't move up");
            }
        }

        public void Undo(Image image)
        {
            if (Grid.GetRow(image) <= 8)
            {
                Grid.SetRow(image, Grid.GetRow(image) + 1);
            }
            else
            {
                Console.WriteLine("Can't move down");
            }
        }

    }
    
    class MoveDownCommand : Command
    {
        //move the image 1 down the row
        public bool IsExecutable(Image image)
        {
            if (Grid.GetRow(image) <= 8)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move down");
                return false;
            }
        }
        
        public bool IsUndoable(Image image)
        {
            if (Grid.GetRow(image) >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move up");
                return false;
            }
        }

        public void Execute(Image image)
        {
            if (Grid.GetRow(image) <= 8)
            {
                Grid.SetRow(image, Grid.GetRow(image) + 1);
            }
            else
            {
                Console.WriteLine("Can't move down");
            }
        }

        public void Undo(Image image)
        {
            if (Grid.GetRow(image) >= 2)
            {
                Grid.SetRow(image, Grid.GetRow(image) - 1);
            }
            else
            {
                Console.WriteLine("Can't move up");
            }
        }
     
    }
    
    class MoveLeftCommand : Command
    {
        //move the image 1 up the column
        public bool IsExecutable(Image image)
        {
            if (Grid.GetColumn(image) >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move up");
                return false;
            }
        }
        
        public bool IsUndoable(Image image)
        {
            if (Grid.GetColumn(image) <= 8)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move down");
                return false;
            }
        }
    
        public void Execute(Image image)
        {
            if (Grid.GetColumn(image) >= 2)
            {
                Grid.SetColumn(image, Grid.GetColumn(image) - 1);
            }
            else
            {
                Console.WriteLine("Can't move left");
            }
        }
    
        public void Undo(Image image)
        {
            if (Grid.GetColumn(image) <= 8)
            {
                Grid.SetColumn(image, Grid.GetColumn(image) + 1);
            }
            else
            {
                Console.WriteLine("Can't move right");
            }
        }
     
    }
    
    class MoveRightCommand : Command
    {
        //move the image 1 down the row
        public bool IsExecutable(Image image)
        {
            if (Grid.GetColumn(image) <= 8)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move right");
                return false;
            }
        }
        
        public bool IsUndoable(Image image)
        {
            if (Grid.GetColumn(image) >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't move left");
                return false;
            }
        }
    
        public void Execute(Image image)
        {
            if (Grid.GetColumn(image) <= 8)
            {
                Grid.SetColumn(image, Grid.GetColumn(image) + 1);
            }
            else
            {
                Console.WriteLine("Can't move right");
            }
        }
    
        public void Undo(Image image)
        {
            if (Grid.GetColumn(image) >= 2)
            {
                Grid.SetColumn(image, Grid.GetColumn(image) - 1);
            }
            else
            {
                Console.WriteLine("Can't move left");
            }
        }
     
    }
    
    class ChangeImageCommand : Command
    {
        public void Execute(Image image)
        {
            image.Source = new BitmapImage(new Uri("C:\\Users\\kento\\RiderProjects\\CSC360\\katanaZero.jpg"));
        }

        public void Undo(Image image)
        {
            image.Source = new BitmapImage(new Uri("C:\\Users\\kento\\RiderProjects\\CSC360\\anyatestmeme.png"));
        }
        
        public bool IsExecutable(Image image, Image katanazero)
        {
            string currentImage = image.Source.ToString();
            string katanaImage = katanazero.Source.ToString();
            
            
            if (currentImage != katanaImage)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't change image");
                return false;
            }
        }
        
        public bool IsUndoable(Image image, Image anyameme)
        {
            string currentImage = image.Source.ToString();
            string anyaImage = anyameme.Source.ToString();
            
            
            if (currentImage != anyaImage)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Can't change image");
                return false;
            }
        }
    }
}