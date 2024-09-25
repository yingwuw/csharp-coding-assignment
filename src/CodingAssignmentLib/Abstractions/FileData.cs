namespace CodingAssignmentLib.Abstractions;

public class FileData
{
    public FileData(IEnumerable<Data> data, string fileName)
    {
        Data = data;
        FileName = fileName;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        
        FileData other = (FileData)obj;

        // Compare FileName and Data
        return FileName == other.FileName && Data.SequenceEqual(other.Data);
    }

    public override int GetHashCode()
    {
        // Compute a hash code based on the FileName and Data
        int hash = 17;
        hash = hash * 23 + (FileName?.GetHashCode() ?? 0);
        hash = hash * 23 + (Data != null ? Data.Aggregate(0, (current, item) => current + (item?.GetHashCode() ?? 0)) : 0);
        return hash;
    }

    public IEnumerable<Data> Data { get; set; }
    public string FileName { get; set; }
}