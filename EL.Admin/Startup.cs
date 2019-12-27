using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Autofac;
using CSRedis;
using EL.Common;
using EL.EntityFrameworkCore;
using EL.Repository;

namespace EL.Admin
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
            var jsonConfigManager = new JsonConfigManager();

            // Redis注册
            // CsRedis：https://github.com/2881099/csredis
            // Redis命令参考：http://doc.redisfans.com/sorted_set/zadd.html
            var redisConnection = jsonConfigManager.GetValue<string>("RedisConnection");
            RedisHelper.Initialization(new CSRedisClient(redisConnection));
            // 数据库连接注册
            var connection = jsonConfigManager.GetValue<string>("ELConnection");
            services.AddDbContext<ELDbContext>(options => options.UseLazyLoadingProxies().UseMySql(connection));
            services.AddDistributedMemoryCache()
                    .AddSession(options =>
                    {
                        options.IdleTimeout = TimeSpan.FromSeconds(10);
                        options.Cookie.HttpOnly = true;
                        options.Cookie.IsEssential = true;
                    });
            services.AddControllersWithViews();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 在这里添加服务注册
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterAssemblyTypes(Assembly.Load("EL.Application")).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
