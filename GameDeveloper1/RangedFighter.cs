// Ranged Fighter

// Ranged enemies have a Distance field that tracks how far the 
// player the ranged enemies is
// The Distance field defaults to 5 upon initialization
// Attacks: Shoot an arrow -> 20 damage
// Throw a Knife -> 15 damage

// A ranged enemy cannot perform an attack if Distance is less than 10

// Dash method - The figher performs a dash - setting Distance to 20

class RangedFighter: Enemy{
    public int Distance;
    public RangedFighter(int distance=5):base("Ranged", 100, new List<Attack>{new Attack("Shoot an Arrow",20),new Attack("Throw a Knife",15)}){
        Distance=distance;
    }

    public override void RandomAttack()
    {
        if(Distance<=10){
            Console.WriteLine("Cannot Perform an Attack. Low Distance");
            Console.WriteLine($"Your Current Distance is: {Distance}");
        }
        else{
            Console.WriteLine("Performed Random Attack");
            base.RandomAttack();
        } 
    }
    public void Dash(){
        Distance=20;
        Console.WriteLine("Performing a Dash");
        Console.WriteLine($"Current Distance: {Distance}");
    }
}