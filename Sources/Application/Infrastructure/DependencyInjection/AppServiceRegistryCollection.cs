using Lamar;

namespace Mmu.Wb.TextBuddy.Infrastructure.DependencyInjection
{
    public class AppServiceRegistryCollection : ServiceRegistry
    {
        public AppServiceRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<AppServiceRegistryCollection>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}