using System;
using System.Collections.Generic;
using System.Text;

namespace kudryavka.Discord
{
    public class Config
    {
        /// <summary>
        /// @link https://discordapp.com/developers/docs/topics/gateway
        /// </summary>
        public const string _WS_URL = "wss://gateway.discord.gg";
        public const string _VERSION = "6";
        //wss://gateway.discord.gg/?v=6&encoding=json

        public static string WS_URL { 
            get 
            {
                return _WS_URL + "/?v=" + _VERSION; 
            } 
        }

        public Config()
        {
            

        }

        public string token;

    }
}
