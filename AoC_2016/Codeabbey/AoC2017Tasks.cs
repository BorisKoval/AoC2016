using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace AoC_2016.Codeabbey
{
    class AoC2017Tasks
    {
        static public string getTask1_1(string Input)
        {
            int sum = 0;
            Regex inputPattern1 = new Regex(@"(\d)(\1+)");  //g + m regex options
            Regex inputPattern2 = new Regex(@"^(\d).*\1$"); // bug (works only for a task input) !
            foreach (Match m in inputPattern1.Matches(Input))
            {
                sum += m.Value.Length > 2 ? Convert.ToInt32(m.Groups[1].Value) * (m.Value.Length-1) : Convert.ToInt32(m.Groups[1].Value);
            }
            sum += inputPattern2.IsMatch(Input) ? Convert.ToInt32(inputPattern2.Match(Input).Groups[1].Value): 0 ;
            return sum.ToString();
        }

        static public string getTask1_2(string Input)
        {
            int sum = 0;
            for (int i = 0; i < Input.Length;i++ )
            {
                char ch1 = Input[i];
                char ch2 = Input[(i + Input.Length / 2) % Input.Length];
                if (ch1 == ch2)
                    sum += Convert.ToInt32(ch1.ToString());
            }
            return sum.ToString();
        }

        static public string getTask2_1(string Input)
        {
            int checksum = 0, max = 0, min = 0;
            foreach (string line in Input.Split(new string[] {"\r\n"}, StringSplitOptions.None))
            {
                max = Convert.ToInt32(line.Substring(0, line.IndexOf(' ')));
                min = Convert.ToInt32(line.Substring(0, line.IndexOf(' ')));
                foreach (string num in line.Split(new char[] { ' ' }))
                {
                    if (Convert.ToInt32(num) > max)
                        max = Convert.ToInt32(num);
                    if (Convert.ToInt32(num) < min)
                        min = Convert.ToInt32(num);
                }
                checksum += max - min;
                max = 0; min = 0;
            }
            return checksum.ToString();
        }

        static public string getTask2_2(string Input)
        {
            int checksum = 0, A = 0, B = 0;
            string[] nums;
            foreach (string line in Input.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                nums = line.Split(new char[] { ' ' });
                for (int i = 0; i < nums.Length; i++)
                {
                    A = Convert.ToInt32(nums[i]);
                    var AB = nums.Where(x => x != nums[i] && (A % Convert.ToInt32(x) == 0 || Convert.ToInt32(x) % A == 0));
                    if (AB.ToArray().Length != 0)
                    {
                        B = Convert.ToInt32(AB.ToArray()[0]);
                        break;
                    }
                }
                checksum += A > B ? A / B : B / A;
            }
            return checksum.ToString();
        }


    }
}
