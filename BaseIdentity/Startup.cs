using BaseIdentity.BusinessLayer.Abstract.AbstractUOW;
using BaseIdentity.BusinessLayer.DIContainer;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Controllers;
using BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers;
using BaseIdentity.PresentationLayer.Models;
using BaseIdentity.PresentationLayer.ViewComponents;
using DocumentFormat.OpenXml.Spreadsheet;
using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace WebApplication1
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
            services.ContainerDependencies();
            //    services.AddScoped<EnrollmentController>();

            //AutoMapper ekle
            services.AddAutoMapper(typeof(Startup));

            services.CustomValidator();

            services.AddScoped<GetAllCourseQueryHandler>();
            services.AddScoped<GetCourseByIdQueryHandler>();
            services.AddScoped<CreateCourseCommandHandler>();
            services.AddScoped<RemoveCourseCommandHandler>();
            services.AddScoped<UpdateCourseCommandHandler>();



            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

            services.AddHttpClient();

            services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));
            services.AddControllersWithViews().AddFluentValidation();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";
                options.AccessDeniedPath = "/Error/Index";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
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


            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/NotFound";
                    await next();
                }
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            //seed
            CreateSuperAdmin(serviceProvider).Wait();
            CreateSuperAdminUser(serviceProvider).Wait();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );


            });

        }

        private async Task CreateSuperAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            {
                var superAdminRole = new AppRole()
                {
                    Name = "SuperAdmin"
                };

                var result = await roleManager.CreateAsync(superAdminRole);
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                var userRole = new AppRole()
                {
                    Name = "User"
                };

                var result = await roleManager.CreateAsync(userRole);
            }
        }


        private async Task CreateSuperAdminUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var accountService = serviceProvider.GetRequiredService<IAccountService>();

            var existingUser = await userManager.FindByNameAsync("superadmin");
            if (existingUser == null)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = "superadmin",
                    Name = "super",
                    Surname = "admin"
                };

                var result = await userManager.CreateAsync(appUser, "Sa12345*");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "SuperAdmin");
                }

                var hasAccount = accountService.GetByAppUserId(appUser.Id);
                if(hasAccount == null)
                {
                    Account account = new Account();
                    account.AppUserId = appUser.Id;
                    account.Balance = 2000;
                    accountService.TInsert(account);
                }
              
            }
        }


    }
}
