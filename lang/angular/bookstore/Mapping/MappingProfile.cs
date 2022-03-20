using AutoMapper;
using bookstore.Controllers.Resources;
using bookstore.Models;

namespace bookstore.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Bookstore,BookstoreResource>();
            CreateMap<BookstoreResource,Bookstore>()
                .ForMember(v=>v.Id,opt=>opt.Ignore());
        }
        
    }
}