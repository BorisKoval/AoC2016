using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace AoC_2016.Codeabbey
{
    static class CdbTasks
    {
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

    }
}
