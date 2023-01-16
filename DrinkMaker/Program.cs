// See https://aka.ms/new-console-template for more information
Console.WriteLine("Drink Maker Practice Assignment");


Soda Coke = new Soda("Coca Cola", "brown", 38, 140, true);
Coffee Cappuccino = new Coffee("French Vanilla Cappuccino", "light brown", 120, 110, "light", "coffee beans");
Wine Merlot = new Wine("Merlot", "red", 32, 120, "Bordeaux", 1992);

// Create a list called AllBeverages and add all your instances to it
// (If this is completed, Congrats! You just practiced polymorphism)
List<Drink> AllBeverages=new List<Drink>(); 
AllBeverages.Add(Coke);
AllBeverages.Add(Cappuccino);
AllBeverages.Add(Merlot);


// Add a "Show Drink" method to your Drink class that displays information about the drink
// Loop through your list of AllBeverages and call the ShowDrink() method for each. 
// (Something appears to be missing, right?)
foreach(Drink a in AllBeverages){
    a.ShowDrink();
}

//Write override methods for each child class that properly displays each class's unique 
// fields and run your loop again (Much better now!)

// Bonus: Try this line of code Cofee MyDrink = new Soda();
// What is wrong with this? Why will it not work?
// Leave a reccomended note about it in Program.cs

// A recommended note would be to always double-check the 
// class and variable names for typos and to make sure 
// that the class being assigned to the variable is the same 
// class that is being instantiated.