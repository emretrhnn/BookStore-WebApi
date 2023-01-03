using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public AuthorDetailViewModel Model;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Include(x=> x.Book).SingleOrDefault(x => x.Id == AuthorId);
            
            if(author == null)
                throw new InvalidOperationException("Yazar Bulunamadı!");

            AuthorDetailViewModel model = _mapper.Map<AuthorDetailViewModel>(author); 
            return model;
        }
    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Book { get; set; }
    }
}