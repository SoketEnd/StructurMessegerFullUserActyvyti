using StructurMessegerFullUserActyvyti.DAL.DB;
using StructurMessegerFullUserActyvyti.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Repositories;

class MessagerRepositori
{
    public async Task CheckValidMessage(string senderEmail, string content)
    {
        if (string.IsNullOrWhiteSpace(senderEmail))
        {
            throw new ArgumentException(nameof(senderEmail));
        }

        if (string.IsNullOrWhiteSpace(content) && content.Length < 5000)
        {
            throw new ArgumentException(nameof(content));
        }

        await SendMessage(senderEmail,content);
    }

    private async Task SendMessage(string senderEmail, string content)
    {
        using (ConnectingDatabase connecting = new ConnectingDatabase())
        {
            var message = new MessageEntity(senderEmail, content);

            await connecting.MessageEntity.AddRangeAsync(message);
            await connecting.SaveChangesAsync();
        }
    }
}
