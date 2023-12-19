using Day7;

namespace Day7Tests
{
    public class Part1Tests
    {
        [Fact]
        public void Part1SampleTest()
        {
            var hands = new List<Hand> { new Hand("32T3K", 0), new Hand("T55J5", 0), new Hand("KK677", 0), new Hand("KTJJT", 0), new Hand("QQQJA", 0) };
            hands.Sort();
            hands[0].GetHand.Should().Be("32T3K");
            hands[1].GetHand.Should().Be("KTJJT");
            hands[2].GetHand.Should().Be("KK677");
            hands[3].GetHand.Should().Be("T55J5");
            hands[4].GetHand.Should().Be("QQQJA");
        }
    }
}
