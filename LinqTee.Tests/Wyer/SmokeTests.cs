using System.Linq;
using NUnit.Framework;

namespace LinqTee.Tests.Wyer
{
    [TestFixture]
    public class SmokeTests
    {
        [Test]
        public void it_left_tees_and_wyes_without_making_changes()
        {
            var actual = Enumerable
                .Range(1, 10)
                //Only left side will have values
                .Tee(x => x <= 100)
                .Wye()
                .Concatenate();

            var expected = Enumerable.Range(1, 10);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_right_tees_and_wyes_without_making_changes()
        {
            var actual = Enumerable
                .Range(1, 10)
                //Only right side will have values
                .Tee(x => x >= 0)
                .Wye()
                .Concatenate();

            var expected = Enumerable.Range(1, 10);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}