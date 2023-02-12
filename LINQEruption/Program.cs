// See https://aka.ms/new-console-template for more information
Console.WriteLine("LINQ Eruption! Core Assignment");

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// 1. Use LINQ to find the first eruption that is in Chile and print the result.

Alternate -
IEnumerable<Eruption> findFirstEruptionChile = eruptions.FirstOrDefault(c => c.Location == "Chile");

Eruption findFirstEruptionChile = eruptions.FirstOrDefault(c => c.Location == "Chile");
if (findFirstEruptionChile != null)
{
    Console.WriteLine(findFirstEruptionChile.ToString()); 
    // Can also output like this^
}
else
{
    Console.WriteLine("No eruption found in Chile");
}
PrintEach(findFirstEruptionChile,"First Eruption that is in Chile: ");

// 2. Find the first eruption from the "Hawaiian Is" location and print it. 
// If none is found, print "No Hawaiian Is Eruption found."
Eruption firstEruptionHawaiian = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
if (firstEruptionHawaiian != null)
{
    Console.WriteLine(firstEruptionHawaiian.ToString());
}
else
{
    Console.WriteLine("No eruption found in Hawaiian Is");
}

// 3. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption thirdprompt = eruptions.FirstOrDefault(p => p.Location == "New Zealand" && p.Year > 1900);
if (thirdprompt != null)
{
    Console.WriteLine(thirdprompt);
}
else
{
    Console.WriteLine("No eruptions found that match the criteria.");
}

// 4. Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> fourthprompt = eruptions.Where(e=>e.ElevationInMeters>2000);
PrintEach(fourthprompt, "Volcano's elevation over 2000m:");

// 5. Find all eruptions where the volcano's name starts with "L" and print them. 
// Also print the number of eruptions found.
IEnumerable<Eruption> fifthprompt = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(fifthprompt, "All volcano's name starting with L: ");
Console.WriteLine("Number of eruptions found: " + fifthprompt.Count());

// 6. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int sixthprompt = eruptions.Max(p=>p.ElevationInMeters);
Console.WriteLine("Highest Elevation: "+sixthprompt);

// 7. Use the highest elevation variable to find and print the name of the 
// Volcano with that elevation.
Eruption seventhprompt = eruptions.FirstOrDefault(p=>p.ElevationInMeters==sixthprompt);
Console.WriteLine("The volcano with the highest elevation is: " + seventhprompt.Volcano);

// 8. Print all Volcano names alphabetically.
IEnumerable<Eruption> eigthprompt = eruptions.OrderBy(e => e.Volcano);
PrintEach(eigthprompt, "Sorted Volcano names alphabetically: ");

// 9. Print the sum of all the elevations of the volcanoes combined.
int ninthprompt = eruptions.Sum(s=>s.ElevationInMeters);
Console.WriteLine("Sum of all the Elevations of the volcanoes( in meters ): "+ninthprompt);

// 10. Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool tenthprompt= eruptions.Any(y=>y.Year==2000);
Console.WriteLine("Volcanoes erupted in the year 2000: "+tenthprompt);

// 11. Find all stratovolcanoes and print just the first three 
// (Hint: look up Take)
IEnumerable<Eruption> stratovolcanoes = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(stratovolcanoes, "First three volcanoes with type Stratovolcanoes: ");

// 12. Print all the eruptions that happened before the year 1000 CE alphabetically 
// according to Volcano name.
IEnumerable<Eruption> twelveprompt = eruptions.Where(e=>e.Year<1000).OrderBy(e => e.Volcano);
PrintEach(twelveprompt, "Sorted Volcanoes before 1000 CE: ");

// 13. Redo the last query, but this time use LINQ to only select the volcano's 
// name so that only the names are printed.
IEnumerable<string> lastPrompt = eruptions.Where(e=>e.Year<1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
Console.WriteLine("Sorted Volcanoes before 1000 CE: (Only names)");
foreach (string name in lastPrompt)
{
    Console.WriteLine(name);
}

// Find the first eruption from the "Greenland" location and print it. 
// If none is found, print "No Greenland Eruption found."
Eruption firstEruptionGreenland = eruptions.FirstOrDefault(c => c.Location == "Greenland");
if (firstEruptionGreenland != null)
{
    Console.WriteLine(firstEruptionGreenland.ToString());
}
else
{
    Console.WriteLine("No eruption found in Greenland");
}


// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
