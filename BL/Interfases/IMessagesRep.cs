using EmailSender.Model;

namespace EmailSender.BL.Interfases
{
    public interface IMessagesRep
    {

        IQueryable<MessagesVM> Get();
        MessagesVM GetById(int id);
        public void Add(MessagesVM msg);
        public void Send(MailVM mail);
    }
}
