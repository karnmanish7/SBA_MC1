using NUnit.Framework;
using Moq;
using WatchCart.Models;
using WatchCart.Repository;
using System.Collections.Generic;
using System;

namespace WatchCart.Test
{
    [TestFixture]
    public class ServiceTest
    {
        UserService userService = new UserService();
        [Test]
        [TestCase("Naveen", ExpectedResult =true)]
        [TestCase("Kumar", ExpectedResult =true)]
        public void ValidateUser(string input)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Name = input;
            var actual = userService.ValidateUser(userDetails);
            Assert.AreEqual($"User {input} is Valid:",actual);
        }

        [Test]
        [TestCase(null, ExpectedResult = false)]
        public void ValidateUserNullChechk(string input)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Name = input;
            var actual = Assert.Throws<ArgumentNullException>(() => userService.ValidateUser(userDetails));
            Assert.AreEqual($"User input is not valid Valid:", actual);
        }

    }
}
