﻿namespace STORESERVICES.API.AUTHOR.Config
{
    public class SwaggerConfig : IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "STORESERVICES.API.AUTHOR v1"));
            }
        }
    }
}
