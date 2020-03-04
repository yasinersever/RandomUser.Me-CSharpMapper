using System;

namespace RandomUser.Me.Attributes
{
    public class RandomUserMeMap : Attribute
    {

        public string Path { get; set; }

        public RandomUserMeMap(string path)
        {
            this.Path = path;
        }

    }
}
