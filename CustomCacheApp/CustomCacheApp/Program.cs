// See https://aka.ms/new-console-template for more information

new CustomCacheApp().Run();

public class CustomCacheApp
{
    private IDataDownloader _downloader;

    public CustomCacheApp() 
    { 
        _downloader = new CachingDataDownloader(new SlowDataDownloader());
    }

    public void Run()
    {
        //download data
        Console.WriteLine(_downloader.DownloadData("id1"));
        Console.WriteLine(_downloader.DownloadData("id2"));
        Console.WriteLine(_downloader.DownloadData("id3"));
        Console.WriteLine(_downloader.DownloadData("id1"));
        Console.WriteLine(_downloader.DownloadData("id2"));
        Console.WriteLine(_downloader.DownloadData("id3"));

        Console.ReadKey();
    }
}


public interface IDataDownloader
{
    string DownloadData(string key);
}

public class SlowDataDownloader : IDataDownloader
{

    public string DownloadData(string key)
    {
        Thread.Sleep(1000);
        return $"Some value for {key}";

    }
}

public class CachingDataDownloader : IDataDownloader
{
    private IDataDownloader _datDownloader;
    private DictionaryCache<string, string> _cache = new();

    public CachingDataDownloader(IDataDownloader dataDownloader)
    {
        _datDownloader = dataDownloader;
    }

    public string DownloadData(string key)
    {
        return _cache.GetResource(key, _datDownloader.DownloadData);
    }

}



public class DictionaryCache<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _dictionary = new ();

    public TValue GetResource(TKey key, Func<TKey, TValue> downloadResource)
    {
        if (!_dictionary.ContainsKey(key))
        {
            _dictionary[key] = downloadResource(key);
        }
        return _dictionary[key];
    }

    
}