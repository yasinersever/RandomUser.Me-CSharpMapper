using System;
using System.Collections.Generic;
using Library.Models;

namespace Library
{
    public class RandomUserMe
    {

        #region Public Methods

        public static User generateSingleUser()
        {
            return null;
        }

        public static List<User> generateMultiUser()
        {
            return null;
        }

        public static T generateSingleUser<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public static List<T> generateMultiUser<T>()
        {
            return null;
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
