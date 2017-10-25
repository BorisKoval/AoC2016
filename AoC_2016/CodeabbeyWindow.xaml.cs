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
            else if (radioButton13.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task13(textBoxInput.Text)).ToString();
            else if (radioButton43.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task43(textBoxInput.Text)).ToString();
            else if (radioButton9.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task9(textBoxInput.Text)).ToString();
            else if (radioButton16.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task16(textBoxInput.Text)).ToString();
            else if (radioButton17.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task17(textBoxInput.Text)).ToString();
            else if (radioButton30.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task30(textBoxInput.Text)).ToString();
            else if (radioButton21.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task21(textBoxInput.Text)).ToString();
            else if (radioButton48.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task48(textBoxInput.Text)).ToString();
            else if (radioButton12.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task12(textBoxInput.Text)).ToString();
            else if (radioButton10.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task10(textBoxInput.Text)).ToString();
            else if (radioButton14.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task14(textBoxInput.Text)).ToString();
            else if (radioButton27.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task27(textBoxInput.Text)).ToString();
            else if (radioButton26.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task26(textBoxInput.Text)).ToString();
            else if (radioButton29.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task29(textBoxInput.Text)).ToString();
            else if (radioButton23.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task23(textBoxInput.Text)).ToString();
            else if (radioButton18.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task18(textBoxInput.Text)).ToString();
            else if (radioButton24.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task24(textBoxInput.Text)).ToString();
            else if (radioButton67.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task67(textBoxInput.Text)).ToString();
            else if (radioButton50.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task50(textBoxInput.Text)).ToString();
            else if (radioButton31.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task31(textBoxInput.Text)).ToString();
            else if (radioButton57.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task57(textBoxInput.Text)).ToString();
            else if (radioButton52.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task52(textBoxInput.Text)).ToString();
            else if (radioButton68.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task68(textBoxInput.Text)).ToString();
            else if (radioButton32.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task32(textBoxInput.Text)).ToString();
            else if (radioButton25.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task25(textBoxInput.Text)).ToString();
            else if (radioButton44.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task44(textBoxInput.Text)).ToString();
            else if (radioButton81.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task81(textBoxInput.Text)).ToString();
            else if (radioButton19.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task19(textBoxInput.Text)).ToString();
            else if (radioButton47.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task47(textBoxInput.Text)).ToString();
            else if (radioButton55.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task55(textBoxInput.Text)).ToString();
            else if (radioButton104.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task104(textBoxInput.Text)).ToString();
            else if (radioButton49.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task49(textBoxInput.Text)).ToString();
            else if (radioButton61.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task61(textBoxInput.Text)).ToString();
            else if (radioButton58.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task58(textBoxInput.Text)).ToString();
            else if (radioButton94.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task94(textBoxInput.Text)).ToString();
            else if (radioButton59.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task59(textBoxInput.Text)).ToString();
            else if (radioButton128.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task128(textBoxInput.Text)).ToString();
            else if (radioButton42.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task42(textBoxInput.Text)).ToString();
            else if (radioButton38.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task38(textBoxInput.Text)).ToString();
            else if (radioButton34.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task34(textBoxInput.Text)).ToString();
            else if (radioButton120.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task120(textBoxInput.Text)).ToString();
            else if (radioButton53.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task53(textBoxInput.Text)).ToString();
            else if (radioButton45.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task45(textBoxInput.Text)).ToString();
            else if (radioButton63.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task63(textBoxInput.Text)).ToString();
            else if (radioButton37.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task37(textBoxInput.Text)).ToString();
            else if (radioButton46.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task46(textBoxInput.Text)).ToString();
            else if (radioButton72.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task72(textBoxInput.Text)).ToString();
            else if (radioButton69.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task69(textBoxInput.Text)).ToString();
            else if (radioButton39.IsChecked == true)
                textBoxAnswer.Text = (Codeabbey.CdbTasks.task39(textBoxInput.Text)).ToString();
        }
    }
}
