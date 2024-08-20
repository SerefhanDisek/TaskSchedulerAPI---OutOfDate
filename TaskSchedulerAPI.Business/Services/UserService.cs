using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.DataAccess.Interfaces;
using AutoMapper;
using TaskSchedulerAPI.Core.Entities;

namespace TaskSchedulerAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> RegisterUserAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userRepository.AddAsync(user);
        }

        public async Task<UserDto> LoginUserAsync(UserLoginDto userLoginDto)
        {

            var user = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);
            if (user == null || !VerifyPassword(userLoginDto.Password, user.PasswordHash))
            {
                return null;
            }
            
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(user.PasswordHash, password))
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        private bool VerifyPassword(string passwordHash, string password)
        {
           
            return true; 
        }

        public Task<string?> LoginUserAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}


/*public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> LoginUserAsync(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return null;
        }

        return _mapper.Map<UserDto>(user);
    }

    // Diğer metodlar
}
*/