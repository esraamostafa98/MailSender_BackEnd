using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmailSender.DAL.Entities
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }


    }
}
