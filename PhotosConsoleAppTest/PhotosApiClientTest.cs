namespace ConsoleAppTests;
using PhotosConsoleApp;
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

}