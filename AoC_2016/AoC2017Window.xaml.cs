using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AoC_2016
{
    /// <summary>
    /// Логика взаимодействия для AoC2017Window.xaml
    /// </summary>
    public partial class AoC2017Window : Window
    {
        public AoC2017Window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton1_1.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.AoC2017Tasks.getTask1_1(textBoxInput.Text)).ToString();
            else if (radioButton1_2.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.AoC2017Tasks.getTask1_2(textBoxInput.Text)).ToString();
            else if (radioButton2_1.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.AoC2017Tasks.getTask2_1(textBoxInput.Text)).ToString();
            else if (radioButton2_2.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.AoC2017Tasks.getTask2_2(textBoxInput.Text)).ToString();
        }
    }
}
