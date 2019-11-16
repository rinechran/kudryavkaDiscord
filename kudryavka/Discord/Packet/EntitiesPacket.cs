using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudryavka.Discord.Packet
{

    public class PacketPayload
    {

    }
    public class PakcetImple
    {
        public string GetPacket()
        {
            return JsonConvert.SerializeObject(this);
        }

        public OPCODE op { get; set; }

        [JsonIgnore]
        public JObject receveData;

        [JsonIgnore]
        public PacketPayload sandData;

        public JObject d
        {
            set
            {
                receveData = value;
            }

            get
            {
                return sandData == null ? receveData : JObject.FromObject(sandData);
            }
        }
        public int ?s;
        public string t { get; set; }


    }

    public class LoginPacketImple : PacketPayload
    {
        public LoginPacketImple(string token)
        {
            this.token = token;
            this.properties = new Properties();
        }

        public class Properties
        {
            public Properties(string os = "BOT")
            {
                browser = "C#";
                device = "C#";
            }
            public string os { get; set; }
            public string browser { get; set; }
            public string device { get; set; }
        }
        public string token { get; set; }
        public Properties properties { get; set; }
    }

    public class Packeter
    {
        public static PakcetImple BasePacket()
        {
            return new PakcetImple();
        }
        public static PakcetImple HeartBeat()
        {
            return new PakcetImple
            {
                op = OPCODE.HEART_BEAT
            };
        }
        public static PakcetImple LoginPacket(string token)
        {
            return new PakcetImple
            {
                op = OPCODE.IDENTIFY,
                sandData = new LoginPacketImple(token)
            };

        }
        
    }

}
