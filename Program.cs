using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleMM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = 2;
            while (true) // runs game
            {
                if (value == 1) // stops game
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Total possible numbers");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Total correct inputs");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    int[] poss = Enumerable.Range(1, x).ToArray();
                    var input = Enumerable.Range(1, y).ToList();

                    var rnd = new Random();
                    var ans = Enumerable.Range(1, x).OrderBy(an => rnd.Next()).Take(y).ToList(); // takes y amount of unique random numbers from 1 to x as the final solution
                    /*
                    foreach (int i in ans)
                    {
                        Console.WriteLine(i); // writes the answer
                    }
                    */
                    Console.WriteLine("Try to guess all the unique numbers between 1 and {0}!", x);

                    for (int i = 0; i < input.Count; i++)
                    {
                        try
                        {
                            input[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            i--;
                        }
                    }

                    // sorts both lists to match them
                    input.Sort();
                    ans.Sort();

                    List<int> dups = new List<int>();

                    while (!Enumerable.SequenceEqual(input, ans))
                    {
                        for (int a = 0; a < ans.Count; a++)
                        {
                            for (int b = 0; b < input.Count; b++)
                            {
                                if (ans[a] == input[b])
                                {
                                    dups = ans.Intersect(input).ToList(); // adds all numbers that exists in both lists to dups
                                }
                            }
                        }

                        if (dups.Count < 1)
                        {
                            for (int i = 0; i < input.Count; i++)
                            {
                                poss = poss.Where(val1 => val1 != input[i]).ToArray(); // removes numbers which are not in the final solution
                            }
                            Console.WriteLine("Remaining possible numbers: ");
                            foreach (int i in poss)
                            {
                                Console.WriteLine(i);
                            }
                            Console.WriteLine("None was correct, enter another guess: ");
                        }
                        else if (dups.Count > 0)
                        {
                            Console.WriteLine("{0} was correct, enter another guess: ", dups.Count); // writes the amount of correct numbers
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        for (int i = 0; i < input.Count; i++)
                        {
                            try
                            {
                                input[i] = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                i--;
                            }
                            if (i == y) // resets the for loop
                            {
                                i = 0;
                            }
                            dups.Clear(); // clears the dups list
                        }
                        input.Sort();
                    }

                    Console.Clear();
                    Console.WriteLine("Correct!");
                    foreach (int i in ans)
                    {
                        Console.WriteLine(i);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press 1 to exit or 2 to continue");
                    value = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
            }
        }
    }
}