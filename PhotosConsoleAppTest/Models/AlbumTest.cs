using PhotosConsoleApp.Models;

public class AlbumTest
{
    /// <summary>
    /// Verifies that the properties are set currectly.
    /// </summary>
    [Fact]
    public void Test_Album_EmptyConstructor()
    {
        // Define
        int id = 34;
        int userId = 89;
        string title = "my nice title";

        // Process
        Album album = new Album() {
            Id = id,
            UserId = userId,
            Title = title
        };

        // Assert
        Assert.Equal(34, album.Id);
        Assert.Equal(89, album.UserId);
        Assert.Equal("my nice title", album.Title);
    }
}
