using API.DataEntities;
using API.DTOs;

namespace API.Data;
public interface IUserRepository
{
    void update (AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetAllAsync();
    Task<AppUser?> GetByIdAsync(int id);
    Task<AppUser?> GetByUsernameAsync(string username);

    Task<IEnumerable<MemberResponse>> GetMembersAsync();

    Task<MemberResponse?> GetMemberAsync(string username);
}
