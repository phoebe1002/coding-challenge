using System;
using System.Collections.Generic;

namespace permutations
{    
    /*
    Given array of distinct integers, print all permutations of the array.
    For example :
    array : [10, 20, 30]

    Permutations are :

    [10, 20, 30]
    [10, 30, 20]
    [20, 10, 30]
    [20, 30, 10]
    [30, 10, 20]
    [30, 20, 10]

    Pick up an array of your choice and write the code that will print all the permutations.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = {10, 20, 30};
            List<Stack<int>> result = permute(input);
            foreach(Stack<int> combination in result)
            {
                Console.WriteLine("[{0}]",string.Join(",", combination)); 
            }
        }

        static List<Stack<int>> permute(int[] input)
        {
            int len = input.Length;
            List<Stack<int>> result = new List<Stack<int>>();
            if (len == 0) return result;
            Boolean[] used = new Boolean[len];
            Stack<int> paths = new Stack<int>();
            permute(input, len, 0, paths, used, result);
            return result;
        }

        private static void permute(int[] input, int len, int depth, Stack<int> paths, bool[] used, List<Stack<int>> result)
        {
            if (depth == len) 
            {
                result.Add(new Stack<int>(paths));
                return;
            }
            for (int i = 0; i < len; i++)
            {
                if (!used[i])
                {
                    paths.Push(input[i]);
                    used[i] = true;

                    permute(input, len, depth + 1, paths, used, result);

                    used[i] = false;
                    paths.Pop();
                }
            }
        }
    }
}
