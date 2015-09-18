using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client.Domain
{
    public class DistributionGroup
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string PrimarySmtpAddress { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
