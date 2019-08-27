# Table of content

- [LinqTee](#linqtee)
- [What is LinqTee?](#what-is-linqtee-)
- [Install](#install)
- [Examples](#examples)
  * [left-right concatenation](#left-right-concatenation)
  * [right-left concatenation](#right-left-concatenation)
  * [zipping collections](#zipping-collections)
    + [Pseudo-code](#pseudo-code)
    + [Real code (left-to-right):](#real-code--left-to-right--)
    + [Real code (right-to-left)](#real-code--right-to-left-)
- [Public Interface](#public-interface)
- [Custom Wye operations](#custom-wye-operations)
  * [Concatenate real example](#concatenate-real-example)
    + [Implementation](#implementation)
- [Nesting calls](#nesting-calls)

<small><i><a href='http://ecotrust-canada.github.io/markdown-toc/'>Table of contents generated with markdown-toc</a></i></small>

# LinqTee
LINQ-to-Object library to easily bifurcate LINQ data flows and join them back together.

You can split your collections data processing flow with **Tee (*T*)** and **Wye (*Y*)** easily.

It is *inspired* by the `tee` linux command (but not the same thing!).

# What is LinqTee?

If you ever needed to build a fluent LINQ-to-object chain, but needed to process parts of data differently, this library call help you having a cleaner code.

# Install

```powershell
PM > Install-Package LinqTee -Version 0.1.0-beta
```

# Examples

## left-right concatenation
```cs
    bool LargerThan5(int x) => x > 5;

    IEnumerable<int> values = Enumerable.Range(1, 10);
    var processedValues = values
            //Split enumerable with some criteria
            .Tee(LargerThan5)
            //We choose to process both streams
            .Process()
            //Do something with the left side
            .Left(even => even * 2)
            //Do something else with the right side
            .Right(odd => odd * 7)
            //'wye' (join) them together.
            .Wye() //<-- operate left-to-right
            //In this case we concat the left with right side.
            .Concatenate();
``` 

## right-left concatenation

```cs
    bool LargerThan5(int x) => x > 5;

    IEnumerable<int> values = Enumerable.Range(1, 10);
    var processedValues = values
            .Tee(LargerThan5)
            .Process()
            .Left(even => even * 2)
            .Right(odd => odd * 7)
            //Operate first on the right collection
            .WyeRight() //<-- right-to-left
            .Concatenate();
```

## zipping collections

It works in a similar way of `lodash`. 

It weaves/intersperses two collections into one.

### Pseudo-code

```
var odds = new []{1,3,5,7,9};
var evens = new []{2,4,6,8,10};

var values = zip(odds, evens);

//Values would be equal to
{1,2,3,4,5,6,7,8,9,10}

//We could also right zip them
var values2 = zipRight(odds, evens);

//It would be equal to
{2,1,4,3,6,5,8,7,10,9}
```

### Real code (left-to-right):

```cs
    bool LargerThan5(int x) => x > 5;

    IEnumerable<int> values = Enumerable.Range(1, 10);
    var processedValues = values
            .Tee(LargerThan5)
            .Process()
            .Left(even => even * 2)
            .Right(odd => odd * 7)
            //Operate first on the right collection
            .Wye() //<-- left-to-right
            .Zip();
```

### Real code (right-to-left)

```cs
    bool LargerThan5(int x) => x > 5;

    IEnumerable<int> values = Enumerable.Range(1, 10);
    var processedValues = values
            .Tee(LargerThan5)
            .Process()
            .Left(even => even * 2)
            .Right(odd => odd * 7)
            //Operate first on the right collection
            .WyeRight() //<-- right-to-left
            .Zip();
```

# Public Interface

The API has been built to avoid misusing it. \
Intellisense will be your best friend, but just in case:


```cs
IEnumerable<T>
    .Tee(T => bool)
    [   
        .Collect()
        { .Left(ref IList<T>) | .IgnoreLeft() }
        { .Right(ref IList<T>) | IgnoreRight() }
    ]
    [
        .Process()
        { .Left(T -> bool) | IgnoreLeft() }
        { .Right(T -> bool | IgnoreRight() }
        { .Wye() | .WyeRight() }
        { .Concatenate() | .Zip() | .OperateWith((IEnumerable<T>, IEnumerable<T>) => IEnumerable<T>) }
    ]
    [
        { .Wye() | .WyeRight() }
        { .Concatenate() | .Zip() | .OperateWith((IEnumerable{T}, IEnumerable{T}) -> IEnumerable{T})) }
    ]
    ;
```

# Custom Wye operations

By default the library includes `concatenation` and `zip` to merge a `Tee` operation.

You can create any custom logic by implementing the `IWyeableOperation<T>` interface.

You only have to implement how you want to merge two collections.
The interface has only a single method with two parameters which by convenience have been called `left` and `right`.
```cs
    public interface IWyeableOperation<T>
    {
        IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right);
    }
```

You don't have to implement the opposite mapping. When using `WyeRight()` method, your operation will just receive the `left` and `right` original collections swapped. 

## Concatenate real example

### Implementation
```cs
    public class ConcatenateMyWay<T> : IWyeableOperation<T>
    {
        public IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Concat(right);
        }
    }
````

Then you can use it as

```cs
    bool LargerThan5(int x) => x > 5;

    IEnumerable<int> values = Enumerable.Range(1, 10);
    var processedValues = values
            .Tee(LargerThan5)
            .Process()
            .Left(even => even * 2)
            .Right(odd => odd * 7)
            .Wye()
            .OperateWith(new ConcatenateMyWay()); //<-- generic way
```

We recommend creating your own extension method to have a cleaner code.

```cs
        public static IEnumerable<T> ConcatenateMyWay<T>(this IWyeable<T> wyeable)
        {
            return wyeable.OperateWith(new Concatenate<T>());
        }
``` 

Then you can invoke it as

```cs
    bool LargerThan5(int x) => x > 5;

    IEnumerable<int> values = Enumerable.Range(1, 10);
    var processedValues = values
            .Tee(LargerThan5)
            .Process()
            .Left(even => even * 2)
            .Right(odd => odd * 7)
            .Wye()
            .ConcatenateMyWay(); // <-- much cleaner
```

# Nesting calls

Nothing prevents you from creating more complex nesting uses.

```cs
    bool LargerThan5(int x) => x > 5;

    var actual = Enumerable.Range(1, 10)
            .Tee(x => x % 2 == 0)
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
                    .Tee(LargerThan50)
                    .Process()
                    .Left(oddLarger5 => oddLarger5)
                    .Right(oddSmaller5 => oddSmaller5)
                    .Wye()
                    .Concatenate();
            })
            .Wye()
            .Concatenate();
```

Starting range collection:

`[1,2,3,4,5,6,7,8,9,10]`

`actual` variable result:

`[6,8,10,2,4,7,9,1,3,5]`
