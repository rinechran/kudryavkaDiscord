using System;
using Newtonsoft.Json;
using System.IO;
using kudryavka.Discord;
using kudryavka.Discord.Dispatch;

namespace kudryavka
{
    class Program
    {
        public const string config = "C:/Users/rinechran/source/repos/kudryavka/kudryavka/config/config.json";
        static Config loadConfig(string path = config)
        {

            if (!File.Exists(path)) {
                throw new ArgumentException("Not fine Config");
            }
            string loadData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(loadData);

        }
        static void Main(string[] args)
        {
            DiscordBot discord = new DiscordBot();
            Config config = loadConfig();
            DisPatchImple disPatch = new DisPatchImple();

            discord.Initalize(config, disPatch);
            discord.Run();


        }
    }
}
