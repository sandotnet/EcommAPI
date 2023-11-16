using EcommAPI.Database;
using EcommAPI.Services;

namespace EcommAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Configure AutoMapperService to DI Container
            //Adding service to DI container
            builder.Services.AddTransient<IProductService,ProductService>();
            builder.Services.AddTransient<IUserService,UserService>();
            builder.Services.AddTransient<IOrderService,OrderService>();
            builder.Services.AddDbContext<MyContext>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}