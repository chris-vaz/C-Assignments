// Melee Fighter

// Health starts at default 120
// Attacks: Punch -> 20, Kick -> 15 and Tackle -> 25 damage
// Rage: The fighter performs a random attack that deals 10 extra damage

class MeleeFighter : Enemy{
    public MeleeFighter():base("Melee", 120, new List<Attack>{
        new Attack("Punch",20),new Attack("Kick",15),new Attack("Tackle",25)}){

        }
    
    public void Rage(){
        Random rand=new Random();
        Attack randAttack=Attacks[rand.Next(0,Attacks.Count)];
        randAttack.Damage+=10;
        Console.WriteLine($"Used {randAttack} that dealt with 10 damage");
        Console.WriteLine($"Total Damage done: {randAttack.Damage}");
    }
    }
