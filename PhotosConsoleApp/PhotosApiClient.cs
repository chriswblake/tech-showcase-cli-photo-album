using System.Net;
using System.Net.Http.Json;
using PhotosConsoleApp.Models;

namespace PhotosConsoleApp {
    public class PhotosApiClient
    {
        // Fields
        private readonly HttpClient httpClient;

        // Constructors
        public PhotosApiClient(string baseAddress) {
            // Create the client and make available to all methods.
            this.httpClient = new HttpClient() {
                BaseAddress = new Uri(baseAddress)
            };
            
            // Configure for JSON
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
    	    this.httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
        }

        // Methods
        public async Task<Photo?> GetPhotoAsync(int id)
        {
            Photo? photo = null;
            
            // Query the API
            string uri = $"photos/{id}";
            try {
                photo = await this.httpClient.GetFromJsonAsync<Photo>(uri);
            }
            // Handle bad requests or errors.
            catch (HttpRequestException e)
            {
                switch(e.StatusCode){
                    case HttpStatusCode.NotFound:
                        Console.WriteLine($"GetPhotoAsync: NotFound: id={id}");
                        break;
                    default:
                        Console.WriteLine($"GetPhotoAsync: HTTPStatusCode: {e.StatusCode} - {e.Message}");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"GetPhotoAsync: Unknown Exception: {e.Message}");
            }

            // Return result
            return photo;
        }
        public async Task<Album?> GetAlbumAsync(int id)
        {
            Album? album = null;
            
            // Query the API
            string uri = $"albums/{id}";
            try {
                album = await this.httpClient.GetFromJsonAsync<Album>(uri);
            }
            // Handle bad requests or errors.
            catch (HttpRequestException e)
            {
                switch(e.StatusCode){
                    case HttpStatusCode.NotFound:
                        Console.WriteLine($"GetAlbumAsync: NotFound: id={id}");
                        break;
                    default:
                        Console.WriteLine($"GetAlbumAsync: HTTPStatusCode: {e.StatusCode} - {e.Message}");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"GetAlbumAsync: Unknown Exception: {e.Message}");
            }

            // Return result
            return album;
        }
        
    
    }
}