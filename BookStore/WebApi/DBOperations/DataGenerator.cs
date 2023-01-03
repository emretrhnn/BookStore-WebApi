using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider servisProvider)
        {
            using (var context = new BookStoreDbContext(servisProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author 
                    {
                        Name = "Emre",
                        Surname = "Kara",
                        Birthdate = new DateTime(1999,06,07),
                        BookId = 1

                    
                    },
                    new Author 
                    {
                        Name = "Elif",
                        Surname = "Ant",
                        Birthdate = new DateTime(1999,11,24),
                        BookId = 2
                        
                    },
                    new Author 
                    {
                        Name = "Burak",
                        Surname = "Altın",
                        Birthdate = new DateTime(1999,10,24),
                        BookId = 3
                        
                    }

                );
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2006,11,14)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2014,12,23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 3,
                        PageCount = 300,
                        PublishDate = new DateTime(2022,05,11)
                    }
                );   
                context.SaveChanges();
            }
        }
    }
}