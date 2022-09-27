using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Application.Categories.Services;
using Core.Application.Categories.Services.Implementation;
using Core.Application.Interfaces;
using Core.Application.Products.Commands;
using Insfrastructure.Persistance.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
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

            services.AddScoped(typeof(IDictionaryQueryService<,>), typeof(BaseDictionaryQueryService<,>));
            services.AddScoped(typeof(IDictionaryCommandService<,>), typeof(BaseDictionaryCommandService<,>));
            services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("Default")));
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<ICategoryCommandService, CategoryCommandService>();
            services.AddScoped<ICategoryQueryService, CategoryQueryService>();
            services.AddScoped<CreateProductCommand>();
            services.AddScoped<DeleteProductCommand>();
            services.AddScoped<UpdateProductCommand>();


            services.AddAutoMapper(typeof(CategoryDto).Assembly);
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}