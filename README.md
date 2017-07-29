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
