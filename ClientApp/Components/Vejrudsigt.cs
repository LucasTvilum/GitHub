using System.Net.Http.Json;
using System.Globalization;

namespace ClientApp.Components;

public class SunService
{
    private readonly HttpClient _httpClient;

    public SunService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(DateTime sunrise, DateTime sunset)> GetSunriseSunsetAsync(double latitude, double longitude, DateTime date)
    {
        var url = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&date={date:yyyy-MM-dd}&formatted=0";

        var result = await _httpClient.GetFromJsonAsync<SunriseSunsetResponse>(url);

        if (result is null || result.results is null || !string.Equals(result.status, "OK", StringComparison.OrdinalIgnoreCase))
            throw new Exception("Error fetching sunrise and sunset data");

        var sunriseUtc = DateTimeOffset.Parse(result.results.sunrise, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        var sunsetUtc  = DateTimeOffset.Parse(result.results.sunset,  CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

        return (sunriseUtc.ToLocalTime().DateTime, sunsetUtc.ToLocalTime().DateTime);
    }
    
    class SunriseSunsetResponse
    {
        public Results? results { get; set; }
        public string? status { get; set; }
    }
    
    class Results
    {
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
    }
}