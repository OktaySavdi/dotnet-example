using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
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
                endpoints.MapGet("/", async context =>
                {
                    Thread.Sleep(5000);
                    await context.Response.WriteAsync("" + umachine + " | This is Project:3 | CallNumber: " + i++ + "");
                });
            });
        }
    }
}
