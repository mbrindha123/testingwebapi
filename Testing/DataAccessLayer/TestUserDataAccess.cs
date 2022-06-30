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

namespace Testing.DataAccessLayer
{
    public class TestUserDataAccess
    {
        public readonly UserData Userdata;
        public Mock<ILogger<UserData>> logger=new Mock<ILogger<UserData>>();
        private Context _context;
        public TestUserDataAccess()
        {
            _context=MockDbContext.GetDbContext();
            Userdata=new UserData(_context,logger.Object);
        }
        //Add
        [Theory]
        [InlineData(null)]
        public void AddUser_ShouldReturnArgumentNullException_WhenObjectIsNull(User user)
        {
            Assert.Throws<ArgumentNullException>(() => Userdata.AddUser(user));
        }
        [Fact]
        public void AddUser_ShouldReturnTrue_WhenObjectIsValid()
        {
            User user=UserMock.AddValidUser();
            var Result=Userdata.AddUser(user);
            Assert.True(Result);
        }
        //GetUser
        [Theory]
        [InlineData(-1)]
        public void GetUser_ShouldReturnValidationException_WhenIdIsInvalid(int Userid)
        {
            Assert.Throws<ValidationException>(() => Userdata.GetUser(Userid));
        }
        // [Theory]
        // [InlineData(1)]
        // public void GetUser_ShouldReturnObject_WhenMethodIsCalled(int Userid)
        // {
        //     User Result=Userdata.GetUser(Userid);
        //     Assert.True(Result);
        // }



        //GetAll
        // [Fact]
        // public void GetAllUser_ShouldReturnListOfUsers_WhenMethodIsCalled()
        // {
        //     MockDbContext.SeedPMSMockData(_context);// from mockdbcontext
        //     var user=UserMock.GetValidateAllUsers();
        //     var Result=Userdata.GetallUsers();
        //     Assert.Equal(user.Count(),Result.Count());
        // }


        //Update
        [Theory]
        [InlineData(null)]
        public void UpdateUser_ShouldThrowValidationException_WhenIdIsInvalid(User user)
        {
            Assert.Throws<ValidationException>(() => Userdata.UpdateUser(user));
        }

        // [Fact]
        // public void UpdateUser_ShouldReturnTrue_WhenObjectIsvalid()
        // {
        //     User user=UserMock.UpdateValidUser();
        //     var Result=Userdata.UpdateUser(user);
        //     Assert.True(Result);
        // }

        //Remove

        [Theory]
        [InlineData(-1)]
        public void RemoveUser_ShouldReturnValidationException_WhenIdIsInvalid(int Userid)
        {
            Assert.Throws<ValidationException>(() => Userdata.Disable(Userid));
        }
        [Theory]
        [InlineData(1)]
        public void RemoveUser_ShouldReturnTrue_WhenIdIsPassed(int Userid)
        {
            var Result=Userdata.Disable(Userid);
            Assert.True(Result);
        }
        

    }
}