using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vegrocery.Domain.Services;
using Vegrocery.Infrastructure.DataManager;
using Vegrocery.Infrastructure.DBContext;
using Vegrocery.Infrastructure.Entities;
using Vegrocery.Infrastructure.Repository;
using Vegrocery.WebAPI.Parser;

namespace Vegrocery
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
            
            services.AddDbContext<ProductContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:VegroceryDB"], b => b.MigrationsAssembly("Vegrocery.WebAPI")));
            services.AddTransient<IProductParser, ProductParser>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IDataRepository<ProductEntity>, ProductManager>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
