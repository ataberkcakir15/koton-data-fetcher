using Core.Models.Response;

namespace DataAccess.Repositories.Abstract
{
    public interface IPlantRepository
    {
        Task<List<GetPlantInformationsResponseModel>> GetPlantInformationsAsync();
        
        Task AddPlantAsync(CreatePlantRequestModel model);

        Task UpdatePlantAsync(int id, UpdatePlantRequestModel model);

        Task DeletePlantAsync(int id);
    }
}
