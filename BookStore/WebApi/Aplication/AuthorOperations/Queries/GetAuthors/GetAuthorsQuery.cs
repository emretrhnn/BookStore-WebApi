using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList();
            List<AuthorsViewModel> avm = _mapper.Map<List<AuthorsViewModel>>(authors);
            return avm;
        }
    }
    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}