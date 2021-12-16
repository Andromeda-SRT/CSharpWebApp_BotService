using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore; //��� ����������� "MyMegaBotContext"
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

            //�������������� ���������� c MsSQL.
            services.AddDbContext<MyMegaBotContext>(options => options.UseSqlServer(
                ConnectionStrings.SQLServer)); // past your connection string here

            //���������������� CommandRepository � ������ Startup
            services.AddScoped<ICommandRepository, CommandRepository>(); // � ������ ��������� ���������
                                                                         // ��������� ���������, �� ������ - ����������.

            services.AddHostedService<BotConnector>(); //����������� ���� ������

            services.AddScoped<IChatIService, chatService>();//����������� "������ �������", ������� ����������
                                                            //���������� ��������� � ������ ���������
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
