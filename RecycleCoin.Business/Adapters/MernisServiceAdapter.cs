using RecycleCoin.Entities.Dtos;

namespace RecycleCoin.Business.Adapters
{
    internal class MernisServiceAdapter
    {
        public static bool IsRealPersonAdapter(UserValidationDto userValidationDto)
        {
            using (var service = new TcDogrula.KPSPublicSoapClient())
            {
                var result = service.TCKimlikNoDogrula(
                    userValidationDto.TcNo,
                    userValidationDto.Name, userValidationDto.LastName, userValidationDto.Year);
                return result;

            }

        }
    }
}
