using System.IO.Abstractions;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class DirUtility : IDirUtility
{
    public DirUtility()
    {
    }

    //read all files in dirName and its sub directories
    public IEnumerable<string> GetFiles(string dirName)
    {
        List<string> files = new List<string>();    
        string[] fileEntries = Directory.GetFiles(dirName);
        foreach (string fileName in fileEntries)
            files.Add(fileName);

        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(dirName);
        foreach (string subdirectory in subdirectoryEntries)
        {
            files.AddRange(GetFiles(subdirectory));
        }

        return files;
    }
}