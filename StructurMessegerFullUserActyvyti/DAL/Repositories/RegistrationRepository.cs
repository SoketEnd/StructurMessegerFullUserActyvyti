using Microsoft.EntityFrameworkCore;
using StructurMessegerFullUserActyvyti.DAL.DB;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StructurMessegerFullUserActyvyti.DAL.Entities;

namespace StructurMessegerFullUserActyvyti.DAL.Repositories;

class RegistrationRepository
{
    public async Task GetRegistrationDataAndChekValid(string Name, string LastName, string Mail, string Password)
    {
        // Проверка имени
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Поле имени осталось пустым", nameof(Name));
        }

        // Проверка фамилии
        if (string.IsNullOrWhiteSpace(LastName))
        {
            throw new ArgumentException("Поле фамилии осталось пустым", nameof(LastName));
        }

        // Проверка почты
        if (string.IsNullOrWhiteSpace(Mail))
        {
            throw new ArgumentException("Поле почты осталось пустым или введено некорректно", nameof(Mail));
        }

        // Проверка пароля (длина и пустое значение)
        if (string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
        {
            throw new ArgumentException("Поле пароля должно содержать минимум 8 символов", nameof(Password));
        }

        // Если все проверки пройдены, вызываем метод регистрации
        await Registration(Name, LastName, Mail, Password);
    }

    private async Task Registration(string Name, string LastName, string Mail, string Password)
    {
        using (ConnectingDatabase dataTable = new ConnectingDatabase())
        {
            // Проверка на существующего пользователя по email перед регистрацией
            var existingUser = await dataTable.UserDataTable
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == Mail);

            if (existingUser != null)
            {
                throw new InvalidOperationException("Пользователь с таким email уже существует.");
            }

            string hashedPassword = HashPassword(Password);

            // Если такого пользователя нет, добавляем нового
            await dataTable.UserDataTable.AddAsync(new UserDataEntity(Name, LastName, Mail, Password));
            await dataTable.SaveChangesAsync();
        }
    }

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
