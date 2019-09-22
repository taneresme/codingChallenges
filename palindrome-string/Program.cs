using System;

namespace palindrome_string
{
    /*
Allie loves strings which are palindrome. 
She has a string. If the string is not palindrome then she plans 
to remove 1 character from the string. Tell her if it is possible to get a string which is palindrome.

Input Format
Input consists of a single line containing the string S

Constraints
1 <= Length of String S <= 3 x 10^6

Output Format
Ouput consist of a single line as "YES" or "NO". Quotes are just for clarity.

Sample Input
mohittihhom

Sample Output
YES

Explanation
if we delete the 8th element 'h' of the string then the resultant string "mohittihom" is a palindrome. 
Therefore the output is YES.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            str = "mohittihhom";
            Console.WriteLine(palindromeRecursive(str) ? "YES" : "NO");
            Console.ReadKey();
        }

        static bool palindromeRecursive(string str)
        {
            if (palindrome(str)) return true;
            for (int i = 0; i < str.Length; i++)
            {
                if (palindrome(str.Remove(i, 1))) return true;
            }
            return false;
        }

        static bool palindrome(string str)
        {
            if (str.Length == 1) return true;

            var leftEnd = str.Length % 2 > 0 
                ? str.Length / 2 
                : (str.Length / 2) - 1;

            for (int i = 0; i < leftEnd; i++)
            {
                if (!str[i].Equals(str[str.Length - i - 1])) return false;
            }
            return true;
        }
    }
}
