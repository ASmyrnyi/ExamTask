using ExamTask;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void DriverMethodsLogin_CorrectData_UserLoggedIn()
        {
            //Arrange + Act
            DriverMethods.Email = "smyrnyi";
            DriverMethods.Password = "thepass123";
            var result = DriverMethods.Login();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DriverMethodsLogin_WrongData_UserNotLoggedIn()
        {
            //Arrange + Act
            DriverMethods.Email = "123";
            DriverMethods.Password = "123";
            var result = DriverMethods.Login();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DriverMethodsLogin_NoData_UserNotLoggedIn()
        {
            //Arrange + Act
            var result = DriverMethods.Login();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DriverMethodsLogin_СheckPath_PathCorrect()
        {
            //Arrange + Act
            var result = DriverMethods.Login();

            // Assert
            Assert.Equal("Tests", DriverMethods.Path);
        }
    }
}