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
using AoC_2016.Codeabbey;

namespace AoC_2016
{
    /// <summary>
    /// Логика взаимодействия для CodeabbeyWindow.xaml
    /// </summary>
    public partial class CodeabbeyWindow : Window
    {
        public CodeabbeyWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.taskOne(textBoxInput.Text)).ToString();
            else if (radioButton2.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.taskTwo(textBoxInput.Text)).ToString();
            else if (radioButton3.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.taskThree(textBoxInput.Text)).ToString();
            else if (radioButton4.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.taskFour(textBoxInput.Text)).ToString();
            else if (radioButton5.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.taskFive(textBoxInput.Text)).ToString();
            else if (radioButton15.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task15(textBoxInput.Text)).ToString();
            else if (radioButton6.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task6(textBoxInput.Text)).ToString();
            else if (radioButton7.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task7(textBoxInput.Text)).ToString();
            else if (radioButton20.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task20(textBoxInput.Text)).ToString();
            else if (radioButton33.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task33(textBoxInput.Text)).ToString();
            else if (radioButton41.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task41(textBoxInput.Text)).ToString();
            else if (radioButton28.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task28(textBoxInput.Text)).ToString();
            else if (radioButton8.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task8(textBoxInput.Text)).ToString();
        }
    }
}
