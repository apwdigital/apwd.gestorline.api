using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1.System;
using Apwd.GestorLine.MongoDb;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;
using Apwd.GestorLine.Services.Contracts.v1.System;
using AutoMapper;

namespace Apwd.GestorLine.Services.Services.v1.System;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserModel> GetLogin(UserLoginModel obj) 
        => _mapper.Map<UserModel>(await _userRepository.GetLoginAsync(obj));

    public async Task<UserModel> Add(AddUserModel obj)
    {
        var newObj = _mapper.Map<User>(obj);

        newObj.Id = Guid.NewGuid().ToString();

        await _userRepository.AddAsync(newObj);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<UserModel>(newObj);
    }
}