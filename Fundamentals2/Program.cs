// See https://aka.ms/new-console-template for more information
Console.WriteLine("Fundamentals 2 Core Assignment");

// Three Basic Arrays
// 1. Create an integer array with the values 0 through 9 inside
// 2. Create a string array with the names "Tim", "Martin", "Nikki"
// and "Sara". 
// 3. Create a boolean array of length 10. Then fill it with 
// alternating true/false values, starting with true.
// (Tip: Do this using logic! Do not hard code the values in!)

// Solution 1
int[] intArray = {0,1,2,3,4,5,6,7,8,9};

// Solution 2
string[] names = {"Tim","Martin","Nikki","Sara"};

//Solution 3
bool[] alt= new bool[10];

// List of Flavors
// 1. Create a string list of ice cream flavors that holds atleast
// 5 different flavors (Feel free to add more than 5)
List<string> flavors=new List<string>();
flavors.Add("Chocolate");
flavors.Add("Vanilla");
flavors.Add("Butterscotch");
flavors.Add("Strawberry");
flavors.Add("Mango");
flavors.Add("Blueberry");

// 2. Output the length of the list after you added the flavors
Console.WriteLine($"Length of the List: {flavors.Count}");

// 3. Output the third flavor of the list
Console.WriteLine($"The third flavor on your list: {flavors[2]}");

// 4. Now remove the third flavor using it's index location
flavors.Remove("Butterscotch");
// 5. Output the length of the list again, it should be one fewer
Console.WriteLine($"Updated Length of the List: {flavors.Count}");

// User Dictionary
// 1. Create a dictionary that will store string keys and string values
Dictionary<string,string> dict= new Dictionary<string, string>();

// 2. Add key/value pairs to the dictonary where: 
// - Each key is a name from your names array (this can be done by hand or
// using logic)
// - Each value is a randomly selected flavor from your flavors list
// (remember the Random function)

// 3. Loop through the dictionary and print out each user's name
// and their associated ice cream flavor

Dictionary<string,string> names_dict= new Dictionary<string, string>();
Random rand=new Random();

foreach (string name in names)
{
    names_dict.Add(name, flavors[rand.Next(0,flavors.Count)]);
}

foreach (KeyValuePair<string,string> entry in names_dict)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}


