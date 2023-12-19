using Day7;

namespace Day7Tests
{
    public class HandCardP2Tests
    {
        [Theory]
        [InlineData("A", "A", false)]
        [InlineData("A", "K", true)]
        [InlineData("A", "Q", true)]
        [InlineData("A", "J", true)]
        [InlineData("A", "T", true)]
        [InlineData("A", "9", true)]
        [InlineData("A", "8", true)]
        [InlineData("A", "7", true)]
        [InlineData("A", "6", true)]
        [InlineData("A", "5", true)]
        [InlineData("A", "4", true)]
        [InlineData("A", "3", true)]
        [InlineData("A", "2", true)]
        public void HandCardTests1(string input1, string input2, bool expected)
        {
            var hand = new HandP2("", 0);
            hand.IsHiger(input1, input2).Should().Be(expected);
        }
        [Theory]
        [InlineData("K", "A", false)]
        [InlineData("Q", "A", false)]
        [InlineData("T", "A", false)]
        [InlineData("9", "A", false)]
        [InlineData("8", "A", false)]
        [InlineData("7", "A", false)]
        [InlineData("6", "A", false)]
        [InlineData("5", "A", false)]
        [InlineData("4", "A", false)]
        [InlineData("3", "A", false)]
        [InlineData("2", "A", false)]
        [InlineData("J", "A", false)]

        public void HandCardTests2(string input1, string input2, bool expected)
        {
            var hand = new HandP2("", 0);
            hand.IsHiger(input1, input2).Should().Be(expected);
        }

        [Theory]
        [InlineData("A", "A", false)]
        [InlineData("K", "K", false)]
        [InlineData("Q", "Q", false)]
        [InlineData("J", "J", false)]
        [InlineData("T", "T", false)]
        [InlineData("9", "9", false)]
        [InlineData("8", "8", false)]
        [InlineData("7", "7", false)]
        [InlineData("6", "6", false)]
        [InlineData("5", "5", false)]
        [InlineData("4", "4", false)]
        [InlineData("3", "3", false)]
        [InlineData("2", "2", false)]
        public void HandCardTests3(string input1, string input2, bool expected)
        {
            var hand = new HandP2("", 0);
            hand.IsHiger(input1, input2).Should().Be(expected);
        }
        [Theory]
        [InlineData("J", "A", false)]
        [InlineData("J", "K", false)]
        [InlineData("J", "Q", false)]
        [InlineData("J", "T", false)]
        [InlineData("J", "9", false)]
        [InlineData("J", "8", false)]
        [InlineData("J", "7", false)]
        [InlineData("J", "6", false)]
        [InlineData("J", "5", false)]
        [InlineData("J", "4", false)]
        [InlineData("J", "3", false)]
        [InlineData("J", "2", false)]
        public void HandCardTests4(string input1, string input2, bool expected)
        {
            var hand = new HandP2("", 0);
            hand.IsHiger(input1, input2).Should().Be(expected);
        }
    }
}
