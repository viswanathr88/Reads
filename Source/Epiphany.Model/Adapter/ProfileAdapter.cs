using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class ProfileAdapter : IAdapter<ProfileModel, GoodreadsProfile>
    {
        public ProfileModel Convert(GoodreadsProfile item)
        {
            ProfileModel profile = new ProfileModel(item);
            return profile;
        }
    }
}
