using System;
using System.Collections.Generic;
using System.Linq;
using LinqTee.Extensions;
using NUnit.Framework;

namespace LinqTee.Tests
{
    public class Integers1To10Tests
    {
        private int[] _evenNumbers;
        private int[] _oddNumbers;
        private IEnumerable<int> _sut;

        private static readonly Func<int, bool> EvenNumbers;
        private static readonly Func<int, bool> OddNumbers;

        static Integers1To10Tests()
        {
            EvenNumbers = x => x % 2 == 0;
            OddNumbers = x => !EvenNumbers(x);
        }

        [SetUp]
        public void SetUp()
        {
            _evenNumbers = new[] {2, 4, 6, 8, 10};
            _oddNumbers = new[] {1, 3, 5, 7, 9};

            _sut = Enumerable.Range(1, 10);

            Assume.That(_sut, Is.Ordered);
        }

        [Test]
        public void it_tees_and_wyes_without_changing_values_order()
        {
            var actual = _sut
                .Tee(EvenNumbers)
                .Process()
                .Left(evenInts => evenInts)
                .Right(oddInts => oddInts)
                .Wye()
                .Concatenate();

            var expectedCollection = _evenNumbers.Concat(_oddNumbers);

            Assert.That(actual, Is.EqualTo(expectedCollection));
        }

        [Test]
        public void it_reverses_left_and_right_collections()
        {
            var actual = _sut
                .Tee(EvenNumbers)
                .Process()
                .Left(evenInts => evenInts.Reverse())
                .Right(oddInts => oddInts.Reverse())
                .Wye()
                .Concatenate();

            var expectedCollection = _evenNumbers
                .Reverse()
                .Concat(_oddNumbers.Reverse());

            Assert.That(actual, Is.EqualTo(expectedCollection));
        }

        [Test]
        public void it_tees_on_nested_enumerables_and_preserve_their_order()
        {
            bool LargerThan5(int x) => x > 5;

            var actual = _sut
                .Tee(EvenNumbers)
                .Process()
                .Left(even =>
                {
                    return even
                        .Tee(LargerThan5)
                        .Process()
                        .Left(evenLarger5 => evenLarger5)
                        .Right(evenSmaller5 => evenSmaller5)
                        .Wye()
                        .Concatenate();
                })
                .Right(odd =>
                {
                    return odd
                        .Tee(LargerThan5)
                        .Process()
                        .Left(oddLarger5 => oddLarger5)
                        .Right(oddSmaller5 => oddSmaller5)
                        .Wye()
                        .Concatenate();
                })
                .Wye()
                .Concatenate();

            var expectedCollection = _evenNumbers
                .OrderByDescending(LargerThan5)
                .Concat(_oddNumbers.OrderByDescending(LargerThan5));

            Assert.That(actual, Is.EqualTo(expectedCollection));
        }

        [Test]
        public void it_tees_and_right_wyes_having_odd_numbers_coming_first()
        {
            var actual = _sut
                .Tee(EvenNumbers)
                .Process()
                .Left(even => even)
                .Right(odd => odd)
                .WyeRight()
                .Concatenate();

            var expected = _oddNumbers.Concat(_evenNumbers);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_tees_and_zip_wyes_resulting_on_original_collection()
        {
            var actual = _sut
                .Tee(OddNumbers)
                .Process()
                .Left(odd => odd)
                .Right(even => even)
                .Wye()
                .Zip();

            var expected = Enumerable.Range(1, 10);
            Assume.That(expected, Is.Ordered);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_tees_and_right_zip_wyes_resulting_on_original_collection()
        {
            var actual = _sut
                .Tee(EvenNumbers)
                .Process()
                .Left(even => even)
                .Right(odd => odd)
                .WyeRight()
                .Zip();

            var expected = Enumerable.Range(1, 10);
            Assume.That(expected, Is.Ordered);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}