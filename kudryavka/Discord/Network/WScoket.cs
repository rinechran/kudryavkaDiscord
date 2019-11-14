using System;
using System.Collections.Generic;
using WebSocketSharp;
using System.Text;

namespace kudryavka.Discord.Network
{
    public class WScoket
    {
        public WScoket(string url)
        {
            this.websocket = new WebSocket(url);

            if (url.Contains("wss"))
            {
                this.websocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            }

        }
        public void Run()
        {
            websocket.Connect();
            Console.ReadKey(true);
        }
        public void Send(string payload)
        {
            websocket.Send(payload);
        }

        public event EventHandler<MessageEventArgs> OnMessage
        {
            add
            {
                websocket.OnMessage += value;
            }
            remove
            {
                websocket.OnMessage -= value;
            }
        }


        WebSocket websocket;

    }
}
