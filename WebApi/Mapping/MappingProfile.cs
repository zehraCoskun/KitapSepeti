using AutoMapper;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Commands.CreateAuthor;
using WebApi.Operations.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Operations.AuthorOperations.Queries;
using WebApi.Operations.BookOperations.Commands.CreateBook;
using WebApi.Operations.BookOperations.Commands.UpdateBook;
using WebApi.Operations.BookOperations.Queries;
using WebApi.Operations.GenreOperations.Commands.CreatGenre;
using WebApi.Operations.GenreOperations.Commands.UpdateGenre;
using WebApi.Operations.GenreOperations.Queries;
using WebApi.Operations.UserOperations.Commands.CreateUserCommand;
using static WebApi.Operations.BookOperations.Queries.GetBooksQuery;

namespace WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //BookController için mapping
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookByIdModel>().ForMember(dest=> dest.Genre,  opt=> opt.MapFrom(src=> src.Genre.GenreName)).ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.FirstName+" "+src.Author.LastName));
            CreateMap<Book, BooksViewModel>().ForMember(dest=> dest.Genre,  opt=> opt.MapFrom(src=> src.Genre.GenreName)).ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.FirstName+" "+src.Author.LastName));
            CreateMap<UpdateBookModel, Book>();

            //AuthorController için mapping
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorByIdModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<UpdateAuthorModel, Author>();

            //GenreController için mapping
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Genre, GetGenreByIdModel>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<UpdateGenreModel, Genre>();

            //UserController için mapping
            CreateMap<CreateUserModel, User>();
        }
    }
}