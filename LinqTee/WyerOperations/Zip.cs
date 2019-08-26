using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee.WyerOperations
{
    public class Zip<T> : IWyeableOperation<T>
    {
        public IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            var zipCollection = new List<T>();

            using (var lEnumerator = left.GetEnumerator())
            using (var rEnumerator = right.GetEnumerator())
            {
                while (lEnumerator.MoveNext())
                {
                    zipCollection.Add(lEnumerator.Current);
                    if (rEnumerator.MoveNext())
                    {
                        zipCollection.Add(rEnumerator.Current);
                    }
                }

                while (rEnumerator.MoveNext())
                    zipCollection.Add(rEnumerator.Current);
            }

            return zipCollection;
        }
    }
}