using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentTests;

public class KeySearchEngineTests
{
    private KeySearchEngine _sut = null!;
    private List<FileData> _fileDataList = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new KeySearchEngine();
        _fileDataList = new List<FileData> {
            new(new List<Data>{new("a0", "b0"),
                               new("c0", "d0"),
                               new("e0", "f0")},
                               @"dummyPath\test1.csv"),
            new(new List<Data>{new("C1", "D1"),
                               new("E1", "F1"),
                               new("A1", "B1")},
                               @"dummyPath\test2.xml"),
            new(new List<Data>{new("cC2", "dD2"),
                               new("aA2", "bB2"),
                               new("eE2", "fF2")},
                               @"dummyPath\test3.json"),
            new(new List<Data>{new("aAa0", "aAa0"),
                               new("cCc0", "cCc0"),
                               new("eEe0", "eEe0")},
                               @"dummyPath\test4.csv"),
            new(new List<Data>{new("CCC1", "DDD1"),
                               new("AAA1", "BBB1"),
                               new("EEE1", "EEE1")},
                               @"dummyPath\test5.xml"),
            new(new List<Data>{new("x2", "y2"),
                               new("u2", "v2"),
                               new("i2", "j2")},
                               @"dummyPath\test6.json")
        };
    }

    [Test]
    public void Search_SomeReturnsData()
    {
        var dataList = _sut.Search("a", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData>
        {
             new(new List<Data>{new("a0", "b0")},
                               @"dummyPath\test1.csv"),
             new(new List<Data>{new("A1", "B1") },
                               @"dummyPath\test2.xml"),
             new(new List<Data>{new("aA2", "bB2") },
                               @"dummyPath\test3.json"),
             new(new List<Data>{new("aAa0", "aAa0") },
                               @"dummyPath\test4.csv"),
             new(new List<Data>{new("AAA1", "BBB1") },
                               @"dummyPath\test5.xml")
        }).AsCollection);
    }

    [Test]
    public void Search_EmptyReturn()
    {
        var dataList = _sut.Search("b", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData> { }).AsCollection);
    }

    [Test]
    public void Search_OneReturn()
    {
        var dataList = _sut.Search("aaa0", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData> {
            new(new List<Data>{new("aAa0", "aAa0") },
                               @"dummyPath\test4.csv"),
        }).AsCollection);
    }

    [Test]
    public void Search_TermEmtpy()
    {
        var dataList = _sut.Search("", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData> {}).AsCollection);
    }

    [Test]
    public void Search_DataListEmpty()
    {
        var dataList = _sut.Search("u0", new List<FileData>()).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData> { }).AsCollection);
    }

    [Test]
    public void SearchSpecialChar_DataList()
    {
        var dataList = _sut.Search("\n", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData> { }).AsCollection);
    }

    [Test]
    public void SearchCapString_DataList()
    {
        var dataList = _sut.Search("AA", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData>
        {
             new(new List<Data>{new("aA2", "bB2") },
                               @"dummyPath\test3.json"),
             new(new List<Data>{new("aAa0", "aAa0") },
                               @"dummyPath\test4.csv"),
             new(new List<Data>{new("AAA1", "BBB1") },
                               @"dummyPath\test5.xml")
        }).AsCollection);
    }

    [Test]
    public void SearchMixUpLow_DataList()
    {
        var dataList = _sut.Search("aA", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData>
        {
             new(new List<Data>{new("aA2", "bB2") },
                               @"dummyPath\test3.json"),
             new(new List<Data>{new("aAa0", "aAa0") },
                               @"dummyPath\test4.csv"),
             new(new List<Data>{new("AAA1", "BBB1") },
                               @"dummyPath\test5.xml")
        }).AsCollection);
    }

    [Test]
    public void Search_LongMatchTerm()
    {
        var dataList = _sut.Search("AAAA1", _fileDataList).ToList();
        Assert.That(dataList, Is.EqualTo(new List<FileData> { }).AsCollection);
    }
}