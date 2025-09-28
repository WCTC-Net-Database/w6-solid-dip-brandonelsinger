using W6_assignment_template.Data;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    // GameEngine orchestrates the main game logic and interactions between characters.
    // It depends on the IContext abstraction for character data, supporting DIP.
    public class GameEngine
    {
        // Reference to the data context, which provides access to all game characters.
        private readonly IContext _context;

        // Constructor injects the data context dependency.
        public GameEngine(IContext context)
        {
            _context = context;
        }

        // Runs the main game demonstration, showing character states and interactions.
        public void Run()
        {
            // Retrieve the first Player, Goblin, and Ghost from the context.
            var player = _context.Characters.OfType<Player>().FirstOrDefault();
            var goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
            var ghost = _context.Characters.OfType<Ghost>().FirstOrDefault();

            // Ensure all required characters are present before proceeding.
            if (player == null || goblin == null || ghost == null)
            {
                Console.WriteLine("Failed to initialize all game characters.");
                return;
            }

            // Display the initial state of each character.
            Console.WriteLine($"\n--- Show the initial states ---");
            Console.WriteLine($"Player: {player.Name}, Gold: {player.Gold}");
            Console.WriteLine($"Goblin: {goblin.Name}, Treasure: {goblin.Treasure}");
            Console.WriteLine($"Ghost: {ghost.Name}, Treasure: {ghost.Treasure}");

            // Demonstrate movement for each character.
            Console.WriteLine($"\n--- Demonstrate movement ---");
            player.Move();
            goblin.Move();
            ghost.Move();

            // Demonstrate each character's unique behavior.
            Console.WriteLine($"\n--- Demonstrate unique behaviors ---");
            player.UniqueBehavior();
            goblin.UniqueBehavior();
            ghost.UniqueBehavior();

            // Demonstrate interface-specific action (flying) for Ghost.
            Console.WriteLine($"\n--- Demonstrate interface-specific action ---");
            if (ghost is IFlyable flyableGhost)
            {
                flyableGhost.Fly();
            }

            // Show gold and treasure before combat interactions.
            Console.WriteLine($"\n--- Before fight ---");
            Console.WriteLine($"{player.Name} Gold before fight: {player.Gold}");
            Console.WriteLine($"{goblin.Name} Treasure before fight: {goblin.Treasure}");
            Console.WriteLine($"{ghost.Name} Treasure before fight: {ghost.Treasure}");

            // Demonstrate combat and loot/gold transfer between characters.
            Console.WriteLine("\n--- Fight demonstrations ---");
            goblin.Attack(player); 
            player.Attack(goblin); 
            Console.WriteLine();
            player.Attack(ghost);
            ghost.Attack(player);

            // Show gold and treasure after combat interactions.
            Console.WriteLine($"\n--- After fight ---");
            Console.WriteLine($"\n{player.Name} Gold after fight: {player.Gold}");
            Console.WriteLine($"{goblin.Name} Treasure after fight: {goblin.Treasure}");
            Console.WriteLine($"{ghost.Name} Treasure after fight: {ghost.Treasure}");

            // Display the updated state of each character.
            Console.WriteLine($"\n--- Show updated states ---");
            Console.WriteLine($"Player: {player.Name}, Gold: {player.Gold}");
            Console.WriteLine($"Goblin: {goblin.Name}, Treasure: {goblin.Treasure}");
            Console.WriteLine($"Ghost: {ghost.Name}, Treasure: {ghost.Treasure}");
        }
    }
}