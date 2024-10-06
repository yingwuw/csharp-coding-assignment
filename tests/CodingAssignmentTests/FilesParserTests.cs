using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentTests;

public class FilesParserTests
{
    private FilesParser _sut = null!;
    private List<string> _files;
    private List<FileData> _expected;

    [SetUp]
    public void Setup()
    {
        _sut = new FilesParser();
        _files = new List<string>(){
            "data/data-utest.csv",
            "data/data-utest.xml",
            "data/data-utest.json"
        };

        _expected = new List<FileData>()
        {
            new(new List<Data>{new("x", "y"),
                                new("u", "v"),
                                new("w", "z")},
                               "data/data-utest.csv"),
             new(new List<Data>{new("a", "b"),
                                new("c", "d"),
                                new("e", "f")},
                               "data/data-utest.xml"),
             new(new List<Data>{new("1", "2"),
                                new("3", "4"),
                                new("5", "6")},
                               "data/data-utest.json")
        };
    }

    [Test]
    public void ParseFiles_ReturnsData()
    {
        //var filesData = _sut.ParseFiles(_files).ToList();
        //Assert.That(filesData, Is.EqualTo(_expected).AsCollection);
    }

    [Test]
    public void ParseEmptyFiles_Return()
    {
        var filesData = _sut.ParseFiles(new List<string>()).ToList();
        Assert.That(filesData, Is.EqualTo(new List<FileData>()).AsCollection);
    }

    [Test]
    public void ParseNonExistsFiles_Return()
    {
        var filesData = _sut.ParseFiles(new List<string>{ "noexist.xml" }).ToList();
        Assert.That(filesData, Is.EqualTo(new List<FileData>()).AsCollection);
    }

    [Test]
    public void ParseUnsupportedFiles_Return()
    {
        var filesData = _sut.ParseFiles(new List<string> { "data/data-utest.txt" }).ToList();
        Assert.That(filesData, Is.EqualTo(new List<FileData>()).AsCollection);
    }

    [Test]
    public void ParseCsvFile_ReturnsDataList()
    {
        //var fileData = _sut.ParseOneFile(_files[0]).ToList();
       // Assert.That(fileData, Is.EqualTo(_expected[0].Data).AsCollection);
    }

    [Test]
    public void ParseXmlFile_ReturnsDataList()
    {
        var fileData = _sut.ParseOneFile(_files[1]).ToList();
        Assert.That(fileData, Is.EqualTo(_expected[1].Data).AsCollection);
    }

    [Test]
    public void ParseJsonFile_ReturnsDataList()
    {
        var fileData = _sut.ParseOneFile(_files[2]).ToList();
        Assert.That(fileData, Is.EqualTo(_expected[2].Data).AsCollection);
    }

    [Test]
    public void ParseUnsupportedFile_ReturnsDataList()
    {
        var fileData = _sut.ParseOneFile("data/data-utest.txt").ToList();
        Assert.That(fileData, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseNonExistFile_ReturnsDataList()
    {
        var fileData = _sut.ParseOneFile("noexist.xml").ToList();
        Assert.That(fileData, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseEmptyFile_ReturnsDataList()
    {
        var fileData = _sut.ParseOneFile("data/data-empty.xml").ToList();
        Assert.That(fileData, Is.EqualTo(new List<Data>()).AsCollection);
    }

    [Test]
    public void ParseCsvFile_ReturnsFileData()
    {
        //FileData? fileData = _sut.GetFileData(_files[0]);
        //Assert.That(fileData, Is.EqualTo(_expected[0]).AsCollection);
    }

    [Test]
    public void ParseXmlFile_ReturnsFileData()
    {
        FileData? fileData = _sut.GetFileData(_files[1]);
        Assert.That(fileData, Is.EqualTo(_expected[1]).AsCollection);
    }

    [Test]
    public void ParseJsonFile_ReturnsFileData()
    {
        FileData? fileData = _sut.GetFileData(_files[2]);
        Assert.That(fileData, Is.EqualTo(_expected[2]).AsCollection);
    }

    [Test]
    public void ParseUnsupportedFile_ReturnsFileData()
    {
        FileData? fileData = _sut.GetFileData("data/data-utest.txt");
        Assert.That(fileData, Is.EqualTo(null).AsCollection);
    }

    [Test]
    public void ParseNonExistFile_ReturnsFileData()
    {
        FileData? fileData = _sut.GetFileData("noexist.xml");
        Assert.That(fileData, Is.EqualTo(null).AsCollection);
    }

    [Test]
    public void ParseEmptyFile_ReturnsFileData()
    {
        FileData? fileData = _sut.GetFileData("data/data-empty.xml");
        Assert.That(fileData, Is.EqualTo(null).AsCollection);
    }
}