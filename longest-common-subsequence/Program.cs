using System;

namespace longest_common_subsequence
{
    /*
Given two sequences, find the length of longest subsequence present in both of them. Both the strings are of uppercase.

Input:
First line of the input contains no of test cases  T,the T test cases follow.
Each test case consist of 2 space separated integers A and B denoting the size of string str1 and str2 respectively
The next two lines contains the 2 string str1 and str2 .

Output:
For each test case print the length of longest  common subsequence of the two strings .

Constraints:
1<=T<=200
1<=size(str1),size(str2)<=100

Example:
Input:
2
6 6
ABCDGH
AEDFHR
3 2
ABC
AC

Output:
3
2

Explanation
LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.

LCS of "ABC" and "AC" is "AC" of length 2
     */
    class Program
    {
        static int[][] results;

        /* DP solution with recurrence and memoization */
        static void Main(string[] args)
        {
            var tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                Console.ReadLine();
                var x = Console.ReadLine();
                var y = Console.ReadLine();

                results = new int[x.Length + 1][];
                for (int j = 0; j < x.Length + 1; j++)
                {
                    results[j] = new int[y.Length + 1];
                    for (int k = 0; k < y.Length + 1; k++)
                    {
                        results[j][k] = -1;
                    }
                }
                
                Console.WriteLine(lcs(x, y, x.Length, y.Length));
                Console.ReadKey();
            }
        }

        static int lcs(string x, string y, int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (results[m][n] > -1) return results[m][n];

            if (x[m - 1].Equals(y[n - 1]))
            {
                results[m][n] = lcs(x, y, m - 1, n - 1) + 1;
                return results[m][n];
            }

            results[m][n] = Math.Max(lcs(x, y, m - 1, n), lcs(x, y, m, n - 1));
            return results[m][n];
        }
    }
}
