using System.Collections.Generic;
using Exchange.Client.Domain;

namespace Exchange.Client
{
    public class CommandResponse
    {
        public List<PowershellError> Errors { get; }

        public bool HasErrors => Errors.Count > 0;

        public CommandResponse()
        {
            Errors = new List<PowershellError>();
        }
    }
}