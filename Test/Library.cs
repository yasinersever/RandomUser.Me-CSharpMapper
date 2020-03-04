using Library;
using NUnit.Framework;

namespace Test
{
    public class Library
    {

        #region Custom Class Definition

        public class CustomUser
        {
            public string UserName { get; set; }

            public string Password { get; set; }
        }

        #endregion

        [Test]
        public void generateSingleUserStandartObject()
        {
            Assert.IsNotNull(RandomUserMe.generateSingleUser());
        }

        [Test]
        public void generateMultiUserStandartObject()
        {
            Assert.IsNotNull(RandomUserMe.generateMultiUser());
        }

        [Test]
        public void generateSingleUserCustomObject()
        {
            Assert.IsNotNull(RandomUserMe.generateSingleUser<CustomUser>());
        }

        [Test]
        public void generateMultiUserCustomObject()
        {
            Assert.IsNotNull(RandomUserMe.generateMultiUser<CustomUser>());
        }

    }
}