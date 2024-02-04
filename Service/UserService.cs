using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {
            try
            {
                var users = _repository.User.GetAllUsers(trackChanges);
                //var usersDto = users.Select(u => new UserDto(u.UserId, u.UserName ?? "", u.Email ?? "")).ToList();
                var usersDto = _mapper.Map<IEnumerable<UserDto>>(users); // User auto mapper
                return usersDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllUsers)} service method {ex}");
                throw;
            }
        }

    }
}
