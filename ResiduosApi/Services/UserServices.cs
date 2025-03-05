using ResiduosApi.Data;
using ResiduosApi.Models;
using ResiduosApi.Repositories;

namespace ResiduosApi.Services
{
    public class UserServices
{
    private readonly UserRepository userRepository;

    public UserServices(ApplicationDbContext context)
    {
        userRepository = new UserRepository(context);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return (await userRepository.GetAllUsers()).ToList();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await userRepository.GetUserById(id);
    }

    public async Task<User> CreateUser(CreateUserRequest request)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Age = request.Age
        };
        return await userRepository.CreateUser(user);
    }

    public async Task<User?> UpdateUserById(int id, CreateUserRequest request)
    {
        var user = new User
        {
            Id = id,
            Name = request.Name,
            Email = request.Email,
            Age = request.Age
        };
        return await userRepository.UpdateUserById(id, user);
    }

    public async Task<bool> DeleteUserById(int id)
    {
        var userDeleted = await userRepository.DeleteUserById(id);
        return userDeleted != null;
    }
}}