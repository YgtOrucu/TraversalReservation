using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayers.DTOs.MailDTOs
{
    public class MailRequestDTO
    {
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiveMail { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
