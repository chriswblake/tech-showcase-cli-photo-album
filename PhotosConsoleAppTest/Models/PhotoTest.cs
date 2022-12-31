using PhotosConsoleApp.Models;

public class PhotoTest
{
    /// <summary>
    /// Verifies that the properties are set currectly.
    /// </summary>
    [Fact]
    public void Test_Photo_EmptyConstructor()
    {
        // Define
        int id = 3;
        int albumId = 13;
        string title = "my nice title";
        string url = "http://my.url.com/image1.jpg";
        string thumbnailUrl = "http://my.url.com/image1-150.jpg";

        // Process
        Photo photo = new Photo() {
            Id = id,
            AlbumId = albumId,
            Title = title,
            Url = url,
            ThumbnailUrl = thumbnailUrl
        };

        // Assert
        Assert.Equal(3, photo.Id);
        Assert.Equal(13, photo.AlbumId);
        Assert.Equal("my nice title", photo.Title);
        Assert.Equal("http://my.url.com/image1.jpg", photo.Url);
        Assert.Equal("http://my.url.com/image1-150.jpg", photo.ThumbnailUrl);
    }
}
