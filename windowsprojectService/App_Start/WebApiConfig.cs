using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using windowsprojectService.DataObjects;
using windowsprojectService.Models;

namespace windowsprojectService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            // Set default and null value handling to "Include" for Json Serializer
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            
            Database.SetInitializer(new windowsprojectInitializer());
        }
    }

    public class windowsprojectInitializer : ClearDatabaseSchemaIfModelChanges<windowsprojectContext>
    {
        protected override void Seed(windowsprojectContext context)
        {
            List<Item> Items = new List<Item>
            {   
                new Item { Id = Guid.NewGuid().ToString(), Name = "Firsthgfgfvbhghf item", Done = true },
            };

            foreach (Item Item in Items)
            {
                context.Set<Item>().Add(Item);
            }

            base.Seed(context);
        }
    }
}

