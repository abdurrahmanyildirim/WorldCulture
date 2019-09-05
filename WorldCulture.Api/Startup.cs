using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WorldCulture.Api.Helpers;
using WorldCulture.Business.Abstract;
using WorldCulture.Business.Concrete;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.DataAccess.Concrete.EntityFramework;

namespace WorldCulture.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<DefaultProfilePhoto>(Configuration.GetSection("DefaultProfilePhoto"));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddAutoMapper(opt => opt.AddProfile<AutoMapperProfiles>());

            //Dependencies
            AddDepencies(services);

            services.AddCors();
            //services.AddResponseCaching(opt =>
            //{
            //    opt.SizeLimit = 250;
            //    opt.MaximumBodySize = 250;
            //    opt.UseCaseSensitivePaths = false;
            //});

            services.AddMemoryCache();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private static void AddDepencies(IServiceCollection services)
        {
            services.AddSingleton<IAccountDal, EfAccountDal>();
            services.AddSingleton<IAccountService, AccountManager>();

            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IRoleService, RoleManager>();

            services.AddSingleton<ICountryDal, EfCountryDal>();
            services.AddSingleton<ICountryService, CountryManager>();

            services.AddSingleton<ICityDal, EfCityDal>();
            services.AddSingleton<ICityService, CityManager>();

            services.AddSingleton<IFamousPlaceDal, EfFamousPlaceDal>();
            services.AddSingleton<IFamousPlaceService, FamousPlaceManager>();

            services.AddSingleton<IReviewDal, EfReviewDal>();
            services.AddSingleton<IReviewService, ReviewManager>();

            services.AddSingleton<IPostDal, EfPostDal>();
            services.AddSingleton<IPostService, PostManager>();

            services.AddSingleton<IRelationDal, EfRelationDal>();
            services.AddSingleton<IRelationService, RelationManager>();

            services.AddScoped<ICloudinaryConfiguration, CloudinaryConfiguration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseResponseCaching();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
