using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WebSocketSharp;
using kudryavka.Discord.Packet;
using kudryavka.Discord.Network;
using System.Threading.Tasks;

namespace kudryavka.Discord
{
    public class DisPatch
    {
        public DisPatch()
        {
            this.wScoket = new WScoket(Config.WS_URL);
            this.wScoket.OnMessage += this.OnMessage;
        }
        public void Run(Config config)
        {
            this.config = config;
            this.wScoket.Run();
        }
        public void OnMessage(Object sender, MessageEventArgs e)
        {
            PakcetImple jsonPacket = JsonConvert.DeserializeObject<PakcetImple>(e.Data);
            lastSeq = jsonPacket.s;

            switch (jsonPacket.op)
            {
                case OPCODE.HELL0:
                    Debug.WriteLine("HELLO PACKET");
                    heartbeatTask = HeartBeatAsync((int)jsonPacket.receveData.SelectToken("heartbeat_interval"));
                    login();
                    break;
                case OPCODE.HEART_BEAT:
                    Debug.WriteLine("HEART_BEAT PACKET");
                    break;
                case OPCODE.HEARTBEAT_ACK:
                    break;

                default:
                    Console.WriteLine(e.Data);
                    break;

            }

        }
        private Task HeartBeatAsync(int millisecondInterval)
        {
            return Task.Run(() =>
            {
                try
                {
                    PakcetImple heartBeat = Packeter.HeartBeat();
                    while (true)
                    {

                        heartBeat.s = lastSeq;
                        Console.WriteLine(heartBeat.GetPacket());
                        this.wScoket.Send(heartBeat.GetPacket());

                        Task.Delay(millisecondInterval).Wait();

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return;
            });
        }
        private void login()
        {

            PakcetImple loginPacket = Packeter.LoginPacket(
                config.token
            );

            wScoket.Send(loginPacket.GetPacket());
            this.isConnecting = true;
        }
        private bool isConnecting;
        WScoket wScoket;
        Config config;
        Task heartbeatTask;
        private int? lastSeq;
    }




}
