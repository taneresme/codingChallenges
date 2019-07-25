using System;

namespace pascal_triangle
{
    /*
Given a positive integer K, return the Kth row of pascal triangle.
Pascal's triangle is a triangular array of the binomial coefficients formed by summing up the elements of previous row.

Example :
1
1 1
1 2 1
1 3 3 1
For K = 3, return 3rd row i.e 1 2 1

Input:
First line contains an integer T, total number of test cases. Next T lines contains an integer N denoting the row of triangle to be printed.

Output:
Print the Nth row of triangle in a separate line.

Constraints:
1 ≤ T ≤ 50
1 ≤ N ≤ 25

Example:
Input:
1
4
Output:
1 3 3 1
     */
    class Program
    {
        static int[][] values;
        static void Main(string[] args)
        {
            int test = int.Parse(Console.ReadLine());

            for (int i = 0; i < test; i++)
            {
                int line = int.Parse(Console.ReadLine());

                values = new int[line + 1][];

                values = pascal(1, line);

                for (int j = 0; j < values[line].Length; j++)
                {
                    Console.Write(String.Format("{0} ", values[line][j]));
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static int[][] pascal(int index, int line)
        {
            if (index > line) return values;

            if (index == 1)
            {
                values[index] = new int[] { 1 };
                return pascal(index + 1, line);
            }
            if (index == 2)
            {
                values[index] = new int[] { 1, 1 };
                return pascal(index + 1, line);
            }

            values[index] = new int[values[index - 1].Length + 1];
            values[index][0] = 1;
            values[index][values[index - 1].Length] = 1;
            for (int i = 0; i < values[index - 1].Length - 1; i++)
            {
                values[index][i + 1] = values[index - 1][i] + values[index - 1][i + 1];
            }
            return pascal(index + 1, line);
        }
    }
}
