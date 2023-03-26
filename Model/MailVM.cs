namespace EmailSender.Model
{
    public class MailVM
    {
        public int MessageId { get; set; }

        public string mail { get; set; }
        public List<string>? mails { get; set; }
    }
}
