using System.IO.Abstractions;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class ParserFactory : IParserFactory
{
    public ParserFactory()
    {
    }

    public IContentParser? GetContentParser(string fileName)
    {
        var fileUtility = new FileUtility(new FileSystem());
        if (fileUtility.GetExtension(fileName) == ".csv")
        {
            return new CsvContentParser();
        }
        else if (fileUtility.GetExtension(fileName) == ".xml")
        {
            return new XmlContentParser();
        }
        else if (fileUtility.GetExtension(fileName) == ".json")
        {
            return new JsonContentParser();
        }

        return null;
    }

}