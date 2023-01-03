using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2006,11,14)
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2014,12,23)
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 3,
                        PageCount = 300,
                        PublishDate = new DateTime(2022,05,11)
                    }
                );   
        }
    }
}