using System.Text.Json.Serialization;

namespace dotnetRPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,

        Cleric
    }
}
