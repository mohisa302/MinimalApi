using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task<UserModel?> GetUser(int id);
        Task<IEnumerable<UserModel>> GetUsers();
        Task InsertUser(UserModel user);
        Task UpdateDelete(int id);
        Task UpdateUser(UserModel user);
    }
}