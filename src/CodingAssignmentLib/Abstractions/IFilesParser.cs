namespace CodingAssignmentLib.Abstractions;

public interface IFilesParser
{
    IEnumerable<FileData> ParseFiles(IEnumerable<string> files);
    IEnumerable<Data> ParseOneFile(string fileName);

}