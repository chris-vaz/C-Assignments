// Magic Caster

// Health starts at a default of 80
// Attacks: Fireball -> 25 damage
// Shield -> 0 damage
// Staff Strike -> 15 damage

// Heal Method - The fighter heals a targeted Enemy character for 40 health and displays
// the new health at the end

class MagicCaster:Enemy{
    public MagicCaster():base("Magic-Caster",80,new List<Attack>{new Attack("Fireball",25), new Attack("Shield",0), new Attack("Staff Strike",15)}){

    }

    public void Heal(Enemy enemy){
        enemy.HealthAmount+=40;
        Console.WriteLine($"Magic Caster healed {enemy} with 40 health");
        Console.WriteLine($"{enemy} health now: {enemy.HealthAmount}");
    }
}