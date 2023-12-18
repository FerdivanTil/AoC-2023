using Businesslogic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 288);
            Helper.WriteResult(Test1, FileType.Test1, 2756160);
            //Helper.WriteResult(Test2, FileType.Test1Sample, 71503);
            //Helper.WriteResult(Test2, FileType.Test1);
        }

        private static long Test1(List<string> input)
        {
            var items = Parse(input);
            var result = items.Select(i => i.GetWinners()).Aggregate((result, next) => result * next);
            return result;
        }

        private static long Test2(List<string> input)
        {
            var items = Parse2(input);
            var result = items.Select(i => i.GetWinners()).Aggregate((result, next) => result * next);
            return result;
        }
        public static IEnumerable<Race> Parse(List<string> input)
        {
            var regex = new Regex(@"(?:Time|Distance):\s+(?:(?<number>\d+)\s*)+");
            var times = regex.Match(input[0]).Groups["number"].Captures.Select(i => Convert.ToInt64(i.Value));
            var distances = regex.Match(input[1]).Groups["number"].Captures.Select(i => Convert.ToInt64(i.Value)).ToArray();
            return times.Select((i, index) => new Race(i, distances[index])).ToList();
        }
        public static IEnumerable<Race> Parse2(List<string> input)
        {
            var regex = new Regex(@"(?:Time|Distance):\s+(?:(?<number>\d+)\s*)+");
            var time = regex.Match(input[0]).Groups["number"].Captures.Select(i => i.Value).Aggregate(string.Concat);
            var distance = regex.Match(input[1]).Groups["number"].Captures.Select(i => i.Value).Aggregate(string.Concat);
            return new[] { new Race(Convert.ToInt64(time), Convert.ToInt64(distance)) };
        }
    }

    [DebuggerDisplay("Time: {Time}, Distance: {Distance}")]
    public class Race
    {
        public long Time { get; set; }
        public long Distance { get; set; }

        public Race(long time, long distance)
        {
            Time = time;
            Distance = distance;
        }
        public IEnumerable<long> GetDistances()
        {
            var time = Enumerable.Range(0, (int)Time);
            var races = time.Select(i => i * (Time - i));
            return races;
        }
        public long GetWinners()
        {
            return GetDistances().Where(i => i > Distance).Count();
        }
    }
}
