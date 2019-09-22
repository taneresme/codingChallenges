using System;
using System.Collections.Generic;

namespace anagram
{
    /*
Given two strings a and b consisting of lowercase characters. 
The task is to check whether two given strings are anagram of each other or not. 
An anagram of a string is another string that contains same characters, 
only the order of characters can be different. For example, “act” and “tac” are anagram of each other.

Input:
The first line of input contains an integer T denoting the number of test cases. 
Each test case consist of two strings in 'lowercase' only, in a single line.

Output:
Print "YES" without quotes if the two strings are anagram else print "NO".

Constraints:
1 ≤ T ≤ 300
1 ≤ |s| ≤ 1016

Example:
Input:
2
geeksforgeeks forgeeksgeeks
allergy allergic

Output:
YES
NO

Explanation:
Testcase 1: Both the string have same characters with same frequency. So, both are anagrams.
Testcase 2: Characters in both the strings are not same, so they are not anagrams.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                var strings = Console.ReadLine().Split(' ');

                Console.WriteLine(anagram(strings) ? "YES" : "NO");

                Console.ReadKey();
            }
        }

        static bool anagram(string[] str)
        {
            if (str[0].Length != str[1].Length)
                return false;

            var str1 = new List<char>(str[0]);
            str1.Sort();
            var str2 = new List<char>(str[1]);
            str2.Sort();

            for (int i = 0; i < str1.Count; i++)
            {
                if (!str1[i].Equals(str2[i])) return false;
            }

            return true;
        }
    }
}
