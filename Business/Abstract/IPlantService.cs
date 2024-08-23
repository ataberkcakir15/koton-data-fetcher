using Core.Common.Concrete;
using Core.Models.Response;

namespace Business.Abstract
{
    public interface IPlantService
    {
        Task<ServiceResult<GetPlantInformationsResponseModel>> GetPlantInformationsAsync();

        Task<ServiceResult> CreatePlantAsync(CreatePlantRequestModel model);

        Task<ServiceResult> UpdatePlantAsync(int id, UpdatePlantRequestModel model);

        Task<ServiceResult> DeletePlantAsync(int id);
    }
}
