using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private const string TimeFormat = "HH:mm:ss"; // Customize the time format if needed

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timeString = reader.GetString();
        if (string.IsNullOrWhiteSpace(timeString))
        {
            throw new JsonException("Invalid time value.");
        }

        if (TimeOnly.TryParseExact(timeString, TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
        {
            return time;
        }

        throw new JsonException($"Invalid time format. Expected format is '{TimeFormat}'.");
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}
