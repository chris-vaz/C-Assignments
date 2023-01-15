class Enemy
{
    public string Name;

    public int HealthAmount;

    public List<Enemy> Attacks = new List<Enemy>();

    public Enemy(string name, int amount)
    {
        Name = name;
        HealthAmount=100;
        Attacks= new List<string>();
    }

    public void RandomAttack(){
        if(Attacks.Count>0){
            Random rand= new Random();
            int index=rand.Next(Attacks.Count);
            Console.WriteLine($"{Name} performs {Attacks[index]} attack.");
        }
        else{
            Console.WriteLine($"{Name} have no attacks to perform");
        }
    }

    public void AddAttack(Attack NewAttack){
        Attack.add(NewAttack);
    }
}