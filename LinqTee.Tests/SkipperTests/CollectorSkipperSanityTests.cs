using System.Collections.Generic;
using System.Linq;
using LinqTee.Extensions;
using NUnit.Framework;

namespace LinqTee.Tests.SkipperTests
{
    [TestFixture]
    public class CollectorSkipperSanityTests
    {
        [Test]
        public void it_can_skip_left_collector_step()
        {
            IList<int> output = new List<int>();

            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .Collect()
                .IgnoreLeft()
                .Right(ref output);

            Assert.Pass();
        }

        [Test]
        public void it_can_skip_right_collector_step()
        {
            IList<int> output = new List<int>();

            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .Collect()
                .Left(ref output)
                .IgnoreRight();

            Assert.Pass();
        }

        [Test]
        public void it_can_skip_both_collector_steps()
        {
            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .Collect()
                .IgnoreLeft()
                .IgnoreRight();

            Assert.Pass();
        }
    }
}