using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_API;
using Testing.Mock;
namespace Testing.Controller
{
    public class TestUserController
    {
        private readonly UserController userControllers;
        private readonly Mock<IUserServices> userServices=new Mock<IUserServices>();
        private readonly Mock<ILogger<UserController>> logger =new Mock<ILogger<UserController>>();
        public TestUserController()
        {
            userControllers=new UserController(userServices.Object,logger.Object);
        }
       //AddUser
       [Theory]
       [InlineData(null)]
       public void AddUser_ShouldreturnStatuscode400_WhenUserObjectIsNull(User user)
       {
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(500,Result?.StatusCode);
       }
        
        [Fact]
       public void AddUser_ShouldreturnStatuscode200_WhenUserObjectIsPassed()
       {

           User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Returns(true);
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
        [Fact]
       public void AddUser_ShouldreturnStatuscode500_WhenUserObjectIsPassed()
       {

           User user=new User();
           userServices.Setup(obj => obj.AddUser(user)).Returns(false);
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(500,Result?.StatusCode);
       }
       //Exception
       [Fact]
       public void AddUser_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
       {

          User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Throws(new ValidationException());
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(400,Result?.StatusCode);
       }
       [Fact]
        public void AddUser_ShouldreturnStatuscode500_WhenExceptionIsThrown()
       {

          User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Throws(new Exception());//Arrange
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(500,Result?.StatusCode);
       }

       //GetUser
       
       [Theory]
       [InlineData(-1)]
       public void GetUser_ShouldReturnStatusCode400_WhenIdIsPassed(int UserId)
       {
        var Result=userControllers.GetUserById(UserId) as ObjectResult;
        Assert.Equal(400,Result?.StatusCode);
       }
       [Theory]
       [InlineData(001)]
       public void GetUser_ShouldReturnStatusCode200_WhenIdIsPassed(int UserId)
       {
        userServices.Setup(obj =>obj.GetUser(UserId)).Returns(true);
        var Result=userControllers.GetUserById(UserId) as ObjectResult;
        Assert.Equal(200,Result?.StatusCode);

       }
       //Exception
       [Theory]
       [InlineData(1)]
       public void GetUser_ShouldReturnStatusCode500_WhenExceptionIsThrown(int UserId)
       {
        userServices.Setup(obj =>obj.GetUser(UserId)).Throws(new Exception());
        var Result=userControllers.GetUserById(UserId) as ObjectResult;
        Assert.Equal(500,Result?.StatusCode);

       }

       //Remove
       [Theory]
       [InlineData(2)]
       
       public void RemoveUser_ShouldReturnStatusCode200_WhenIdIsPassed(int id)
       {
        userServices.Setup(obj=>obj.Disable(id)).Returns(true);
        var Result=userControllers.Disable(id) as ObjectResult;
        Assert.Equal(200,Result?.StatusCode);
       }
    //    [Theory]
    //    [InlineData(3)]
    //    public void RemoveUser_ShouldReturnStatusCode400_WhenIdIsPassed(int id)
    //    {
    //     userServices.Setup(obj=>obj.Disable(id)).Returns(true);
    //     var Result=userControllers.Disable(id) as ObjectResult;
    //     Assert.Equal(400,Result?.StatusCode);
    //    }

    //Exception
       [Theory]
       [InlineData(1)]
       public void RemoveUser_ShouldReturnStatusCode400_WhenExceptionIsThrown(int UserId)
       {
        userServices.Setup(obj =>obj.Disable(UserId)).Throws(new Exception());
        var Result=userControllers.Disable(UserId) as ObjectResult;
        Assert.Equal(400,Result?.StatusCode);

       }

       //GetAll
       [Fact]
       public void GetAllUsers_ShouldReturnGetAllUsers_WhenMethodIsCalled()
       {
          var user=UserMock.GetValidateAllUsers();
          userServices.Setup(obj=>obj.GetallUsers()).Returns(user);
          var Result=userControllers.Getallusers() as ObjectResult;
          Assert.Equal(user,Result?.Value);
          
       }
       //Exception
        [Fact]
       public void GetAllUsers_ShouldReturnStatuscode500_WhenExceptionIsThrown()
       {
          
          userServices.Setup(obj=>obj.GetallUsers()).Throws(new Exception());
          var Result=userControllers.Getallusers() as ObjectResult;
          Assert.Equal(500,Result?.StatusCode);
          
       }

       //Update
       [Theory]
       [InlineData(null)]
       public void UpdateUser_ShouldReturnStatusCode400_WhenObjectIsPassed(User user)
       {
           var Result=userControllers.UpdateUser(user) as ObjectResult;
           Assert.Equal(400,Result?.StatusCode);
       }

    //    [Fact]
    //    public void UpdateUser_ShouldReturnStatusCode200_WhenObjectIsPassed()
    //    {
    //        User user=UserMock.GeValidUser();
    //        userServices.Setup(obj=>obj.UpdateUser(user)).Returns(true);
    //        var Result=userControllers.UpdateUser(user) as ObjectResult;
    //        Assert.Equal(200,Result?.StatusCode);
    //    }
    //     [Fact]
    //    public void UpdateUser_ShouldReturnStatusCode400_WhenUserServiceReturnsFalse()
    //    {
    //        User user=UserMock.GetValidUser();
    //        userServices.Setup(obj=>obj.UpdateUser(user)).Returns(false);
    //        var Result=userControllers.UpdateUser(user) as ObjectResult;
    //        Assert.Equal(400,Result?.StatusCode);
    //    }
    //    //Exception

    //    [Fact]
    //    public void UpdateUser_ShouldReturnStatusCode500_WhenExceptionIsThrown()
    //    {
    //        User user=UserMock.GetValidUser();
    //        userServices.Setup(obj=>obj.UpdateUser(user)).Throws(new Exception());
    //        var Result=userControllers.UpdateUser(user) as ObjectResult;
    //        Assert.Equal(500,Result?.StatusCode);
    //    }







      



    }
}