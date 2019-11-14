using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using kudryavka.Discord.Network;
using kudryavka.Discord.Dispatch;
using Newtonsoft.Json.Linq;

namespace kudryavka.Discord
{

    class DiscordBot
    {
        public DiscordBot()
        {

        }
        public void Run()
        {
            if (wScoket == null)
                throw new InvalidOperationException("Called before Initalize method");
            wScoket.Run();
        }
        public void Initalize(Config config, DisPatchImple disPatch)
        {
            if (config == null)
            {
                throw new System.InvalidOperationException("NOT CONFIG");
            }
            if (disPatch == null)
            {
                throw new System.InvalidOperationException("NOT DISPATCH");
            }
            this.config = config;
            this.disPatch = disPatch;

            wScoket = new WScoket(Config.WS_URL);
            disPatch.login += (sender, e) =>
            {
                LOGIN_PACKET packet = new LOGIN_PACKET();
                packet.token = config.token;
                packet.properties.os = "asd";
                packet.properties.browser = "asd";
                packet.properties.device = "asd";

                PakcetImple pakcetImple = new PakcetImple();
                pakcetImple.d = JObject.FromObject(packet);
                pakcetImple.op = OPCODE.IDENTIFY;
                Console.WriteLine(JsonConvert.SerializeObject(pakcetImple));
                wScoket.Send(JsonConvert.SerializeObject(pakcetImple));

            };

            wScoket.OnMessage += disPatch.OnMessage;
        }

        private Config config;
        private DisPatchImple disPatch;
        private WScoket wScoket;

    }

    public class LOGIN_PACKET
    {

        public LOGIN_PACKET()
        {
            properties = new Properties();
        }
        public string token { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string os { get; set; }
        public string browser { get; set; }
        public string device { get; set; }
    }


}
