using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace LinqTee.Tests
{
    public class Integers1To10Tests
    {
        private int[] _expectedLeftCollection;
        private int[] _expectedRightCollection;
        private IEnumerable<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _expectedLeftCollection = new[] {2, 4, 6, 8, 10};
            _expectedRightCollection = new[] {1, 3, 5, 7, 9};

            _sut = Enumerable.Range(1, 10);
        }

        [Test]
        public void it_reverses_left_and_right_collections()
        {
            Expression<Func<int, bool>> evenNumbers = x => x % 2 == 0;

            var finalCollection = _sut
                .Tee(evenNumbers)
                .Left(ints => ints.Reverse())
                .Right(ints => ints.Reverse())
                .Wye();

            var expectedCollection = _expectedLeftCollection
                .Reverse()
                .Concat(_expectedRightCollection.Reverse());

            Assert.That(finalCollection, Is.EqualTo(expectedCollection));
        }
    }
}