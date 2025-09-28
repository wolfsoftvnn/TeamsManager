using TeamsManager.Infrastructure.Startup;
using TeamsManager.Infrastructure.Startup.Tasks;

namespace TeamsManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new BootstrapContext());
        }
    }
    
}