using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using RandomUser.Me.Attributes;
using RandomUser.Me.Enums;
using RandomUser.Me.Models;
using RandomUser.Me.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RandomUser.Me
{
    public class RandomUserMe
    {

        private const string SERVICE_ADDRESS = "https://randomuser.me/api/1.3/";
        private const string QUERY_PARAM_NAME_COUNT = "results";
        private const string QUERY_PARAM_NAME_GENDER = "gender";
        private const string QUERY_PARAM_NAME_PASSWORD = "password";
        private const string QUERY_PARAM_NAME_NATIONALITY = "nat";

        #region Public Methods

        public static User generateSingleUser(Gender? gender, PasswordOptions passwordOptions, params Nationality[] nationalities)
        {
            return generateMultiUser(1, gender, passwordOptions, nationalities)[0];
        }

        public static List<User> generateMultiUser(int count, Gender? gender, PasswordOptions passwordOptions, params Nationality[] nationalities)
        {
            try
            {
                string URL = generateURL(count, gender, passwordOptions, nationalities);
                string serviceRequestResult = getServiceRequestResult(URL);
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(serviceRequestResult);
                if (rootObject.Error != null)
                    throw new Exception(rootObject.Error);
                return rootObject.Users;
            }
            catch (Exception exp)
            {
                throw new Exception("An error occurred during the operation. Please see inner exception.", exp);
            }
        }

        public static T generateSingleUser<T>(Gender? gender, PasswordOptions passwordOptions, params Nationality[] nationalities)
        {
            return generateMultiUser<T>(1, gender, passwordOptions, nationalities)[0];
        }

        public static List<T> generateMultiUser<T>(int count, Gender? gender, PasswordOptions passwordOptions, params Nationality[] nationalities)
        {
            try
            {
                if (!checkObject<T>())
                    throw new Exception("Custom object does not have RandomUserMeMap attribute");
                string URL = generateURL(count, gender, passwordOptions, nationalities);
                string serviceRequestResult = getServiceRequestResult(URL);
                JObject allData = JObject.Parse(serviceRequestResult);
                if (allData["error"] != null)
                    throw new Exception(allData["error"].ToString());
                List<T> result = new List<T>();
                foreach (JObject item in allData["results"].Children())
                {
                    T obj = Activator.CreateInstance<T>();

                    foreach (PropertyInfo property in obj.GetType().GetProperties().Where(x => x.GetCustomAttributes(true).Any(y => y is RandomUserMeMap)).ToList())
                    {
                        string path = property.GetCustomAttribute<RandomUserMeMap>().Path;
                        property.SetValue(obj, item.SelectToken(path).ToObject(property.PropertyType));
                    }

                    result.Add(obj);
                }
                return result;
            }
            catch (Exception exp)
            {
                throw new Exception("An error occurred during the operation. Please see inner exception.", exp);
            }
        }

        #endregion

        #region Private Methods

        private static string generateURL(int count, Gender? gender, PasswordOptions passwordOptions, Nationality[] nationalities)
        {
            string result = SERVICE_ADDRESS + "?";

            if (count > 1)
                result += "&" + QUERY_PARAM_NAME_COUNT + "=" + count.ToString();

            if (gender != null && gender != Gender.both)
                result += "&" + QUERY_PARAM_NAME_GENDER + "=" + gender.ToString();

            if (passwordOptions != null)
            {
                result += "&" + QUERY_PARAM_NAME_PASSWORD + "=";
                foreach (PasswordType nationality in passwordOptions.PasswordTypes)
                    result += nationality.ToString() + ",";
                result += passwordOptions.MinLength.ToString() + "," + passwordOptions.MaxLength.ToString();
            }

            if (nationalities != null)
            {
                result += "&" + QUERY_PARAM_NAME_NATIONALITY + "=";
                foreach (Nationality nationality in nationalities)
                    result += nationality.ToString().ToLower() + ",";
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        private static string getServiceRequestResult(string URL)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("The request to the RandomUser.Me web service failed.");
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static bool checkObject<T>()
        {
            var obj = Activator.CreateInstance<T>();
            return obj.GetType().GetProperties().Any(x => x.GetCustomAttributes(true).Any(x => x is RandomUserMeMap));
        }

        #endregion
    }
}
