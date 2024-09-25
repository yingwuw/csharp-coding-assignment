namespace CodingAssignmentLib.Abstractions;

public interface IDirUtility
{
    IEnumerable<string> GetFiles(string dirName);
}