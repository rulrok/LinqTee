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
        private static readonly Expression<Func<int, bool>> EvenNumbers;

        static Integers1To10Tests()
        {
            EvenNumbers = x => x % 2 == 0;
        }

        [SetUp]
        public void SetUp()
        {
            _expectedLeftCollection = new[] {2, 4, 6, 8, 10};
            _expectedRightCollection = new[] {1, 3, 5, 7, 9};

            _sut = Enumerable.Range(1, 10);

            Assume.That(_sut, Is.Ordered);
        }

        [Test]
        public void it_tees_and_wyes_without_changing_values_order()
        {
            var finalCollection = _sut
                .Tee(EvenNumbers)
                .Left(ints => ints)
                .Right(ints => ints)
                .Wye();

            var expectedCollection = _expectedLeftCollection.Concat(_expectedRightCollection);

            Assert.That(finalCollection, Is.EqualTo(expectedCollection));
        }

        [Test]
        public void it_reverses_left_and_right_collections()
        {
            var finalCollection = _sut
                .Tee(EvenNumbers)
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