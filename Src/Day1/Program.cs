using Businesslogic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 142);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test2Sample, 281);
            Helper.WriteResult(Test2, FileType.Test2);
        }

        private static int Test1(List<string> input)
        {
            var regex = new Regex(@"[^\d]");
            var result = input.Select(i => regex.Replace(i, string.Empty))
                              .Select(i => i.ToList().Select(i => i - 48))
                              .Select(i => i.First() * 10 + i.Last());
            return result.Sum();
        }

        private static int Test2(List<string> input)
        {
            var result = input.Select(FindValue).ToList();

            return result.Sum();
        }

        public static int FindValue(string input)
        {
            var allNumber = Enumerable.Range(1, 9);
            var allTextNumbers = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }.Select((value, index) => new { Value = value, Index = index }).ToList();

            // Replace all number to there text version.
            foreach (var x in allTextNumbers)
            {
                input = input.Replace((x.Index + 1).ToString(), x.Value);
            }
            // Find the indexes of all the text numbers.
            var value = allTextNumbers.Select(i => new { Index = input.IndexOf(i.Value), Value = i.Index + 1 })
                .Where(i => i.Index != -1)
                .OrderBy(i => i.Index);

            // Get the first and the last.
            var first = value.First().Value;
            var last = value.Last().Value;
            return first * 10 + last;
        }
    }
}
