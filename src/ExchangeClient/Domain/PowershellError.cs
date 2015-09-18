using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client.Domain
{
    public class PowershellError
    {
        public string Message { get; set; }

        public ErrorRecord InnerError { get; set; }

        public PowershellError(ErrorRecord error)
        {
            InnerError = error;
            Message = error.ToString();
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
