namespace ecommerce_app
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
        public static void Init(IServiceProvider services)
        {
            Services = services;
        }
    }
}