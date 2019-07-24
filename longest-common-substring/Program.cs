using System;

namespace longest_common_substring
{
    /*
Given two strings X and Y. The task is to find the length of the longest common substring.

Input:
First line of the input contains number of test cases T. Each test case consist of three lines, 
first of which contains 2 space separated integers N and M denoting the size of string X and Y strings respectively.
The next two lines contains the string X and Y.

Output:
For each test case print the length of longest  common substring of the two strings .

Constraints:
1 <= T <= 200
1 <= N, M <= 100

Example:
Input:
2
6 6
ABCDGH
ACDGHR
3 2
ABC
AC

Output:
4
1

Example:
Testcase 1: CDGH is the longest substring present in both of the strings.
     */
    class Program
    {
        static int[][] results;

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
                        results[j][k] = 0;
                    }
                }

                Console.WriteLine(lcs(x, y, x.Length, y.Length));
                Console.ReadKey();
            }
        }

        static int lcs(string x, string y, int m, int n)
        {
            int xMax = 0;
            int iMax = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (x[i - 1].Equals(y[j - 1]))
                    {
                        results[i][j] = results[i - 1][j - 1] + 1;
                        if (results[i][j] > xMax)
                        {
                            xMax = results[i][j];
                            iMax = i;
                        }
                    }
                }
            }

            return x.Substring(iMax - xMax, xMax).Length;
        }
    }
}
