using AutoMapper;
using EmailSender.BL.Helper;
using EmailSender.BL.Interfases;
using EmailSender.DAL.Database;
using EmailSender.DAL.Entities;
using EmailSender.Model;

namespace EmailSender.BL.Reposatories
{
    public class MessagesRep:IMessagesRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public MessagesRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

      

        public void Add(MessagesVM msg)
        {
            var data = mapper.Map<Messages>(msg);

            db.Messages.Add(data);
            db.SaveChanges();
        }

        public IQueryable<MessagesVM> Get()
        {
            var data = db.Messages.Select(c => new MessagesVM
            {
                MessageId = c.MessageId,
                Subject = c.Subject,
                Message = c.Message,
               
            });
            return data;
        }

        public MessagesVM GetById(int id)
        {
            return db.Messages.Where(a => a.MessageId == id)
                              .Select(c => new MessagesVM
                              {
                                  MessageId = c.MessageId,
                                  Subject = c.Subject,
                                  Message = c.Message,

                              })
                              .FirstOrDefault();
        
    }

        public void Send(MailVM mailVM)
        {
            var Messag = db.Messages.Find(mailVM.MessageId);

            mailVM.mails= mailVM.mail.Split(",").ToList();
            sendMail.senderMail(Messag, mailVM.mails);
        }
    }
}
