using System;

namespace stock_buy_and_sell
{
    /*
The cost of stock on each day is given in an array A[] of size N. Find all the days on which you buy and sell the stock 
so that in between those days your profit is maximum.

Input: 
First line contains number of test cases T. First line of each test case contains an integer value N denoting the number of days, 
followed by an array of stock prices of N days. 

Output:
For each testcase, output all the days with profit in a single line. And if there is no profit then print "No Profit".

Constraints:
1 <= T <= 100
2 <= N <= 103
0 <= Ai <= 104

Example
Input:
2
7
100 180 260 310 40 535 695
10
23 13 25 29 33 19 34 45 65 67

Output:
(0 3) (4 6)
(1 4) (5 9)

Explanation:
Testcase 1: We can buy stock on day 0, and sell it on 3rd day, which will give us maximum profit.

Note: Output format is as follows - (buy_day sell_day) (buy_day sell_day)
For each input, output should be in a single line.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int test = int.Parse(Console.ReadLine());

            for (int i = 0; i < test; i++)
            {
                int n = int.Parse(Console.ReadLine());
                string[] line = Console.ReadLine().Split(' ');
                /* prepare stocks */
                int[] stocks = new int[n];
                for (int j = 0; j < n; j++)
                {
                    stocks[j] = int.Parse(line[j]);
                }

                Maximize(stocks, n);
            }
        }

        static void Maximize(int[] stocks, int n)
        {
            int profit = 0;
            int localMin = stocks[0];
            int localMinIndex = 0;
            int localMax = -1;
            int localMaxIndex = -1;
            for (int i = 1; i < n; i++)
            {
                if (stocks[i] < localMin || stocks[i] < stocks[i - 1])
                {
                    if (localMax > -1)
                    {
                        profit += stocks[localMaxIndex] - stocks[localMinIndex];
                        Console.Write(string.Format("({0} {1}) ", localMinIndex, localMaxIndex));
                        localMax = -1;
                        localMaxIndex = -1;
                    }
                    localMin = stocks[i];
                    localMinIndex = i;
                }
                else if (stocks[i] > localMax)
                {
                    localMax = stocks[i];
                    localMaxIndex = i;
                }
            }

            if (localMax > -1)
            {
                profit += stocks[localMaxIndex] - stocks[localMinIndex];
                Console.Write(string.Format("({0} {1}) ", localMinIndex, localMaxIndex));
            }
            if (profit == 0)
            {
                Console.Write("No Profit");
            }

            Console.WriteLine();
        }
    }
}
