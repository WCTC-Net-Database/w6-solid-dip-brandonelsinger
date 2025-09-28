using System.Text.Json;
using System.Text.Json.Serialization;
using W6_assignment_template.Models;

namespace W6_assignment_template.Data;

// Custom JSON converter for CharacterBase and its derived types.
// Enables polymorphic (type-aware) serialization and deserialization.
public class CharacterBaseConverter : JsonConverter<CharacterBase>
{
    // Reads JSON and deserializes it into the correct derived CharacterBase type.
    public override CharacterBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Parse the incoming JSON into a document for inspection.
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            // Extract the $type property to determine which derived type to instantiate.
            var typeProperty = root.GetProperty("$type").GetString();
            // Map the $type string to the actual .NET type.
            Type type = typeProperty switch
            {
                "W6_assignment_template.Models.Player" => typeof(Player),
                "W6_assignment_template.Models.Goblin" => typeof(Goblin),
                "W6_assignment_template.Models.Ghost" => typeof(Ghost),
                _ => throw new NotSupportedException($"Type {typeProperty} is not supported")
            };
            // Deserialize the JSON into the correct type and return as CharacterBase.
            return (CharacterBase)JsonSerializer.Deserialize(root.GetRawText(), type, options);
        }
    }

    // Serializes a CharacterBase (or derived) object to JSON.
    public override void Write(Utf8JsonWriter writer, CharacterBase value, JsonSerializerOptions options)
    {
        // Serialize the object using the default serializer.
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}