namespace SL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Policy1",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5104/",
                            "http://localhost:5283/api/");
                    });
                options.AddPolicy("AnotherPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5104/")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            var app = builder.Build();
            app.UseCors();
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


