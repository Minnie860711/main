using Fitness_EF.ServiceExtension;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Fitness_Service.Service;

namespace Fitness
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Add services to the container.
            services.AddControllersWithViews();
            
            services.AddHttpContextAccessor();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All)); // 避免ViewBag,ViewData,TempData中文亂碼
            services.AddHttpClient(); // HttpClient

            #region == Configure相關 ==
            //services.Configure<ConfigFixedValue_DTO>(this.Configuration.GetSection("ConfigFixedValue")); // 改用靜態類別(GlobalParameter)處理了
            #endregion   

            #region == Cookie登入驗證 (CookieAuthentication) ==
            // 設定 Cookie 式登入驗證，指定登入登出 Action
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.SlidingExpiration = true; // 有操作時，是否自動延長時間
                });
            #endregion

            #region == 資料庫服務相關(Aplus) ==
            services.AddDIServices_ByFitnessEF(Configuration);
            services.AddScoped<MemberService>();
            #endregion
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region == 預設 / 常用 ==
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // 這樣的話，Controller、Action不必再加上[RequireHttps]屬性
            app.UseStaticFiles();
            app.UseRouting();

            // 留意寫Code順序，先執行驗證...
            app.UseAuthentication();
            // Controller、Action才能加上 [Authorize] 屬性
            app.UseAuthorization();

            // 微軟建議 ASP.net Core 3.0 開始改用 Endpoint
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
            #endregion
        }
    }
}