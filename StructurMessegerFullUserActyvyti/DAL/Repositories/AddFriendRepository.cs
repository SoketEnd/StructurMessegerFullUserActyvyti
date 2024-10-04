using StructurMessegerFullUserActyvyti.DAL.DB;
using StructurMessegerFullUserActyvyti.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Repositories;

public class AddFriendRepository
{
    public async Task ChekValidAddFriend(string Emal)
    {
        if (string.IsNullOrWhiteSpace(Emal))
        {
            throw new ArgumentException("Пользователь с такой почтой не найден, возможно вы ошиблись в написании почты или оставили поле пустым");
        }

        await AddFriend(Emal);
    }

    private async Task AddFriend(string Email)
    {
        using (ConnectingDatabase connecting = new ConnectingDatabase())
        {
            // Поиск пользователя по email
            var person = connecting.UserDataTable.FirstOrDefault(x => x.Email == Email);

            if (person != null)
            {
                // Логирование для отладки
                Console.WriteLine($"Найден пользователь: {person.Name}");

                // Создание записи о новом друге и добавление его в таблицу друзей
                var newFriend = new UserFriendsEntity(person.Name, person.LastName, person.Email, person.UserID);

                await connecting.UserFriendsTable.AddAsync(newFriend);
                await connecting.SaveChangesAsync();  // Сохранение изменений в базе данных

                Console.WriteLine($"Вы успешно добавили пользователя - {person.Name}");
            }
            else
            {
                Console.WriteLine("Пользователя с такой почтой не найдено");
            }
        }
    }
}
