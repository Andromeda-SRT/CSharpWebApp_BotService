using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore; //Для регистрации "MyMegaBotContext"
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelegramBot.Bot;
using WebApplication1.Repository;
using WebApplication1.Service;
using WebApplication1.ConnectionStrings;

namespace TelegramBot
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
            services.AddControllers();

            //Инициализируем соединение c MsSQL.
            services.AddDbContext<MyMegaBotContext>(options => options.UseSqlServer(
                ConnectionStrings.SQLServer)); // past your connection string here

            //Зарегистрировать CommandRepository в классе Startup
            services.AddScoped<ICommandRepository, CommandRepository>(); // В первом аргументе дженерика
                                                                         // указываем интерфейс, во втором - реализацию.

            services.AddHostedService<BotConnector>(); //Регистрация бота телеги

            services.AddScoped<IChatIService, chatService>();//Регистрация "общего сервиса", который занимается
                                                            //обработкой сообщений с любого источника
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
