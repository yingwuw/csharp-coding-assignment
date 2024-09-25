using System.Xml.Linq;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class XmlContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        List<Data> res = new List<Data>();
        if (string.IsNullOrEmpty(content))
            return res;

        XDocument xmlDoc;
        try {
            xmlDoc = XDocument.Parse(content);
        }
        catch (System.Xml.XmlException e)
        {
            Console.WriteLine(e.Message);
            return res;
        }

        foreach (var element in xmlDoc.Descendants("Data"))
        {
            if (element.Element("Key") == null || element.Element("Value") == null)
                continue;

            string? key = element.Element("Key")?.Value;
            string? value = element.Element("Value")?.Value;

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                res.Add(new Data(key, value));
            }
        }

        return res;

    }
}