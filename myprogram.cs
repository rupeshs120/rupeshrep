using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            //moves are either U,D,L,R
            //Please enter the values which are correct here
            var valueparam = new[] { "U", "D", "L", "R" };
            if (!valueparam.Any(moves.Contains))
            {
                //Not throwing a fatal exception because i want the program to continue. 
                Console.WriteLine("Please enter the correct input U,D,L,R");
            }
            else
            {
                //Time Complexity: O(N), where N is the length of the string.
                bool pos = JudgeCircle(moves);
                if (pos)
                {
                    Console.WriteLine("The Robot return’s to initial Position (0,0)");
                }
                else
                {
                    Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
                }

                Console.WriteLine();
            }

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s.ToLower());//Making sure to convert everyting to lower case.
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            //Time complexity is O(N) where N is the length of the array. 
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);


            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            //Time complexity is again O(n) where is the length of the array. 
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            //Make sure if the user does not enter anything we simply move ahead by giving them a message. 
            if(word1.Length ==0 || word2.Length ==0)
            {
                Console.WriteLine("Words passed in are empty or null");
            }
            //Time complexity is O(n1)*O(n2) cause we need to iterate through both the words to form the merged sentence. 
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }


        ///
        /// <returns></returns>
        private static bool JudgeCircle(string moves)
        {
            try
            {
                int lr = 0;//Indicating a left or a right move
                int ud = 0;//Indicating Up or Down move. 
                foreach (char c in moves)
                {
                    //A left move is considered a negative move, a right move is considered as 
                    //a positive move. Similarly, with up and down. We will make sure if the 
                    //total moves are comming up to zero or not. 
                    if (c == 'L') lr--;
                    if (c == 'R') lr++;
                    if (c == 'U') ud++;
                    if (c == 'D') ud--;
                }
                return lr == 0 && ud == 0;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// A pangram is a sentence where every letter of the English alphabet appears at least once.
        /// Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
        ///   Example 1:Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
        ///   Output: true
        ///   Explanation: sentence contains at least one of every letter of the English alphabet.

        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool CheckIfPangram(string s)
        {
            try
            {
                // I m using a group by clause on the string that is passed in. 
                //So each letter in the string passed in will have its own unique group. 
                //If, the count of those group could not be 26 it means that we do not 
                //have all the alphabet in the string. 

                return s.GroupBy(i => i).Count() == 26; ;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Given an array of integers nums 
        /// A pair(i, j) is called good if nums[i] == nums[j] and i<j.
        /// Return the number of good pairs.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int NumIdenticalPairs(int[] arr)
        {
            try
            {
                int count = 0;
                //Get the length of the array that was passed in. 
                int l = arr.Length;

                for (int i = 0; i < l; i++)
                {
                    for (int j = i + 1; j < l; j++)
                    {
                        //Basically check the first digit with the other digit. if they are 
                        //same just move the counter up since this is good pair. 
                        if (arr[i] == arr[j])
                            count++;
                    }
                }
                return count;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Given an array of integers nums, calculate the pivot index of this array.
        /// The pivot index is the index where the sum of all the numbers strictly to the left of  the index
        /// is equal to the sum of all the numbers strictly to the index's right.If the index is on the left edge
        /// of the array, then the left sum is 0 because there are no elements to the left.
        /// This also applies to the right edge of the array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private static int PivotIndex(int[] nums)
        {
            try
            {
                int leftSum = 0;
                int rightSum = nums.Sum();
                for (int i = 0; i < nums.Length; i++)
                {
                    leftSum += nums[i];
                    if (leftSum == rightSum)
                    {
                        return i;
                    }
                    rightSum -= nums[i];
                }
                return -1;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order,
        /// starting with word1. If a string is longer than the other,
        /// append the additional letters onto the end of the merged string.
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                string result = "";
                int i = 0, j = 0;
                while (i < word1.Length || j < word2.Length)
                {

                    if (i < word1.Length)
                        result = result + word1[i];

                    if (j < word2.Length)
                        result = result + word2[j];

                    i++;
                    j++;
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        /// <summary>
        /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only
        /// We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
        /// The rules of Goat Latin are as follows:
        /// 1. If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word. For example, the word 'apple' becomes 'applema'.
        /// 2. If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
        ///For example, the word "goat" becomes "oatgma".
        ///3)Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
        ///For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                var words = sentence.Split();
                StringBuilder sb = new StringBuilder();
                StringBuilder a = new StringBuilder();
                a.Append("a");

                foreach (var word in words)
                {
                    if ("aeiou".Contains(word[0], StringComparison.OrdinalIgnoreCase))
                    {
                        sb.Append(word);
                    }
                    else
                    {
                        sb.Append(word.Substring(1));
                        sb.Append(word[0]);
                    }
                    sb.Append("ma");
                    sb.Append(a.ToString());
                    a.Append("a");
                    sb.Append(" ");
                }

                sb.Length--;
                return sb.ToString();

            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}




