using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
namespace PMS_API
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[Action]")]
    public class UserController:Controller{
        
        private IUserServices _userServices;
        private ILogger _logger;
        public UserController(IUserServices userServices,ILogger<UserController> logger)
        {
            _userServices=userServices;
            _logger=logger;
           
        }
        //Calling all users 
        [HttpGet]
        public IActionResult Getallusers(){
            try{
                
                return Ok(_userServices.GetallUsers());
            }
           catch(Exception exception){
               _logger.LogInformation($"UserController :GetAllUsers()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return Problem(exception.Message);
           }
        }
        [HttpGet]

        public IActionResult GetUserProfile()

        {

            try{

                int currentUser = Convert.ToInt32(User.FindFirst("UserId").Value);

                return Ok(_userServices.GetUser(currentUser));

            }

            catch(Exception exception){

                _logger.LogInformation($"UserController :GetUserById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");

               return Problem(exception.Message);

            }

        }
        [HttpGet]
        public IActionResult GetSpecificUserDetails(){
            try{
                
                return Ok(_userServices.GetSpecificUserDetails());
            }
           catch(Exception exception){
               _logger.LogInformation($"UserController :GetSpecificUserDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return Problem(exception.Message);
           }
            
            
        }
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            if(id<=0)
            {
                return BadRequest("UserId must be greater than zero");
            }
            try{
                
                return Ok(_userServices.GetUser(id));
            }
            catch(ValidationException exception){
                _logger.LogInformation($"UserController :GetUserById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch(Exception exception){
                _logger.LogInformation($"UserController :GetUserById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return Problem(exception.Message);
            }
        }
        
        [HttpPost]
        public IActionResult AddUser(User userValues){
            if(userValues==null){
                _logger.LogInformation("UserController :AddUser()-user tries to enter null values");
                return BadRequest("User values should not be null");
            }
            
               
            try{
                //int currentUser = Convert.ToInt32(User.FindFirst("UserId").Value);
                //Adding user via userservice
                return _userServices.AddUser(userValues)?Ok(new{message="User Added Successfully"}):Problem("Sorry internal error occured");
                
                
            }
            catch(ValidationException exception){
                _logger.LogInformation($"UserController :AddUser()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
          
            catch(Exception exception){
                _logger.LogInformation($"UserController :AddUser()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
         [HttpPut]
         
         public IActionResult UpdateUser(User user)
         {
            if(user==null){
                _logger.LogInformation("UserController :UpdateUser()-user tries to enter null values");
                return BadRequest("User values not be null");
            }
            
            //updating user via userservices
             
             try{
                
                return _userServices.UpdateUser(user)? Ok(new{message="User Updated Successfully"}):BadRequest(new{message="Sorry internal error occured"});

            }
             
             catch(Exception exception){
                 _logger.LogInformation($"UserController:UpdateUser()-{exception.Message}{exception.StackTrace}");
                 return Problem(exception.Message);
             }
            
        } 
         [HttpDelete(Name="Disable")]
         public IActionResult Disable(int id){
             if (id == 0) 
             return BadRequest(new{message="User is required"});
            try{
                
                return _userServices.Disable(id)?Ok(new{message="User Disabled Successfully"}):BadRequest(new{message="Sorry internal error occured"});
            }
             
             catch(Exception exception){
                 _logger.LogInformation($"UserController:DisableUser()-{exception.Message}{exception.StackTrace}");
                 return BadRequest(exception.StackTrace);
             }
        }
       
        

    [HttpPut("Change Password")]

    public IActionResult ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword)

    {

        if (string.IsNullOrEmpty(OldPassword) && string.IsNullOrEmpty(NewPassword) && string.IsNullOrEmpty(ConfirmPassword))

            BadRequest("All the password fiels should be entered");

        try

        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId").Value);
            return _userServices.ChangePassword(OldPassword,NewPassword,ConfirmPassword,currentUser) ? Ok("Password Changed Successfully") : BadRequest("Sorry internal error occured");



        }

        catch (ValidationException exception)

        {

            _logger.LogInformation($"User Service :ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword): {exception.Message}");

            return BadRequest(exception.Message);

        }



        catch (Exception exception)

        {

            _logger.LogInformation("Pool Service : RemovePool throwed an exception", exception);

            return BadRequest("Sorry some internal error occured");

        }



    }

    }
}
