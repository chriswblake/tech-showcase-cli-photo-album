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

    /// <summary>
    /// Provides an ID that is in the database.
    /// Since the album exists, it should return an Album object
    /// with all details provided.
    /// </summary>
    [Fact]
    public async void Test_GetAlbumAsync_KnownId()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        int id = 23;

        // Process
        Album? album = await api.GetAlbumAsync(id);

        // Assert
        Assert.NotNull(album);
        Assert.Equal(23, album.Id);
        Assert.Equal(3, album.UserId);
        Assert.Equal("incidunt quisquam hic adipisci sequi", album.Title);
    }

    /// <summary>
    /// Provides an ID that is not available withing the database.
    /// Since the album does not exist, it should return null.
    /// </summary>
    [Fact]
    public async void Test_GetAlbumAsync_UnknownId()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        int id = 18900000;

        // Process
        Album? album = await api.GetAlbumAsync(id);

        // Assert
        Assert.Null(album);
    }

    /// <summary>
    /// Provides an ID that is in the database.
    /// Since the album exists, it should return an a list of Photo objects,
    /// each with all its details.
    /// </summary>
    [Fact]
    public async void Test_GetAlbumPhotosAsync_KnownId()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        int id = 15;

        // // Process
        List<Photo?> photos = await api.GetAlbumPhotosAsync(id);

        // // Assert
        Assert.NotNull(photos);
        Assert.NotEmpty(photos);
        Assert.Equal(50, photos.Count);
    }

    /// <summary>
    /// Provides an ID that is not available withing the database.
    /// Since the album does not exist, and hence has no photos, it should return an empty list.
    /// </summary>
    [Fact]
    public async void Test_GetAlbumPhotosAsync_UnknownId()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);
        int id = 18900000;

        // Process
        List<Photo?> photos = await api.GetAlbumPhotosAsync(id);

        // Assert
        Assert.Empty(photos);
    }

    /// <summary>
    /// Retrieves all albums from the database, in a list.
    /// </summary>
    [Fact]
    public async void Test_GetAlbumsAsync_All()
    {
        // Define
        var baseAddress = "https://jsonplaceholder.typicode.com";
        PhotosApiClient api = new PhotosApiClient(baseAddress);

        // Process
        List<Album?> albums = await api.GetAlbumsAsync();

        // Assert
        Assert.NotEmpty(albums);
        Assert.Equal(100, albums.Count);
    }

}