using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview1
{
    class Sum3Or5Not15
    {
        // Helper
        public static bool Is3Or5Not15(int i)
        {
            return i % 15 != 0 && (i % 3 == 0 || i % 5 == 0); // Not divisible 15 but 3 or 5
        }

        // Solution 1 recursive linear time
        public static int Sum3Or5Not15Recur(int n)
        {
            // Base case
            if (n < 3) return 0;

            // Recursive
            if (Is3Or5Not15(n)) return Sum3Or5Not15Recur(n - 1) + n;
            return Sum3Or5Not15Recur(n - 1);
        }

        // Solution 2 loop linear time
        public static int Sum3Or5Not15Loop(int n)
        {
            int sum = 0;
            for (int i = n; i > 2; i--)
                if (Is3Or5Not15(i)) sum += i;
            return sum;
        }

        // Solution 3 constant time
        public static int Sum3Or5Not15Alt(int n)
        {
            int div3 = n / 3;
            int div5 = n / 5;
            int div15 = n / 15;

            // If you can make SumOfSeq without a loop, then you get constant time
            // i.e. is there a function SumOfSeq(3, n) = 3 + 3*2 + 3*3 + 3*4 + ... + 3*n in constant time?
            //
            // With a bit of quick math:
            // 3(1 + 1*2 + 1*3 + 1*4 + ... + 1*n) = 3(1 + 2 + 3 + 4 + ... + n)
            // 
            // Turns out 1 + 2 + 3 + 4 + ... + n is called sum of sequence
            // and is equal to (n x (n + 1) ) / 2
            return SumOfSeq(3, div3) + SumOfSeq(5, div5) - (2 * SumOfSeq(15, div15));
        }

        // Helper
        public static int SumOfSeq(int n, int times)
        {
            return n * (times * (times + 1)) / 2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Sum3Or5Not15Recur(100));
            Console.WriteLine(Sum3Or5Not15Loop(100));
            Console.WriteLine(Sum3Or5Not15Alt(100));
        }
    }
}
