using bizland.business.Services.Implementations;
using bizland.business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business
{
    public static  class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<ITeamMemberService, TeamMemberService>();
        }
    }
}
