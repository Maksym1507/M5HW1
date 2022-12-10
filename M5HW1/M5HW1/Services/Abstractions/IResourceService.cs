using M5HW1.Dtos.Responses;
using M5HW1.Dtos;

namespace M5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        Task<ReqresPageResponse<ResourceDto[]>> GetResources();

        Task<ResourceDto> GetResourceById(int id);
    }
}
