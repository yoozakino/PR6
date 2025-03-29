using Microsoft.VisualStudio.TestTools.UnitTesting;
using ПР6_часть_2;
using System;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void RegisterTest_NewUser_ReturnsTrue()
        {
            var regPage = new RegPage();

            string fio = "Иван Иванов";
            string login = "new_user_123";
            string password = "StrongPass123!";
            string gender = "Мужской";
            string role = "Пользователь";
            string phone = "+79123456789";
            string photo = "photo.jpg";

            // Проверяем успешность регистрации нового пользователя
            bool result = regPage.RegisterUser(fio, login, password, gender, role, phone, photo);

            Assert.IsTrue(result);
        }
    }
}
