using System.Collections.Generic;
using System.Linq;
using LinqTee.Extensions;
using NUnit.Framework;

namespace LinqTee.Tests
{
    [TestFixture]
    public class TeeableColectorTests
    {
        private static bool EvenNumber(int x) => x % 2 == 0;

        [Test]
        public void it_collects_elements_into_ref_variables()
        {
            IList<int> evenNumbers = new List<int>();
            IList<int> oddNumbers = new List<int>();

            var range = Enumerable.Range(1, 100).ToList();

            range
                .Tee(EvenNumber)
                .Collect()
                .Left(ref evenNumbers)
                .Right(ref oddNumbers);

            //Assert left side
            Assert.Multiple(testDelegate: () =>
            {
                Assert.That(evenNumbers, Has.Count.EqualTo(range.Count / 2));
                Assert.That(evenNumbers, Has.All.Matches<int>(EvenNumber));
            });

            //Assert right side
            Assert.Multiple(() =>
            {
                Assert.That(oddNumbers, Has.Count.EqualTo(range.Count / 2));
                Assert.That(oddNumbers, Has.None.Matches<int>(EvenNumber));
            });
        }

        [Test]
        public void it_collects_only_left_side()
        {
            IList<int> evenNumbers = new List<int>();

            var range = Enumerable.Range(1, 100).ToList();

            range
                .Tee(EvenNumber)
                .Collect()
                .Left(ref evenNumbers)
                .IgnoreRight();

            Assert.That(evenNumbers, Has.Exactly(range.Count / 2).Items);
            Assert.That(evenNumbers, Has.All.Matches<int>(EvenNumber));
        }

        [Test]
        public void it_collects_only_right_side()
        {
            IList<int> oddNumbers = new List<int>();

            var range = Enumerable.Range(1, 100).ToList();

            range
                .Tee(EvenNumber)
                .Collect()
                .IgnoreLeft()
                .Right(ref oddNumbers);

            Assert.That(oddNumbers, Has.Exactly(range.Count / 2).Items);
            Assert.That(oddNumbers, Has.None.Matches<int>(EvenNumber));
        }

        [Test]
        public void it_can_ignore_both_sides()
        {
            var range = Enumerable.Range(1, 100).ToList();

            range
                .Tee(EvenNumber)
                .Collect()
                .IgnoreLeft()
                .IgnoreRight();
            
            Assert.Pass();
        }
    }
}