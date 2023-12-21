using NYTTFORSOK;
using Xunit;


namespace NYTTFORSOK_tests;

public class FileService_Tests
{
    [Fact]

    public void GetContentFromFile_FileExists_ReturnsList()
    {
        // Arrange
        string filePath = @"C:\my-projects\NYJSONFIL.json";
        FileService fileService = new FileService(); 

        // Act
        var result = fileService.GetContentFromFile(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Contact>>(result);
        Assert.True(result.Count > 0);
    }

    [Fact]
    public void GetContentFromFile_FileDoesNotExist_ReturnsEmptyList()
    {
        // Arrange
        var filePath = @$"C:\{Guid.NewGuid()}\test.json";
        var fileService = new FileService(); 

        // Act
        var result = fileService.GetContentFromFile(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Contact>>(result);
        Assert.Empty(result);
    }
}
