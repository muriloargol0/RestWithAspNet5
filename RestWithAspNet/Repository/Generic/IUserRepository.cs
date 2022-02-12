using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Repository.Generic
{
    public interface IUserRepository
    {
        User ValidadeCredentials(UserVO user);
        User RefreshUserInfo(User user);
    }
}
