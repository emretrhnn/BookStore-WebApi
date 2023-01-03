
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateCommand
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorId {get; set;}
        public UpdateAuthorModel Model { get; set; }
        

        public UpdateAuthorCommand(IBookStoreDbContext context )
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if(author == null)
                throw new InvalidOperationException("Yazar Bulunamadı ! ");

            author.BookId = Model.BookId != default ? Model.BookId : author.BookId;
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}