using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MagicNight.Areas.Identity;
using MagicNight.Data;
using MagicNight.Models.Database.Drafts;
using MagicNight.Services;
using MagicNight.States;
using MudBlazor.Services;

namespace MagicNight
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountsContext>();
            services.AddDbContext<DatabaseContext>();
            services.AddDbContext<CardsContext>();
            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AccountsContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider,
                    RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddMudServices();
            services.AddScoped<CardService>();
            services.AddScoped<DownloadService>();
            services.AddScoped<DeckService>();
            services.AddScoped<ImportService>();
            services.AddScoped<SetService>();
            services.AddScoped<MtgApiService>();
            services.AddScoped<RollService>();
            services.AddScoped<CommanderRollService>();
            services.AddScoped<TournamentService>();
            services.AddScoped<GenerateService>();
            services.AddScoped<DraftService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<UserService>();
            services.AddScoped<StateContainer>();
            services.AddSingleton<LiveDraftService>();
            services.AddSingleton<LobbyService>();
            services.AddSingleton<PackService>();
            services.AddHostedService<DraftTimerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private string Database => Configuration["Database"];

    }
}