namespace Nice.Common.Cache
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Nice.Common.Cache.Cache();
        }
    }
}
