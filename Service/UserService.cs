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
            var users = _repository.User.GetAllUsers(trackChanges);
            //var usersDto = users.Select(u => new UserDto(u.UserId, u.UserName ?? "", u.Email ?? "")).ToList();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users); // Use auto mapper
            return usersDto;
        }

    }
}
