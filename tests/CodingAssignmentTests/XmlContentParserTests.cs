using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentTests;

public class XmlContentParserTests
{
    private XmlContentParser _sut = null!;
    
    [SetUp]
    public void Setup()
    {
        _sut = new XmlContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {
        var content = "<Root>" + Environment.NewLine
                            + "<Data>" + Environment.NewLine
                                + "<Key>1</Key>" + Environment.NewLine
                                + "<Value>2</Value>" + Environment.NewLine
                            + "</Data>" + Environment.NewLine
                            + "<Data>" + Environment.NewLine
                                + "<Key>3</Key>" + Environment.NewLine
                                + "<Value>4</Value>" + Environment.NewLine
                            + "</Data>" + Environment.NewLine
                            + "</Root>";


        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>
        {
            new("1", "2"),
            new("3", "4")
        }).AsCollection);
    }

    [Test]
    public void ParseEmptyXml_ReturnsData()
    {
        var content = "<Root/>";

        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseEmptyString_ReturnsData()
    {
        var content = "";

        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseInvalidFormat_ReturnsData()
    {
        var content = "abc";

        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseInvalidTag_ReturnsData()
    {
        var content = "<Root>" + Environment.NewLine
                            + "<Tag>" + Environment.NewLine
                                + "<Key>1</Key>" + Environment.NewLine
                                + "<Value>2</Value>" + Environment.NewLine
                            + "</Tag>" + Environment.NewLine
                            + "</Root>";

        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseInvalidXml_ReturnsData()
    {
        var content = "<Root>" + Environment.NewLine
                            + "<Tag>" + Environment.NewLine
                                + "<Key>1</Key>" + Environment.NewLine
                                + "<Value>2</Value>" + Environment.NewLine
                            + "</Tag>" + Environment.NewLine
                            + "</root>";

        var dataList = _sut.Parse(content).ToList();
        Assert.That(dataList, Is.EqualTo(new List<Data>()).AsCollection);
    }
}