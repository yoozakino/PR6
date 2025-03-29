using Microsoft.VisualStudio.TestTools.UnitTesting;
using ПР6_часть_2;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void AuthTest_WrongPassword_ReturnsFalse()
        {
            var authPage = new AuthPage();
            string login = "admin";
            string password = "WrongPassword";
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result, "Авторизация должна провалиться при неправильном пароле");
        }

        [TestMethod]
        public void AuthTest_WrongLogin_ReturnsFalse()
        {
            var authPage = new AuthPage();
            string login = "WrongUser";
            string password = "Admin@123";
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result, "Авторизация должна провалиться при неправильном логине");
        }

        [TestMethod]
        public void AuthTest_SqlInjection_ReturnsFalse()
        {
            var authPage = new AuthPage();
            string login = "' OR 1=1 --";
            string password = "12345";
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result, "Авторизация должна провалиться при попытке SQL-инъекции");
        }

        [TestMethod]
        public void AuthTest_SpecialCharacters_ReturnsFalse()
        {
            var authPage = new AuthPage();
            string login = "<script>alert('XSS')</script>";
            string password = "<b>bold</b>";
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result, "Авторизация должна провалиться при вводе специальных символов");
        }

        [TestMethod]
        public void AuthTest_WhitespaceOnly_ReturnsFalse()
        {
            var authPage = new AuthPage();
            string login = "    ";
            string password = "    ";
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result, "Авторизация должна провалиться, если логин и пароль содержат только пробелы");
        }

        [TestMethod]
        public void AuthTest_LongInput_ReturnsFalse()
        {
            var authPage = new AuthPage();
            string login = new string('a', 300);
            string password = new string('b', 300);
            bool result = authPage.Auth(login, password);
            Assert.IsFalse(result, "Авторизация должна провалиться при слишком длинных вводных данных");
        }
    }
}
