using W6_assignment_template.Interfaces;
namespace W6_assignment_template.Models
{
    // Goblin is a character type that inherits common properties and methods from CharacterBase.
    // It implements ILootable, allowing its treasure to be looted by other characters.
    public class Goblin : CharacterBase, ILootable
    {

        // The treasure that the Goblin possesses, which can be looted by other characters.
        public string Treasure { get; set; }

        // Constructor initializes the Goblin's properties, including its treasure.
        public Goblin(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        // Implements the unique behavior required by CharacterBase.
        // This method is specific to Goblin and can be customized.
        public override void UniqueBehavior()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{Name} uses their unique behavior!");
            Console.ResetColor();
        }
    }
}