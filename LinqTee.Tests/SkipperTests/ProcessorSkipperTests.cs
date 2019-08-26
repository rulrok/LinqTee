using System.Linq;
using LinqTee.Extensions;
using NUnit.Framework;

namespace LinqTee.Tests.SkipperTests
{
    [TestFixture]
    public class ProcessorSkipperTests
    {
        [Test]
        public void it_can_skip_left_processor_step()
        {
            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .Process()
                .IgnoreLeft()
                .Right(ints => ints);

            Assert.Pass();
        }

        [Test]
        public void it_can_skip_right_processor_step()
        {
            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .Process()
                .Left(ints => ints)
                .IgnoreRight();

            Assert.Pass();
        }

        [Test]
        public void it_can_skip_both_processor_steps()
        {
            Enumerable
                .Range(1, 10)
                .Tee(x => x >= 5)
                .Process()
                .IgnoreLeft()
                .IgnoreRight();

            Assert.Pass();
        }
    }
}