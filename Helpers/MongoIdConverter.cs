using System;
using System.Linq;
using EFT;
using Newtonsoft.Json;

namespace ZGFueDkx.ZGCLib.Helpers;

// IL2CPP's JSON attributes belong to the native Newtonsoft assembly. Managed
// Newtonsoft cannot see them, so wire-format IDs need an explicit converter.
internal sealed class MongoIdConverter : JsonConverter
{
    public override bool CanConvert(Type type) => type == typeof(MongoID);
    public override object? ReadJson(JsonReader reader, Type type, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = reader.Value as string;
        if (reader.TokenType != JsonToken.String || value is null || value.Length != 24 || !value.All(Uri.IsHexDigit))
            throw new JsonSerializationException("Expected a 24-character MongoID string.");
        return new MongoID(value);
    }
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) => writer.WriteValue(value?.ToString());
}
