using AgileContentService.Infra;
using AgileContentService.Interfaces;
using Topshelf;

namespace AgileContentService
{
    class Program
    {
        static void Main(string[] args)
        {
             HostFactory.Run(s =>
            {
                s.Service<IService>(ts =>
                {
                    ts.ConstructUsing(name => new TopShelfService());
                    ts.WhenContinued(tc => tc.Start());
                    ts.WhenPaused(tc => tc.Stop());
                    ts.WhenShutdown(tc => tc.Stop());
                    ts.WhenStarted(tc => tc.Start());
                    ts.WhenStopped(tc => tc.Stop());
                });

                s.RunAsLocalSystem();

                s.SetDescription("AgileContent Code Test");
                s.SetDisplayName("AgileContent File Converter");
                s.SetServiceName("AG.FileConverter");
                s.StartAutomatically();
            });
        }
    }
}
