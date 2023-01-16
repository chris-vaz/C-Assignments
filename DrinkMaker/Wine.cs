class Wine: Drink{
    public string Region;
    public int Year;

    public Wine(string n, string col, double t, int cal, string region, int year):base(n,col,t,true,cal){
        Region=region;
        Year=year; 
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region-Based: {Region}");
        Console.WriteLine($"Origin: {Year}");
    }
}