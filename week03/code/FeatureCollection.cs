public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}
public static string[] EarthquakeDailySummary()
{
    const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

    using var client = new HttpClient();
    using var request = new HttpRequestMessage(HttpMethod.Get, uri);
    using var response = client.Send(request);
    using var stream = response.Content.ReadAsStream();

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(stream, options);

    var result = new List<string>();

    foreach (var feature in featureCollection.Features)
    {
        string place = feature.Properties.Place ?? "Unknown place";
        string mag = feature.Properties.Mag.HasValue ? feature.Properties.Mag.Value.ToString("0.00") : "N/A";
        result.Add($"{place} - Mag {mag}");
    }

    return result.ToArray();
}
