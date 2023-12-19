using Day7;

namespace Day7Tests
{
    public class HandRankTest
    {
        [Theory]
        [InlineData("AAAAA", "AAAAA", 0)]
        [InlineData("AAAAA", "AAAAJ", 1)]
        [InlineData("AAAAA", "AAAJJ", 1)]
        [InlineData("AAAAA", "AA1JJ", 1)]
        [InlineData("AAAAA", "Q2AJJ", 1)]
        [InlineData("AAAAA", "2345J", 1)]
        [InlineData("AAAAJ", "AAAAA", -1)]
        [InlineData("AAAJJ", "AAAAA", -1)]
        [InlineData("AA1JJ", "AAAAA", -1)]
        [InlineData("Q2AJJ", "AAAAA", -1)]
        [InlineData("2345J", "AAAAA", -1)]
        [InlineData("AAAAA", "JJJJJ", 1)]
        [InlineData("33332", "2AAAA", 1)]
        [InlineData("77888", "77788", 1)]
        public void HandRankTest1(string input1, string input2, int expected)
        {
            var hand1 = new Hand(input1, 0);
            var hand2 = new Hand(input2, 0);
            hand1.CompareTo(hand2).Should().Be(expected);
        }
    }
}
