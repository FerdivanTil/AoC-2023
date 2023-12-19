namespace Day7
{
    public class Hand : IComparable<Hand>
    {
        public List<string> Cards { get; init; }
        public int Winnings { get; init; }

        public Hand(string input, int winnings)
        {
            Cards = input.Select(i => i.ToString()).ToList();
            Winnings = winnings;
        }
        public static T Parse<T>(string input) where T : Hand
        {
            var values = input.Split(" ");
            return (T)Activator.CreateInstance(typeof(T), new object[] { values[0], Convert.ToInt32(values[1]) });
        }

        public string GetHand => string.Concat(Cards);

        public virtual Rank GetRank()
        {
            var grouped = Cards.GroupBy(i => i);
            if (grouped.Count() == 1)
            {
                return Rank.FiveOfAKind;
            }
            if (grouped.Count() == 2 && grouped.Select(i => i.Count()).Max() == 4)
            {
                return Rank.FourOfAKind;
            }
            if (grouped.Count() == 3 && grouped.Select(i => i.Count()).Max() == 3)
            {
                return Rank.ThreeOfAKind;
            }
            if (grouped.Count() == 2 && grouped.Select(i => i.Count()).Max() == 3)
            {
                return Rank.FullHouse;
            }
            if (grouped.Count() == 3 && grouped.Select(i => i.Count()).Max() == 2)
            {
                return Rank.TwoPair;
            }
            if (grouped.Count() == 4 && grouped.Select(i => i.Count()).Max() == 2)
            {
                return Rank.OnePair;
            }
            return Rank.HighCard;
        }
       
        protected List<string> cards = new List<string> { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
        internal bool IsHiger(string x, string y)
        {
            return cards.IndexOf(x) < cards.IndexOf(y);
        }

        public int CompareTo(Hand other)
        {
            var xRank = GetRank();
            var yRank = other.GetRank();
            if (xRank > yRank)
            {
                return 1;
            }
            if (GetHand == other.GetHand)
            {
                return 0;
            }
            if (xRank == yRank)
            {
                foreach (var i in Enumerable.Range(0, 5))
                {
                    if (IsHiger(Cards[i], other.Cards[i]))
                    {
                        return 1;
                    }
                    if (IsHiger(other.Cards[i], Cards[i]))
                    {
                        return -1;
                    }
                }
                return 0;
            }

            return -1;
        }

        public enum Rank
        {
            FiveOfAKind = 7,
            FourOfAKind = 6,
            FullHouse = 5,
            ThreeOfAKind = 4,
            TwoPair = 3,
            OnePair = 2,
            HighCard = 1,
        }
    }
}
