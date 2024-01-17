using bizland.core.Repositories.Interfaces;
using bizland.data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.data
{
    public static class ServiceRegistrations
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
        }
    }
}
