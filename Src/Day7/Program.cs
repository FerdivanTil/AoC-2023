using Businesslogic;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 6440);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test1Sample, 5905);
            Helper.WriteResult(Test2, FileType.Test1);
        }

        private static int Test1(List<string> input)
        {
            var hands = input.Select(Hand.Parse<Hand>).ToList();
            hands.Sort();
            var result = hands.Select((item, index) => new { index, item }).Aggregate(0, (result, next) => result += ((next.index + 1) * next.item.Winnings));
            return result;
        }

        private static int Test2(List<string> input)
        {
            var hands = input.Select(Hand.Parse<HandP2>).ToList();
            hands.Sort();
            hands.ForEach(hand => { Console.WriteLine($"{hand.GetHand} {hand.GetRank()} {hand.Winnings}"); });
            var result = hands.Select((item, index) => new { index, item }).Aggregate(0, (result, next) => result += ((next.index + 1) * next.item.Winnings));
            return result;
        }
    }
}
