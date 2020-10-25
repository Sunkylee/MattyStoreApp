using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MattyStoreApp.DataAccess.Data;
using MattyStoreApp.DataAccess.Repository;
using MattyStoreApp.DataAccess.Repository.IRepository;
using MattyStoreApp.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using MattyStoreApp.DataAccess.Initializer;
using Stripe;

namespace MattyStoreApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);
            services.Configure<StripSettings>(Configuration.GetSection("Stripe"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
           // services.AddScoped<IDbInitializer, DbInitializer>();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //   .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "1518694618333277";
                options.AppSecret = "2d4737d152ab98d9051c23dc1dda2f81";

            });
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "328988176764-kcst364ek8c7ede4evq9v60sjqav2hg1.apps.googleusercontent.com";
                options.ClientSecret = "ubt9jcSsCQdHmc5Q0Y7QcL2i";

            });
            services.AddSession(options => {

                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      //  IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
           // dbInitializer.Initialize();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
