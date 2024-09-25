using System.IO.Abstractions;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class FilesParser : IFilesParser
{
    public FilesParser()
    {
    }

    //convert files contents to FileData list
    public IEnumerable<FileData> ParseFiles(IEnumerable<string> files)
    {
        List<FileData> result = new List<FileData>();
        foreach (string fileName in files)
        {
            FileData? fileData = GetFileData(fileName);
            if (fileData is FileData fd)
                result.Add(fd);
        }

        return result;
    }

    public IEnumerable<Data> ParseOneFile(string fileName)
    {
        IContentParser? parser = new ParserFactory().GetContentParser(fileName);
        if (parser != null)
            return parser.Parse(new FileUtility(new FileSystem()).GetContent(fileName));

        return Enumerable.Empty<Data>();
    }

    public FileData? GetFileData(string fileName)
    {
        var dataList = ParseOneFile(fileName);
        if (dataList.Count<Data>() > 0)
            return new FileData(dataList, fileName);

        return null;
    }
}