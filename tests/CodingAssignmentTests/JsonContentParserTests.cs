using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentTests;

public class JsonContentParserTests
{
    private JsonContentParser _sut = null!;
    
    [SetUp]
    public void Setup()
    {
        _sut = new JsonContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {
        var content = "[{\"Key\":\"a\",\"Value\":\"b\"},{\"Key\":\"c\",\"Value\":\"d\"}]";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>
        {
            new("a", "b"),
            new("c", "d")
        }).AsCollection);
    }

    [Test]
    public void ParseEmptyJson_Return()
    {
        var content = "[]";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.Empty);
    }

    [Test]
    public void ParseEmptyString_Return()
    {
        var content = "";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.Empty);
    }

    [Test]
    public void ParseInvalidString_Return()
    {
        var content = "abc";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.Empty);
    }

    [Test]
    public void ParseInvalidJsonEmpty_Return()
    {
        var content = "[{}]";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>{new(null!,null!)}).AsCollection);
    }

    [Test]
    public void ParseInvalidJsonPair_Return()
    {
        var content = "[{a, b}]";
        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.Empty);
    }
}