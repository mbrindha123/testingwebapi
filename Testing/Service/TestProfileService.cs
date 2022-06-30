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
    public class TestProfileService
    {
        private readonly ProfileService profileService;
        private Mock<IProfileData> profiledata=new Mock<IProfileData>();
        private Mock<ILogger<ProfileService>> logger =new Mock<ILogger<ProfileService>>();
        public TestProfileService()
        {
            profileService=new ProfileService(profiledata.Object,logger.Object);
        }

        //AddPersonalDetails
        [Theory]
        [InlineData(null)]
        public void AddPersonalDetails_ShouldThrowArgumentNullException_WhenObjectIsNull(PersonalDetails personaldetail)
        {
           Assert.Throws<ArgumentNullException>(()=>profileService.AddPersonalDetail(personaldetail));
        }
        [Fact]
        public void AddPersonalDetails_ShouldReturnTrue_WhenObjectIsPassed()
        {
            PersonalDetails personaldetail=ProfileMock.AddValidPersonalDetails();
            profiledata.Setup(obj=>obj.AddPersonalDetail(personaldetail)).Returns(true);
            var Result=profileService.AddPersonalDetail(personaldetail);
            Assert.True(Result);
        }
          [Fact]
        public void AddPersonalDetails_ShouldReturnFalse_WhenObjectIsPassed()
        {
            PersonalDetails personaldetail=ProfileMock.AddValidPersonalDetails();
            profiledata.Setup(obj=>obj.AddPersonalDetail(personaldetail)).Returns(false);
            var Result=profileService.AddPersonalDetail(personaldetail);
            Assert.False(Result);
        }

        //GetAllPersonalDetail
        [Fact]
        public void GetallPersonalDetail_ShouldReturnPersonalDetails_WhenMethodIsCalled()
        {
            var personalDetail=ProfileMock.GetValidateAllPersonalDetails();
            profiledata.Setup(obj=>obj.GetAllPersonalDetails()).Returns(personalDetail);
            var Result=profileService.GetAllPersonalDetails();
            Assert.Equal(personalDetail.Count(),Result.Count());

        }
        [Fact]
        public void GetAllPersonalDetail_ShouldThrowException_WhenMethodIsCalled()
        {
            profiledata.Setup(obj=>obj.GetAllPersonalDetails()).Throws(new Exception());
            Assert.Throws<Exception>(()=>profileService.GetAllPersonalDetails());
        }

        //GetPersonalDetail
        [Theory]
        [InlineData(-1)]
        public void GetPersonalById_ShouldThrowArgumentNullException_WhenIdIsInvalid(int personalid)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.GetPersonalDetailsById(personalid));
        }
        [Theory]
        [InlineData(1)]
        public void GetPersonalById_ShouldThrowException_WhenIdIsPassed(int personalid)
        {
            profiledata.Setup(obj=>obj.GetPersonalDetailsById(personalid)).Throws(new Exception());
            Assert.Throws<Exception>(()=>profileService.GetPersonalDetailsById(personalid));
        }

        //UpdatePersonalDetail
        [Theory]
        [InlineData(null)]
        public void UpdatePersonalDetail_ShouldThrowArgumentNullException_WhenObjectIsNull(PersonalDetails personaldetail)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.UpdatePersonalDetail(personaldetail));
        }
        // [Fact]
        // public void UpdatePersonalDetail_ShouldReturnTrue_WhenObjectIsPassed()
        // {
        //     PersonalDetails personalDetail=ProfileMock.GetValidPersonalDetails();
        //     profiledata.Setup(obj=>obj.UpdatePersonalDetail(personalDetail)).Returns(true);
        //     var Result=profileService.UpdatePersonalDetail(personalDetail);
        //     Assert.True(Result);
        // }
        // [Fact]
        // public void UpdatePersonalDetail_ShouldThrowException_WhenObjectIsPassed()
        // {
        //     PersonalDetails personaldetail=ProfileMock.GetValidPersonalDetails();
        //     profiledata.Setup(obj=>obj.UpdatePersonalDetail(personaldetail)).Throws(new Exception());
        //     Assert.Throws<Exception>(()=>profileService.UpdatePersonalDetail(personaldetail));
           
        // }
        
        //Remove
        public void RemovePersonal

    }
}