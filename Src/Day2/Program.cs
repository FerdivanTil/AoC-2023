using Businesslogic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 8);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test1Sample, 2286);
            Helper.WriteResult(Test2, FileType.Test1);
        }

        private static int Test1(List<string> input)
        {
            var games = input.Select(Parse).ToList();

            var result = games.Where(i => !i.GetColorDraws("red").Any(x => x.Amount > 12)
                                          && !i.GetColorDraws("green").Any(x => x.Amount > 13)
                                          && !i.GetColorDraws("blue").Any(x => x.Amount > 14)
                                          );
            return result.Sum(i => i.Id);
        }

        private static int Test2(List<string> input)
        {
            var games = input.Select(Parse).ToList();
            var result = games.Select(i => i.GetColorDraws("red").Select(i => i.Amount).Max() * i.GetColorDraws("green").Select(i => i.Amount).Max() * i.GetColorDraws("blue").Select(i => i.Amount).Max());
            return result.Sum();
        }
        private static Game Parse(string input)
        {
            var regex = new Regex(@"^Game (?<id>\d+): (?<draws>.*)$");
            var parsed = regex.Match(input);
            var game = new Game();
            game.Id = Convert.ToInt32(parsed.Groups["id"].Value);
            game.Parse(parsed.Groups["draws"].Value);
            return game;
        }
    }

    [DebuggerDisplay("{Id}")]
    public class Game
    {
        public int Id { get; set; }
        public List<DrawCollection> Draws { get; set; } = new();
        public void Parse(string input)
        {
            Draws.AddRange(input.Split("; ").Select(DrawCollection.Parse));
        }
        public IEnumerable<Draw> GetColorDraws(string color)
        {
            return Draws.SelectMany(i => i.Collection.Where(i => i.Color == color));
        }
    }
    public class DrawCollection
    {
        public List<Draw> Collection { get; set; } = new();
        public static DrawCollection Parse(string input)
        {
            return new DrawCollection
            {
                Collection = input.Split(", ").Select(Draw.Parse).ToList(),
            };
        }
    }

    [DebuggerDisplay("{Amount} {Color}")]
    public class Draw
    {
        public int Amount { get; set; }
        public string Color { get; set; }
        public static Draw Parse(string input)
        {
            var values = input.Split(" ");
            return new Draw
            {
                Amount = Convert.ToInt32(values[0]),
                Color = values[1],
            };
        }

    }
}
