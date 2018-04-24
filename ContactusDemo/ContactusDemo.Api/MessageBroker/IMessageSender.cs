using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactusDemo.Api.MessageBroker
{
    public interface IMessageSender
    {
        void SendData();        
    }
}
