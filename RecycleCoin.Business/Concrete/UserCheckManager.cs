using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.Adapters;
using RecycleCoin.Entities.Dtos;

namespace RecycleCoin.Business.Concrete
{
    public class UserCheckManager:IUserCheckService
    {
        public bool IsRealPerson(UserValidationDto userValidationDto)
        {
            return MernisServiceAdapter.IsRealPersonAdapter(userValidationDto);
        }
    }
}
