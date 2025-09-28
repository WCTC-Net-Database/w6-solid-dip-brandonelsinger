namespace W6_assignment_template.Models
{
    // Player is a character type that inherits common properties and methods from CharacterBase.
    // It adds a Gold property and implements its own unique behavior.
    public class Player : CharacterBase
    {
        // The amount of gold the player possesses.
        public int Gold { get; set; }

        // Constructor initializes the player's properties, including gold.
        public Player(string name, string type, int level, int hp, int gold)
            : base(name, type, level, hp)
        {
            Gold = gold;
        }

        // Implements the unique behavior required by CharacterBase.
        // This method is specific to Player and can be customized.
        public override void UniqueBehavior()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} uses their unique behavior!");
            Console.ResetColor();
        }
    }
}
