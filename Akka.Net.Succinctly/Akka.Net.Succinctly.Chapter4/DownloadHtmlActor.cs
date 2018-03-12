using System;
using Akka.Actor;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Chapter4
{
    public class DownloadHtmlActor : ReceiveActor
    {
        public DownloadHtmlActor()
        {
            ReceiveAsync<string>(async url => await GetPageHtmlAsync(url));
        }

        private async Task GetPageHtmlAsync(string url)
        {
            var html = await new System.Net.WebClient().DownloadStringTaskAsync(url);

            Console.WriteLine("\n=====================================");
            Console.WriteLine($"Data for {url}");
            Console.WriteLine(html.Trim().Substring(0, 100));
        }
    }
}