# InfinityString
[InfinityString](https://www.nuget.org/packages/InfinityString/) is a C# struct for infinity iterations on strings, either by indexing ou enumeration.

``` csharp
using InfinityStringLib;
```

# Usage

``` csharp
    var infinity = new InfinityString("batatinha");
```
As the name implies, the InfinityString struct turns an ordinary string into a endless one. This happens when trying to access it by indexes or getting its enumerator:

``` csharp
    var infinity = new InfinityString("batatinha");

    // This runs till word == Int32.MaxValue
    // If you want the base word length, use .TrueLength
    for (var word = 0; word < infinity.Length; i++)
    {
        Console.Write(infinity[word]);
    }
    // Outputs "batatinhabatatinhabatatinhabatatinhabatatinha [...]


    // This runs forever
    foreach (var word in infinity)
    {
        Console.Write(word);
    }

    // Outputs "batatinhabatatinhabatatinhabatatinhabatatinha [...] ad infinitum
```

Under the hoods, the InfinityString class is a struct, but in practice it behaves the same as a string, using implicit conversions. It's designed to be interoperable with the String class:

``` csharp
    InfinityString infinity = "batatinha";
    string word = infinity;
    
    Console.Write(infinity == word); // true    
```

If you want to access the original value directly, just use the .Value property:

``` csharp
    InfinityString infinity = "batatinha";
    infinity.Value; // "batatinha"
```

# How It Works
The InfinityString struct doesn't store a string repeated multiple times. Internally, just the base word and the length are stored, so it won't destroy your RAM :)

It just makes sure that the index requested is within the base word length. If it isn't, some simple calulations are made to get the adequate index.

The struct acts as if the string is concatenated endlessly. Take for example the word "Hello", with length 5. Using the InfinityString struct, if you try to get the [5] index, it'd return 'H'. Same thing with index 10 and 15 and so on.
