class Vehicle
{
    public string Name;
    public int Passengers;
    public string Color;
    public bool Engine;
    public int TopSpeed;
    public int Miles;
    public List<Vehicle> vehicleList = new List<Vehicle>();

    public Vehicle(string name, int passengers, string color, bool engine, int topspeed)
    {
        Name = name;
        Passengers = passengers;
        Color = color;
        Engine = engine;
        TopSpeed = topspeed;
        Miles = 0;
    }
    public Vehicle(string name, string color)
    {
        Name = name;
        Passengers = 0;
        Color = color;
        Engine = false;
        TopSpeed = 0;
        Miles = 0;
    }
    public void ShowInfo()
    {
        Console.WriteLine("Vehicle Details: ");
        Console.WriteLine($"Vehicle Name: {Name}");
        Console.WriteLine($"Number of Passengers the vehicle can carry: {Passengers}");
        Console.WriteLine($"Color of the Vehicle: {Color}");
        Console.WriteLine($"Whether or not the vehicle has Engine: {Engine}");
        Console.WriteLine($"Top Speed: {TopSpeed}");
        Console.WriteLine($"Miles Travelled: {Miles}");
    }
    public void Travel(int distance)
    {
        Miles += distance;
        Console.WriteLine($"Total Updated Miles Covered: {Miles}");
    }

    // // Put all the vehicles you created into a list
    // void CreateList()
    // {
    //     vehicleList.Add(Car);
    //     vehicleList.Add(Bike);
    //     vehicleList.Add(RollerBlade);
    // }

    // Loop through the List and have each vehicle run its ShowInfo() method
    public void LoopShow()
    {
        foreach (Vehicle v in vehicleList)
        {
            v.ShowInfo();
        }
    }

    // Make one of the vehcles travel 100 miles
    // Print the information of the vehicle to verify the 
    // distance travelled went up
    public void TravelHundred()
    {
        Miles += 100;
        Console.WriteLine("Distance Travelled Increased!");
        Console.WriteLine($"Total Miles Covered: {Miles}");
    }

}
