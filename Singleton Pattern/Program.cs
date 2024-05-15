using Singleton_Pattern;

class Program
{
    static void Main(string[] args)
    {
        Servers servers = Servers.Instance;

        // Добавление серверов
        Console.WriteLine(servers.AddServer("http://example.com")); // true
        Console.WriteLine(servers.AddServer("https://example.org")); // true
        Console.WriteLine(servers.AddServer("ftp://invalid.server")); // false
        Console.WriteLine(servers.AddServer("http://example.com")); // false (дубликат)

        // Получение серверов
        List<string> httpServers = servers.GetHttpServers();
        List<string> httpsServers = servers.GetHttpsServers();

        Console.WriteLine("HTTP Servers:");
        foreach (string server in httpServers)
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("HTTPS Servers:");
        foreach (string server in httpsServers)
        {
            Console.WriteLine(server);
        }
    }
}
