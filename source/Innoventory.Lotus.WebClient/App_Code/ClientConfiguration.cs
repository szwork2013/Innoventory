using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Innoventory.Lotus.WebClient
{
    public class ClientConfiguration
    {
        public static string LoadConfig()
        {
            string configString = string.Empty;

            ApplicationConfig config = new ApplicationConfig();

            config.ApiUrl = "http://localhost/api/v1";

            config.ImageHost = "TBD";

            configString = Newtonsoft.Json.JsonConvert.SerializeObject(config);

            return configString;
        }
    }

    public class ApplicationConfig
    {
        public string ApiUrl { get; set; }

        public string ImageHost { get; set; }
    }
}