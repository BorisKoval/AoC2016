using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Numerics;
using System.Collections;
using System.Globalization;

namespace AoC_2016.Codeabbey
{
    class CdbTasks
    {
        #region Solved
        static public double taskOne(string Input)
        {
            double sum = 0;
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            sum = Convert.ToDouble(inputPtrn.Match(Input).Groups[1].Value) + Convert.ToDouble(inputPtrn.Match(Input).Groups[2].Value);
            return sum;
        }

        static public double taskTwo(string Input)
        {
            double sum = 0;
            Regex inputPtrn = new Regex(@"\d+");            
            foreach (Match num in inputPtrn.Matches(Input))
            {                
                sum += Convert.ToDouble(num.Value);
            }
            return sum;
        }

        static public string taskThree(string Input)
        {
            string sums = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                sums += (Convert.ToDouble(num.Groups[1].Value) + Convert.ToDouble(num.Groups[2].Value)).ToString() + " ";
            }
            return sums;
        }

        static public string taskFour(string Input)
        {
            string mins = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                if (Convert.ToDouble(num.Groups[1].Value) < Convert.ToDouble(num.Groups[2].Value))
                    mins += (Convert.ToDouble(num.Groups[1].Value)).ToString() + " ";
                else
                    mins += (Convert.ToDouble(num.Groups[2].Value)).ToString() + " ";
            }
            return mins;
        }

        static public string taskFive(string Input)
        {
            string mins = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+) (-?\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                if ((Convert.ToDouble(num.Groups[1].Value) < Convert.ToDouble(num.Groups[2].Value)) & (Convert.ToDouble(num.Groups[1].Value) < Convert.ToDouble(num.Groups[3].Value)))
                    mins += (Convert.ToDouble(num.Groups[1].Value)).ToString() + " ";
                else if ((Convert.ToDouble(num.Groups[2].Value) < Convert.ToDouble(num.Groups[1].Value)) & (Convert.ToDouble(num.Groups[2].Value) < Convert.ToDouble(num.Groups[3].Value)))
                    mins += (Convert.ToDouble(num.Groups[2].Value)).ToString() + " ";
                else
                    mins += (Convert.ToDouble(num.Groups[3].Value)).ToString() + " ";
            }
            return mins;
        }

        static public string task15(string Input)
        {
            string maxMin = "";
            Regex inputPtrn = new Regex(@"-?\d+");
            List<int> nums = new List<int>();
            foreach (Match num in inputPtrn.Matches(Input))
            {
                nums.Add(Convert.ToInt32(num.Value));
            }
            maxMin = (nums.Max()).ToString() + " " + (nums.Min()).ToString();
            return maxMin;
        }

        static public string task6(string Input)
        {
            string divRounding = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                double temp = Convert.ToDouble(num.Groups[1].Value) / Convert.ToDouble(num.Groups[2].Value);
                divRounding += temp > 0 ? (Math.Round(temp)).ToString() + " " : (-Math.Round(Math.Abs(temp))).ToString() + " ";
            }
            return divRounding;
        }

        static public string task7(string Input)
        {
            string temp = "";
            Regex inputPtrn = new Regex(@"-?\d+");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                temp += (Math.Round((Convert.ToInt32(num.Value) - 32) / 1.8)).ToString() + " ";
            }
            return temp;
        }

        static public string task20(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"-?\d+");
            List<char> vowels= new List<char>(new char[] {'a','o','u','i', 'e', 'y'});
            StringReader strReader = new StringReader(Input);
            string str ="";
            while ((str = strReader.ReadLine()) != null)
            {
                int temp =0;
                foreach (char ch in str)
                {
                    if (vowels.Contains(ch))
                        temp++;       
                }
                output += temp.ToString() + " ";
            }
            strReader.Close();
            return output;
        }

        static public string task33(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"\d+");
            string binInput = "";
            foreach (Match num in inputPtrn.Matches(Input))
            {
                binInput = Convert.ToString(Convert.ToInt32(num.Value),2);
                binInput = binInput.Length != 8 ? '0' + binInput : binInput;
                int tempSum = 0;
                for (int i = 0; i < binInput.Length; i++)
                {
                    tempSum += Convert.ToInt32(binInput[i].ToString());
                }
                if (tempSum % 2 != 0)
                {
                    continue;
                }
                if (binInput[0] == '1')
                {
                    binInput = '0' + binInput.Substring(1, binInput.Length-1);
                    output += (char)(Convert.ToInt32(Convert.ToString(Convert.ToInt32(binInput, 2), 10)));                    
                }
                else 
                    output += (char)(Convert.ToInt32(Convert.ToString(Convert.ToInt32(binInput,2),10)));
            }
            return output;
        }

        static public string task41(string Input)
        {
            string median = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+) (-?\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                double a = Convert.ToDouble(num.Groups[1].Value);
                double b = Convert.ToDouble(num.Groups[2].Value);
                double c = Convert.ToDouble(num.Groups[3].Value);
                if ((a < b && a > c) | (a < c && a > b))
                    median += a.ToString() + " ";
                else if ((b < a && b > c) | (b < c && b > a))
                    median += b.ToString() + " ";
                else
                    median += c.ToString() + " ";
            }
            return median;
        }

        static public string task28(string Input)
        {
            string categories = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d?.\d+)");
            string input = Input.Replace('.', ',');
            foreach (Match num in inputPtrn.Matches(input))
            {
                double weight = Convert.ToDouble(num.Groups[1].Value);
                double height = Convert.ToDouble(num.Groups[2].Value);
                double BMI = weight/Math.Pow(height,2);
                if (BMI < 18.5)
                    categories += "under"+" ";
                else if (BMI>=18.5 & BMI<25)
                    categories += "normal" + " ";
                else if (BMI >= 25 & BMI < 30)
                    categories += "over" + " ";
                else
                    categories += "obese" + " ";
            }
            return categories;
        }

        static public string task8(string Input)
        {
            string progression = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+) (-?\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                int A=Convert.ToInt32(num.Groups[1].Value);
                int B=Convert.ToInt32(num.Groups[2].Value);
                int N=Convert.ToInt32(num.Groups[3].Value);
                int sum = 0;
                for (int i= 0; i<N; i++)
                {
                    sum += A + B * i;
                }
                progression += sum.ToString() + " ";
            }
            return progression;
        }

        static public string task13(string Input)
        {
            string sum = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            string number = "";
            foreach (Match num in inputPtrn.Matches(Input))
            {
                int temp = 0;
                number = Convert.ToString(num);
                for (int i = 0; i < number.Length; i++)
                {
                    temp += (int)Char.GetNumericValue(number[i])* (i+1);
                }
                sum += temp.ToString()+" ";
            }
            return sum;
        }

        static public string task43(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(0\.\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                output += (Math.Floor(Convert.ToDouble(num.Value.Replace('.',','))*6)+1).ToString() + " ";
            }
            return output;
        }

        static public string task9(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+)");
            foreach (Match num in inputPtrn.Matches(Input))
            {
                int a = Convert.ToInt32(num.Groups[1].Value);
                int b = Convert.ToInt32(num.Groups[2].Value);
                int c = Convert.ToInt32(num.Groups[3].Value);
                if (a + b > c && a + c > b && b + c > a)
                    output += 1 + " ";
                else
                    output += 0 + " ";
            }
            return output;
        }

        static public string task16(string Input)
        {
            string output = "";            
            Regex inputPtrn = new Regex(@"(\d+)");
            StringReader strReader = new StringReader(Input);
            string str = "";
            double sum=0;
            while ((str = strReader.ReadLine()) != null)
            {
                sum = 0;
                str = str.Substring(0, str.Length - 2);
                foreach (Match num in inputPtrn.Matches(str))
                {
                    sum += Convert.ToInt32(num.Value);
                }
                output += Math.Round(sum / inputPtrn.Matches(str).Count) + " ";
            }
            strReader.Close();
            return output;
        }

        static public string task17(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            double sum = 0;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                sum = (sum+ Convert.ToDouble(num.Value))*113;
                sum %= 10000007;
            }
            output = (sum).ToString();
            return output;
        }

        static public string task30(string Input)
        {
            return new string(Input.ToCharArray().Reverse().ToArray());
        }

        static public string task21(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            SortedDictionary<int, int> numbers = new SortedDictionary<int, int>();
            foreach (Match num in inputPtrn.Matches(Input))
            {
                if (!numbers.ContainsKey(Convert.ToInt32(num.Value)))
                    numbers.Add(Convert.ToInt32(num.Value),1);
                else
                    numbers[Convert.ToInt32(num.Value)]++;
            }
            foreach (int n in numbers.Values)
                output += n.ToString() + " ";            
            return output;        
        }

        static public string task48(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            int x=0;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                x = Convert.ToInt32(num.Value);
                int steps = 0;
                while (x > 1)
                {
                    x = x % 2 == 0 ? x / 2 : 3 * x + 1;
                    steps++;
                }
                output += steps + " ";
            }
            return output;
        }

        static public string task12(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+)");
            int days,hrs, mins, secs;
            StringReader strReader = new StringReader(Input);
            string str = "";
            while ((str = strReader.ReadLine()) != null)
            {
                Match dates = inputPtrn.Matches(str)[0];
                secs = Convert.ToInt32(dates.Groups[8].Value) + Convert.ToInt32(dates.Groups[7].Value) * 60 + Convert.ToInt32(dates.Groups[6].Value) * 60 * 60 + Convert.ToInt32(dates.Groups[5].Value) * 60 * 60 * 24;
                secs -= Convert.ToInt32(dates.Groups[4].Value) + Convert.ToInt32(dates.Groups[3].Value) * 60 + Convert.ToInt32(dates.Groups[2].Value) * 60 * 60 + Convert.ToInt32(dates.Groups[1].Value) * 60 * 60 * 24;
                days = secs / (60 * 60 * 24);
                secs %= (60 * 60 * 24);
                hrs = secs / (60 * 60);
                secs %= (60 * 60);
                mins = secs / 60;
                secs %= 60;
                output += string.Format("({0} {1} {2} {3}) ", days, hrs, mins, secs);
            }
            strReader.Close();
            return output;
        }

        static public string task10(string Input)
        {
            string output = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+) (-?\d+) (-?\d+)");
            int x1,y1,x2,y2,a=0,b=0;
            StringReader strReader = new StringReader(Input);
            string str = "";
            while ((str = strReader.ReadLine()) != null)
            {
                Match dots = inputPtrn.Matches(str)[0];
                x1 = Convert.ToInt32(dots.Groups[1].Value);
                y1 = Convert.ToInt32(dots.Groups[2].Value);
                x2 = Convert.ToInt32(dots.Groups[3].Value);
                y2 = Convert.ToInt32(dots.Groups[4].Value);
                a = (y1 - y2) / (x1 - x2);
                b = y2 - a * x2;
                output += string.Format("({0} {1}) ", a, b);
            }
            strReader.Close();
            return output;
        }
        #endregion

        static public string task14(string Input)
        {
            Regex inputPtrn = new Regex(@"(.) (\d+)");
            double value = Convert.ToDouble(Input.Substring(0, Input.IndexOf("\r\n")));
            double m = Convert.ToDouble(Input.Substring(Input.IndexOf('%') + 1, Input.Length - Input.IndexOf('%')-1));
            Input = Input.Remove(0, Input.IndexOf("\r\n"));
            foreach (Match num in inputPtrn.Matches(Input))
            {
                switch (num.Groups[1].Value)
                {
                    case "+":
                        value += Convert.ToDouble(num.Groups[2].Value);
                        break;
                    case "*":
                        value *= Convert.ToDouble(num.Groups[2].Value);
                        value %= m;
                        break;
                    case "%":
                        value %= Convert.ToDouble(num.Groups[2].Value);
                        break;
                }
            }
            return value.ToString();
        }

        static public string task27(string Input)
        {
            Regex inputPtrn = new Regex(@"(\d+)");
            int size = Convert.ToInt32(Input.Substring(0, Input.IndexOf("\r\n")));
            Input = Input.Remove(0, Input.IndexOf("\r\n"));
            int[] arr = new int[size];
            int steps = 0, swaps = 0,temp=0;
            bool swaped = false;
            for (int i = 0; i < size;i++ )
            {
                arr[i] = Convert.ToInt32(inputPtrn.Matches(Input)[i].Value);
            }
            for (int i = 1; i < size; i++)
            {
                steps++;
                for (int j = 0; j < size - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        swaped = true;
                        swaps++;
                    }
                }
                if (!swaped)
                    break;
                swaped = false;
            }
            return steps.ToString() + " " + swaps.ToString();
        }

        static public string task26(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            int A, B, gcd=0, lcm;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                A = Convert.ToInt32(num.Groups[1].Value);
                B = Convert.ToInt32(num.Groups[2].Value);
                while (A != B)
                {
                    if (A > B)
                    {
                        A = A - B;
                        gcd = A;
                    }
                    else if (B > A)
                    {
                        B = B - A;
                        gcd = B;
                    }
                }
                lcm = Convert.ToInt32(num.Groups[1].Value) * Convert.ToInt32(num.Groups[2].Value) / gcd;
                Output += string.Format("({0} {1}) ", gcd, lcm);
            }
            return Output;
        }

        static public string task29(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            int index = 1;
            SortedDictionary<int, int> arr = new SortedDictionary<int, int>();
            foreach (Match num in inputPtrn.Matches(Input))
            {
                arr.Add(Convert.ToInt32(num.Value), index++);
            }
            foreach (int value in arr.Values)
                Output += value + " ";
            return Output;
        }

        static public string task23(string Input)
        {
            Regex inputPtrn = new Regex(@"(\d+)");
            int[] arr = new int[inputPtrn.Matches(Input).Count];
            int k = 0, swaps =0, temp=0;
            double sum = 0;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                arr[k++] = Convert.ToInt32(num.Value);
            }
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                    swaps++;
                }
                sum = (sum + arr[i]) * 113;
                sum %= 10000007;
            }
            sum = (sum + arr[arr.Length-1]) * 113;
            sum %= 10000007;
            return swaps.ToString()+" "+sum.ToString();
        }

        static public string task18(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            double r = 1, X = 0;
            int N = 0;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                X = Convert.ToDouble(num.Groups[1].Value);
                N = Convert.ToInt32(num.Groups[2].Value);
                r = 1;
                for (int i = 0; i < N; i++)
                {
                    r = (r + X / r) / 2;
                }
                Output += Math.Round(r,10).ToString() + " ";
            }
            return Output.Replace(',','.');
        }

        static public string task24(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            int N = 0, steps=0;
            List<int> sequence = new List<int>();
            foreach (Match num in inputPtrn.Matches(Input))
            {
                N = Convert.ToInt32(num.Value);
                do
                {
                    sequence.Add(N);
                    steps++;
                    N *= N;
                    N = (N / 100) % 10000;
                } while (!sequence.Contains(N));
                Output += steps.ToString() + " ";
                steps = 0;
                sequence.Clear();
            }
            return Output;
        }

        static public string task67(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            BigInteger N = 0, temp = 0;
            Dictionary<int, BigInteger> fib = new Dictionary<int, BigInteger>();
            fib[0] = 0;
            fib[1] = 1;
            for (int i = 2; i <= 1000; i++)
            {
                temp = fib[i - 2] + fib[i-1];
                fib.Add(i, temp);
            }
            foreach (Match num in inputPtrn.Matches(Input))
            {
                N = BigInteger.Parse(num.Value);
                if (fib.ContainsValue(N))
                    Output += fib.Where(x => x.Value == N).ToArray()[0].Key + " ";
            }
            return Output;
        }

        static public string task50(string Input)
        {
            string Output = "";
            StringReader reader = new StringReader(Input);
            string line = "", reversedLine="";
            char pal='N';
            while ((line = reader.ReadLine()) != null)
            {
                line = line.ToLower();
                line = new string(line.Where(x => char.IsLetter(x)).ToArray());
                reversedLine = new string(line.Reverse().ToArray());
                if (line == reversedLine)
                    pal = 'Y';
                else
                    pal = 'N';
                Output += pal + " ";
            }
            return Output;
        }

        static public string task31(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (\w+)");
            int n=0;
            foreach(Match line in inputPtrn.Matches(Input))
            {
                n= Convert.ToInt32(line.Groups[1].Value);
                if (n > 0)
                    Output += line.Groups[2].Value.Substring(n, line.Groups[2].Value.Length - n) + line.Groups[2].Value.Substring(0, n) + " ";
                else if (n < 0)
                    Output += line.Groups[2].Value.Substring(line.Groups[2].Value.Length + n, -n) + line.Groups[2].Value.Substring(0, line.Groups[2].Value.Length + n) + " ";
            }
            return Output;
        }

        static public string task57(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+.\d+)");
            double[] temps = new double[inputPtrn.Matches(Input).Count];
            double n = 0, n1 = 0, n2 = 0;
            for (int i = 0; i < temps.Length;i++ )
            {
                n = Convert.ToDouble(inputPtrn.Matches(Input)[i].Value.Replace('.',','));
                temps[i] = n;
                if (i > 1)
                {
                    n1 = Convert.ToDouble(inputPtrn.Matches(Input)[i - 2].Value.Replace('.', ','));
                    n2 = Convert.ToDouble(inputPtrn.Matches(Input)[i - 1].Value.Replace('.', ','));
                    temps[i - 1] = Math.Round((n1 + n2 + n) / 3, 10);
                }
            }
            Output = String.Join(" ", temps.Select(x => x.ToString().Replace(',','.')).ToArray());
            return Output;
        }

        static public string task52(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+)");
            double a = 0, b = 0, c = 0;
            foreach (Match line in inputPtrn.Matches(Input))
            {
                a = Convert.ToDouble(line.Groups[1].Value);
                b = Convert.ToDouble(line.Groups[2].Value);
                c = Convert.ToDouble(line.Groups[3].Value);
                if (c == Math.Sqrt(a * a + b * b))
                    Output += "R ";
                else if (c < Math.Sqrt(a * a + b * b))
                    Output += "A ";
                else
                    Output += "O ";
            }
            return Output;
        }

        static public string task68(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+)");
            double S = 0, A = 0, B = 0;
            foreach (Match line in inputPtrn.Matches(Input))
            {
                S = Convert.ToDouble(line.Groups[1].Value);
                A = Convert.ToDouble(line.Groups[2].Value);
                B = Convert.ToDouble(line.Groups[3].Value);
                Output += Math.Round((S / (A + B)) * A,10).ToString().Replace(',','.') + " ";
            }
            return Output;
        }

        static public string task32(string Input)
        {
            int N =Convert.ToInt32(Input.Substring(0, Input.IndexOf(' ')));
            int K = Convert.ToInt32(Input.Substring(Input.IndexOf(' '), Input.Length - Input.IndexOf(' ')));
            int m = 1;
            for (int i = 1; i <= N; i++)
            {
                m = (m + K - 1) % i + 1;
            }
            return m.ToString();
        }

        static public string task25(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+) (\d+) (\d+)");
            double A = 0, C = 0, M = 0, X = 0,N=0 ;
            foreach (Match line in inputPtrn.Matches(Input))
            {
                A = Convert.ToDouble(line.Groups[1].Value);
                C = Convert.ToDouble(line.Groups[2].Value);
                M = Convert.ToDouble(line.Groups[3].Value);
                X = Convert.ToDouble(line.Groups[4].Value);
                N = Convert.ToDouble(line.Groups[5].Value);
                for (int i = 0; i < N; i++)
                    X = (A * X + C) % M;
                Output += X.ToString() + " ";
            }
            return Output;
        }

        static public string task44(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            double R1 = 0, R2 = 0, sum;
            foreach (Match line in inputPtrn.Matches(Input))
            {
                R1 = Convert.ToDouble(line.Groups[1].Value);
                R2 = Convert.ToDouble(line.Groups[2].Value);
                sum = (R1 % 6 + 1) + (R2 % 6 + 1);
                Output += sum.ToString() + " ";
            }
            return Output;
        }

        static public string task81(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(-?\d+)");
            int n=0;
            foreach (Match line in inputPtrn.Matches(Input))
            {
                n = Convert.ToInt32(line.Value);
                Output += Convert.ToString(n, 2).Count(x => x == '1')+" ";
            }
            return Output;
        }

        static public string task19(string Input)
        {
            string Output = "";
            StringReader reader = new StringReader(Input);
            string line = "";
            string[] brackets = { "(", ")", "[", "]", "{", "}", "<", ">" };
            int n = 0;
            while ((line = reader.ReadLine()) != null)
            {
                line = new string(line.Where(ch => brackets.Contains(ch.ToString())).ToArray());
                n = line.Length;
                while (line.Length !=0)
                {
                    line = line.Replace("()", "");
                    line = line.Replace("[]", "");
                    line = line.Replace("{}", "");
                    line = line.Replace("<>", "");
                    if (n == line.Length)
                        break;
                    n = line.Length;
                }
                if (line.Length == 0)
                    Output += 1 + " ";
                else
                    Output += 0 + " ";
            }
            return Output;
        }

        static public string task47(string Input)
        {
            string Output = "";            
            StringReader reader = new StringReader(Input);
            string line = "";
            line = reader.ReadLine();
            int K = Convert.ToInt32(line.Substring(line.IndexOf(' '), line.Length - line.IndexOf(' ')));
            while ((line = reader.ReadLine()) != null)
            {
                foreach (char ch in line)
                {
                    if (ch == ' ' || ch=='.')
                    {
                        Output += ch;
                        continue;
                    }
                    Output += (char)(((int)ch + (26 - K) - 65) % 26 + 65);
                }
                Output += " ";
            }
            reader.Close();
            return Output;
        }

        static public string task55(string Input)
        {
            string Output = "";
            string[] inArr = Input.Split(' ');
            Dictionary<string, int> inDict = new Dictionary<string, int>();
            foreach (string str in inArr)
            {
                if (!inDict.ContainsKey(str))
                    inDict[str] = 1;
                else
                    inDict[str]++;
            }
            Output = String.Join(" ", inDict.Where(x => x.Value > 1).OrderBy(c => c.Key).Select(c => c.Key));
            return Output;
        }

        static public string task104(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+) (\d+) (\d+) (\d+)");
            double X1 = 0, Y1 = 0, X2 = 0, Y2 = 0, X3 = 0, Y3 = 0, a = 0, b = 0, c = 0;
            double area=0, p=0;
            foreach (Match line in inputPtrn.Matches(Input))
            {
                X1 = Convert.ToDouble(line.Groups[1].Value);
                Y1 = Convert.ToDouble(line.Groups[2].Value);
                X2 = Convert.ToDouble(line.Groups[3].Value);
                Y2 = Convert.ToDouble(line.Groups[4].Value);
                X3 = Convert.ToDouble(line.Groups[5].Value);
                Y3 = Convert.ToDouble(line.Groups[6].Value);
                a = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
                b = Math.Sqrt(Math.Pow((X3 - X2), 2) + Math.Pow((Y3 - Y2), 2));
                c = Math.Sqrt(Math.Pow((X1 - X3), 2) + Math.Pow((Y1 - Y3), 2));
                p = (a + b + c) / 2;
                area = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)),1);
                Output += area.ToString(new CultureInfo("en-US")) + " ";
            }
            return Output;
        }

        static public string task49(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\w)(\w)");
            StringReader reader = new StringReader(Input);
            string line = "";
            int score = 0;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (Match m in inputPtrn.Matches(line))
                {
                    if (m.Groups[1].Value == m.Groups[2].Value)
                        continue;
                    if (m.Value == "RS" || m.Value == "SP" || m.Value == "PR")
                        score++;
                    else
                        score--;
                }
                if (score > 0)
                    Output += 1 + " ";
                else if (score <0)
                    Output += 2 + " ";
                score = 0;
            }
            return Output;
        }

        static public string task61(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            StreamWriter writer = new StreamWriter(@"C://primes.txt", false, Encoding.UTF8);
            List<int> primes = new List<int>();

            //for (int j = 2; j < 3000000; j++)
            //    primes.Add(j);
            //int p = 2;
            //while (p < 275)//2750131
            //{
            //    primes = primes.Where(x => x==p || x % p != 0).ToList();

                //for (int d = p * p; d < 3000000; d += p)
                //{
                //    primes.Remove(d);
                //}

            //    p = primes.First(x => x > p);
            //}

            primes.Add(2);
            primes.Add(3);
            primes.Add(5);
            primes.Add(7);
            writer.Write("2 3 5 7 ");
            for (int i = primes.Max() + 1; primes.Count < 200000; i++)
            {
                if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
                    continue;
                if (primes.Count(x => x > 7 && i % x == 0) != 0)
                    continue;
                primes.Add(i);
                writer.Write(Convert.ToString(i)+" ");
            }
            writer.Close();


            foreach (Match m in inputPtrn.Matches(Input))
            {
                Output += primes[Convert.ToInt32(m.Value)-1] + " ";
            }
            return Output;
        }
        //first 200k primes filter (~5 sec, ~500 mb RAM)
        public static List<int> Primes(List<int> arr, int index = 0)
        {
            if (arr[199999] == 2750159 || index > arr.Count / 2)
                return arr;
            return Primes(arr.Where(x => x == arr[index] || x % arr[index] != 0).ToList(), index + 1);
        }

        static public string task58(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            string[] suits = {"Clubs", "Spades", "Diamonds", "Hearts"};
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (Match card in inputPtrn.Matches(Input))
            {
                Output += ranks[Convert.ToInt32(card.Value)%13]+"-of-"+suits[(int)(Convert.ToInt32(card.Value) / 13)]+" ";
            }
            return Output;
        }

        static public string task94(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            string line = "";
            int temp=0;
            using (StringReader reader = new StringReader(Input))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (Match num in inputPtrn.Matches(line))
                    {
                        temp += Convert.ToInt32(num.Value) * Convert.ToInt32(num.Value);
                    }
                    Output += temp + " ";
                    temp = 0;
                }
                reader.Close();
            }
            return Output;
        }

        static public string task59(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d\d\d\d)");
            string code = Input.Substring(0, Input.IndexOf(' '));
            Input = Input.Remove(0, Input.IndexOf("\r\n"));
            int hint1 = 0, hint2 = 0;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (num.Value[i] == code[i])
                        hint1++;
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == j)
                            continue;
                        if (code[i] == num.Value[j])
                            hint2++;
                    }
                }
                Output += hint1 + "-" + hint2+" ";
                hint1 = 0;
                hint2 = 0;
            }            
            return Output;
        }

        static public string task128(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            int N = 0, K = 0;
            ulong upFac = 1, downFac = 1;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                N = Convert.ToInt32(num.Groups[1].Value);
                K = Convert.ToInt32(num.Groups[2].Value);
                if (K == 0)
                {
                    Output += 1 + " ";
                    continue;
                }
                for (int i = 1; i <= N; i++)
                {
                    if (K >= N - K)
                    {
                        if (i <= N - K)
                            downFac *= (ulong)i;
                        if (i > K)
                            upFac *= (ulong)i;
                    }
                    else if (K < N - K)
                    {
                        if (i <= K)
                            downFac *= (ulong)i;
                        if (i > N - K)
                            upFac *= (ulong)i;
                    }
                }
                Output += upFac / downFac + " ";
                upFac = 1; downFac = 1;
            }
            return Output;
        }

        static public string task42(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\S)");
            string[] inputArr = Input.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int sum = 0, aces = 0;
            foreach (string line in inputArr)
            {
                foreach (Match card in inputPtrn.Matches(line))
                {
                    if (card.Value=="A")
                    {
                        aces++;
                        continue;
                    }
                    sum += char.IsDigit(card.Value[0]) ? Convert.ToInt32(card.Value) : 10;
                }
                if (sum + aces > 21)
                {
                    Output += "Bust ";
                }
                else
                {
                    sum = sum + (aces - 1) + 11 <= 21 ? sum + (aces - 1) + 11 : sum + aces;
                    Output += sum + " ";
                }
                sum = 0; aces = 0;
            }
            return Output;
        }

        static public string task38(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(-?\d+) (-?\d+) (-?\d+)");
            double A = 0, B = 0, C = 0, x1 = 0, x2 = 0, D = 0;
            foreach (Match equation in inputPtrn.Matches(Input))
            {
                A = Convert.ToInt32(equation.Groups[1].Value);
                B = Convert.ToInt32(equation.Groups[2].Value);
                C = Convert.ToInt32(equation.Groups[3].Value);
                D = Math.Pow(B, 2) - 4 * A * C;
                if (D >= 0)
                {
                    x1 = Math.Round((Math.Sqrt(D) - B) / (2 * A));
                    x2 = Math.Round((-Math.Sqrt(D) - B) / (2 * A));
                    Output += x1 + " " + x2 + "; ";
                }
                else if (D < 0)
                {
                    Output += Math.Round(-B / (2 * A)) + "+" + Math.Round(Math.Sqrt(-D) / (2 * A)) +   "i "+Math.Round(-B / (2 * A)) + "-" + Math.Round(Math.Sqrt(-D) / (2 * A))+ "i; ";
                }
            }
            return Output;
        }

        static public string task34(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+\,\d+) (\d+\,\d+) (\d+\,\d+) (\d+\,\d+)");
            double A = 0, B = 0, C = 0, D = 0, leftX = 0, rightX = 100, midX = 0, fM = 0;
            Input = Input.Replace('.', ',');
            foreach (Match equation in inputPtrn.Matches(Input))
            {
                A = Convert.ToDouble(equation.Groups[1].Value);
                B = Convert.ToDouble(equation.Groups[2].Value);
                C = Convert.ToDouble(equation.Groups[3].Value);
                D = Convert.ToDouble(equation.Groups[4].Value);
                while (Math.Abs(rightX - leftX) > 0.0000001)
                {
                    midX = (leftX + rightX) / 2;
                    fM = A * midX + B * Math.Sqrt(Math.Pow(midX, 3)) - C * Math.Exp(-midX / 50) - D;
                    if (fM < 0)
                        leftX = midX;
                    else
                        rightX = midX;
                }
                Output += Math.Round(midX, 7) + " ";
                leftX = 0; rightX = 100;
            }
            Output = Output.Replace(',', '.');
            return Output;
        }

        static public string task120(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            int[] arr = new int[Convert.ToInt32(Input.Substring(0, Input.IndexOf("\r\n")))];
            int maxIndex = 0, temp = 0;
            Input = Input.Remove(0, Input.IndexOf("\r\n"));
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(inputPtrn.Matches(Input)[i].Value);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[maxIndex])
                        maxIndex = j;
                }
                temp = arr[maxIndex];
                arr[maxIndex] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
                Output += maxIndex + " ";
                maxIndex = 0;
            }
            return Output;
        }

        static public string task53(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\w)(\d) (\w)(\d)");
            foreach (Match figures in inputPtrn.Matches(Input))
            {
                if (figures.Groups[1].Value == figures.Groups[3].Value ||
                    figures.Groups[2].Value == figures.Groups[4].Value ||
                    Math.Abs(Convert.ToChar(figures.Groups[1].Value) - Convert.ToChar(figures.Groups[3].Value)) == Math.Abs(Convert.ToChar(figures.Groups[2].Value) - Convert.ToChar(figures.Groups[4].Value)))
                    Output += "Y ";
                else
                    Output += "N ";
            }
            return Output;
        }

        static public string task45(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            string[] suits = { "C", "D", "H", "S" };
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };
            string temp = "";
            string[] cards = new string[52];
            for (int i = 0; i < 52; i++)
            {
                cards[i] = suits[(int)(i / 13)] + ranks[i % 13];
            }
            int index = 0;
            foreach (Match card in inputPtrn.Matches(Input))
            {
                temp = cards[index];
                cards[index] = cards[Convert.ToInt32(card.Value) % 52];
                cards[Convert.ToInt32(card.Value) % 52] = temp;
                index++;
            }
            Output = string.Join(" ", cards);
            return Output;
        }

        static public string task63(string Input)
        {
            string Output = "";
            string[] nums = Input.Split(new string[] {"\r\n"}, StringSplitOptions.None);
            long num = 0;
            foreach (string sNum in nums)
            {
                num = long.Parse(sNum);
                for (int i = 2; i <= num; i++)
                {
                    while (num % i == 0)
                    {
                        Output += i + "*";
                        num /= i;
                    }
                }
                Output = Output.Remove(Output.Length - 1, 1);
                Output += " ";
            }
            return Output;
        }

        static public string task37(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+) (\d+)");
            double P = 0, R = 0, L = 0, leftX = 0, rightX = 100, midX = 0;
            Match nums = inputPtrn.Match(Input);
            P = Convert.ToDouble(nums.Groups[1].Value);
            R = Convert.ToDouble(nums.Groups[2].Value);
            L = Convert.ToDouble(nums.Groups[3].Value);
            leftX = (int)(P / L);
            rightX = P;
            while (Math.Abs(rightX - leftX) > 0.1)
            {
                for (int i = 0; i < L; i++)
                {
                    midX = (leftX + rightX) / 2;
                    P = P + P * (R / 1200) - midX;
                }
                if (P < 0)
                    rightX = midX;
                else
                    leftX = midX;
                P = Convert.ToDouble(nums.Groups[1].Value);
            }            
            Output += (int)(midX)+1 + " ";
            return Output;
        }

        static public string task46(string Input)
        {
            string Output = "";
            StringReader reader = new StringReader(Input);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] input = line.Split(' ');
                char[,] field = new char[3, 3];
                int i = 0;
                bool won = false;
                for (i = 0; i < 4; i++)
                {
                    int n = Convert.ToInt32(input[i]) - 1;
                    if (i % 2 != 0)
                        field[n / 3, n % 3] = 'X';
                    else
                        field[n / 3, n % 3] = 'O';
                }

                for (i = 4; i < 9; i++)
                {
                    int n = Convert.ToInt32(input[i]) - 1;
                    if (i % 2 != 0)
                        field[n / 3, n % 3] = 'X';
                    else
                        field[n / 3, n % 3] = 'O';
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[j, 0] != '\0' & field[j, 0] == field[j, 1] & field[j, 1] == field[j, 2])
                        {
                            won = true;
                            break;
                        }
                        if (field[0, j] != '\0' & field[0, j] == field[1, j] & field[1, j] == field[2, j])
                        {
                            won = true;
                            break;
                        }
                    }
                    if (field[0, 0] != '\0' & field[0, 0] == field[1, 1] & field[1, 1] == field[2, 2])
                        won = true;
                    else if (field[2, 0] != '\0' & field[2, 0] == field[1, 1] & field[1, 1] == field[0, 2])
                        won = true;

                    if (won)
                    {
                        Output += (i + 1).ToString() + " ";
                        break;
                    }
                }
                if (i==9)
                    Output += 0 + " ";
            }
            reader.Close();
            return Output;
        }

        static public string task72(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            string consonant = "bcdfghjklmnprstvwxz", vowels = "aeiou"; 
            int A = 445, C = 700001, M = 2097152, N=0, X=0;
            int seed = Convert.ToInt32(Input.Substring(Input.IndexOf(" ")+1, Input.IndexOf("\r\n")-1));
            Input = Input.Remove(0, Input.IndexOf("\r\n")+2);            
            X = seed;
            foreach (Match num in inputPtrn.Matches(Input))
            {
                N = Convert.ToInt32(num.Value);
                for (int i = 1; i <= N; i++)
                {
                    X = (A * X + C) % M;
                    if (i % 2 != 0)
                        Output += consonant[X % 19];
                    else
                        Output += vowels[X % 5];
                }
                Output += " ";
            }
            return Output;
        }

        static public string task69(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            List<int> cases = new List<int>();
            List<BigInteger> fib = new List<BigInteger>();
            foreach (Match number in inputPtrn.Matches(Input))
            {
                cases.Add(Convert.ToInt32(number.Value));
            }
            fib.Add(0); 
            fib.Add(1);
            int i = 2;
            BigInteger num = 0;
            while (cases.Count != 0)
            {
                fib.Add(fib[i - 2] + fib[i - 1]);
                num = fib.Where(x => x != 0 & x % cases[0] == 0).ToList().Count != 0 ? fib.Where(x => x != 0 & x % cases[0] == 0).ToList()[0] : 0;
                if (num != 0)
                {
                    cases.RemoveAt(0);
                    Output += fib.IndexOf(num) + " ";
                }
                i++;
            }
            return Output;
        }

        static public string task39(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            List<int> shares = new List<int>();
            StringReader reader = new StringReader(Input);
            string line = "",name = "";
            int avg = 0;
            double deviation = 0;
            while ((line = reader.ReadLine()) != null)
            {
                name = line.Substring(0, line.IndexOf(' '));
                foreach (Match n in inputPtrn.Matches(line))
                {
                    shares.Add(Convert.ToInt32(n.Value));
                    avg += Convert.ToInt32(n.Value);
                }
                avg /= 14;
                foreach (int n in shares)
                    deviation += Math.Pow(avg - n, 2);
                deviation = Math.Sqrt(deviation/14);
                if (deviation >= 4 * (avg * 0.01))
                    Output += name + " ";
                avg = 0;
                deviation = 0;
                shares.Clear();
            }
            reader.Close();
            return Output;
        }

        static public string task62(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+)");
            List<int> primes = new List<int>();
            int a = 0, b = 0;
            for (int j = 2; j < 3000000; j++)
                primes.Add(j);
            primes = Primes(primes);
            foreach (Match nums in inputPtrn.Matches(Input))
            {
                a = Convert.ToInt32(nums.Groups[1].Value);
                b = Convert.ToInt32(nums.Groups[2].Value);
                Output += primes.Count(x => x >= a & x <= b) + " ";
            }
            return Output;
        }

        static public string task121(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+)");
            LinkedList<int> arr = new LinkedList<int>();
            int i=0, num=0;
            foreach (Match sNum in inputPtrn.Matches(Input))
            {
                num = Convert.ToInt32(sNum.Value);
                arr.AddLast(num);
                if (arr.Count < 2)
                    continue;
                for (i = 0; i < arr.Count; i++)
                {
                    if (arr.ToList()[i] > num)
                    {
                        arr.AddBefore(arr.Find(arr.ToList()[i]), num);
                        arr.RemoveLast();
                        break;
                    }
                }
                Output += i == arr.Count ? "0 " : arr.Count - i - 1 + " ";
            }
            return Output;
        }

        static public string task134(string Input)
        {
            string Output = "0 0 ";
            int width = Convert.ToInt32(Input.Split(' ')[0]);
            int height = Convert.ToInt32(Input.Split(' ')[1]);
            int length = Convert.ToInt32(Input.Split(' ')[2]);
            int x = 1, y = 1, x0 = 0, y0 = 0;
            for (int i = 0; i < 100; i++)
            {
                Output += x + " " + y + " ";
                if ((x - x0 > 0 & x != width - length) | x == 0)
                {
                    x0 = x;
                    x++;
                }
                else
                {
                    x0 = x;
                    x--;
                }
                if ((y - y0 > 0 & y != height - 1) | y == 0)
                {
                    y0 = y;
                    y++;
                }
                else
                {
                    y0 = y;
                    y--;
                }
            }
            return Output;
        }

        static public string task127(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\w+)");
            StreamReader reader = new StreamReader(@"tast127dict.txt");
            string[] dict = reader.ReadToEnd().Split(new string[] {"\r\n"}, StringSplitOptions.None);
            reader.Close();
            int count = 0;
            foreach (Match inWord in inputPtrn.Matches(Input))
            {
                foreach (string word in dict)
                {
                    if (word == inWord.Value)
                        continue;
                    var temp = word.ToList();
                    var temp2 = inWord.Value.ToList();
                    temp.Sort();
                    temp2.Sort();
                    count += new string(temp.ToArray()) == new string(temp2.ToArray()) ? 1 : 0;
                }
                Output += count + " ";
                count = 0;
            }
            return Output;
        }

        static public string task75(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d) (\d) (\d) (\d) (\d)");
            foreach (Match dices in inputPtrn.Matches(Input))
            {
                string[] temp=dices.Value.Split(' ');
                if (temp.Distinct().ToList().Count == 4)
                    Output += "pair ";
                else if (temp.Distinct().ToList().Count == 3)
                {
                    if (temp.GroupBy(x => x).Max(x=>x.Count())==3)
                        Output += "three ";
                    else
                        Output += "two-pairs ";
                }
                else if (temp.Distinct().ToList().Count == 2)
                {
                    if (temp.GroupBy(x => x).Max(x => x.Count()) == 4)
                        Output += "four ";
                    else
                        Output += "full-house ";
                }
                else if (temp.Distinct().ToList().Count == 1)
                    Output += "yacht ";
                else if (!temp.ToList().Contains("6"))
                    Output += "small-straight ";
                else if (!temp.ToList().Contains("1"))
                    Output += "big-straight ";
                else
                    Output += "none ";
            }
            return Output;
        }

        static public string task74(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+):(\d+)");
            double hour = 0, min = 0, hourX = 0, hourY = 0, minX = 0, minY = 0;
            foreach (Match time in inputPtrn.Matches(Input))
            {
                min = Convert.ToInt32(time.Groups[2].Value);
                hour = (Convert.ToInt32(time.Groups[1].Value) % 12) + min / 60;
                hourX = 10 + 6 * Math.Sin((30 * hour) * Math.PI / 180);
                hourY = 10 + 6 * Math.Cos((30 * hour) * Math.PI / 180);
                minX = 10 + 9 * Math.Sin((6 * min) * Math.PI / 180);
                minY = 10 + 9 * Math.Cos((6 * min) * Math.PI / 180);
                Output += string.Format("{0:0.0#######} {1:0.0#######} {2:0.0#######} {3:0.0#######} ", hourX, hourY, minX, minY);
            }
            return Output.Replace(',', '.');
        }

        //static public string ArtemTask(string Input)
        //{
        //    int sum = 0, a, b;
        //    for (int i = 1; i < 10; i++)
        //    {
        //        a = 0;
        //        b = i;
        //        for (int j = 0; j <= i; j++)
        //        {
        //            int num = i * 100 + a * 10 + b;
        //            sum += num;
        //            a++;
        //            b--;
        //        }
        //    }
        //    return sum.ToString();
        //}

        static public string task36(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d)");
            int[] asd = new int[4];
            List<string> cases = new List<string>();
            cases = inputPtrn.Matches(Input).Cast<Match>().Select(m => m.Value).ToList();
            List<int>[] codes = new List<int>[4] { new List<int>(), new List<int>(), new List<int>(), new List<int>() };
            for (int i=0;i<4;i++)
            {
                for (int j = 0; j < 10; j++)
                    codes[i].Add(j);
            }            
            while (cases.Count !=0)
            {
                for (int i = 0; i < cases.Count; i++)
                {
                    if (cases[i].Substring(5, 1) == "0")
                    {
                        codes[0].Remove(Convert.ToInt32(cases[i].Substring(0, 1)));
                        codes[1].Remove(Convert.ToInt32(cases[i].Substring(1, 1)));
                        codes[2].Remove(Convert.ToInt32(cases[i].Substring(2, 1)));
                        codes[3].Remove(Convert.ToInt32(cases[i].Substring(3, 1)));
                        cases.RemoveAt(i);
                    }
                    else if (cases[i].Substring(5, 1) != "0")
                    {
                        int index = 0;
                        int a = 0;
                        //int a = cases[i].Substring(0, 4).Count(x => codes[index++].Contains(Convert.ToInt32(x.ToString())));
                        int b = Convert.ToInt32(cases[i].Substring(5, 1));
                        List<int> indexes = new List<int>();
                        foreach (char ch in cases[i])
                        {
                            if (ch == ' ')
                                break;
                            if (codes[index].Contains(Convert.ToInt32(ch.ToString())))
                            {
                                a++;
                                indexes.Add(index);
                            }
                            index++;
                        }
                        if (a == b)
                        {
                            foreach (int n in indexes)
                                codes[n].RemoveAll(x => x != Convert.ToInt32(cases[i].Substring(n, 1)));
                            cases.RemoveAt(i);
                        }
                        else if (b <= codes.Count(x => x.Count == 1))
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (codes[j].Count == 1)
                                    continue;
                                codes[j].Remove(Convert.ToInt32(cases[i].Substring(j, 1)));
                            }
                            cases.RemoveAt(i);
                        }
                    }
                }
            }
            Output = codes[0][0].ToString() + codes[1][0].ToString() + codes[2][0].ToString() + codes[3][0].ToString();
            return Output;
        }

        static public string task171(string Input)
        {
            string Output = "";
            Regex inputPtrn = new Regex(@"(\d+) (\d+,\d+)");
            double D = 0, A = 0;
            foreach (Match tree in inputPtrn.Matches(Input.Replace('.', ',')))
            {
                D = Convert.ToDouble(tree.Groups[1].Value);
                A = Convert.ToDouble(tree.Groups[2].Value) % 90;
                Output += Math.Round(D * Math.Tan(A * Math.PI / 180)) + " ";
            }
            return Output;
        }

        static public string task73(string Input)
        {
            string Output = "", line = "";
            StringReader reader = new StringReader(Input);
            double distance = 0, height = 0, width = 0;
            while ((line = reader.ReadLine()) != null)
            {
                height = 0; width = 0;
                foreach (char ch in line)
                {
                    switch (ch)
                    {
                        case 'A':
                            width++;
                            break;
                        case 'D':
                            width--;
                            break;
                        case 'B':
                            width += 0.5;
                            height += 0.8660254037844386;
                            break;
                        case 'C':
                            width -= 0.5;
                            height += 0.8660254037844386;
                            break;
                        case 'F':
                            width += 0.5;
                            height -= 0.8660254037844386;
                            break;
                        case 'E':
                            width -= 0.5;
                            height -= 0.8660254037844386;
                            break;
                    }
                }
                distance = Math.Sqrt(width * width + height * height);
                Output += string.Format("{0:0.0#######} ", distance).Replace(',','.');
            }
            return Output;
        }

        static public string task156(string Input)
        {
            string Output = "", cardNumbers = "", tempNumbers="";
            StringReader reader = new StringReader(Input);
            int n=0;
            while ((cardNumbers = reader.ReadLine()) != null)
            {
                if (cardNumbers.Contains('?'))
                {
                    n = cardNumbers.IndexOf('?');
                    cardNumbers = cardNumbers.Replace('?', '0');
                    while (GetChecksum(cardNumbers) % 10 != 0)
                    {
                        var temp = cardNumbers.ToArray();
                        temp[n] = (Convert.ToInt16(cardNumbers.Substring(n, 1)) + 1).ToString()[0];
                        cardNumbers = new string(temp);
                    }
                }
                else
                {
                    tempNumbers = cardNumbers;
                    n = 0;
                    while (GetChecksum(cardNumbers) % 10 != 0)
                    {
                        cardNumbers = tempNumbers;
                        var temp = cardNumbers.ToArray();
                        char t = temp[n];
                        temp[n] = temp[n + 1];
                        temp[n + 1] = t;
                        cardNumbers = new string(temp);
                        n++;
                    }
                }
                Output += cardNumbers + " ";
            }
            return Output;
        }
        public static int GetChecksum(string cardNumbers)
        {
            int checksum = 0, n=0;
            for (int i = 15; i >= 0; i--)
            {
                n = Convert.ToInt16(cardNumbers[i].ToString());
                if (i % 2 != 0)
                    checksum += n;
                else
                    checksum += n * 2 < 10 ? n * 2 : n * 2 - 9;
            }
            return checksum;
        }


        static public string task54(string Input)
        {
            string Output = "";
            int[,] test = new int[3, 3] { { 3, 2, 1 }, { 2, 1, 0 }, { 1, 0, 0 } };


            return Search(test, 4);
        }


        public static string Search(int[,] m, int N)
        {
            string Output = "";
            bool flag = false;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == N)
                    {
                        flag = true;
                        Output += i + " " + j + "; ";
                    }
                }
            }
            if (flag == true)
                return Output;
            else
                return "Not found";
        }

        public static string BSearch(int[,] m, int N)//binary search
        {
            string Output = "";
            bool flag = false;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == N)
                    {
                        flag = true;
                        Output += i + " " + j + "; ";
                    }
                }
            }
            if (flag == true)
                return Output;
            else
                return "Not found";
        }

        /*

Well, if you actually do have a sorted array, you can do a binary search until you find one of the indexes you're looking for, and from there, the rest should be easy to find since they're all next to each-other.

once you've found your first one, than you go find all the instances before it, and then all the instances after it.

Using that method you should get roughly O(lg(n)+k) where k is the number of occurrences of the value that you're searching for.

EDIT:

And, No, you will never be able to access all k values in anything less than O(k) time.


Second edit: so that I can feel as though I'm actually contributing something useful:

Instead of just searching for the first and last occurrences of X than you can do a binary search for the first occurence and a binary search for the last occurrence. which will result in O(lg(n)) total. once you've done that, you'll know that all the between indexes also contain X(assuming that it's sorted)

You can do this by searching checking if the value is equal to x , AND checking if the value to the left(or right depending on whether you're looking for the first occurrence or the last occurrence) is equal to x.
*/




    }
}
