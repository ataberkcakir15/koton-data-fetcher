using Core.Models.Response;
using Dapper;
using DataAccess.Queries;
using DataAccess.Repositories.Abstract;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Concrete
{
    public class PlantRepository : IPlantRepository
    {

        public async Task<List<GetPlantInformationsResponseModel>> GetPlantInformationsAsync()
        {
            using var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Koton;Trusted_Connection=true");
            var response = await connection.QueryAsync<GetPlantInformationsResponseModel>(
                sql: PlantQueries.GET_PLANT_INFORMATION,
                commandTimeout: 0);
            return response.ToList();
        }

        public async Task AddPlantAsync(CreatePlantRequestModel model)
        {
            using var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Koton;Trusted_Connection=true");
            var query = "INSERT INTO Plants (Trees, Vegetables) VALUES (@Trees, @Vegetables)";
            await connection.ExecuteAsync(query, new { Trees = model.Trees, Vegetables = model.Vegetables });
        }

        public async Task UpdatePlantAsync(int id, UpdatePlantRequestModel model)
        { 
            using var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Koton;Trusted_Connection=true");
            var query = "UPDATE Plants SET Trees = @Trees, Vegetables = @Vegetables WHERE PlantsId = @Id";
            await connection.ExecuteAsync(query, new {Trees = model.Trees, Vegetables = model.Vegetables, Id = id }); 
        }

        public async Task DeletePlantAsync(int id)
        {
            using var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Koton;Trusted_Connection=true");
            var query = "DELETE FROM Plants Where PlantsId = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
