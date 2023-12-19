using Day7;

namespace Day7Tests
{
    public class HandTest
    {
        [Theory]
        [InlineData("AAAAA")]
        [InlineData("22222")]
        [InlineData("88888")]
        public void HandTestFiveOfAKind(string input)
        {
            var hand = new Hand(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.FiveOfAKind);
        }

        [Theory]
        [InlineData("AAAA2")]
        [InlineData("22122")]
        [InlineData("88988")]
        [InlineData("98888")]
        public void HandTestFourOfAKind(string input)
        {
            var hand = new Hand(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.FourOfAKind);
        }

        [Theory]
        [InlineData("AAA12")]
        [InlineData("22132")]
        [InlineData("889A8")]
        [InlineData("98A88")]
        public void HandTestThreeOfAKind(string input)
        {
            var hand = new Hand(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.ThreeOfAKind);
        }
        [Theory]
        [InlineData("AAA22")]
        [InlineData("22112")]
        [InlineData("88AA8")]
        [InlineData("A8A88")]
        public void HandTestFullHouse(string input)
        {
            var hand = new Hand(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.FullHouse);
        }

        [Theory]
        [InlineData("AA322")]
        [InlineData("22113")]
        [InlineData("98AA8")]
        [InlineData("A9A88")]
        public void HandTestTwoPair(string input)
        {
            var hand = new Hand(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.TwoPair);
        }
        [Theory]
        [InlineData("AA312")]
        [InlineData("221A3")]
        [InlineData("98A18")]
        [InlineData("A9A58")]
        public void HandTestOnePair(string input)
        {
            var hand = new Hand(input, 0);
            hand.GetRank().Should().Be(Hand.Rank.OnePair);
        }
    }
}