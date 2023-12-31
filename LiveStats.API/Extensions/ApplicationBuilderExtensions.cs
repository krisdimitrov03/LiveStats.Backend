﻿namespace LiveStats.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
            => app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

        public static IApplicationBuilder MapControllers(this IApplicationBuilder app)
            => app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        public static IApplicationBuilder UseDevelopmentSettings(this IApplicationBuilder app)
            => app.UseDeveloperExceptionPage()
                //.UseExceptionHandler()
                .UseSwagger()
                .UseSwaggerUI();
    }
}
