using System.ComponentModel.DataAnnotations;

namespace EmailSender.Model
{
    public class MessagesVM
    {
        public int MessageId { get; set; }
        [Required(ErrorMessage = "Subject Required")]
        [MaxLength(100, ErrorMessage = "Max len 100")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message Required")]
       
        public string Message { get; set; }

       
    }
}
