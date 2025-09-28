using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    // Ghost is a character type that inherits common properties and methods from CharacterBase.
    // It implements IFlyable to provide flying behavior and ILootable to allow its treasure to be looted.
    public class Ghost : CharacterBase, IFlyable, ILootable
    {
        // The treasure that the Ghost possesses, which can be looted by other characters.
        public string Treasure { get; set; }

        // Constructor initializes the Ghost's properties, including its treasure.
        public Ghost(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        // Implements the flying behavior defined by IFlyable.
        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }

        // Implements the unique behavior required by CharacterBase.
        // This method is specific to Ghost and can be customized.
        public override void UniqueBehavior()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} uses their unique behavior!");
            Console.ResetColor();
        }
    }
}
