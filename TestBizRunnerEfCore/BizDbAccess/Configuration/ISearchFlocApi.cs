using DataLayer.Dtos;

namespace BizDbAccess.Configuration
{
    public interface ISearchFlocApi
    {
        ActualNodeDetailsDto SearchFlocByName(string flocName);
    }
}