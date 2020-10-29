using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestAPIwithAuth0.Business.Implementations;
using RestAPIwithAuth0.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Business.Helpers.Abstracts
{
    public static class ServiceExtensions
    {
        public static void AddAppServices(this IServiceCollection services,
         IConfiguration Configuration)
        {
            services.AddTransient<IEmployee, EmployeeService>();
            services.AddTransient<IAuth, AuthService>();
            services.AddTransient<IAudit, AuditService>();

        }
    }
}
