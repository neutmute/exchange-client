using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client.Domain
{
    public class DistributionGroupMember
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Title { get; set; }

        public string DisplayName { get; set; }

        public string PrimarySmtpAddress { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
