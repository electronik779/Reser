using Microsoft.Extensions.DependencyInjection;

namespace Reser.maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            window.Width = 1100;
            window.Height = 800;

            return window;
        }
    }
}