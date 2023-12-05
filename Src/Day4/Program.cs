using Businesslogic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 13);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test1Sample, 30);
            Helper.WriteResult(Test2, FileType.Test1, 5132675);
        }

        private static int Test1(List<string> input)
        {
            var regex = new Regex(@"Card\s+(?<id>\d+):(?:\s*(?<win>\d+))+\s[|](?:\s*(?<card>\d+))+");
            var items = input.Select(i => regex.Match(i))
                             .Select(i => new Game(i.Groups["id"].Value, i.Groups["win"].Captures.Select(i => i.Value), i.Groups["card"].Captures.Select(i => i.Value)))
                .ToList();
            var result = items.Select(i =>  i.GetWinners().Count()).Where(i => i > 0).Select(i => (int)Math.Pow(2, i-1));
            return (int)result.Sum();
        }

        private static int Test2(List<string> input)
        {
            var regex = new Regex(@"Card\s+(?<id>\d+):(?:\s*(?<win>\d+))+\s[|](?:\s*(?<card>\d+))+");
            var items = input.Select(i => regex.Match(i))
                             .Select(i => new Game(i.Groups["id"].Value, i.Groups["win"].Captures.Select(i => i.Value), i.Groups["card"].Captures.Select(i => i.Value)))
                             .ToList();
            var total = new List<Game>(items);
            foreach (var item in items)
            {
                if (item.GetWinners().Count() > 0)
                {
                    total.AddRange(GetRounds(items, item.Id, item.GetWinners().Count()));
                }
            }

            return total.Count();
        }

        public static List<Game> GetRounds(List<Game> list, int id, int winners)
        {
            var round = list.Where(i => Enumerable.Range(id + 1, winners).Contains(i.Id)).ToList();
            var addition = round.SelectMany(i => GetRounds(list, i.Id, i.GetWinners().Count())).ToList();
            return round.Concat(addition).ToList();
        }
    }

    [DebuggerDisplay("{Id}")]
    public class Game
    {
        public int Id { get; set; }
        public List<int> Winners { get; set; }
        public List<int> Cards { get; set; }
        public Game(string id, IEnumerable<string> winners, IEnumerable<string> cards)
        {
            Id = Convert.ToInt32(id);
            Winners = winners.Select(i => Convert.ToInt32(i)).ToList();
            Cards = cards.Select(i => Convert.ToInt32(i)).ToList();
        }
        public List<int> GetWinners()
        {
            return Winners.Intersect(Cards).ToList();
        }

    }

}
