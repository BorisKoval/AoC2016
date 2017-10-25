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
using AoC_2016.Codeabbey;

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
        }

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
                code += keypad[i, j].ToString();
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
            int[,] triangle = new int[100000000000, 3];
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

                string temp = "";
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
                answer += result + line.Substring(line.Length - 10, 3) + "\r\n";
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
            string hash = "";

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
                for (int i = 0; i <= 7; i++)
                {
                    if (!messageDict[i].ContainsKey(Convert.ToChar(line.Substring(i, 1))))
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

        public string GetDay6_2(string filePath)
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
                for (int i = 0; i <= 7; i++)
                {
                    if (!messageDict[i].ContainsKey(Convert.ToChar(line.Substring(i, 1))))
                        messageDict[i].Add(Convert.ToChar(line.Substring(i, 1)), 1);
                    else
                        messageDict[i][Convert.ToChar(line.Substring(i, 1))]++;
                }
            }
            strReader.Close();
            for (int i = 0; i <= 7; i++)
            {
                message += messageDict[i].First(x => x.Value == messageDict[i].Values.Min()).Key;
            }
            return message;
        }

        public int GetDay7_1(string filePath)
        {
            int ips = 0;
            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            Regex abbaPatrn = new Regex(@"(\w)((?!\1)\w)\2\1");
            Regex abbaAntiPtrn = new Regex(@"\[\w*(\w)((?!\1)\w)\2\1\w*\]");

            while ((line = strReader.ReadLine()) != null)
            {
                if (abbaAntiPtrn.IsMatch(line))
                    continue;
                else if (abbaPatrn.IsMatch(line))
                    ips++;
            }
            strReader.Close();
            return ips;
        }

        public int GetDay8_1(string filePath)
        {
            int pixels = 0;
            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            int[,] screen = new int[6, 50];
            int[,] tempScreen = new int[6, 50];
            Regex rect = new Regex(@"rect (\d*)x(\d*)");
            Regex rotateX = new Regex(@"rotate column x=(\d*) by (\d*)");
            Regex rotateY = new Regex(@"rotate row y=(\d*) by (\d*)");

            while ((line = strReader.ReadLine()) != null)
            {
                if (rect.IsMatch(line))
                {
                    int maxI = Convert.ToInt16(rect.Match(line).Groups[2].Value);
                    int maxJ = Convert.ToInt16(rect.Match(line).Groups[1].Value);
                    for (int i = 0; i < maxI; i++)
                    {
                        for (int j = 0; j < maxJ; j++)
                        {
                            screen[i, j] = 1;
                        }
                    }
                }
                else if (rotateX.IsMatch(line))
                {
                    Array.Copy(screen, tempScreen, screen.Length);
                    int temp = Convert.ToInt16(rotateX.Match(line).Groups[1].Value);
                    for (int i = 0; i < 6; i++)
                    {
                        tempScreen[(i + Convert.ToInt16(rotateX.Match(line).Groups[2].Value)) % 6, temp] = screen[i, temp];
                    }
                    Array.Copy(tempScreen, screen, screen.Length);
                }
                else if (rotateY.IsMatch(line))
                {
                    Array.Copy(screen, tempScreen, screen.Length);
                    int temp = Convert.ToInt16(rotateY.Match(line).Groups[1].Value);
                    for (int j = 0; j < 50; j++)
                    {
                        tempScreen[temp, (j + Convert.ToInt16(rotateY.Match(line).Groups[2].Value)) % 50] = screen[temp, j];
                    }
                    Array.Copy(tempScreen, screen, screen.Length);
                }
            }
            strReader.Close();

            foreach (int num in screen)
            {
                if (num == 1) pixels++;
            }
            return pixels;
        }

        public int GetDay8_2(string filePath)
        {
            int pixels = 0;
            StreamReader strReader = new StreamReader(filePath);
            string line = "";
            int[,] screen = new int[6, 50];
            int[,] tempScreen = new int[6, 50];
            Regex rect = new Regex(@"rect (\d*)x(\d*)");
            Regex rotateX = new Regex(@"rotate column x=(\d*) by (\d*)");
            Regex rotateY = new Regex(@"rotate row y=(\d*) by (\d*)");

            while ((line = strReader.ReadLine()) != null)
            {
                if (rect.IsMatch(line))
                {
                    int maxI = Convert.ToInt16(rect.Match(line).Groups[2].Value);
                    int maxJ = Convert.ToInt16(rect.Match(line).Groups[1].Value);
                    for (int i = 0; i < maxI; i++)
                    {
                        for (int j = 0; j < maxJ; j++)
                        {
                            screen[i, j] = 1;
                        }
                    }
                }
                else if (rotateX.IsMatch(line))
                {
                    Array.Copy(screen, tempScreen, screen.Length);
                    int temp = Convert.ToInt16(rotateX.Match(line).Groups[1].Value);

                    for (int i = 0; i < 6; i++)
                    {
                        tempScreen[(i + Convert.ToInt16(rotateX.Match(line).Groups[2].Value)) % 6, temp] = screen[i, temp];
                    }
                    Array.Copy(tempScreen, screen, screen.Length);
                }
                else if (rotateY.IsMatch(line))
                {
                    Array.Copy(screen, tempScreen, screen.Length);
                    int temp = Convert.ToInt16(rotateY.Match(line).Groups[1].Value);
                    for (int j = 0; j < 50; j++)
                    {
                        tempScreen[temp, (j + Convert.ToInt16(rotateY.Match(line).Groups[2].Value)) % 50] = screen[temp, j];
                    }
                    Array.Copy(tempScreen, screen, screen.Length);
                }
            }
            strReader.Close();

            drawArray(screen, 6, 50);
            foreach (int num in screen)
            {
                if (num == 1) pixels++;
            }
            return pixels;
        }

        public void drawArray(int[,] arr, int I, int J)
        {
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    textBoxDay4_2Answer.Text += arr[i, j] + "|";
                }
                textBoxDay4_2Answer.Text += "\r\n";
            }
            textBoxDay4_2Answer.Text += "-------------------------------------------------------\r\n";
        }

        public int GetDay9_1(string filePath)
        {
            int fileLength = 0;
            StreamReader strReader = new StreamReader(filePath);
            string line = strReader.ReadToEnd();
            strReader.Close();
            Regex delPatrn = new Regex(@"^\((\d*)x(\d*)\)");

            while (line != "")
            {
                if (Char.IsLetter(line[0]))
                {
                    fileLength++;
                    line = line.Remove(0, 1);
                }
                else if (delPatrn.IsMatch(line))
                {
                    int a = Convert.ToInt32(delPatrn.Match(line).Groups[1].Value);
                    int b = Convert.ToInt32(delPatrn.Match(line).Groups[2].Value);
                    fileLength += a * b;
                    line = line.Remove(0, a + delPatrn.Match(line).Length);
                }
            }

            return fileLength;
        }

        public int GetDay10_1(string filePath)
        {
            int botNumber = 0;
            int[,] bots = new int[500, 2];
            StreamReader fileReader = new StreamReader(filePath);
            string input = fileReader.ReadToEnd();
            fileReader.Close();
            Regex valueToBotPtrn = new Regex(@"value (\d+) goes to bot (\d+)");
            Regex botToBotsPtrn =
                new Regex(@"bot (\d+) gives low to bot (\d+) and high to bot (\d+)");
            Regex valueToOutputPtrn =
                new Regex(@"bot (\d+) gives low to output \d+ and high to (bot (\d+)|(output \d+))");

            StringReader strReader = new StringReader(input);
            while (input.Length != 0)
            {
                string command = "";
                if ((command = strReader.ReadLine()) == null)
                {
                    strReader.Close();
                    strReader.Dispose();
                    strReader = new StringReader(input);
                    continue;
                }

                if (valueToBotPtrn.IsMatch(command))
                {
                    bots[Convert.ToInt32(valueToBotPtrn.Match(command).Groups[2].Value), freeBotIndex(bots, Convert.ToInt32(valueToBotPtrn.Match(command).Groups[2].Value))] =
                        Convert.ToInt32(valueToBotPtrn.Match(command).Groups[1].Value);

                    input = input.Replace(command + "\r\n", "");
                }
                else if (botToBotsPtrn.IsMatch(command))
                {
                    int sourceBot = Convert.ToInt32(botToBotsPtrn.Match(command).Groups[1].Value);
                    int targetBot1 = Convert.ToInt32(botToBotsPtrn.Match(command).Groups[2].Value);
                    int targetBot2 = Convert.ToInt32(botToBotsPtrn.Match(command).Groups[3].Value);
                    if (twoSortedNumbers(bots, sourceBot)[0] == -1)
                        continue;

                    if ((bots[sourceBot, 0] == 17 && bots[sourceBot, 1] == 61) ||
                        (bots[sourceBot, 0] == 61 && bots[sourceBot, 1] == 17))
                    {
                        botNumber = sourceBot;
                        break;
                    }
                    bots[targetBot1, freeBotIndex(bots, targetBot1)] =
                        twoSortedNumbers(bots, sourceBot)[0];
                    bots[targetBot2, freeBotIndex(bots, targetBot2)] =
                        twoSortedNumbers(bots, sourceBot)[1];
                    bots[sourceBot, 0] = 0;
                    bots[sourceBot, 1] = 0;

                    input = input.Replace(command + "\r\n", "");
                }
                else if (valueToOutputPtrn.Match(command).Groups[4].Value != "")
                {
                    int sourceBot = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[1].Value);
                    if (twoSortedNumbers(bots, sourceBot)[0] == -1)
                        continue;

                    if ((bots[sourceBot, 0] == 17 && bots[sourceBot, 1] == 61) ||
                        (bots[sourceBot, 0] == 61 && bots[sourceBot, 1] == 17))
                    {
                        botNumber = sourceBot;
                        break;
                    }
                    bots[sourceBot, 0] = 0;
                    bots[sourceBot, 1] = 0;

                    input = input.Replace(command + "\r\n", "");
                }
                else if (valueToOutputPtrn.IsMatch(command))
                {
                    int sourceBot = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[1].Value);
                    int targetBot = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[3].Value);
                    if (twoSortedNumbers(bots, sourceBot)[0] == -1)
                        continue;

                    if ((bots[sourceBot, 0] == 17 && bots[sourceBot, 1] == 61) ||
                        (bots[sourceBot, 0] == 61 && bots[sourceBot, 1] == 17))
                    {
                        botNumber = sourceBot;
                        break;
                    }

                    bots[targetBot, freeBotIndex(bots, targetBot)] =
                        twoSortedNumbers(bots, sourceBot)[1];
                    bots[sourceBot, 0] = 0;
                    bots[sourceBot, 1] = 0;

                    input = input.Replace(command + "\r\n", "");
                }
            }
            return botNumber;
        }
        public int[] twoSortedNumbers(int[,] array, int n)
        {
            int[] sortedNumbers = new int[2] { array[n, 0], array[n, 1] };
            if (array[n, 0] == 0 || array[n, 1] == 0)
            {
                sortedNumbers[0] = -1;
            }
            else if (sortedNumbers[0] > sortedNumbers[1])
            {
                int temp = sortedNumbers[1];
                sortedNumbers[1] = sortedNumbers[0];
                sortedNumbers[0] = temp;
            }
            return sortedNumbers;
        }
        public int freeBotIndex(int[,] array, int n)
        {
            int index = -1;
            if (array[n, 0] != 0)
                index = 1;
            else
                index = 0;
            return index;
        }

        public int GetDay10_2(string filePath)
        {
            int[,] bots = new int[500, 2];
            int[] outputs = new int[3];
            StreamReader fileReader = new StreamReader(filePath);
            string input = fileReader.ReadToEnd();
            fileReader.Close();
            Regex valueToBotPtrn = new Regex(@"value (\d+) goes to bot (\d+)");
            Regex botToBotsPtrn =
                new Regex(@"bot (\d+) gives low to bot (\d+) and high to bot (\d+)");
            Regex valueToOutputPtrn =
                new Regex(@"bot (\d+) gives low to output (\d+) and high to (bot (\d+)|(output (\d+)))");

            StringReader strReader = new StringReader(input);
            while (input.Length != 0)
            {
                string command = "";
                if ((command = strReader.ReadLine()) == null)
                {
                    strReader.Close();
                    strReader.Dispose();
                    strReader = new StringReader(input);
                    continue;
                }

                if (valueToBotPtrn.IsMatch(command))
                {
                    bots[Convert.ToInt32(valueToBotPtrn.Match(command).Groups[2].Value), freeBotIndex(bots, Convert.ToInt32(valueToBotPtrn.Match(command).Groups[2].Value))] =
                        Convert.ToInt32(valueToBotPtrn.Match(command).Groups[1].Value);

                    input = input.Replace(command + "\r\n", "");
                }
                else if (botToBotsPtrn.IsMatch(command))
                {
                    int sourceBot = Convert.ToInt32(botToBotsPtrn.Match(command).Groups[1].Value);
                    int targetBot1 = Convert.ToInt32(botToBotsPtrn.Match(command).Groups[2].Value);
                    int targetBot2 = Convert.ToInt32(botToBotsPtrn.Match(command).Groups[3].Value);
                    if (twoSortedNumbers(bots, sourceBot)[0] == -1)
                        continue;

                    bots[targetBot1, freeBotIndex(bots, targetBot1)] =
                        twoSortedNumbers(bots, sourceBot)[0];
                    bots[targetBot2, freeBotIndex(bots, targetBot2)] =
                        twoSortedNumbers(bots, sourceBot)[1];
                    bots[sourceBot, 0] = 0;
                    bots[sourceBot, 1] = 0;

                    input = input.Replace(command + "\r\n", "");
                }
                else if (valueToOutputPtrn.Match(command).Groups[5].Value != "")
                {
                    int sourceBot = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[1].Value);
                    if (twoSortedNumbers(bots, sourceBot)[0] == -1)
                        continue;

                    int output1 = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[2].Value);
                    int output2 = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[2].Value);
                    if (output1 == 0 || output1 == 1 || output1 == 2)
                        outputs[output1] = twoSortedNumbers(bots, sourceBot)[0];
                    else if (output2 == 0 || output2 == 1 || output2 == 2)
                        outputs[output2] = twoSortedNumbers(bots, sourceBot)[1];

                    bots[sourceBot, 0] = 0;
                    bots[sourceBot, 1] = 0;

                    input = input.Replace(command + "\r\n", "");
                }
                else if (valueToOutputPtrn.IsMatch(command))
                {
                    int sourceBot = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[1].Value);
                    int targetBot = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[4].Value);
                    if (twoSortedNumbers(bots, sourceBot)[0] == -1)
                        continue;

                    int output1 = Convert.ToInt32(valueToOutputPtrn.Match(command).Groups[2].Value);

                    if (output1 == 0 || output1 == 1 || output1 == 2)
                        outputs[output1] = twoSortedNumbers(bots, sourceBot)[0];

                    bots[targetBot, freeBotIndex(bots, targetBot)] =
                        twoSortedNumbers(bots, sourceBot)[1];
                    bots[sourceBot, 0] = 0;
                    bots[sourceBot, 1] = 0;

                    input = input.Replace(command + "\r\n", "");
                }
            }
            return outputs[0]*outputs[1]*outputs[2];
        }

        public int GetDay11_1(string filePath)
        {
            //int[,] bots = new int[500, 2];
            //int[] outputs = new int[3];
            //StreamReader fileReader = new StreamReader(filePath);
            //string input = fileReader.ReadToEnd();
            //fileReader.Close();
            //Regex valueToBotPtrn = new Regex(@"value (\d+) goes to bot (\d+)");

            //StringReader strReader = new StringReader(input);
            //while (input.Length != 0)
            //{

            //}

            //return outputs[0] * outputs[1] * outputs[2];
            return 0;
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
            else if (radioButtonDay6_2.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay6_2(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            else if (radioButtonDay7_1.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay7_1(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            else if (radioButtonDay8_1.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay8_1(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            else if (radioButtonDay8_2.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay8_2(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            else if (radioButtonDay9_1.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay9_1(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            else if (radioButtonDay10_1.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay10_1(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
            else if (radioButtonDay10_2.IsChecked.Value)
            {
                textBoxAnyDayAnswer.Text = GetDay10_2(Convert.ToString(textBoxAnyDayPath.Text)).ToString();
            }
        }

        private void buttonCodeabbeyOpen_Click(object sender, RoutedEventArgs e)
        {
            CodeabbeyWindow codeabbeyWindow = new CodeabbeyWindow();
            codeabbeyWindow.Show();
        }
    }
}
