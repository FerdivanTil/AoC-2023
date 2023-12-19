using Day7;

namespace Day7Tests
{
    public class Part2Tests
    {
        [Fact]
        public void Part2SampleTest()
        {
            var hands = new List<HandP2> { new HandP2("32T3K", 0), new HandP2("T55J5", 0), new HandP2("KK677", 0), new HandP2("KTJJT", 0), new HandP2("QQQJA", 0) };
            hands.Sort();
            hands[0].GetHand.Should().Be("32T3K");
            hands[1].GetHand.Should().Be("KK677");
            hands[2].GetHand.Should().Be("T55J5");
            hands[3].GetHand.Should().Be("QQQJA");
            hands[4].GetHand.Should().Be("KTJJT");
        }
    }
}
