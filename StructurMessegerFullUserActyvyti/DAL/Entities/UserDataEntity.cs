using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Entities;

class UserDataEntity
{
    [Key]
    public Guid UserID { get; set; } = new Guid();
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<UserFriendsEntity> Friends { get; set; }

    public UserDataEntity(string Name, string LastName, string Email, string Password)
    {
        this.Name = Name;
        this.LastName = LastName;
        this.Email = Email;
        this.Password = Password;
        Friends = new List<UserFriendsEntity>();
    }
}
