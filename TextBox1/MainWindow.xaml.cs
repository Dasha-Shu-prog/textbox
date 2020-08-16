using System;
using System.Windows;
using System.Windows.Controls;


namespace TextBox1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int value = 0;
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 350;

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

            decrement.IsEnabled = true;
            increment.IsEnabled = true;
            if (value == MIN_VALUE)
            {
                decrement.IsEnabled = false;
            } else if (value == MAX_VALUE) {
                increment.IsEnabled = false;
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

    }
}
