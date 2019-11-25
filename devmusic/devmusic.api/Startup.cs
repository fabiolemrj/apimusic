using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using devmusic.api.Data;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Buffers;
using System.IO;
using AutoMapper;
using devmusic.api.Data.ProfileMaps;
using devmusic.api.Service;

namespace devmusic.api
{
    public class Startup
    {
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ProfileMapEntity());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            //InMemory(services);
            InDatabase(services);
            
            services.AddScoped<DBMusicContext, DBMusicContext>();
            services.AddScoped<ServiceMusic, ServiceMusic>();
            services.AddScoped<ServiceAuthor, ServiceAuthor>();
            services.AddScoped<ServiceMusicAuthor, ServiceMusicAuthor>();

          
            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }, ArrayPool<char>.Shared));
            });


        }

        private void InMemory(IServiceCollection service)
        {
            service.AddDbContext<DBMusicContext>(opt => opt.UseInMemoryDatabase());
        }
        private void InDatabase(IServiceCollection service)
        {
            var str = $"{Configuration["connectionString"]}";            
            service.AddDbContext<DBMusicContext>(o => o.UseSqlServer(str));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
