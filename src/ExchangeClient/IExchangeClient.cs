using Exchange.Client.Commands;
using Exchange.Client.Domain;

namespace Exchange.Client
{
    public interface IExchangeClient
    {
        CommandResponse RemoveDistributionGroupMember(string identity, string member);
        CommandResponse AddDistributionGroupMember(string identity, string member);
        GetDistributionGroupMemberResponse GetDistributionGroupMember(string name);
        GetDistributionGroupResponse GetDistributionGroup(string name);
        CommandResponse NewDistributionGroup(DistributionGroup group);
    }
}