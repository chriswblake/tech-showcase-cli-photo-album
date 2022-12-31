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

    }
}