using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IMapper mapper, IBookStoreDbContext context = null)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);

            if(author != null)
                throw new InvalidOperationException("Yazar zaten mevcut");

            author = _mapper.Map<Author>(Model);
        
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}