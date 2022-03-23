using APIVentas.Models.Response;
using APIVentas.Models.ViewModels;

namespace APIVentas.Services
{
    public interface IUserServices
    {
        UserResponse Auth(AutRequest model);
    }
}
