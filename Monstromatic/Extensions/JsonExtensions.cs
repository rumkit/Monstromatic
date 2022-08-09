using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Monstromatic.Extensions;

public static class JsonExtensions
{
    public static MemoryStream ToJson<T>(this T data)
    {
        MemoryStream stream = new();
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        JsonSerializer.Serialize(stream, data, options);
        stream.Position = 0;
        
        return stream;
    }

    public static T FromJson<T>(this Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream);
    }
}