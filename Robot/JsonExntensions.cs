using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Robot
{
    public static class JsonExntensions
    {
        public static void Dump(this object input)
        {
            var dump = JsonSerializer.Serialize(input, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            Console.WriteLine(dump);
        }
    }
}