using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Entities;

class UserFriendsEntity
{
    [Key]  // Указание, что это первичный ключ
    public Guid FriendID { get; set; } = Guid.NewGuid();  // Уникальный идентификатор для друзей

    public string Name { get; set; }
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [ForeignKey("User")]
    public Guid UserID { get; set; }

    public UserDataEntity User { get; set; }

    public UserFriendsEntity() { }

    public UserFriendsEntity(string name, string lastName, string email, Guid userID)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        UserID = userID;
    }
}

