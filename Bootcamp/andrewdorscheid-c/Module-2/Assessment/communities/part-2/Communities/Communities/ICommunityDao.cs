using System.Collections.Generic;

namespace Communities
{
    public interface ICommunityDao
    {
        void Save(Community newCommunity);
        IList<Community> GetAllCommunities();
    }
}