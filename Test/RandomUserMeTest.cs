using System;
using RandomUser.Me;
using RandomUser.Me.Attributes;
using RandomUser.Me.Enums;
using RandomUser.Me.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using RandomUser.Me.Options;

namespace UnitTest
{
    public class RandomUserMeTest
    {

        #region Custom Class Definitions

        public class CustomUser
        {
            [RandomUserMeMap("login.username")]
            public string UserName { get; set; }

            [RandomUserMeMap("login.username")]
            public string Password { get; set; }

            [RandomUserMeMap("email")]
            public string Email { get; set; }

            [RandomUserMeMap("picture")]
            public Picture Picture { get; set; }

            [RandomUserMeMap("gender")]
            public Gender Gender { get; set; }

            [RandomUserMeMap("nat")]
            public Nationality Nationality { get; set; }

            [RandomUserMeMap("registered.date")]
            public DateTime RegisterDateTime { get; set; }
        }

        public class CustomExceptionObject
        {

            // There is no RandomUserMeMap Attribute

            public string UserName { get; set; }

            public string Password { get; set; }
        }

        #endregion

        #region StandartObject

        [Test]
        public void StandartObject_GenerateSingleUser()
        {
            Assert.IsNotNull(RandomUserMe.generateSingleUser(null, null, null));
        }

        [Test]
        public void StandartObject_GenerateMultiUser()
        {
            Assert.IsNotNull(RandomUserMe.generateMultiUser(10, null, null, null));
        }

        #endregion

        #region Custom Object

        [Test]
        public void CustomObject_GenerateSingleUser()
        {
            Assert.IsNotNull(RandomUserMe.generateSingleUser<CustomUser>(null, null, null));
        }

        [Test]
        public void CustomObject_GenerateMultiUser()
        {
            Assert.IsNotNull(RandomUserMe.generateMultiUser<CustomUser>(10, null, null, null));
        }

        [Test]
        public void CustomObject_NoRandomUserMeMapAttributeException()
        {
            Assert.Throws<Exception>(() => RandomUserMe.generateSingleUser<CustomExceptionObject>(null, null, null));
        }
        #endregion

        #region Gender

        [Test]
        public void Gender_Female()
        {
            List<User> userList = RandomUserMe.generateMultiUser(100, Gender.female, null, null);
            List<Gender> genders = userList.Select(x => x.Gender).Distinct().ToList();
            if (genders.Count == 1 && genders[0] == Gender.female)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Gender_Male()
        {
            List<User> userList = RandomUserMe.generateMultiUser(100, Gender.male, null, null);
            List<Gender> genders = userList.Select(x => x.Gender).Distinct().ToList();
            if (genders.Count == 1 && genders[0] == Gender.male)
                Assert.Pass();
            else
                Assert.Fail();
        }

        #endregion

        #region Password Options

        [Test]
        public void PasswordOptions_LengthCheck()
        {
            PasswordOptions options = new PasswordOptions(5, 10, PasswordType.special);
            List<User> userList = RandomUserMe.generateMultiUser(100, null, options, null);
            List<int> passwordLengths = userList.Select(x => x.Login.Password.Length).Distinct().ToList();
            if (options.MinLength <= passwordLengths.Min() && passwordLengths.Max() <= options.MaxLength)
                Assert.Pass();
            else
                Assert.Fail();
        }

        #endregion

        #region Nationality

        [Test]
        public void Nationality_Check()
        {
            Nationality[] request = new Nationality[] { Nationality.TR, Nationality.US, Nationality.CH };
            List<User> userList = RandomUserMe.generateMultiUser(100, null, null, request);
            List<Nationality> nationalities = userList.Select(x => x.Nationality).Distinct().ToList();
            if (!nationalities.Except(request).Any())
                Assert.Pass();
            else
                Assert.Fail();
        }

        #endregion

    }
}