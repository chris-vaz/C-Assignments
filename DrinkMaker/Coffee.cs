class Coffee : Drink{ 
    public string Roast; 
    public string Beans; 

    public Coffee(string n,string col, double t, int cal, string r, string b): base(n,col,t,true,cal){
        Roast=r;
        Beans=b;
    }
    public override void ShowDrink(){
        base.ShowDrink();
        Console.WriteLine($"Roast: {Roast}");
        Console.WriteLine($"Beans: {Beans}");
    }
}