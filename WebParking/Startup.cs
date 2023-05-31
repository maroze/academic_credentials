﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebParking.Data.Data;
using WebParking.Data;
using WebParking.Service.Services;
using WebParking.Service.Services.Implementations;
using WebParking.Data.Repositories;
using WebParking.Data.Repositories.Implementations;
using WebParking.Common;
using WebParking.Services.EmailServices;
using WebParking.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Identity;

namespace WebParking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Используйте этот метод для добавления сервисов 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddSingleton(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

            services.AddDbContext<ParkingContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("WebParking.Data")));
           

            //scoped мы получаем один и тот же инстанс в рамках одного HTTP-запроса, и разные для разных HTTP-запросов
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordEncryption, PasswordEncryption>();

            services.AddScoped<IParkingRepository, ParkingRepository>();
            services.AddScoped<IParkingService, ParkingService>();

            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<ILotService,LotService>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ParkingContext>();

            services.AddAutoMapper(typeof(Startup));

            var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfig")["secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost"
                };
            });
            //предоставляет полезные сведения об ошибках в среде разработки

            services.AddControllersWithViews();
            services.AddSwaggerGen();
        }
        // Используйте этот метод для настройки запросов HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

