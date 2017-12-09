using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());

            //var input = Console.ReadLine();
            //var tokens = input.Split(' ');
            //var a = int.Parse(tokens[0]);
            //var b = int.Parse(tokens[1]);


            //string[] ar_temp = Console.ReadLine().Split(' ');
            //long[] ar = Array.ConvertAll(ar_temp, Int64.Parse);

            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            var n = int.Parse(tokens[0]);
            var capacity = int.Parse(tokens[1]);


            List<int> values = new List<int>();
            List<int> weights = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var input2 = Console.ReadLine();
                var tokens2 = input2.Split(' ');
                values.Add(int.Parse(tokens2[0]));
                weights.Add(int.Parse(tokens2[1]));

            }

            Console.WriteLine(get_optimal_value(capacity, weights, values));


            //Console.WriteLine(fibonacci_fast(n));
            //Console.WriteLine(fibonacci_lastDigit(n));
            // Console.WriteLine(gcd_naive(a,b));
            //Console.WriteLine(gcd(a, b));


           // Console.WriteLine(findChange(a));
        }

        private static double get_optimal_value(int capacity, List<int> weights, List<int> values)
        {
            double result = 0;
            Dictionary<int, double> unit = new Dictionary<int, double>();
            

            for (int i = 0; i < weights.Count; i++)
            {
                double perunit = (double) values[i] / weights[i];
                unit.Add(i, perunit);
            }

            // Use OrderBy method.
            foreach (var item in unit.OrderByDescending(i => i.Value))
            {

                if (capacity >= weights[item.Key])
                {
                    result += values[item.Key];
                    capacity -= weights[item.Key];
                }
                else if (capacity == 0)
                {
                    break;
                }
                else 
                {
                    double remain = (double) weights[item.Key] / capacity;
                    result += (double) values[item.Key] / remain ;
                    break;
                }

         
            }




            return Math.Round(result, 4);
        }

        private static int findChange(int a)
        {
            
            int count = 0;

            while (a >= 10)
            {
                count++;
                a = a - 10;
            }

            while (a >= 5)
            {
                count++;
                a = a - 5;
            }

            while (a >= 1)
            {
                count++;
                a = a - 1;
            }

            return count;
        }

        public static int fibonacci_fast(int i)
        {
            // write your code here

            int previous = 0;
            int current = 1;
            int result = i;

            for (int n = 0; n < i - 1; ++n)
            {
                result = previous + current;
                previous = current;
                current = result;
            }

            return result;
        }

        public static int fibonacci_lastDigit(int i)
        {
            // write your code here

            int previous = 0;
            int current = 1;
            int result = i;

            for (int n = 0; n < i - 1; ++n)
            {
                result = (previous + current) % 10;
                previous = current;
                current = result;
            }

            return result;
        }

        public static void test_solution()
        {
            //assert(fibonacci_fast(3) == 2);
            //assert(fibonacci_fast(10) == 55);
            //for (int n = 0; n < 20; ++n)
            //    assert(fibonacci_fast(n) == fibonacci_naive(n));
        }


        public static int gcd_naive(int a, int b)
        {
            int current_gcd = 1;
            for (int d = 2; d <= a && d <= b; d++)
            {
                if (a % d == 0 && b % d == 0)
                {
                    if (d > current_gcd)
                    {
                        current_gcd = d;
                    }
                }
            }
            return current_gcd;
        }

        public static int gcd(int a, int b)
        {

            int rem = a % b;
            while (rem != 0)
            {
                a = b;
                b = rem;
                rem = a % b;
            }       

            return b;
        }

        public static string LongestSeq(string strPass)
        {
            int longestSeq = 0;

            char[] strChars = strPass.ToCharArray();

            int numCurrSeq = 1;
            int startNum = 0;
            int startLongNum = 0;
            for (int i = 0; i < strChars.Length - 1; i++)
            {
                if (strChars[i] == strChars[i + 1])
                {
                    numCurrSeq++;
                }
                else
                {
                    numCurrSeq = 1;
                    startNum = i + 1;
                }

                if (longestSeq < numCurrSeq)
                {
                    longestSeq = numCurrSeq;
                    startLongNum = startNum;
                }
            }

            return string.Format("{0}{1}", longestSeq, startLongNum);
        }

        public static string CountSeq(string strPass)
        {
            int longestSeq = 0;


            char[] strChars = strPass.ToCharArray();

            int numCurrSeq = 1;
            string result = "";
            for (int i = 0; i < strChars.Length - 1; i++)
            {
                if (strChars[i] == strChars[i + 1])
                {
                    numCurrSeq++;
                }
                else
                {
                    result += string.Format("{0}{1}", strChars[i].ToString(), numCurrSeq);
                    numCurrSeq = 1;
                }

                //if (longestSeq < numCurrSeq)
                //{
                //    longestSeq = numCurrSeq;
                //}
            }
            result += string.Format("{0}{1}", strChars[strChars.Length - 1].ToString(), numCurrSeq);
            return result;
        }

    }
}


