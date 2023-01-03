using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
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
        }
    }
}