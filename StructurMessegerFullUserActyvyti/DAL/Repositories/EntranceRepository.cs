using Microsoft.EntityFrameworkCore;
using StructurMessegerFullUserActyvyti.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Repositories;

class EntranceRepository
{
    public async Task ChekValidEntrace(string Email, string Password)
    {
        // Проверка, заполнено ли поле Email
        if (string.IsNullOrWhiteSpace(Email))
        {
            throw new ArgumentException("Заполните поле почты");
        }

        // Проверка, заполнено ли поле Password
        if (string.IsNullOrWhiteSpace(Password))
        {
            throw new ArgumentException("Заполните поле пароля");
        }

        // Если валидация прошла успешно, вызываем метод входа
        await Entrance(Email, Password);
    }

    private async Task Entrance(string Email, string Password)
    {
        using (ConnectingDatabase dataTable = new ConnectingDatabase())
        {
            // Поиск пользователя по email
            var person = await dataTable.UserDataTable
                .FirstOrDefaultAsync(x => x.Email == Email);

            // Проверяем, найден ли пользователь
            if (person == null)
            {
                Console.WriteLine("Пользователь с таким email не найден.");
                return;
            }

            // Хешируем введенный пароль и сравниваем с хешем в базе данных
            string hashedPassword = HashPassword(Password);

            if (person.Password != hashedPassword)
            {
                Console.WriteLine("Неверный пароль.");
                return;
            }

            // Если все проверки пройдены
            Console.WriteLine($"Вы успешно вошли в аккаунт! {person.Name}");
        }
    }

    // Метод для хеширования пароля с использованием SHA256
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            // Преобразуем строку пароля в байты
            var bytes = Encoding.UTF8.GetBytes(password);

            // Хешируем байты пароля
            var hashBytes = sha256.ComputeHash(bytes);

            // Преобразуем хешированные байты в строку Base64
            return Convert.ToBase64String(hashBytes);
        }
    }
}
