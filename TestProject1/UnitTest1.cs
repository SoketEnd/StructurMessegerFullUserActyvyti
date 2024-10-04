using NPOI.HSSF.Record;
using System.Collections.Generic;
using StructurMessegerFullUserActyvyti;
using StructurMessegerFullUserActyvyti.DAL.Entities;
using StructurMessegerFullUserActyvyti.DAL.Repositories;
[TestFixture]
public class EntranceEntityTests
{
    [Test]
    public async Task AddFriend_AddCorrendDataBase()
    {
        var AddFridn = new AddFriendRepository();

        string Email = "john.doe@example.com";

        var res = AddFridn.ChekValidAddFriend(Email);

        Assert.IsNotNull(res);
    }
}
