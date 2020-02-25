﻿using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Demo;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.UI;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Demo
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedDemoModule),
        typeof(AbpAutofacModule)
        )]
    public class AbpAspNetCoreMvcUiThemeBasicDemoModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var env = context.Services.GetHostingEnvironment();

            if (env.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpAspNetCoreMvcUiThemeSharedDemoModule>(Path.Combine(env.ContentRootPath, string.Format("..{0}..{0}src{0}Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Demo", Path.DirectorySeparatorChar)));
                });
            }
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseVirtualFiles();
            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}