using Day7;

namespace Day7Tests
{
    public class HandP2Test
    {
        [Theory]
        [InlineData("AAAAA")]
        [InlineData("22222")]
        [InlineData("88888")]
        [InlineData("8JJJJ")]
        [InlineData("88JJJ")]
        [InlineData("888JJ")]
        [InlineData("8888J")]
        [InlineData("7J777")]
        public void HandTestFiveOfAKind(string input)
        {
            var hand = new HandP2(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.FiveOfAKind);
        }

        [Theory]
        [InlineData("AAAA2")]
        [InlineData("22122")]
        [InlineData("88988")]
        [InlineData("98888")]
        [InlineData("98J88")]
        [InlineData("98JJ8")]
        [InlineData("9JJJ8")]
        [InlineData("JKTTJ")]
        [InlineData("3J3A3")]
        [InlineData("T6JJT")]
        [InlineData("A9AJJ")]
        public void HandTestFourOfAKind(string input)
        {
            var hand = new HandP2(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.FourOfAKind);
        }

        [Theory]
        [InlineData("AAA12")]
        [InlineData("22132")]
        [InlineData("889A8")]
        [InlineData("98AJ8")]
        [InlineData("98AJJ")]
        [InlineData("TQQJ2")]
        [InlineData("5JJ38")]
        [InlineData("8483J")]
        [InlineData("A9AJ8")]
        public void HandTestThreeOfAKind(string input)
        {
            var hand = new HandP2(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.ThreeOfAKind);
        }

        [Theory]
        [InlineData("AAA22")]
        [InlineData("22112")]
        [InlineData("88AA8")]
        [InlineData("A8A88")]
        [InlineData("A8AJ8")]
        [InlineData("Q77Q7")]
        public void HandTestFullHouse(string input)
        {
            var hand = new HandP2(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.FullHouse);
        }

        [Theory]
        [InlineData("AA322")]
        [InlineData("22113")]
        [InlineData("98AA8")]
        [InlineData("A9A88")]
        public void HandTestTwoPair(string input)
        {
            var hand = new HandP2(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.TwoPair);
        }
        [Theory]
        [InlineData("AA312")]
        [InlineData("221A3")]
        [InlineData("98A18")]
        [InlineData("A9A58")]
        [InlineData("29AJ8")]
        [InlineData("65K2J")]
        public void HandTestOnePair(string input)
        {
            var hand = new HandP2(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.OnePair);
        }
    }
}