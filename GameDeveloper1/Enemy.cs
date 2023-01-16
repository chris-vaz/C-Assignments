class Enemy
{
    public string Name;

    public int HealthAmount;

    public List<Attack> Attacks;

    public Enemy(string name, int health, List<Attack> attacks)
    {
        Name = name;
        HealthAmount=health;
        Attacks= attacks;
    }

    public virtual void RandomAttack(){
        if(Attacks.Count>0){
            Random rand= new Random();
            int index=rand.Next(0,Attacks.Count);
            Console.WriteLine($"{Name} performs {Attacks[index].Name} attack.");
        }
        else{
            Console.WriteLine($"{Name} have no attacks to perform");
        }
    }

    public void AddAttack(Attack NewAttack){
        Attacks.Add(NewAttack);
    }
}