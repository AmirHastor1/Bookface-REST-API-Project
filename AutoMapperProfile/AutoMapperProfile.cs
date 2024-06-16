using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Bookface.AutoMapperProfile
{
    public class AutoMapperProfile : Profile

    {
        public AutoMapperProfile()
        {
            //CreateMap<User, UserDTO>().ReverseMap();
            //CreateMap<Blog, BlogDTO>().ReverseMap();
            //CreateMap<Comment, CommentDTO>().ReverseMap();
            //CreateMap<Notification, NotificationDTO>().ReverseMap();
            //CreateMap<Book, BookDTO>().ReverseMap();
            // CreateMap<Book, BookDTO>().ForMember(x=> x.Author, options => options.Ignore());
            //CreateMap<Rental, RentalDTO>().ForSourceMember(x => x.Book, opt => opt.DoNotValidate()).ReverseMap();//.ForMember(x=> x.Book, opt => opt.Ignore());
        }

    }
}