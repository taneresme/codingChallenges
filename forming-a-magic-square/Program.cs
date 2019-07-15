using System;
using System.Collections.Generic;

namespace forming_a_magic_square
{
    /* 
     * Solution of https://www.hackerrank.com/challenges/magic-square-forming/problem in a generic way!
     */
    class Program
    {
        static void Main(string[] args)
        {
            //int[][] s = new int[][] {
            //    new int[]{4, 9, 2 },
            //    new int[]{3, 5, 7 },
            //    new int[]{8, 1, 5 },
            //};
            int[][] s = new int[][] {
                new int[]{4, 8, 2},
                new int[]{4, 5, 7},
                new int[]{6, 1, 6},
            };

            int result = formingMagicSquare(s);

            Console.WriteLine(result);
            Console.ReadKey();
        }
        
        static int formingMagicSquare(int[][] s)
        {
            int n = s.Length;
   
            List<int[][]> magics = Build(n, 0, 0);

            int min = 9999;
            foreach (int[][] magic in magics)
            {
                int diff = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        diff += Math.Abs(magic[i][j] - s[i][j]);
                    }
                }
                if (diff < min) min = diff;
            }
            return min;
        }

        static List<int[][]> Build(int n, int x, int y)
        {
            int[] digits = new int[n * n];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = i + 1;
            }

            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[n];
            }

            return Fill(arr, n, digits, 0, 0);
        }

        static List<int[][]> Fill(int[][] arr, int n, int[] digits, int x, int y)
        {
            List<int[][]> magics = new List<int[][]>();

            for (int i = 0; i < digits.Length; i++)
            {
                List<int> bst = new List<int>(digits);
                arr[x][y] = digits[i];
                bst.Remove(digits[i]);

                if (x + 1 < n)
                {
                    magics.AddRange(Fill(arr, n, bst.ToArray(), x + 1, y));
                }
                else if (y + 1 < n)
                {
                    magics.AddRange(Fill(arr, n, bst.ToArray(), 0, y + 1));
                }
            }

            if (IsMagic(arr, n))
            {
                int[][] clone = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    clone[j] = (int[])arr[j].Clone();
                }
                magics.Add(clone);
            }

            return magics;
        }

        static bool IsMagic(int[][] s, int n)
        {
            int[] totals = new int[n * 2 + 2];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    totals[j] += s[j][i];
                    totals[n + j] += s[i][j];
                }

                totals[totals.Length - 2] += s[i][i];
                totals[totals.Length - 1] += s[i][n - i - 1];
            }

            for (int i = 0; i < totals.Length - 1; i++)
            {
                if (totals[i] != totals[i + 1])
                    return false;
            }

            return true;
        }
    }

}