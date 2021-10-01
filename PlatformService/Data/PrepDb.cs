using PlatformService.Models;

namespace PlatformService.Data
{

    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

            }

        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding Platforms");
                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Java", Publisher = "Oracle", Cost = "Free" },
                    new Platform() { Name = "C#", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Python", Publisher = "Google", Cost = "Free" },
                    new Platform() { Name = "C++", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "C", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Ruby", Publisher = "Oracle", Cost = "Free" },
                    new Platform() { Name = "Swift", Publisher = "Apple", Cost = "Free" },
                    new Platform() { Name = "Kotlin", Publisher = "JetBrains", Cost = "Free" },
                    new Platform() { Name = "Go", Publisher = "Google", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Skipping seeding of Platforms");
            }
        }

    }
}