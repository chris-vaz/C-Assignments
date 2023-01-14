// See https://aka.ms/new-console-template for more information
Console.WriteLine("Debugging Practice Assignment");

// Challenge 1
bool amProgrammer = true;
double Age = 27.9;
List<string> Names = new List<string>();
Names.Add("Monica");
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
MyDictionary.Add("Hi there", "0");
// This is a tricky one! Hint: look up what a char is in C#
string MyName = "MyName";

// Challenge 2
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
for(int i = Numbers.Count; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]);
}

// Challenge 3
List<int> MoreNumbers = new List<int>() {12,7,10,-3,9};
foreach(int i in MoreNumbers)
{
    Console.WriteLine(MoreNumbers[i]);
}

// Challenge 4
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
foreach(int num in EvenMoreNumbers)
{
    if(num % 3 == 0)
    {
        EvenMoreNumbers[num] = 0;
    }
}

// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
MyString[7] = "p"; // This line is the error

// The error message is indicating that a string is immutable, 
// meaning it cannot be modified once it has been created. 
// The code is trying to change a character in the string by specifying an index and assigning a new value, 
// but this is not allowed in C#.

// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(12);
if(randomNum == 12)
{
    Console.WriteLine("Hello");
}
// bug is that the random number generator may produce the same number multiple times because the seed 
// of the random number generator is not set which means that it may generate the same sequence of random 
// numbers each time the program is run.