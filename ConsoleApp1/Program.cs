using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Composite;
using Mandatory2DGameFramework.model.CreatureTypes;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.Decorator;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Observer;
using Mandatory2DGameFramework.Strategy;
using Mandatory2DGameFramework.worlds;
using System.Diagnostics;



Trace.AutoFlush = true;
MyLogger.Instance.AddListener(new ConsoleTraceListener());
MyLogger.Instance.AddListener(new TextWriterTraceListener("log.txt"));
MyLogger.Instance.LogInfo("Singleton logger works!");
MyLogger.Instance.LogWarning("Low health warning");
MyLogger.Instance.LogError("Enemy attack error");

// Config
var config = GameConfigLoader.Load("C:\\Datamatiker Uddannelsen\\4.Semester Valgfager\\Programmering\\Mandatory2DGameFramework\\ConsoleApp1\\GameConfig.xml");
var world = new World(config.MaxX, config.MaxY);

// Creatures
var fighter1 = new Warrior { Name = "Warrior", HitPoint = 100 };
var fighter2 = new Dragon { Name = "Dragon", HitPoint = 120 };

// Weapons
fighter1.AddWeapons(
    new Sword { Name = "Sword", Hit = 15, Weight = 5 },
    new Pistol { Name = "Pistol", Hit = 12, Weight = 3 },
    new Sword { Name = "Sword", Hit = 15, Weight = 5 }
);

fighter2.AddWeapons(
    new Pistol { Name = "Pistol", Hit = 12, Weight = 3 },
    new Sword { Name = "Sword", Hit = 15, Weight = 5 }
);

AttackItemDecorator boosted = 
    new BoostDecorator(new Sword { Name = "Sword", Hit = 15, Weight = 5 }, 5);
fighter2.AddWeapons(boosted);

// combined to weapons
var combined = 
    new Sword { Name = "Sword", Hit = 15, Weight = 5 } + new Pistol { Name = "Pistol", Hit = 12, Weight = 3 };
fighter2.AddWeapons(combined);


// Defence
fighter1.DDefenceComposite.AddDefence(
    new Shield { Name = "Shield", ReduceHitPoint = 5 }
);
fighter2.DDefenceComposite.AddDefence(
    new Helmet { Name = "Helmet", ReduceHitPoint = 3 }
);

// Strategy
fighter1.SetAttackStrategy(new PowerAttack());
fighter2.SetAttackStrategy(new NormalAttack());

// Observer
var logger = new CreatureLogger();
fighter1.AddObserver(logger);
fighter2.AddObserver(logger);

// Battle
var random = new Random();
Creature attacker, defender;
if (random.Next(2) == 0)
{
    attacker = fighter1;
    defender = fighter2;
}
else
{
    attacker = fighter2;
    defender = fighter1;
}


const int MaxRounds = 10;
int round = 1;

while (fighter1.HitPoint > 0 && fighter2.HitPoint > 0 && round <= MaxRounds)
{
    Console.WriteLine($"--- Round {round} ---");
    Console.WriteLine($"{fighter1.Name} HP: {fighter1.HitPoint} | {fighter2.Name} HP: {fighter2.HitPoint}");

    attacker.PerformAttack(defender);
    if (defender.HitPoint <= 0) break;

    (attacker, defender) = (defender, attacker);
    round++;
}

Console.WriteLine(
    fighter1.HitPoint <= 0 ? $"{fighter2.Name} wins!" :
    fighter2.HitPoint <= 0 ? $"{fighter1.Name} wins!" :
    "Draw!"
);











#region another tests

//// ── Template Method ────────────────────────────────────────────
//Console.WriteLine("=== TEMPLATE METHOD TEST ===");
//warrior.ReceiveHit(20);
//Console.WriteLine($"Warrior HP after hit: {warrior.HitPoint}");

//Console.WriteLine("Testing death:");
//goblin.ReceiveHit(999);
//Console.WriteLine();

//// ── Decorator ─────────────────────────────────────────────────
//Console.WriteLine("=== DECORATOR TEST ===");
//AttackItem sword = new Sword();
//AttackItem boosted = new BoostDecorator(sword, 5);
//AttackItem weakened = new WeakenDecorator(sword, 3);
//AttackItem doubleBoosted = new BoostDecorator(boosted, 5);

//Console.WriteLine($"Sword:         {sword}");
//Console.WriteLine($"Boosted:       {boosted}");
//Console.WriteLine($"Weakened:      {weakened}");
//Console.WriteLine($"DoubleBoosted: {doubleBoosted}\n");

//// ── Operator Overload ──────────────────────────────────────────
//Console.WriteLine("=== OPERATOR OVERLOAD TEST ===");
//AttackItem combined = sword + boosted;
//Console.WriteLine($"Combined: {combined}\n");

//// ── Composite + Weight ─────────────────────────────────────────
//Console.WriteLine("=== COMPOSITE + WEIGHT TEST ===");
//var pistol = new Pistol { Weight = 5 };
//var sword2 = new Sword { Weight = 8 };
//var heavySword = new Sword { Name = "HeavySword", Weight = 20 };

//dragon.MaxWeight = 15;
//Console.WriteLine($"Dragon MaxWeight: {dragon.MaxWeight}");
//dragon.AddWeapon(pistol);     // Weight 5  – OK
//dragon.AddWeapon(sword2);     // Weight 8  – OK (total 13)
//dragon.AddWeapon(heavySword); // Weight 20 – Afvises!

//Console.WriteLine($"Total weapons added: {dragon.WeaponComposite.Attacks.Count}");
//Console.WriteLine($"Total weight: {dragon.WeaponComposite.TotalWeight()}");
//Console.WriteLine($"Total hit: {dragon.WeaponComposite.TotalHit()}\n");

//// ── DefenceComposite ───────────────────────────────────────────
//Console.WriteLine("=== DEFENCE COMPOSITE TEST ===");
//var shield = new DefenceItem { Name = "Shield", ReduceHitPoint = 5 };
//var helmet = new DefenceItem { Name = "Helmet", ReduceHitPoint = 3 };

//warrior.DDefenceComposite.AddDefence(shield);
//warrior.DDefenceComposite.AddDefence(helmet);
//Console.WriteLine($"Total defence reduction: {warrior.DDefenceComposite.TotalReduceHitPoint()}");
//warrior.ReceiveHit(20);
//Console.WriteLine($"Warrior HP after hit with defence: {warrior.HitPoint}\n");

//// ── Strategy ───────────────────────────────────────────────────
//Console.WriteLine("=== STRATEGY TEST ===");
//var newWarrior = new Warrior { Name = "Warrior2", HitPoint = 100 };
//var newGoblin = new Goblin { Name = "Goblin2", HitPoint = 100 };
//newGoblin.AddObserver(logger);

//newWarrior.SetAttackStrategy(new NormalAttack());
//Console.WriteLine("Normal attack:");
//newWarrior.PerformAttack(newGoblin);
//Console.WriteLine($"Goblin2 HP after normal attack: {newGoblin.HitPoint}");

//newWarrior.SetAttackStrategy(new PowerAttack());
//Console.WriteLine("Power attack:");
//newWarrior.PerformAttack(newGoblin);
//Console.WriteLine($"Goblin2 HP after power attack: {newGoblin.HitPoint}\n");

//// ── Cleanup ────────────────────────────────────────────────────
//Trace.Flush();
//MyLogger.Instance.RemoveListener(fileListener);
//Console.WriteLine("=== ALL TESTS DONE – check log.txt ===");

#endregion