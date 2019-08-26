using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LinqTee.Tests
{
    [TestFixture]
    public class SkipperTests
    {
        [Test]
        public void it_can_skip_left_collector_step()
        {
            IList<int> output = new List<int>();

            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .IgnoreLeft()
                .RightCollect(ref output);

            Assert.Pass();
        }

        [Test]
        public void it_can_skip_right_collector_step()
        {
            IList<int> output = new List<int>();

            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .LeftCollect(ref output)
                .IgnoreRight();

            Assert.Pass();
        }

        [Test]
        public void it_can_skip_both_collector_steps()
        {
            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .IgnoreLeft()
                .IgnoreRight();

            Assert.Pass();
        }
    }
}