using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector.DirectLine;

namespace MarMission.Models
{
    public class BotConnection
    {
        public DirectLineClient Client = new DirectLineClient("xyDbS9lXtjk.cwA.Sqs.uap6tAT5SwNGdUp_VMt4MFGamXphOKbuqYhmcNG25AI");
        public Conversation MainConversation;
        public ChannelAccount Account;

        public BotConnection()
        {
            MainConversation = Client.Conversations.StartConversation();
            Account = new ChannelAccount { Id=  , Name =};
        }
    }
}
