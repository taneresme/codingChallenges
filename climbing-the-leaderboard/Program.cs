using System;
using System.Collections.Generic;

namespace climbing_the_leaderboard
{
    /*
     * Solution to https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[] { 100, 100, 50, 40, 40, 20, 10 };
            int[] alice = new int[] { 5, 25, 50, 120 };
            //result 6 4 2 1
            var result = climbingLeaderboard(scores, alice);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            List<int> positions = new List<int>();
            int[] scoresPositions = new int[scores.Length];
            scoresPositions[0] = 1;

            for (int i = 1; i < scores.Length; i++)
            {
                scoresPositions[i] = scoresPositions[i - 1];
                if (scores[i] < scores[i - 1])
                    scoresPositions[i]++;
            }

            int j = scores.Length - 1;
            for (int i = 0; i < alice.Length; i++)
            {
                j = findPosition(i, j, alice, scores, scoresPositions, positions);
            }

            return positions.ToArray();
        }

        static int findPosition(int i, int j, int[] alice, int[] scores, int[] scoresPositions, List<int> positions)
        {
            for (; j >= 0; j--)
            {
                if (alice[i] < scores[j])
                {
                    break;
                }
                else if (alice[i] == scores[j])
                {
                    positions.Add(scoresPositions[j]);
                    return j;
                }
            }
            if (j < 0)
            {
                positions.Add(1);
                return j;
            }
            positions.Add(scoresPositions[j] + 1);
            return j;
        }
    }
}
