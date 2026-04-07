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

// ── Logging setup ──────────────────────────────────────────────
var fileListener = new TextWriterTraceListener("log.txt");
Trace.AutoFlush = true;
var consoleListener = new ConsoleTraceListener();
MyLogger.Instance.AddListener(consoleListener);

Console.WriteLine("=== SINGLETON TEST ===");
MyLogger.Instance.LogInfo("Singleton logger works!");
MyLogger.Instance.LogWarning("Low health warning");
MyLogger.Instance.LogError("Enemy attack error");
Console.WriteLine("Singleton: Log entries written to log.txt\n");

// ── XML Konfiguration ──────────────────────────────────────────
Console.WriteLine("=== XML CONFIG TEST ===");
var config = GameConfigLoader.Load("C:\\Datamatiker Uddannelsen\\4.Semester Valgfager\\Programmering\\Mandatory2DGameFramework\\ConsoleApp1\\GameConfig.xml");
var world = new World(config.MaxX, config.MaxY);
Console.WriteLine($"World size: {world.MaxX} x {world.MaxY}");
Console.WriteLine($"Level: {config.Level}\n");

// ── Observer setup ─────────────────────────────────────────────
Console.WriteLine("=== OBSERVER TEST ===");
var warrior = new Warrior { Name = "Warrior", HitPoint = 100 };
var goblin = new Goblin { Name = "Goblin", HitPoint = 50 };
var dragon = new Dragon { Name = "Dragon", HitPoint = 200 };

var logger = new CreatureLogger();
warrior.AddObserver(logger);
goblin.AddObserver(logger);
dragon.AddObserver(logger);
Console.WriteLine("Observers added to Warrior, Goblin and Dragon\n");

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

// ── Turn-Based Battle Test ─────────────────────────────────────
Console.WriteLine("=== TURN-BASED BATTLE ===");

var fighter1 = new Warrior { Name = "Warrior", HitPoint = 100 };
var fighter2 = new Dragon { Name = "Dragon", HitPoint = 120 };

// Giv dem våben
fighter1.AddWeapon(new Sword { Name = "Sword", Hit = 15, Weight = 5 });
fighter2.AddWeapon(new Pistol { Name = "Pistol", Hit = 12, Weight = 3 });

// Giv dem strategier
fighter1.SetAttackStrategy(new NormalAttack());
fighter2.SetAttackStrategy(new PowerAttack());

// Tilføj observers
fighter1.AddObserver(logger);
fighter2.AddObserver(logger);

// Tilfældig hvem starter
var random = new Random();
Creature attacker = random.Next(2) == 0 ? fighter1 : fighter2;
Creature defender = attacker == fighter1 ? fighter2 : fighter1;

Console.WriteLine($"{attacker.Name} goes first!\n");

int maxRounds = 10;
int round = 1;

while (fighter1.HitPoint > 0 && fighter2.HitPoint > 0 && round <= maxRounds)
{
    Console.WriteLine($"--- Round {round} ---");
    Console.WriteLine($"{fighter1.Name} HP: {fighter1.HitPoint} | {fighter2.Name} HP: {fighter2.HitPoint}");

    // Attacker angriber defender
    Console.WriteLine($"{attacker.Name} attacks {defender.Name}!");
    attacker.PerformAttack(defender);

    // Tjek om defender er død
    if (defender.HitPoint <= 0)
        break;

    // Skift tur
    (attacker, defender) = (defender, attacker);
    round++;
    Thread.Sleep(2000); // Pause for at gøre det mere dramatisk
}

Console.WriteLine("\n=== BATTLE RESULT ===");
if (fighter1.HitPoint <= 0)
    Console.WriteLine($"{fighter2.Name} wins after {round} rounds!");
else if (fighter2.HitPoint <= 0)
    Console.WriteLine($"{fighter1.Name} wins after {round} rounds!");
else
    Console.WriteLine($"Draw after {maxRounds} rounds! {fighter1.Name} HP: {fighter1.HitPoint} | {fighter2.Name} HP: {fighter2.HitPoint}");


Console.BackgroundColor = ConsoleColor.Red;