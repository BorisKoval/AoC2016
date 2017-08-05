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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Threading;

namespace AoC_2016
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dsTimer = new System.Windows.Threading.DispatcherTimer();
        }
        

        //public string timer()
        //{
        //    string time = "";
            



        //    return time;
        //}


        public double GetDay1_1(string filePath)
        {
            double x = 0, y = 0;
            char[] direction = new char[4] { 'N', 'E', 'S', 'W' };
            char currentDirection = 'N';
            Point p = new Point(x, y);

            StreamReader strReader = new StreamReader(filePath);
            string line = "";

            line = strReader.ReadLine();
            strReader.Close();

            while (line.Length != 0)
            {
                string temp = line.Substring(0, line.IndexOf(','));
                line = line.Remove(0, line.IndexOf(',') + 2);

                if (Convert.ToChar(temp.First()) == 'R')
                {
                    if (Array.IndexOf(direction, currentDirection) == 3)
                        currentDirection = 'N';
                    else
                        currentDirection = direction[Array.IndexOf(direction, currentDirection) + 1];
                }
                else if (Convert.ToChar(temp.First()) == 'L')
                {
                    if (Array.IndexOf(direction, currentDirection) == 0)
                        currentDirection = 'W';
                    else
                        currentDirection = direction[Array.IndexOf(direction, currentDirection) - 1];
                }
                temp = temp.Remove(0, 1);

                switch (currentDirection)
                {
                    case 'N':
                        p.Y += Convert.ToDouble(temp);
                        break;
                    case 'S':
                        p.Y -= Convert.ToDouble(temp);
                        break;
                    case 'E':
                        p.X += Convert.ToDouble(temp);
                        break;
                    case 'W':
                        p.X -= Convert.ToDouble(temp);
                        break;
                    default:
                        break;
                }
            }
            return p.X + p.Y;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBoxDay1_1Answer.Text = GetDay1_1(Convert.ToString(textBoxDay1_1Path.Text)).ToString();
        }

        public int GetDay2_1(string filePath)
        {
            int[,] keypad = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            string code = "";

            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            
            int i = 1, j = 1;
            while ((line = strReader.ReadLine()) != null)
            {
                while (line.Length != 0) //[строка, столбец]
                {
                    if (Convert.ToChar(line.Substring(0, 1)) == 'U')
                    {
                        try
                        {
                            keypad[--i, j].ToString();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            i++;
                        }
                    }
                    else if (Convert.ToChar(line.Substring(0, 1)) == 'R')
                    {
                        try
                        {
                            keypad[i, ++j].ToString();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            j--;
                        }
                    }
                    else if (Convert.ToChar(line.Substring(0, 1)) == 'D')
                    {
                        try
                        {
                            keypad[++i, j].ToString();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            i--;
                        }
                    }
                    else if (Convert.ToChar(line.Substring(0, 1)) == 'L')
                    {
                        try
                        {
                            keypad[i, --j].ToString();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            j++;
                        }
                    }
                    line = line.Remove(0, 1);
                }
                code += keypad[i, j].ToString();
            }
            strReader.Close();

            return Convert.ToInt32(code);
        }

        public string GetDay2_2(string filePath)
        {
            char[,] keypad = new char[,] { { '0', '0', '1', '0', '0' }, { '0', '2', '3', '4', '0' }, { '5', '6', '7', '8', '9' }, { '0', 'A', 'B', 'C', '0' }, { '0', '0', 'D', '0', '0' } };
            string code = "";

            StreamReader strReader = new StreamReader(filePath);
            string line = "";

            int i = 2, j = 0;
            while ((line = strReader.ReadLine()) != null)
            {
                while (line.Length != 0) //[строка, столбец]
                {
                    if (Convert.ToChar(line.Substring(0, 1)) == 'U')
                    {
                        try
                        {
                            if (keypad[--i, j] == '0')
                            {
                                i++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            i++;
                        }
                    }
                    else if (Convert.ToChar(line.Substring(0, 1)) == 'R')
                    {
                        try
                        {
                            if (keypad[i, ++j] == '0')
                            {
                                j--;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            j--;
                        }
                    }
                    else if (Convert.ToChar(line.Substring(0, 1)) == 'D')
                    {
                        try
                        {
                            if (keypad[++i, j] == '0')
                            {
                                i--;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            i--;
                        }
                    }
                    else if (Convert.ToChar(line.Substring(0, 1)) == 'L')
                    {
                        try
                        {
                            if (keypad[i, --j] == '0')
                            {
                                j++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            j++;
                        }
                    }
                    line = line.Remove(0, 1);
                }
                code += keypad[i,j].ToString();
            }
            strReader.Close();

            return code;
        }

        public int GetDay3_1(string filePath)
        {
            int count = 0;
            Regex reg = new Regex(@"(\d+)");
            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            int[] triangle = new int[3];
            while ((line = strReader.ReadLine()) != null)
            {
                triangle[0] = Convert.ToInt32(reg.Matches(line)[0].Value);
                triangle[1] = Convert.ToInt32(reg.Matches(line)[1].Value);
                triangle[2] = Convert.ToInt32(reg.Matches(line)[2].Value);
                Array.Sort(triangle);
                if ((triangle[0] + triangle[1]) > triangle[2])
                    count++;
            }
            return count;
        }

        public int GetDay3_2(string filePath)
        {
            int count = 0;
            Regex reg = new Regex(@"(\d+)");
            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            int[,] triangle = new int[100000000000,3];
            int[] temp = new int[3];
            int n = 0;
            while ((line = strReader.ReadLine()) != null)
            {                
                triangle[n++, 0] = Convert.ToInt32(reg.Matches(line)[0].Value);
                triangle[n, 1] = Convert.ToInt32(reg.Matches(line)[1].Value);
                triangle[n, 2] = Convert.ToInt32(reg.Matches(line)[2].Value);
            }

            for (long i = 0; i <= (triangle.LongLength / 3); i++)
            {

            }



            return count;
        }

        public int GetDay4_1(string filePath)
        {
            int IDsum = 0;
            StreamReader strReader = new StreamReader(filePath);
            string line = "";

            SortedDictionary<char, int> room = new SortedDictionary<char, int>();
            
            while ((line = strReader.ReadLine()) != null)
            {
                room.Clear();

                foreach (char ch in line)
                {
                    if (ch == '-')
                        continue;
                    else if (Char.IsDigit(ch))
                        break;
                    if (!room.ContainsKey(ch))
                        room.Add(ch, 1);
                    else
                        room[ch]++;
                }

                var sortRoom = from pair in room
                               orderby pair.Value descending
                               select pair;

                string temp="";
                foreach (KeyValuePair<char, int> pair in sortRoom)
                {
                    temp += pair.Key;
                    if (temp.Length == 5)
                        break;
                }
                
                if (temp == line.Substring(line.Length - 6, 5))
                    IDsum += Convert.ToInt32(line.Substring(line.Length - 10, 3));
                }
            return IDsum;
        }

        public string GetDay4_2(string filePath)
        {
            string answer = "";
            StreamReader strReader = new StreamReader(filePath);
            string line = "";

            while ((line = strReader.ReadLine()) != null)
            {
                string result = "";
                foreach (char ch in line)
                {
                    if (Char.IsDigit(ch))
                        break;

                    if (ch == '-')
                    {
                        result += ' ';
                        continue;
                    }
                    result += (char)((ch - 97 + Convert.ToInt16(line.Substring(line.Length - 10, 3))) % 26 + 97);
                }
                answer += result + line.Substring(line.Length - 10, 3)+"\r\n";
            }
            return answer;
        }

        public string GetDay5_1(string filePath)
        {
            string pass = "";
            StreamReader strReader = new StreamReader(filePath);
            string line = strReader.ReadLine();
            strReader.Close();

            int addition = 0;
            string hash ="";

            while (pass.Length != 8)
            {
                while (hash == "" || hash.Substring(0, 5) != "00000")
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        hash = GetMd5Hash(md5Hash, line + addition);
                    }
                    
                    addition++;

                }
                pass += hash.Substring(5, 1);

                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, line + addition);
                }
            }           

            return String.Format("HASH: {0} || str: {1}", hash, pass);
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string GetDay6_1(string filePath)
        {
            string message = "";
            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            Dictionary<char, int>[] messageDict = new Dictionary<char, int>[8]
            {
                new Dictionary<char, int>(),
                new Dictionary<char, int>(),
                new Dictionary<char, int>(),
                new Dictionary<char, int>(),
                new Dictionary<char, int>(),
                new Dictionary<char, int>(),                
                new Dictionary<char, int>(),                
                new Dictionary<char, int>()
            };           

            while ((line = strReader.ReadLine()) != null)
            {
                for (int i = 0; i <= 7; i++ )
                {
                    if (!messageDict[i].ContainsKey(Convert.ToChar(line.Substring(i,1))))
                        messageDict[i].Add(Convert.ToChar(line.Substring(i, 1)), 1);
                    else
                        messageDict[i][Convert.ToChar(line.Substring(i, 1))]++;
                }
             }
            strReader.Close();
            for (int i = 0; i <= 7; i++)
            {
                message += messageDict[i].First(x => x.Value == messageDict[i].Values.Max()).Key;
            }
            return message;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBoxDay2_1Answer.Text = GetDay2_1(Convert.ToString(textBoxDay2_1Path.Text)).ToString();
        }

        private void buttonDay2_2_Click(object sender, RoutedEventArgs e)
        {
            textBoxDay2_2Answer.Text = GetDay2_2(Convert.ToString(textBoxDay2_2Path.Text));
        }

        private void buttonDay3_1_Click(object sender, RoutedEventArgs e)
        {
            textBoxDay3_1Answer.Text = GetDay3_1(Convert.ToString(textBoxDay3_1Path.Text)).ToString();
        }

        private void buttonDay4_1_Click(object sender, RoutedEventArgs e)
        {
            textBoxDay4_1Answer.Text = GetDay4_1(Convert.ToString(textBoxDay4_1Path.Text)).ToString();
        }

        private void buttonDay4_2_Click(object sender, RoutedEventArgs e)
        {
            textBoxDay4_2Answer.Text = GetDay4_2(Convert.ToString(textBoxDay4_2Path.Text)).ToString();
        }

        private void buttonPathSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                textBoxAnyDayPath.Text = openFileDialog.FileName;
        }

        private void buttonAnyDay_Click(object sender, RoutedEventArgs e)
        {
            //switch (RadioButton.IsCheckedProperty.

            if (radioButtonDay5_1.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay5_1(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            //else if (radioButtonDay5_2.IsChecked.Value)
            //{
            //    textBoxAnyDayAnswer.Text = GetDay5_2(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            //}
            else if (radioButtonDay6_1.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay6_1(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
        }


    }
}
