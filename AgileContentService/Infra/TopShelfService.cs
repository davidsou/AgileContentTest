using AgileContentService.Interfaces;
using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace AgileContentService.Infra
{
    public class TopShelfService : IService
    {
        private IDisposable app = null;
        private readonly string url;

        public string Name { get; private set; }

        public TopShelfService()
        {
            url = $"http://{Environment.MachineName}:{ConfigurationManager.AppSettings["Port"]}";
            Name = ConfigurationManager.AppSettings["MicroService"];
        }
        public void Start()
        {
            app = WebApp.Start<Startup>(url);

        }

        public void Stop()
        {
            app.Dispose();
        }
    }
}
