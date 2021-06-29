using System.Windows;

namespace gala_darbs
{
    public partial class App : Application
    {
        public App()
        {
            // Initialize application-scope property
            this.Properties["NumberOfAppSessions"] = 0;
        }
    }
}