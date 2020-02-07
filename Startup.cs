using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System;

namespace istioproject
{
    public class Startup
    {
        int i = 1;
        string umachine = Environment.MachineName; 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/",  async context =>
                {
                    #region versiyon 1
                    await context.Response.WriteAsync("" + umachine + " | This is Project:1 | CallNumber: " + i++ + "");
                    #endregion

                    #region versiyon 2
                    //await context.Response.WriteAsync("" + umachine + " | This is Project:2 | CallNumber: " + i++ + "");
                    #endregion

                    #region versiyon 3
                    //Thread.Sleep(5000);
                    //await context.Response.WriteAsync("" + umachine + " | This is Project:3 | CallNumber: " + i++ + "");
                    #endregion

                    #region versiyon 4
                    //context.Response.StatusCode = 502;
                    //await context.Response.WriteAsync("");
                    #endregion
                });
            });
        }
    }
}
