using W6_assignment_template.Models;

namespace W6_assignment_template.Data
{
    // IContext defines the contract for data operations related to game characters.
    // This abstraction allows the game logic to interact with character data without depending on specific implementations.
    public interface IContext
    {
        // List of all characters in the game (players, goblins, ghosts, etc.).
        List<CharacterBase> Characters { get; set; }

        // Adds a new character to the data store.
        void AddCharacter(CharacterBase character);

        // Updates an existing character's properties in the data store.
        void UpdateCharacter(CharacterBase character);

        // Removes a character from the data store by name.
        void DeleteCharacter(string characterName);

    }
}
