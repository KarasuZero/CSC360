using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Stack _commandStack = new Stack();
  
        private string GetContent(Stack stack)
        {
            string output = "";
            
            foreach (string item in stack)
            {
                output += item + ", ";
            }
            return output;
        }
        
        private void BtUp_OnClick(object sender, RoutedEventArgs e) //row operation
        {
            //TODO handle edge cases
            //move image 1 to the top
            Grid.SetRow(TheImage, Grid.GetRow(TheImage) - 1);
            _commandStack.Push("Up");

            OutPutTB.Text = GetContent(_commandStack);
        }

        private void BtDown_OnClick(object sender, RoutedEventArgs e) //row operation
        {
            //TODO handle edge cases
            
            Grid.SetRow(TheImage, Grid.GetRow(TheImage) + 1);
            _commandStack.Push("Down");
            
            OutPutTB.Text = GetContent(_commandStack);
        }
        
        private void BtLeft_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO handle edge cases
            
            Grid.SetColumn(TheImage, Grid.GetColumn(TheImage) - 1);
            _commandStack.Push("Left");
            
            OutPutTB.Text = GetContent(_commandStack);
        }
        
        private void BtRight_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO handle edge cases
            
            Grid.SetColumn(TheImage, Grid.GetColumn(TheImage) + 1);
            _commandStack.Push("Right");
            
            OutPutTB.Text = GetContent(_commandStack);
        }

        private void BtRe_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO implement undo
            throw new NotImplementedException();
        }
        
        private void BtBG_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO handle edge cases
            
            TheImage.Source = new BitmapImage(new Uri("C:\\Users\\kento\\RiderProjects\\CSC360\\katanaZero.jpg"));
            _commandStack.Push("BGChange");
            
            OutPutTB.Text = GetContent(_commandStack);
        }
    }
}