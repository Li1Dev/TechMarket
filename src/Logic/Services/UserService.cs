using System.Security.Claims;
using AutoMapper;
using TechMarket.BLL.DTO;
using TechMarket.BLL.Infrastructure;
using TechMarket.BLL.Interfaces;
using TechMarket.DAL.Interfaces;
using TechMarket.Data.Db.Entities;

namespace TechMarket.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }

        public Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {

            throw new NotImplementedException();
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDTO)
        {
            ApplicationUser user = await _database.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser() { Email = userDTO.Email, UserName = userDTO.FirstName };
                var result = await _database.UserManager.CreateAsync(user, userDTO.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault()!.ToString()!, "");
                await _database.UserManager.AddToRoleAsync(user, userDTO.Role);
                CustomerProfile profile = _mapper.Map<CustomerProfile>(userDTO);
                await _database.ClientManager.CreateAsync(profile);
                await _database.SaveAsync();
                return new OperationDetails(true, "Регистрация пройдена успешно", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "");
            }
        }

        public Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
