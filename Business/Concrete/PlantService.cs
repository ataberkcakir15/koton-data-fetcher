using Business.Abstract;
using Core.Common.Concrete;
using Core.Constants;
using Core.Helpers.Abstract;
using Core.Models.Response;
using DataAccess.Repositories.Abstract;
using System.Net;
using System.Reflection;


// business katmani is yapar, controller katmani mesela veriyi gonderir alir vs. ama arka plandaki isleri business a yazariz.

namespace Business.Concrete
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IFlowersHelper _flowersHelper;

        public PlantService(IPlantRepository plantRepository, IFlowersHelper flowersHelper) // helper
        {
            _plantRepository = plantRepository;
            _flowersHelper = flowersHelper;
        }
        /// <summary>
        /// DB den bitki bilgilerini cekiyor. flowerAPI a gidip flower bilgilerini de aliyor. koton firmasinin ihtiyacindan dolayi eklenmistir.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<GetPlantInformationsResponseModel>> GetPlantInformationsAsync()
        {
            try
            {
                var response = await _plantRepository.GetPlantInformationsAsync();

                if (response == null)
                {
                    return new ServiceResult<GetPlantInformationsResponseModel>
                    {
                        HttpStatusCode = HttpStatusCode.NoContent // basarili istek ancak veri yok!
                    };
                }
                else
                {
                    var flowers = await _flowersHelper.GetFlowersInformationAsync();

                    return new ServiceResult<GetPlantInformationsResponseModel>
                    {
                        HttpStatusCode = HttpStatusCode.OK,
                        UserMessage = ResponseMessagesConstant.SUCCESS,
                        InternalMessage = ResponseMessagesConstant.SUCCESS,
                        Data = response,
                        Flowers = flowers
                    };
                }
            }
            catch (Exception exception)
            {
                return new ServiceResult<GetPlantInformationsResponseModel>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    UserMessage = ResponseMessagesConstant.EXCEPTION,
                    InternalMessage = $" Hata mesajı {exception.Message} {exception.InnerException}", // string interpo
                };
            }
        }
        public async Task<ServiceResult> CreatePlantAsync(CreatePlantRequestModel model)
        {
            try
            {
                await _plantRepository.AddPlantAsync(model);

                return new ServiceResult
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    UserMessage = ResponseMessagesConstant.SUCCESS,
                    InternalMessage = ResponseMessagesConstant.SUCCESS
                };
            }
            catch (Exception exception)
            {
                return new ServiceResult
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    UserMessage = ResponseMessagesConstant.EXCEPTION,
                    InternalMessage = $"Error message: {exception.Message} {exception.InnerException}"
                };
            }
        }

        public async Task<ServiceResult> UpdatePlantAsync(int id, UpdatePlantRequestModel model)
        {
            try
            {
                await _plantRepository.UpdatePlantAsync(id, model);

                return new ServiceResult
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    UserMessage = ResponseMessagesConstant.SUCCESS,
                    InternalMessage = ResponseMessagesConstant.SUCCESS
                };
            }
            catch (Exception exception)
            {
                return new ServiceResult
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    UserMessage = ResponseMessagesConstant.EXCEPTION,
                    InternalMessage = $"Error message: {exception.Message} {exception.InnerException}"
                };
            }
        }

        public async Task<ServiceResult> DeletePlantAsync(int id)
        {
            try
            {
                await _plantRepository.DeletePlantAsync(id);

                return new ServiceResult
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    UserMessage = ResponseMessagesConstant.SUCCESS,
                    InternalMessage = ResponseMessagesConstant.SUCCESS
                };
            }
            catch (Exception exception)
            {
                return new ServiceResult
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    UserMessage = ResponseMessagesConstant.EXCEPTION,
                    InternalMessage = $"Error message: {exception.Message} {exception.InnerException}"
                };
            }
        }
    }
}
