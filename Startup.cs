using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace Bug_Tracker_Backend
{
    public class Startup
    {
        //Adding CORS so localhost can grab api
        readonly string MyAllowedSpecificOrigins = "_myAllowedSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Added alongside Newtonsoft MVC Package because of error
            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
          
            //ADDED FOR EF CORE TO WORK
            services.AddDbContext<Bug_Tracker_Backend.Model.DBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Adding CORS so localhost can grab api
            services.AddCors(option =>
                {
                    option.AddPolicy(name: MyAllowedSpecificOrigins,
                                            builder =>
                                            {
                                                builder.WithOrigins("http://localhost:3000");
                                                builder.WithOrigins("http://localhost:90");
                                                builder.AllowAnyHeader();
                                                builder.AllowAnyMethod();
                                            });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Adding CORS so localhost can grab api
            app.UseCors(MyAllowedSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
