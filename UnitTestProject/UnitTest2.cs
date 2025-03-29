using Microsoft.VisualStudio.TestTools.UnitTesting;
using ПР6_часть_2;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest_ValidUser_ReturnsTrue()
        {
            // Создаем объект страницы авторизации
            var authPage = new AuthPage();

            // Пример корректного логина и пароля
            string login = "admin";
            string password = "Admin@123";

            // Пример успешной авторизации
            bool result = authPage.Auth(login, password);

            // Проверяем, что метод возвращает true для корректных данных
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AuthTest_InvalidUser_ReturnsFalse()
        {
            // Создаем объект страницы авторизации
            var authPage = new AuthPage();

            // Пример некорректного логина и пароля
            string login = "wrong_login";
            string password = "wrong_password";

            // Пример неуспешной авторизации
            bool result = authPage.Auth(login, password);

            // Проверяем, что метод возвращает false для некорректных данных
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuthTest_EmptyLogin_ReturnsFalse()
        {
            // Создаем объект страницы авторизации
            var authPage = new AuthPage();

            // Пример пустого логина
            string login = "";
            string password = "";

            // Проверяем, что метод возвращает false, если логин пустой
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuthTest_EmptyPassword_ReturnsFalse()
        {
            // Создаем объект страницы авторизации
            var authPage = new AuthPage();

            // Пример пустого пароля
            string login = " ";
            string password = " ";

            // Проверяем, что метод возвращает false, если пароль пустой
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result);
        }
    }
}
