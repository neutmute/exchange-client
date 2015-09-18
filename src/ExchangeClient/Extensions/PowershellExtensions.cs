using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client
{
    public static class PowershellExtensions
    {

        public static void Add(this List<CommandParameter> target, string name, object value)
        {
            var parameter = new CommandParameter(name, value);
            target.Add(parameter);
        }
    }
}
