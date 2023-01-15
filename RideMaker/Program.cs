// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ride Maker Practice Assignment");

// Create atleast 4 different vehicles using any of the constructors
// (use each constructor at least once)

Vehicle Car = new Vehicle("Honda Accord", 4, "Red", true, 220);
Vehicle Bike = new Vehicle("Mountain Bike", "Black");
Vehicle RollerBlade = new Vehicle("Rollerblades", 1, "White", false, 40);
Vehicle Boat = new Vehicle("Cruise Boat", 50, "White", true, 35);

Car.ShowInfo();
Car.Travel(300);
Car.ShowInfo();
Boat.ShowInfo();
Boat.TravelHundred();
Boat.ShowInfo();