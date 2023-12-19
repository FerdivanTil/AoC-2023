namespace Day7
{
    public class HandP2 : Hand
    {
        public HandP2(string input, int winnings) : base(input, winnings)
        {
            cards = new List<string> { "A", "K", "Q", "T", "9", "8", "7", "6", "5", "4", "3", "2", "J" };
    }
        public override Rank GetRank()
        {
            var grouped = Cards.GroupBy(i => i);
            // FiveOfAKind
            if (grouped.Count() == 1)
            {
                return Rank.FiveOfAKind;
            }
            if (grouped.Count() == 2 && grouped.Any(i => i.Key == "J"))
            {
                return Rank.FiveOfAKind;
            }
            // FourOfAKind
            if (grouped.Count() == 2 && grouped.Select(i => i.Count()).Max() == 4)
            {
                return Rank.FourOfAKind;
            }
            if (grouped.Count() == 3 && grouped.Any(i => i.Key == "J")  && grouped.Select(i => i.Count()).Max() > 2)
            {
                return Rank.FourOfAKind;
            }
            if (grouped.Count() == 3 && grouped.Any(i => i.Key == "J") && grouped.First(i => i.Key == "J").Count() + grouped.Select(i => i.Count()).Max() == 4)
            {
                return Rank.FourOfAKind;
            }
            // ThreeOfAKind
            if (grouped.Count() == 3 && grouped.Select(i => i.Count()).Max() == 3)
            {
                return Rank.ThreeOfAKind;
            }
            if (grouped.Count() == 4 && grouped.Any(i => i.Key == "J") && grouped.First(i => i.Key == "J").Count() + grouped.Where(i => i.Key != "J").Select(i => i.Count()).Max() == 3)
            {
                return Rank.ThreeOfAKind;
            }

            // FullHouse
            if (grouped.Count() == 2 && grouped.Select(i => i.Count()).Max() == 3)
            {
                return Rank.FullHouse;
            }
            if (grouped.Count() == 3 && grouped.Any(i => i.Key == "J") && grouped.Select(i => i.Count()).Max() == 2)
            {
                return Rank.FullHouse;
            }

            // TwoPair
            if (grouped.Count() == 3 && grouped.Select(i => i.Count()).Max() == 2)
            {
                return Rank.TwoPair;
            }
            if (grouped.Count() == 4 && grouped.Any(i => i.Key == "J")  && grouped.Select(i => i.Count()).Max() == 2)
            {
                return Rank.TwoPair;
            }

            // OnePair
            if (grouped.Count() == 4  && grouped.Select(i => i.Count()).Max() == 2)
            {
                return Rank.OnePair;
            }

            if (grouped.Count() == 5 && grouped.Any(i => i.Key == "J"))
            {
                return Rank.OnePair;
            }
            return Rank.HighCard;
        }
    }
}
