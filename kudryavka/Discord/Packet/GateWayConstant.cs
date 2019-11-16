using System;
using System.Collections.Generic;
using System.Text;

namespace kudryavka.Discord.Packet
{
    /**
     * Opcodes and Status Codes
     * @link https://discordapp.com/developers/docs/topics/opcodes-and-status-codes
     */
    public enum OPCODE {
        DISPATCH = 0,
        HEART_BEAT = 1,
        IDENTIFY = 2,
        STATUS_UPDATE = 3,
        VOICE_STATE_UPDATE = 4,
        RESUME = 6,
        RECONNECT = 7,
        REQUEST_GUILD_MEMBERS = 8,
        INVAILD_SESSION = 9,
        HELL0 = 10,
        HEARTBEAT_ACK = 11
    }
}
