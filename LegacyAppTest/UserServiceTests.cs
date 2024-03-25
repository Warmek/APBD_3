using LegacyApp;

namespace LegacyAppTest;

public class UnitTest1
{
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_Name()
    {
        var userService = new UserService();
        
        var res = userService.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);
        
        Assert.False(res);
    }

    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        var userService = new UserService();

        Assert.Throws<ArgumentException>(() =>
        {
            _ = userService.AddUser("John", "Unknown", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);
        });
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Below_Age_21()
    {
        var userService = new UserService();
        
        var res = userService.AddUser("John", "Doe", "kowalski@wp.pl", new DateTime(2007, 1, 1), 1);
        
        Assert.False(res);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Is_Invalid()
    {
        var userService = new UserService();

        var res = userService.AddUser("John", "Doe", "kowalskiwppl", new DateTime(1980, 1, 1), 1);
        
        Assert.False(res);
    }

}