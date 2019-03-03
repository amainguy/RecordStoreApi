using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RecordStore.Data;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;

namespace RecordStore.DI
{
    internal static class RecordStoreDataServiceCollectionExtensions
    {
        public static void AddRecordStoreDataServices (this IServiceCollection services)
        {
            services.AddDbContext<RecordStoreDbContext>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RecordStoreDbContext>()
                .AddDefaultTokenProviders();

            
        }
    }
}
