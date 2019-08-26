using System.Collections.Generic;
using System.Linq;
using LinqTee.WyerOperations;
using NUnit.Framework;

namespace LinqTee.Tests.WyerOperations
{
    [TestFixture]
    public class WyeZipTests
    {
        private Zip<int> _zip;

        [SetUp]
        public void SetUp()
        {
            _zip = new Zip<int>();
        }

        [Test]
        public void it_zips_same_size_collections()
        {
            var odds = new[] {1, 3, 5};
            var evens = new[] {2, 4, 6};

            var expected = Enumerable.Range(1, 6);
            var actual = _zip.Operate(odds, evens);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_zips_collection_with_empty()
        {
            var collection = new[] {1, 2, 3, 4};

            var expected = Enumerable.Range(1, 4);
            var actual = _zip.Operate(collection, Enumerable.Empty<int>());

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_zips_empty_with_colletion()
        {
            var collection = new[] {1, 2, 3, 4};

            var expected = Enumerable.Range(1, 4);
            var actual = _zip.Operate(Enumerable.Empty<int>(), collection);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_zips_unbalanced_collections()
        {
            var left = new[] {1, 3, 5, 7, 9};
            var right = new[] {2, 4};

            var expectedLeft = new[] {1, 2, 3, 4, 5, 7, 9};
            var actualLeft = _zip.Operate(left, right);

            Assert.That(actualLeft, Is.EqualTo(expectedLeft));

            var expectedRight = new[] {2, 1, 4, 3, 5, 7, 9};
            var actualRight = _zip.Operate(right, left);

            Assert.That(actualRight, Is.EqualTo(expectedRight));
        }

        [Test]
        public void it_zips_two_empty_collections()
        {
            var left = Enumerable.Empty<int>();
            var right = Enumerable.Empty<int>();

            var expected = Enumerable.Empty<int>();
            var actual = _zip.Operate(left, right);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void it_throws_argument_null_exception_if_right_side_is_null()
        {
            var left = new[] {1, 2, 3, 4};
            IEnumerable<int> right = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.That(() => _zip.Operate(left, right), Throws.ArgumentNullException);
        }

        [Test]
        public void it_throws_argument_null_exception_if_left_side_is_null()
        {
            IEnumerable<int> left = null;
            var right = new[] {1, 2, 3, 4};

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.That(() => _zip.Operate(left, right), Throws.ArgumentNullException);
        }
    }
}