using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace PhoneNumberGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Korea Phone Number Generator";
            string fmt = "00000000";
            Stopwatch stopwatch = new Stopwatch();
            string stemp1;
            stopwatch.Reset();
            int temp = 0;
            if (!File.Exists("phone.txt"))
            {
                File.WriteAllText("phone.txt", "");
            }
            else
            {
                Console.WriteLine("이전데이터를발견했습니다");
                Console.WriteLine("이전데이터를불러와서 이어서작업하시겠습니까? 작업하시려면 Y를 아니면 N 을 입력해주세요");
                string input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    string[] tempa = File.ReadAllLines("phone.txt");
                    int tempacount = tempa.Length;
                    temp = tempacount;
                }
                else
                {
                    File.Delete("phone.txt");
                    File.WriteAllText("phone.txt", "");
                }
            }
            stopwatch.Start();
            while (temp != 99999999)
            {
                stemp1 = stopwatch.Elapsed.ToString();
                Console.Title = "Korea Phone Number Generator - " + stemp1;
                string s = temp.ToString(fmt);
                temp++;
                string s1 = s.Substring(0, 4);
                string s2 = s.Substring(4);
                string result = "010-" + s1 + "-" + s2;
                Console.WriteLine(result);
                StreamWriter sw = new StreamWriter("phone.txt", true);
                sw.WriteLine(result);
                sw.Close();
            }
            Console.Clear();
            stopwatch.Stop();
            stemp1 = stopwatch.Elapsed.ToString();
            Console.WriteLine("Sucess");
            Console.WriteLine("경과시간 : " + stemp1);
            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
