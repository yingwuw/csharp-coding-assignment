using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentTests;

public class CsvContentParserTests
{
    private CsvContentParser _sut = null!;
    
    [SetUp]
    public void Setup()
    {
        _sut = new CsvContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {

        //Environment.NewLine is "\r\n"
        //however, my computer csv files new-line reads as "\n"
        var content = "a,b\n" + "c,d\n";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.Not.EqualTo(new List<Data>
        {
            new("a", "b"),
            new("c", "d")
        }).AsCollection);
    }
}