namespace W6_assignment_template.Interfaces
{
    // ICharacter defines the essential contract for all character types in the game.
    // This abstraction supports the Dependency Inversion Principle by allowing game logic
    // to interact with any character type through a common interface.
    public interface ICharacter
    {
        // Performs an attack on another character.
        // The target is also an ICharacter, enabling polymorphic interactions.
        void Attack(ICharacter target);

        // Moves the character to a new location or state.
        void Move();

        // The name of the character.
        string Name { get; set; }
    }
}