# N-Gram Categorisation
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

### INGramSet
This library organises N-Grams into sets, inheriting from `INGramSet<T>`. This
interface uses generics to accommodate many types of data.

### StringSet
As N-Grams are commonly associated with textual data, a `StringSet` class is
included out of the box. Its usage is straightforward: define a new `StringSet`
by passing it the text you want to parse. It will automatically generate a range
of N-Grams, from 1 to 5 in magnitude, and order them starting from the most
frequent.

Check out the unit tests for a sample that identifies the language of some text:

    //...
    StringSet englishTrainingParagraph = new StringSet(@"(a paragraph in English)");
    StringSet frenchTrainingParagraph = new StringSet(@"(a paragraph in French)");
    StringSet germanTrainingParagraph = new StringSet(@"(a paragraph in German)");
    //...
    StringSet testLanguage = new StringSet(@"(some sample text in French)");

    double distanceEnglish = testLanguage.GetDistance(englishTrainingParagraph);
    double distanceFrench = testLanguage.GetDistance(frenchTrainingParagraph);
    double distanceGerman = testLanguage.GetDistance(germanTrainingParagraph);
    
    // Lower 'distances' indicate better matches. Therefore, if distanceFrench is
    // less than distanceEnglish and distanceGerman, then it has been correctly
    // identified as the best match.
    Assert.IsTrue(distanceFrench < distanceEnglish);
    Assert.IsTrue(distanceFrench < distanceGerman);
