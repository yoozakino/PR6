using Microsoft.VisualStudio.TestTools.UnitTesting;
using ПР6_часть_2;
using System;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            // Создаем объект страницы авторизации
            var authPage = new AuthPage();

            // Подключаемся к базе данных
            using (var db = new Entities())
            {
                // Получаем всех пользователей, которые есть в базе данных
                var users = db.Userr.ToList();

                // Для каждого пользователя из базы данных проверяем, что авторизация проходит успешно
                foreach (var user in users)
                {
                    // Параметры теста (логин и пароль пользователя из базы данных)
                    string login = user.Loginn;
                    string password = user.Passwordd;

                    // Выполняем авторизацию
                    bool result = authPage.Auth(login, password);

                    // Проверяем, что авторизация прошла успешно
                    Assert.IsTrue(result, $"Авторизация не прошла для пользователя с логином: {login}");
                }
            }
        }
    }
}
