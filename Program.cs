using Microsoft.Extensions.DependencyInjection;
using W6_assignment_template.Data;
using W6_assignment_template.Services;

namespace W6_assignment_template
{
    // Program is the entry point of the application.
    // It sets up dependency injection and starts the game engine.
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new service collection for dependency injection.
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build the service provider from the configured services.
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Retrieve an instance of GameEngine from the service provider.
            var gameEngine = serviceProvider.GetService<GameEngine>();

            // Run the game if the GameEngine was successfully retrieved.
            gameEngine?.Run();
        }

        // Configures services for dependency injection.
        // Registers IContext as a singleton and GameEngine as transient.
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IContext, DataContext>(); // DataContext will be shared across the app
            services.AddTransient<GameEngine>(); // A new GameEngine instance per request
        }
    }
}
