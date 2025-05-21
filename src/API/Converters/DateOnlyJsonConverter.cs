using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Converters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string DateFormat = "yyyy-MM-dd"; // Specify the desired date format

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();

            if(string.IsNullOrEmpty(dateString))
            {
                return default;
            }

            return DateOnly.ParseExact(dateString, DateFormat);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }
    }
}
