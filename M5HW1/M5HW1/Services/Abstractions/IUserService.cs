using M5HW1.Dtos;
using M5HW1.Dtos.Responses;

namespace M5HW1.Services.Abstractions
{
    public interface IUserService
    {
        Task<PageBaseResponse<UserDto>> GetUsersByPage(int page);

        Task<UserDto[]> GetUsersWithDelay(int delay);

        Task<UserDto> GetUserById(int id);

        Task<UserResponse> CreateUser(string name, string job);

        Task<UpdateUserResponse> PutUser(int id, string name, string job);

        Task<UpdateUserResponse> PatchUser(int id, string name, string job);

        Task DeleteUser(int id);
    }
}
