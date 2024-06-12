using InkwellReads.Books.Application.Map;
using InkwellReads.Books.Infrastructure.Data;
using InkwellReads.Books.Infrastructure.Repositories;
using InkWellReads.Books.API.Middlewares;
using InkWellReads.Books.Domain.Entities;
using InkWellReads.Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InkWellReads.Books.API.Extensions
{
    public static class IoCExtension
    {
        public static void AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.Load("InkwellReads.Books.Application"));
            });

            var connectionstring = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(
               opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<ErrorHandlerMiddleware>();

            services.AddScoped<IRepository<Book, string>, BookRepository>();
            services.AddScoped<IRepository<Author, string>, AuthorRepository>();
            services.AddScoped<IRepository<Category, string>, CategoryRepository>();

            services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
