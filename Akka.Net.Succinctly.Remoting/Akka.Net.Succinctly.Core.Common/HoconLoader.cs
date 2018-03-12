using Akka.Configuration;

namespace Akka.Net.Succinctly.Core.Common
{
    public static class HoconLoader
    {
        public static Config FromFile(string path)
        {
            var hoconContent = System.IO.File.ReadAllText(path);
            return ConfigurationFactory.ParseString(hoconContent);
        }
    }
}
