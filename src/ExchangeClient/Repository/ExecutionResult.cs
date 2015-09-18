using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client.Domain
{
    class ExecutionResult
    {
        public Collection<PSObject> Results { get; set; }

        public List<PowershellError> Errors { get; set; }

        public ExecutionResult()
        {
            Errors = new List<PowershellError>();
        }

    }
}
