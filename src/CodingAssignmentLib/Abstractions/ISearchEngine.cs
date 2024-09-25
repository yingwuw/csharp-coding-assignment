namespace CodingAssignmentLib.Abstractions;

public interface ISearchEngine
{
    IEnumerable<FileData> Search(string term, IEnumerable<FileData> fileList);
}