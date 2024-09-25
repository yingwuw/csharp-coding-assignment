using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class CsvContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        //data.csv new-line was interpretted as "\n"
        //but Environment.NewLine was interpretted as "\r\n" on my computer
        return content.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(line =>
        {
            var items = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return new Data(items[0], items[1]);
        });
    }
}