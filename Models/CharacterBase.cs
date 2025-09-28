using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    // CharacterBase is an abstract class that provides common properties and methods
    // for all character types in the game. It implements the ICharacter interface,
    // supporting the Dependency Inversion Principle and code reuse.
    public abstract class CharacterBase : ICharacter
    {
        // Common properties shared by all characters.
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        // Constructor for initializing character properties.
        protected CharacterBase(string name, string type, int level, int hp)
        {
            Name = name;
            Type = type;
            Level = level;
            HP = hp;
        }

        // Parameterless constructor for deserialization and flexibility.
        protected CharacterBase() { }

        // Implements the attack logic for all characters.
        // If the attacker is a Player and the target is lootable, the player takes the treasure.
        // If both attacker and target are Players, the attacker takes the target's gold.
        public void Attack(ICharacter target)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} attacks {target.Name}");
            Console.ResetColor();

            // Player attacks a lootable target (e.g., Goblin or Ghost)
            if (this is Player player && target is ILootable targetWithTreasure && !string.IsNullOrEmpty(targetWithTreasure.Treasure))
            {
                Console.WriteLine($"{Name} takes {targetWithTreasure.Treasure} from {target.Name}");
                player.Gold += 10; // Each treasure is worth 10 gold
                targetWithTreasure.Treasure = null; // Remove treasure from target
            }
            // Player attacks another Player and takes their gold
            else if (this is Player playerWithGold && target is Player targetWithGold && targetWithGold.Gold > 0)
            {
                Console.WriteLine($"{Name} takes gold from {target.Name}");
                playerWithGold.Gold += targetWithGold.Gold;
                targetWithGold.Gold = 0; // Remove gold from target
            }
        }

        // Implements movement logic for all characters.
        public void Move()
        {
            Console.WriteLine($"{Name} moves.");
        }

        // Abstract method for unique behavior to be implemented by derived classes
        public abstract void UniqueBehavior();
    }
}
