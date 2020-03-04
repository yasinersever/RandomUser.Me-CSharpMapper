# RandomUser.Me-CSharpMapper

A .NET C# class mapper for https://randomuser.me written in .NET Core

## How to use

```c#

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

// Custom Object

CustomUser customUser = RandomUserMe.generateSingleUser<CustomUser>(null, null, null);
List<CustomUser> customUsers = RandomUserMe.generateMultiUser<CustomUser>(10, null, null, null);



// Standart Object

User user = RandomUserMe.generateSingleUser(null, null, null);
List<User> users = RandomUserMe.generateMultiUser(10, null, null, null);

```
