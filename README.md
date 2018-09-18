![NGrammer](https://github.com/michaelmcmullin/ngram-categorisation/blob/master/Assets/ngrammer.png?raw=true)

# NGrammer
### Using generic N-Grams to handle data categorisation in C#
This project was originally inspired by the 1994 paper, *N-Gram-Based Text
Categorization*, by William B. Cavnar and John M. Trenkle. I created a version
in the digital print company I work for that extracted information from
free-form text instructions, and attempted to pre-set some of the job parameters
based on the results. By getting the correct results most of the time, it
saved operators a significant amount of effort, considering we had to process
several hundred jobs a day.

The project presented here is rebuilt from the ground up to be more generally
applicable. Generics are used to handle a wider range of applications. For
example, instead of comparing character strings within a larger body of text,
it would be possible to compare image slices within a larger image, or number
sequences within binary data.

## Installation
NGrammer is available on NuGet, so install using your preferred option:

**Package Manager**:  
`Install-Package NGrammer`

**.NET CLI**:  
`dotnet add package NGrammer`

**Visual Studio**:  
Right-click your project, select *Manage NuGet Packages...* (or similar),
then use the UI to search for *NGrammer* under the *Browse* link.

## Quick Start
Let's see how to train and predict different languages. To see the full code,
check out [this unit test](https://github.com/michaelmcmullin/ngram-categorisation/blob/a27530bb61d81db78860447890df0b84bd5b90c3/NGramXunitTests/NGrammerStringSetTests.cs)
(it's pretty much the same as what's here, but the text hasn't been truncated).

```C#
using NGrammer;
// ...
var tester = new NGrammer<string, StringSet>();

// Train the tester object so it can recognise different languages.
// Each training set is given a unique name (e.g. "English"), and some training data.
tester.AddTrainingSet("English", "[this is supposed to be a few paragraphs written in English]");
tester.AddTrainingSet("French", "[this is supposed to be a few paragraphs written in French]");
tester.AddTrainingSet("German", "[this is supposed to be a few paragraphs written in German]");

// Now that tester is trained, let's give it another piece of text, and see
// if it can predict what language it's written in.
string unknownLanguage = "[here's another bunch of text, let's say it's French]";

Console.WriteLine(tester.Predict(unknownLanguage));
// OUTPUT:
// French
```

### StringSet
So what is a `StringSet` in the above code? It turns out that `NGrammer` can work
with any type of data, so long as it implements `IEquatable<T>` (numerics, strings
and any class that implements it). However, it also needs an implementation of
`INGramSet<T>`, where `T` is the type you want to work with.

As N-Grams are commonly associated with textual data, a `StringSet` implementation
is included out of the box. So the first line:

```C#
var tester = new NGrammer<string, StringSet>();
```
...ensures that `tester` works with strings using the `StringSet` class. Check
out the files `INGramSet.cs`, `NGramSets/StringSet.cs` to see how they work.
Feel free to implement your own implementation so you can train and predict
data your own way.
