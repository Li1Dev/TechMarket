using System.Security.Claims;
using TechMarket.BLL.DTO;
using TechMarket.BLL.Infrastructure;

namespace TechMarket.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDTO);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
