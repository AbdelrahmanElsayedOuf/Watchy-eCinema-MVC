using eCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Data
{
    public static class AppDbInitializer
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("AppDbContext");

                try
                {
                    context.Database.Migrate(); // Use Migrate instead of EnsureCreated for better control

                    SeedCinemas(context, logger);
                    SeedActors(context, logger);
                    SeedProducers(context, logger);
                    SeedMovies(context, logger);
                    SeedActorMovies(context, logger);

                    logger.LogInformation("Database seeded successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                    // Don't throw - allow application to continue running
                }
            }

            return app;
        }

        private static void SeedCinemas(AppDbContext context, ILogger logger)
        {
            if (context.Cinemas.Any())
            {
                logger.LogInformation("Cinemas already exist, skipping seeding.");
                return;
            }

            var cinemas = new List<Cinema>
            {
                new Cinema
                {
                    Name = "Cinema City",
                    Description = "Premium movie experience with state-of-the-art facilities",
                    Logo = "https://example.com/cinema1.jpg",
                    Address = "123 Main St, City Center",
                    Phone = "+1234567890",
                    Email = "info@cinemacity.com"
                },
                new Cinema
                {
                    Name = "Star Cinema",
                    Description = "The best place for family entertainment",
                    Logo = "https://example.com/cinema2.jpg",
                    Address = "456 Oak Ave, Downtown",
                    Phone = "+0987654321",
                    Email = "contact@starcinema.com"
                },
                new Cinema
                {
                    Name = "MegaPlex",
                    Description = "Largest screens and best sound quality in town",
                    Logo = "https://example.com/cinema3.jpg",
                    Address = "789 Pine Rd, Westside",
                    Phone = "+1122334455",
                    Email = "support@megaplex.com"
                },
                new Cinema
                {
                    Name = "Royal Theater",
                    Description = "Luxury cinema experience with premium seating",
                    Logo = "https://example.com/cinema4.jpg",
                    Address = "321 Elm St, East End",
                    Phone = "+5566778899",
                    Email = "bookings@royaltheater.com"
                },
                new Cinema
                {
                    Name = "CineWorld",
                    Description = "Affordable movies with great quality",
                    Logo = "https://example.com/cinema5.jpg",
                    Address = "654 Maple Dr, Northside",
                    Phone = "+4433221100",
                    Email = "info@cineworld.com"
                }
            };

            context.Cinemas.AddRange(cinemas);
            context.SaveChanges();
            logger.LogInformation("Cinemas seeded successfully.");
        }

        private static void SeedActors(AppDbContext context, ILogger logger)
        {
            if (context.Actors.Any())
            {
                logger.LogInformation("Actors already exist, skipping seeding.");
                return;
            }

            var actors = new List<Actor>
            {
                new Actor()
                {
                    FullName = "Robert Downey Jr.",
                    Bio = "Academy Award-nominated actor known for Iron Man and Sherlock Holmes",
                    ImageUrl = "https://example.com/robert.jpg",
                    BirthDate = new DateTime(1965, 4, 4),
                    Country = "USA"
                },
                new Actor()
                {
                    FullName = "Scarlett Johansson",
                    Bio = "Acclaimed actress known for Black Widow and Lost in Translation",
                    ImageUrl = "https://example.com/scarlett.jpg",
                    BirthDate = new DateTime(1984, 11, 22),
                    Country = "USA"
                },
                new Actor()
                {
                    FullName = "Tom Hanks",
                    Bio = "Two-time Oscar winner known for Forrest Gump and Saving Private Ryan",
                    ImageUrl = "https://example.com/tom.jpg",
                    BirthDate = new DateTime(1956, 7, 9),
                    Country = "USA"
                },
                new Actor()
                {
                    FullName = "Meryl Streep",
                    Bio = "Most nominated actress in Academy Award history",
                    ImageUrl = "https://example.com/meryl.jpg",
                    BirthDate = new DateTime(1949, 6, 22),
                    Country = "USA"
                },
                new Actor()
                {
                    FullName = "Denzel Washington",
                    Bio = "Two-time Academy Award winner and renowned dramatic actor",
                    ImageUrl = "https://example.com/denzel.jpg",
                    BirthDate = new DateTime(1954, 12, 28),
                    Country = "USA"
                },
                new Actor()
                {
                    FullName = "Emma Watson",
                    Bio = "Known for Hermione Granger in Harry Potter series",
                    ImageUrl = "https://example.com/emma.jpg",
                    BirthDate = new DateTime(1990, 4, 15),
                    Country = "UK"
                },
                new Actor()
                {
                    FullName = "Leonardo DiCaprio",
                    Bio = "Oscar winner known for Titanic and The Revenant",
                    ImageUrl = "https://example.com/leo.jpg",
                    BirthDate = new DateTime(1974, 11, 11),
                    Country = "USA"
                },
                new Actor()
                {
                    FullName = "Jennifer Lawrence",
                    Bio = "Academy Award winner for Silver Linings Playbook",
                    ImageUrl = "https://example.com/jennifer.jpg",
                    BirthDate = new DateTime(1990, 8, 15),
                    Country = "USA"
                }
            };

            context.Actors.AddRange(actors);
            context.SaveChanges();
            logger.LogInformation("Actors seeded successfully.");
        }

        private static void SeedProducers(AppDbContext context, ILogger logger)
        {
            if (context.Producers.Any())
            {
                logger.LogInformation("Producers already exist, skipping seeding.");
                return;
            }

            var producers = new List<Producer>
            {
                new Producer()
                {
                    FullName = "Steven Spielberg",
                    Bio = "Legendary director and producer of Jurassic Park, ET, and Indiana Jones",
                    ImageUrl = "https://example.com/steven.jpg",
                    Country = "USA"
                },
                new Producer()
                {
                    FullName = "Kathleen Kennedy",
                    Bio = "President of Lucasfilm and producer of Star Wars franchise",
                    ImageUrl = "https://example.com/kathleen.jpg",
                    Country = "USA"
                },
                new Producer()
                {
                    FullName = "Kevin Feige",
                    Bio = "President of Marvel Studios and architect of the MCU",
                    ImageUrl = "https://example.com/kevin.jpg",
                    Country = "USA"
                },
                new Producer()
                {
                    FullName = "Quentin Tarantino",
                    Bio = "Acclaimed director and producer known for Pulp Fiction and Django Unchained",
                    ImageUrl = "https://example.com/quentin.jpg",
                    Country = "USA"
                },
                new Producer()
                {
                    FullName = "Christopher Nolan",
                    Bio = "Director and producer known for Inception and The Dark Knight trilogy",
                    ImageUrl = "https://example.com/christopher.jpg",
                    Country = "UK"
                }
            };

            context.Producers.AddRange(producers);
            context.SaveChanges();
            logger.LogInformation("Producers seeded successfully.");
        }

        private static void SeedMovies(AppDbContext context, ILogger logger)
        {
            if (context.Movies.Any())
            {
                logger.LogInformation("Movies already exist, skipping seeding.");
                return;
            }

            // Ensure we have cinemas and producers first
            var cinemas = context.Cinemas.ToList();
            var producers = context.Producers.ToList();

            if (!cinemas.Any() || !producers.Any())
            {
                logger.LogWarning("Cannot seed movies - missing cinemas or producers.");
                return;
            }

            var movies = new List<Movie>
            {
                new Movie()
                {
                    Name = "The Last Adventure",
                    Description = "An epic journey through uncharted territories",
                    ImageUrl = "https://example.com/movie1.jpg",
                    Price = 320,
                    StartDate = DateTime.Now.AddDays(5),
                    EndtDate = DateTime.Now.AddDays(30),
                    MovieCategory = Enum.MovieCategory.Action,
                    ProducerId = producers[0].Id,
                    CinemaId = cinemas[0].Id,
                    TrailerUrl = "https://youtube.com/trailer1"
                },
                new Movie()
                {
                    Name = "Laugh Out Loud",
                    Description = "A hilarious comedy that will keep you entertained",
                    ImageUrl = "https://example.com/movie2.jpg",
                    Price = 220,
                    StartDate = DateTime.Now.AddDays(-5),
                    EndtDate = DateTime.Now.AddDays(30),
                    MovieCategory = Enum.MovieCategory.Comedy,
                    ProducerId = producers[1].Id,
                    CinemaId = cinemas[1].Id,
                    TrailerUrl = "https://youtube.com/trailer2"
                },
                new Movie()
                {
                    Name = "The Silent Echo",
                    Description = "A dramatic tale of love and loss",
                    ImageUrl = "https://example.com/movie3.jpg",
                    Price = 180,
                    StartDate = DateTime.Now.AddDays(3),
                    EndtDate = DateTime.Now.AddDays(10),
                    MovieCategory = Enum.MovieCategory.Drama,
                    ProducerId = producers[2].Id,
                    CinemaId = cinemas[2].Id,
                    TrailerUrl = "https://youtube.com/trailer3"
                },
                new Movie()
                {
                    Name = "Ancient Mysteries",
                    Description = "Documentary exploring historical secrets",
                    ImageUrl = "https://example.com/movie4.jpg",
                    Price = 380,
                    StartDate = DateTime.Now.AddDays(1),
                    EndtDate = DateTime.Now.AddDays(12),
                    MovieCategory = Enum.MovieCategory.Documentry,
                    ProducerId = producers[3].Id,
                    CinemaId = cinemas[3].Id,
                    TrailerUrl = "https://youtube.com/trailer4"
                },
                new Movie()
                {
                    Name = "Future World",
                    Description = "Sci-fi adventure in a dystopian future",
                    ImageUrl = "https://example.com/movie5.jpg",
                    Price = 410,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndtDate = DateTime.Now.AddDays(-2),
                    MovieCategory = Enum.MovieCategory.Action,
                    ProducerId = producers[4].Id,
                    CinemaId = cinemas[4].Id,
                    TrailerUrl = "https://youtube.com/trailer5"
                },
                new Movie()
                {
                    Name = "Mountain Dreams",
                    Description = "Inspiring story of overcoming challenges",
                    ImageUrl = "https://example.com/movie6.jpg",
                    Price = 280,
                    StartDate = DateTime.Now.AddDays(7),
                    EndtDate = DateTime.Now.AddDays(21),
                    MovieCategory = Enum.MovieCategory.Drama,
                    ProducerId = producers[0].Id,
                    CinemaId = cinemas[1].Id,
                    TrailerUrl = "https://youtube.com/trailer6"
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
            logger.LogInformation("Movies seeded successfully.");
        }

        private static void SeedActorMovies(AppDbContext context, ILogger logger)
        {
            if (context.Actor_Movies.Any())
            {
                logger.LogInformation("Actor-Movies already exist, skipping seeding.");
                return;
            }

            var actors = context.Actors.ToList();
            var movies = context.Movies.ToList();

            if (!actors.Any() || !movies.Any())
            {
                logger.LogWarning("Cannot seed actor-movies - missing actors or movies.");
                return;
            }

            var actorMovies = new List<Actor_Movie>();
            var random = new Random();

            // Create multiple actor-movie relationships
            foreach (var movie in movies)
            {
                // Add 2-4 actors to each movie
                var actorsForMovie = actors.OrderBy(a => random.Next()).Take(random.Next(2, 5)).ToList();

                foreach (var actor in actorsForMovie)
                {
                    actorMovies.Add(new Actor_Movie()
                    {
                        ActorId = actor.Id,
                        MovieId = movie.Id
                    });
                }
            }

            context.Actor_Movies.AddRange(actorMovies);
            context.SaveChanges();
            logger.LogInformation("Actor-Movies seeded successfully.");
        }
    }
}