using System;
using RandomUser.Me.Enums;

namespace RandomUser.Me.Options
{
    public class PasswordOptions
    {

        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public PasswordType[] PasswordTypes { get; set; }

        public PasswordOptions(int minLength, int maxLength, params PasswordType[] passwordTypes)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            PasswordTypes = passwordTypes;
        }
    }
}
