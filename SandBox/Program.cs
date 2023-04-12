using System;
using System.Collections.Generic;

class Program
{
    static int CountPairs(int[] arr, int k)
    {
        HashSet<int> set = new HashSet<int>();
        int count = 0;

        foreach (int num in arr)
        {
            if (set.Contains(k - num))
            {
                count++;
            }
            set.Add(num);
        }

        return count;
    }

    static int[][] MergeIntervals(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return intervals;
        }

        // Sort the intervals by their starting points
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> mergedIntervals = new List<int[]>();
        mergedIntervals.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] interval = intervals[i];

            // If the current interval overlaps with the last merged interval, merge them
            if (interval[0] <= mergedIntervals[mergedIntervals.Count - 1][1])
            {
                int end = Math.Max(interval[1], mergedIntervals[mergedIntervals.Count - 1][1]);
                mergedIntervals[mergedIntervals.Count - 1][1] = end;
            }
            else
            {
                // Otherwise, add the current interval to the list of merged intervals
                mergedIntervals.Add(interval);
            }
        }

        return mergedIntervals.ToArray();
    }

    static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> complements = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (complements.ContainsKey(complement))
            {
                return new int[] { complements[complement], i };
            }

            complements[nums[i]] = i;
        }

        return new int[0];
    }

    static void ReverseStringFromChar(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;

            left++;
            right--;
        }
    }

    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    //Palindrome is a sentence where you can read the same words, reading sentence backwards
    static bool IsPalindrome(string s)
    {
        s = s.ToLower(); // Ignore cases

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // Ignore non-alphanumeric characters
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }

            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            // Compare characters
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    //Generate combinations
    public static List<List<int>> GenerateCombinations(int n, int p)
    {
        List<List<int>> result = new List<List<int>>();
        GenerateCombinationsHelper(n, p, new List<int>(), result);
        return result;
    }

    private static void GenerateCombinationsHelper(int n, int k, List<int> combination, List<List<int>> result)
    {
        if (k == 0 && n == 0)
        {
            result.Add(new List<int>(combination));
            return;
        }

        if (k == 0 || n == 0)
        {
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            combination.Add(i);
            GenerateCombinationsHelper(n - i, k - 1, combination, result);
            combination.RemoveAt(combination.Count - 1);
        }
    }

    public static int[,] FindPairs(int[] arr, int target)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == target)
                {
                    count++;
                }
            }
        }
        int[,] pairs = new int[count, 2];
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == target)
                {
                    pairs[index, 0] = arr[i];
                    pairs[index, 1] = arr[j];
                    index++;
                }
            }
        }
        return pairs;
    }

    public static bool TwoSumExists(List<int> nums, int target)
    {
        HashSet<int> set = new HashSet<int>();
        foreach (int num in nums)
        {
            int complement = target - num;
            if (set.Contains(complement))
            {
                return true;
            }
            set.Add(num);
        }
        return false;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        int n = s.Length;
        int ans = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();

        for (int j = 0, i = 0; j < n; j++)
        {
            if (map.ContainsKey(s[j]))
            {
                i = Math.Max(map[s[j]], i);
            }
            ans = Math.Max(ans, j - i + 1);
            map[s[j]] = j + 1;
        }

        return ans;
    }

    //Check if anagrams, like silent = listen => true
    static bool AreAnagrams(string str1, string str2)
    {
        string s1 = new string(str1.ToLower().Where(c => !Char.IsWhiteSpace(c)).OrderBy(c => c).ToArray());
        string s2 = new string(str2.ToLower().Where(c => !Char.IsWhiteSpace(c)).OrderBy(c => c).ToArray());

        return s1 == s2;
    }

    //Count chars in a string
    static List<Tuple<char, int>> CountCharacters(string s)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        List<Tuple<char, int>> result = charCount.Select(kvp => Tuple.Create(kvp.Key, kvp.Value)).ToList();
        result.Sort((x, y) => y.Item2.CompareTo(x.Item2));
        return result;
    }

    //Find single one integer that doesn't appear twice
    public static int SingleNumber(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            result ^= nums[i]; // Using XOR to cancel out pairs of numbers
        }
        return result;
    }

    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                    swapped = true;
                }
            }
            n--;
        } while (swapped);
    }

    //Reverse list what ever list input is
    public List<int> ReverseList(List<int> inputList)
    {
        // Create a new list to store the reversed elements
        List<int> reversedList = new List<int>();

        // Loop through the input list in reverse and add each element to the new list
        for (int i = inputList.Count - 1; i >= 0; i--)
        {
            reversedList.Add(inputList[i]);
        }

        return reversedList;
    }

    static void Main(string[] args)
    {
        //Count pairs
        int[] arr = { 1, 5, 3, 4, 2 };
        int k = 6;

        int numPairs = CountPairs(arr, k);

        Console.WriteLine($"Number of pairs that sum up to value {k} is {numPairs} pairs");

        //Merge overlapping intervals
        int[][] intervals = new int[][] {
            new int[] {1, 3},
            new int[] {2, 6},
            new int[] {8, 10},
            new int[] {15, 18}
        };

        int[][] mergedIntervals = MergeIntervals(intervals);

        Console.WriteLine("Merged Intervals:");
        foreach (int[] interval in mergedIntervals)
        {
            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }

        //Two sum of numbers in an array of integers and an integer target, that return the indices of two numbers such that they add up to target
        int[] nums = new int[] { 2, 7, 11, 15 };
        int target = 9;

        int[] indices = TwoSum(nums, target);
        int valueOne = nums[0];
        int valueTwo = nums[1];
        Console.WriteLine($"Indices: [{indices[0]}, {indices[1]}]");
        Console.WriteLine($"Values: {valueOne}, {valueTwo}");

        //Reverse string from char to char, creating new string from char
        char[] s = new char[] { 'h', 'e', 'l', 'l', 'o' };

        Console.WriteLine($"Before: {new string(s)}");

        ReverseStringFromChar(s);

        Console.WriteLine($"After: {new string(s)}");

        //Reverse string
        string inputString = "Hello, world!";
        string reversedString = ReverseString(inputString);
        Console.WriteLine("Original string: " + inputString);
        Console.WriteLine("Reversed string: " + reversedString);

        //Is Palindrome (can be read backwards) true : false
        string a = "A man, a plan, a canal: Panama";

        Console.WriteLine(IsPalindrome(a)); // Output: true

        //Generate combinations
        int n = 4;
        int p = 2;

        List<List<int>> results = GenerateCombinations(n, p);

        Console.WriteLine("All possible combinations of {0} numbers that add up to {1}:", p, n);
        foreach (List<int> combination in results)
        {
            Console.WriteLine(string.Join(", ", combination));
        }

        //Find pairs that adds up to get targets value
        int[] iArr = { 1, 2, 3, 4, 5 };
        int iTarget = 6;
        int[,] pairs = FindPairs(iArr, iTarget);
        int count = pairs.GetLength(0);
        Console.WriteLine("Number of pairs: " + count);
        Console.WriteLine("Pairs:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(pairs[i, 0] + ", " + pairs[i, 1]);
        }

        //is it possible to choose two different integers from the list that add up to the target?
        List<int> numss = new List<int> { 1, 3, 5, 7 };
        int targett = 8;
        bool exists = TwoSumExists(numss, targett);
        Console.WriteLine(exists);

        //Longest substring from string input
        string provideString = "abcabcbb";
        int answer = LengthOfLongestSubstring(provideString);
        Console.WriteLine(answer);

        //Anagram check
        Console.WriteLine("Are \"listen\" and \"silent\" anagrams? " + AreAnagrams("listen", "silent"));
        Console.WriteLine("Are \"Dormitory\" and \"Dirty room\" anagrams? " + AreAnagrams("Dormitory", "Dirty room"));
        Console.WriteLine("Are \"Astronomer\" and \"Moon starer\" anagrams? " + AreAnagrams("Astronomer", "Moon starer"));
        Console.WriteLine("Are \"Sunlight\" and \"Moon light\" anagrams? " + AreAnagrams("Sunlight", "Moon light"));

        //Count chars in a string
        string sCount = "mississippi";
        List<Tuple<char, int>> result = CountCharacters(sCount);
        foreach (Tuple<char, int> pair in result)
        {
            Console.WriteLine("{0}: {1}", pair.Item1, pair.Item2);
        }

        //Single int that doesnt appear twice
        Console.WriteLine("Input int that doest appear twice");
        int[] numbs = { 2, 2, 1 };
        Console.WriteLine(SingleNumber(numbs)); // Output: 1

        int[] numbs2 = { 4, 1, 2, 1, 2 };
        Console.WriteLine(SingleNumber(numbs2)); // Output: 4

        //Bubble sort
        int[] arrX = { 3, 6, 1, 8, 2 };
        BubbleSort(arrX);
        Console.WriteLine("Bubble sort");
        Console.WriteLine(string.Join(", ", arrX));

        //To reverse a list that you give (non generic)
        List<int> numsl = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original list: " + string.Join(", ", numsl));

        numsl.Reverse();
        Console.WriteLine("Reversed list: " + string.Join(", ", numsl));

        //To reverse list what ever you input list in
        List<int> inputList = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("Input list: ");
        foreach (int num in inputList)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Program prog = new Program();
        List<int> reversedList = prog.ReverseList(inputList);

        Console.WriteLine("Reversed list: ");
        foreach (int num in reversedList)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}