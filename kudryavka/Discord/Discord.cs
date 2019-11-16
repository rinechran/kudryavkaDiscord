using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using kudryavka.Discord.Network;
using kudryavka.Discord.Packet;
using Newtonsoft.Json.Linq;

namespace kudryavka.Discord
{

    class DiscordBot
    {
        public DiscordBot()
        {
            disPatch = new DisPatch();

        }
        public void Run(Config config)
        {
            disPatch.Run(config);
        }
        public void Initalize(Config config)
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
        }

        private Config config;
        private DisPatch disPatch;

    }




}
