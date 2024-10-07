using StructurMessegerFullUserActyvyti.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurMessegerFullUserActyvyti.DAL.Repositories
{
    class UseAccauntMethodRepository
    {
        public async Task AccauntMethod()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Добро пожаловать в новый месседжер !");
                    Console.WriteLine("1: Вход");
                    Console.WriteLine("2: Регистрация");
                    // Проверяем, является ли введенное значение числом
                    if (byte.TryParse(Console.ReadLine(), out byte value))
                    {
                        Console.WriteLine("Введите номер действия ");
                    }

                    switch (value)
                    {
                        case 1: // Действие - вход в систему
                            {
                                Console.Clear(); // Очищаем консоль

                                EntranceRepository entranceRepository = new EntranceRepository();

                                Console.WriteLine("Введите вашу почту для входа");
                                string Email = Console.ReadLine();

                                Console.WriteLine("Введите ваш пароль");
                                string Password = Console.ReadLine();

                                // Проверка данных для входа
                                await entranceRepository.ChekValidEntrace(Email, Password);

                                using (ConnectingDatabase connecting = new())
                                {
                                    var person = connecting.UserDataTable.FirstOrDefault(x => x.Email == Email && x.Password == Password);

                                    if (person != null)
                                    {
                                        Console.WriteLine("Вход выполнен успешно! Добро пожаловать, " + person.Name);
                                        // Выполняем дальнейшие действия после входа
                                        await ShowUserActions(person.Email);
                                    }
                                    else
                                    {
                                        // Если пользователь не найден
                                        Console.WriteLine("Ошибка: Неправильный Email или пароль.");
                                    }
                                }
                                break;
                            }
                        case 2: // Действие - регистрация нового пользователя
                            {
                                Console.Clear(); // Очищаем консоль
                                Console.WriteLine("введите ваше имя");
                                string Name = Console.ReadLine();

                                Console.WriteLine("введите вашу фамилию");
                                string middleName = Console.ReadLine();

                                Console.WriteLine("введите вашу почту");
                                string Email = Console.ReadLine();

                                Console.WriteLine("введите ваш пароль");
                                string Password = Console.ReadLine();

                                RegistrationRepository registrationRepository = new RegistrationRepository();
                                // Проверка и обработка данных для регистрации
                                await registrationRepository.GetRegistrationDataAndChekValid(Name, middleName, Email, Password);

                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений (пока не реализована)
            }
        }

        private static async Task ShowUserActions(string email)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1: Отправить сообщение");
                Console.WriteLine("2: Добавить друга");
                Console.WriteLine("3: Посмотреть профиль");
                Console.WriteLine("4: Выйти");

                if (byte.TryParse(Console.ReadLine(), out byte action))
                {
                    switch (action)
                    {
                        case 1: // Действие - отправить сообщение
                            {
                                // Запрос почты получателя
                                Console.WriteLine("Введите почту куда отправить сообщение !");
                                string Email = Console.ReadLine();

                                Console.WriteLine("Введите сообщение");
                                string Content = Console.ReadLine();

                                MessagerRepositori messagerRepositori = new MessagerRepositori();
                                // Проверка и отправка сообщения
                                await messagerRepositori.CheckValidMessage(Email, Content);

                                break;
                            }
                        case 2: // Действие - добавить друга
                            {
                                // Запрос почты для поиска друга
                                Console.WriteLine("Введите почту для поиска нового друга");
                                string Email = Console.ReadLine();

                                AddFriendRepository friendRepository = new AddFriendRepository();
                                // Проверка и добавление друга
                                await friendRepository.ChekValidAddFriend(Email);

                                break;
                            }
                        case 3: // Действие - посмотреть профиль
                            {
                                // Запрос почты для поиска профиля
                                Console.WriteLine("Введите почту того чей профиль хотите посмотреть");
                                string Email = Console.ReadLine();
                                // Создание экземпляра репозитория профиля
                                ProfileRepository profileRepository = new ProfileRepository();
                                // Отображение профиля пользователя
                                profileRepository.ShowProfile(Email);

                                break;
                            }
                        case 4: // Действие - выход
                            {
                                return; // Выход из действий, возвращаемся в главное меню
                            }
                        default:
                            // Обработка неверного выбора
                            Console.WriteLine("Неверный выбор, попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    // Обработка ввода, не являющегося числом
                    Console.WriteLine("Пожалуйста, введите число.");
                }
            }
        }
    }
}
