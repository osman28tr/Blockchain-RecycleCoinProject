using RecycleCoin.Entities.Dtos;

namespace RecycleCoin.Business.Abstract
{
    internal interface IUserCheckService
    {
        bool IsRealPerson(UserValidationDto userValidationDto);

    }
}
