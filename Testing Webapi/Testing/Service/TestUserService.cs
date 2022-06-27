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
namespace Testing.Service
{
    public class TestUserService
    {
        private readonly UserServices Userservices;
        private readonly Mock<IUserData> Userdata=new Mock<IUserData>();
        private readonly Mock<ILogger<UserServices>> logger=new Mock<ILogger<UserServices>>();
        public TestUserService()
        {
            Userservices=new UserServices(Userdata.Object,logger.Object);
        }
        
        [Theory]
        [InlineData(null)]
        public void AddUser_ShouldThrowArgumentNullException_WhenUserObjectIsNull(User user)
        {
            Assert.Throws<ArgumentNullException>(() => Userservices.AddUser(user));
        }
        [Fact]
        public void AddUser_ShouldReturnTrue_WhenObjectIsPassed()
        {
            User user=UserMock.AddValidUser();
            Userdata.Setup(obj=>obj.AddUser(user)).Returns(true);
            var Result=Userservices.AddUser(user);
            Assert.True(Result);
        }
        [Fact]
        public void AddUser_ShouldThrowValidationException_WhenUserObjectIsInvalid()
        {
            User user=new User();
            Assert.Throws<ValidationException>(() => Userservices.AddUser(user));
        }
        [Fact]
       public void AddUser_ShouldReturnFalse_WhenExceptionIsThrown()
       {
           User user=UserMock.AddValidUser();
           Userdata.Setup(obj=>obj.AddUser(user)).Throws(new Exception());
           var Result=Userservices.AddUser(user);
           Assert.False(Result);
       }
       //get
       [Theory]
       [InlineData(-1)]
        public void GetUser_ShouldThrowArgumentNullException_WhenUserIdIsNull(int Userid)
        {
            Assert.Throws<ArgumentNullException>(() => Userservices.GetUser(Userid));
        }

        // [Theory]
        // [InlineData(1)]
        // public void GetUser_ShouldReturnTrue_WhenUserIdIsPassed(int Userid)
        // {
        //     User user=UserMock.GetValidUser();
        //     Userdata.Setup(obj=>obj.GetUser(Userid)).Returns(user);
        //     var Result=Userservices.GetUser(Userid);

            
        // }
        
        //Remove
        // [Theory]
        // [InlineData(1)]
        // public RemoveUser_ShouldThrow



        
    }
}