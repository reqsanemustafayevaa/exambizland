using bizland.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Services.Interfaces
{
    public interface ITeamMemberService
    {
        Task CreateAsync(TeamMember teamMember);
        Task UpdateAsync(TeamMember teamMember);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<List<TeamMember>> GetAllAsync();
        Task<TeamMember> GetByIdAsync(int id);
    }
}
