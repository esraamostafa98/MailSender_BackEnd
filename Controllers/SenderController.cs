using EmailSender.BL.Interfases;
using EmailSender.DAL.Entities;
using EmailSender.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IMessagesRep messages;

        public SenderController(IMessagesRep messages)
        {
            this.messages = messages;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = messages.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = messages.GetById(id);
            return Ok(data);
        }

        
       
        [HttpPost("postdata")]
        public ActionResult PostData([FromForm]MessagesVM msg)
        {
            messages.Add(msg);
            return Ok();
        }

        [HttpPost("sendmail")]
        public ActionResult SendMail(MailVM mail)
        {
            messages.Send(mail);
            return Ok();
        }


    }
}
