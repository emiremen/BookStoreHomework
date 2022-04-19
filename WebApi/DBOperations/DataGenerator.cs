using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                else
                {
                    context.Genres.AddRange(
                        new Genre
                        {
                            Name = "Personal Growth"
                        },
                        new Genre
                        {
                            Name = "Science Finction"
                        },
                        new Genre
                        {
                            Name = "Novel"
                        }
                    );
                    context.Books.AddRange(
                        new Book
                        {
                            Title = "Lean Startup",
                            GenreId = 1, //Personal Growth
                            PageCount = 236,
                            PublishDate = new DateTime(2004, 05, 18)
                        },
                        new Book
                        {
                            Title = "Herland",
                            GenreId = 2, // Sci-Fi
                            PageCount = 340,
                            PublishDate = new DateTime(2017, 08, 23)
                        },
                        new Book
                        {
                            Title = "Dune",
                            GenreId = 2, // Sci-Fi
                            PageCount = 520,
                            PublishDate = new DateTime(2019, 10, 30)
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}