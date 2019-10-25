namespace MovieFinder
{
    public class OmdbApiConfiguration
    {
        public string Url { get; }
        public string Key { get; }

        public OmdbApiConfiguration(string url, string key)
        {
            Url = url;
            Key = key;
        }
    }
}