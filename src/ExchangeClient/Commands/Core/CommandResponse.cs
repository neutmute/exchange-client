using System.Collections.Generic;
using Exchange.Client.Domain;

namespace Exchange.Client
{
    public class CommandResponse
    {
        public List<PowershellError> Errors { get; private set; }

        public CommandResponse()
        {
            Errors = new List<PowershellError>();
        }
    }
}