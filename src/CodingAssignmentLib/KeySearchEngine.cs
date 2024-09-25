using CodingAssignmentLib.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO.Abstractions;
using System.Diagnostics;

namespace CodingAssignmentLib;

public class KeySearchEngine : ISearchEngine
{
    public IEnumerable<FileData> Search(string term, IEnumerable<FileData> fileList)
    {
        List<FileData> resultList = new List<FileData>();

        if(string.IsNullOrEmpty(term))
            return resultList;

        foreach (var fileData in fileList)
        {
            List<Data> resultData = new List<Data>();
            foreach (var data in fileData.Data)
            {
                //case insensitive search
                if (data.Key.ToLower().StartsWith(term.ToLower()))
                    resultData.Add(data);
            }

            if(resultData.Count > 0)
                resultList.Add(new FileData(resultData, fileData.FileName));
        }

        return resultList;
    }
}