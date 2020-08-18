using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Key = System.Windows.Input.Key;
namespace TextBox1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int value = 0;
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 999;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;

            if (textbox.Text.Length == 0)
                value = MIN_VALUE;

            if (Int32.TryParse(textbox.Text, out result))
            {
                validateData(ref result);
                value = result;
            }
            textbox.Text = value.ToString();

            if (value == MIN_VALUE)
                decrement.IsEnabled = false;

            else if (value == MAX_VALUE)
                increment.IsEnabled = false;

            else
            {
                decrement.IsEnabled = true;
                increment.IsEnabled = true;
            }
        }

        private void validateData(ref int value)
        {
            if (value > MAX_VALUE)
            {
                value = MAX_VALUE;
            }
            if (value < MIN_VALUE)
            {
                value = MIN_VALUE;
            }
        }
        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            int newValue = --value;
            validateData(ref newValue);
            textbox.Text = value.ToString();
        }
        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            int newValue = ++value;
            validateData(ref newValue);
            textbox.Text = value.ToString();
        }
        private void textbox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            textbox.Focusable = true;
        }
        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Right || e.Key == Key.Up)
            {
                 Increment_Click(sender, null);
                 increment.Focusable = true;
            }
            else if (e.Key == Key.Left || e.Key == Key.Down)
            {
                Decrement_Click(sender, null);
                decrement.Focusable = true;
            } 
        }      
        private void textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.Key)
            {
                case Key.Right:
                    {
                        Increment_Click(sender, null);
                        break;
                    }
                case Key.Left:
                    {
                        Decrement_Click(sender, null);
                        break;
                    }
                case Key.Up:
                    {
                        Increment_Click(sender, null);
                        break;
                    }
                case Key.Down:
                    {
                        Decrement_Click(sender, null);
                        break;
                    }
            }

        }
    }    
}
