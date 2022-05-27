using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book()
                    {
                        id = 1,
                        Title = "Beyaz Diş",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2022, 05, 22)
                    },
                    new Book
                    {
                        id = 2,
                        Title = "Güvercin Kanat",
                        GenreId = 2,
                        PageCount = 150,
                        PublishDate = new DateTime(2015, 02, 21)
                    },
                    new Book
                    {
                        id = 3,
                        Title = "Semerkant",
                        GenreId = 3,
                        PageCount = 200,
                        PublishDate = new DateTime(2002, 12, 5)
                    });
                context.SaveChanges();
            }
        }
    }
}
