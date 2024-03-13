using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Helpers
{
    /*
     * Read: This method is responsible for deserializing JSON to a TimeOnly object.
     * It checks if the JSON token type is a string, then parses the string value using TimeOnly.
     * ParseExact. It expects the time string in the format "HH:mm".
     * If the token type is not a string or if the time string is null,
     * it throws a JsonException.
     * Write: This method serializes a TimeOnly value to JSON.
     * It writes the time string representation using the "HH:mm" format.
    */
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is JsonTokenType.String)
            {
                string? timeString = reader.GetString();

                ArgumentNullException.ThrowIfNull(timeString, nameof(timeString));
                return TimeOnly.ParseExact(timeString, "HH:mm", null);

            }
            else
                throw new InvalidCastException("can not cast ");

        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("HH:mm"));
        }
    }
}
