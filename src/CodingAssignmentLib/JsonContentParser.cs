using System.Collections.Generic;
using System.Text.Json;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class JsonContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        if (string.IsNullOrEmpty(content))
            return Enumerable.Empty<Data>();

        List<Data>? keyValuePairs;
        try
        {
            // Deserialize the JSON content into a list of Data objects
            keyValuePairs = JsonSerializer.Deserialize<List<Data>>(content);
        }
        catch(Exception e) {
            Console.WriteLine(e.Message);
            return Enumerable.Empty<Data>();
        }
        
        return keyValuePairs == null ? Enumerable.Empty<Data>() : keyValuePairs;

    }
}