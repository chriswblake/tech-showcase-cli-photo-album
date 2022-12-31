namespace ConsoleAppTests;
using PhotosConsoleApp;
using PhotosConsoleApp.Models;
using sr = System.Reflection;

public class PhotosApiClientTest
{
    /// <summary>
    /// This is a simple placeholder test to verify this class is being
    /// recognized by the unit test scanner.
    /// </summary>
    [Fact]
    public void Test_PhotosApiClientTest_Loads()
    {
        // Define
        var firstName = "DaViD";

        // Process
        var result = firstName.ToLower();

        // Assert
        Assert.Equal("david", result);
    }

    /// <summary>
    /// Verifies that the base URL is set for the private httpClient
    /// when the API client is constructed.
    /// </summary>
    [Fact]
    public void Test_PhotosApiClient()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";

        // Process
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        
        // Assert
        HttpClient httpClient = (HttpClient) typeof(PhotosApiClient).GetField("httpClient", sr.BindingFlags.NonPublic | sr.BindingFlags.Instance).GetValue(api);
        Assert.Equal(new Uri("https://jsonplaceholder.typicode.com"), httpClient.BaseAddress);
    }

    /// <summary>
    /// Provides an ID that is in the database.
    /// Since the photo exists, it should return a Photo object
    /// with all details provided.
    /// </summary>
    [Fact]
    public async void Test_GetPhotoAsync_KnownId()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        int id = 1;

        // Process
        Photo? photo = await api.GetPhotoAsync(id);

        // Assert
        Assert.NotNull(photo);
        Assert.Equal(1, photo.Id);
        Assert.Equal(1, photo.AlbumId);
        Assert.Equal("accusamus beatae ad facilis cum similique qui sunt", photo.Title);
        Assert.Equal("https://via.placeholder.com/600/92c952", photo.Url);
        Assert.Equal("https://via.placeholder.com/150/92c952", photo.ThumbnailUrl);
    }

    /// <summary>
    /// Provides an ID that is not available withing the database.
    /// Since the photo does not exist, it should return null.
    /// </summary>
    [Fact]
    public async void Test_GetPhotoAsync_UnknownId()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        int id = 18900000;

        // Process
        Photo? photo = await api.GetPhotoAsync(id);

        // Assert
        Assert.Null(photo);
    }
}