using AutoMapper;
using EmailSender.DAL.Entities;
using EmailSender.Model;

namespace EmailSender.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<MessagesVM, Messages>();
            CreateMap<Messages, MessagesVM>();
        }
        }
}
