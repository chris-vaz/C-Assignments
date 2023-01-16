class Soda : Drink{ 
    public bool dietv; 

    public Soda(string n, string col, double t, int cal, bool diet ): base(n,col,t,true,cal){
        dietv=diet;
    }

    public override void ShowDrink(){
        base.ShowDrink();
        Console.WriteLine($"Is it a Diet Version?: {dietv}");
    }
}