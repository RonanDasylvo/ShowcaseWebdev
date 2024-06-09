using System.Text.Json;

namespace Showcase.Attributes;

public static class SessionExtensions
{
    public static void SetObjectAsJson<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetObjectFromJson<T>(this ISession session, string key)
    {
        string? value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}