// See https://aka.ms/new-console-template for more information
Console.WriteLine("Game Developer 1 Core Assignment");
Console.WriteLine("Game Developer 2 Core Assignment");

// 1. Create instances of the Melee, Ranged and Magic Caster classes
MeleeFighter melee=new MeleeFighter();
RangedFighter range=new RangedFighter();
MagicCaster magic= new MagicCaster();

// 2. Perform a Random Attack from your Melee class character
melee.RandomAttack();

// 3. Perform the Rage method from your Melee class character
melee.Rage();

// 4. Perform a Random Attack from your Ranged Class character
// (if you wrote everything as listed above, you should not have been able to attack due to the Distance constraint)
range.RandomAttack();

// 5. Perform the Dash method from your Ranged class character
range.Dash();

// 6. Perform another Random Attack from your Ranged Class character 
// (this one should have worked now if everything is set up properly)
range.RandomAttack();

// 7. Perform a Random Attack from your Magic Caster Class
magic.RandomAttack();

// 8. Perform the Heal method on the Ranged Instance
magic.Heal(range);

// 9. Perform the Heal method on yourself (The Magic Caster)
magic.Heal(magic);