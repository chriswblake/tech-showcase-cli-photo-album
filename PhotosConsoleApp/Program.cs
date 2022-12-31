using System.Diagnostics;
using PhotosConsoleApp;
using PhotosConsoleApp.Models;

// Start stopwatch (out of curiosity)
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

// Create client to photos service
var baseAddress = "https://jsonplaceholder.typicode.com";
PhotosApiClient api = new PhotosApiClient(baseAddress);
Console.WriteLine($"Connected to Photos API: {baseAddress}");

// Get all albums
List<Album?> albums = await api.GetAlbumsAsync();

// Cycle through each album and display the photos
Console.WriteLine($"Retrieving photos for {albums.Count} albums...");
foreach(Album? album in albums)
{
    // Skip any failed albums (there shouldn't be any)
    if (album == null) continue;

    // Get this album's photos
    List<Photo?> albumPhotos = await api.GetAlbumPhotosAsync(album.Id);

    // Show album ID, and each photos' id/title
    Console.WriteLine($">photo-album: {album.Id}");
    foreach(Photo? photo in albumPhotos)
    {
        if (photo == null) continue;
        Console.WriteLine($"[{photo.Id}] {album.Title}");
    }
}
stopWatch.Stop();

// Show summary with time to run
TimeSpan ts = stopWatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);
Console.WriteLine($"Retrieved photos for {albums.Count} albums, in runtime: {elapsedTime}.");
// Console.WriteLine("RunTime: " + elapsedTime);
