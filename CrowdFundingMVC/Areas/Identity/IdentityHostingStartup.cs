﻿using CrowdFundingMVC.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CrowdFundingMVC.Areas.Identity.IdentityHostingStartup))]
namespace CrowdFundingMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CrFrDbContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("CrFrDbContextConnection")));

                services.AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));

                }).AddXmlDataContractSerializerFormatters();
            });
        }
    }
}