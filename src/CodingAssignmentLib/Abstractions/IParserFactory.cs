namespace CodingAssignmentLib.Abstractions;

public interface IParserFactory
{
    IContentParser? GetContentParser(string fileName);
}