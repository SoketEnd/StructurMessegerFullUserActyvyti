using StructurMessegerFullUserActyvyti.DAL.DB;
using StructurMessegerFullUserActyvyti.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Repositories;

class ProfileRepository
{
    public UserDataEntity ShowProfile(string email)
    {
        using (ConnectingDatabase connecting = new ConnectingDatabase())
        {
            var person = connecting.UserDataTable.FirstOrDefault(x => x.Email == email);

            return person;
        }
    }
}
