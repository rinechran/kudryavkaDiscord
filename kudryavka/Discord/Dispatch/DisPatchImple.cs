using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;

namespace kudryavka.Discord.Dispatch
{
    public class DisPatchImple
    {
        public DisPatchImple()
        {

        }
        public void OnMessage(Object sender, MessageEventArgs e)
        {
            PakcetImple jsonPacket = JsonConvert.DeserializeObject<PakcetImple>(e.Data);

            switch (jsonPacket.op)
            {
                case OPCODE.HELL0:
                    login(this, EventArgs.Empty);
                    break;
                default:
                    Console.WriteLine(e.Data);
                    break;

            }

        }
        public event EventHandler login;

    }

    public class PakcetImple
    {

        public string t { get; set; }
        public string s { get; set; }
        public JObject d { get; set; }
        public OPCODE op { get; set; }

    }
    

}
