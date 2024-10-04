using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Entities
{
    class MessageEntity
    {
        [Key]
        public Guid MessageID { get; set; } = Guid.NewGuid();
        public string SenderEmail { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public MessageEntity(string senderEmail, string content)
        {
            SenderEmail = senderEmail;
            Content = content;
        }
    }
}
