using System.Text.Json;
using W6_assignment_template.Models;

namespace W6_assignment_template.Data
{
    // DataContext provides data storage and management for all character types.
    // Implements IContext to abstract data operations for the game.
    public class DataContext : IContext
    {
        // Stores all characters (Player, Goblin, Ghost, etc.) in a single list.
        public List<CharacterBase> Characters { get; set; }  // Generalized to store all character types

        // JSON serialization options, including custom converter for polymorphic deserialization.
        private readonly JsonSerializerOptions options;

        // Constructor initializes serialization options and loads character data from file.
        public DataContext()
        {
            options = new JsonSerializerOptions
            {
                Converters = { new CharacterBaseConverter() }, // Enables polymorphic deserialization
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            LoadData(); // Load character data from JSON file on startup
        }

        // Loads character data from the input JSON file into the Characters list.
        private void LoadData()
        {
            var jsonData = File.ReadAllText("Files/input.json");
            Characters = JsonSerializer.Deserialize<List<CharacterBase>>(jsonData, options); // Load all character types
        }

        // Adds a new character to the list and saves changes to the file.
        public void AddCharacter(CharacterBase character)
        {
            Characters.Add(character);
            SaveData();
        }

        // Updates an existing character's properties and saves changes to the file.
        public void UpdateCharacter(CharacterBase character)
        {
            var existingCharacter = Characters.FirstOrDefault(c => c.Name == character.Name);
            if (existingCharacter != null)
            {
                // Update common properties
                existingCharacter.Level = character.Level;
                existingCharacter.HP = character.HP;

                // Update Player-specific property
                if (existingCharacter is Player player && character is Player updatedPlayer)
                {
                    player.Gold = updatedPlayer.Gold;  // Specific to Player
                }
                // Update Goblin-specific property
                if (existingCharacter is Goblin goblin && character is Goblin updatedGoblin)
                {
                    goblin.Treasure = updatedGoblin.Treasure;  // Specific to Goblin
                }

                SaveData();
            }
        }

        // Removes a character by name and saves changes to the file.
        public void DeleteCharacter(string characterName)
        {
            var character = Characters.FirstOrDefault(c => c.Name == characterName);
            if (character != null)
            {
                Characters.Remove(character);
                SaveData();
            }
        }

        // Serializes the Characters list and writes it to the input JSON file.
        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(Characters, options);
            File.WriteAllText("Files/input.json", jsonData);
        }
    }
}
