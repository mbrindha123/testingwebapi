using System;
using System.ComponentModel.DataAnnotations;
namespace PMS_API{
   

    public class UserServices : IUserServices
    {
        private IUserData userData;

        private ILogger<UserServices> _logger;
      
        public UserServices(IUserData userdata,ILogger<UserServices> logger){
            _logger=logger;
            userData=userdata;//UserDataFactory.GetUserObject(logger);
        }
        private UserValidation _validation=UserDataFactory.GetValidationObject();
        public IEnumerable<User> GetallUsers()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from  user in userData.GetallUsers() where user.IsActive==true select user;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"UserServices:GetAll()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public Object GetSpecificUserDetails()
        {
            try
            {
                return (from user in userData.GetallUsers() select user).ToList()
                .Select(var => new
                {
                    Name = var.Name,
                    UserId=var.UserId,
                    Designation = var.designation.DesignationName,
                    ReportingPerson = var.ReportingPersonUsername
                }
                );
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"User Service : GetSpecificUserDetails() : {exception.Message} : {exception.StackTrace}");
                throw exception;
            }
        }
        public object GetUser(int id)
        {
            if(id<=0)
                throw new ArgumentNullException($"UserId is not provided {id}");
            try
            {
                var getuser= userData.GetUser(id); 
                if(getuser.IsActive==true){
                return new {
                    userid=getuser.UserId,
                    name =getuser.Name,
                    email=getuser.Email,
                    username=getuser.UserName,
                    password=getuser.Password,
                    gender=getuser.gender.GenderName,
                    countryCode=getuser.countrycode.CountryCodeName,
                    mobilenumber=getuser.MobileNumber,
                    designation=getuser.designation.DesignationName,
                    reportingpersonUsername=getuser.ReportingPersonUsername,
                    organisation=getuser.organisation.OrganisationName

                };
                }
                else{
                    throw new ValidationException("User not found");
                }
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetUser()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public bool AddUser(User item)

        {
            if(item==null)
                throw new ArgumentNullException($"UserServices:Add()-user values should not be null{item}");
            _validation.userValidate(item);
            try
            {
               
                item.CreatedBy=item.UserId;
                item.CreatedOn=DateTime.Now;
                return userData.AddUser(item)?true:false;              //Ternary operator
                
            }
            catch(ValidationException exception){
                _logger.LogInformation($"UserServices:Add()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
            
            catch(Exception exception){
                _logger.LogInformation($"UserServices:Add()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }
        public bool Disable(int id)
        {
            if(id<=0)
                throw new ArgumentNullException($"UserId is not provided{id}");

            
            try
            {

                return userData.Disable(id)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"UserServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }
        public bool UpdateUser(User item)
        {
            
            if(item==null)throw new ArgumentNullException($" UserServices:Update()-user values not be null{item}");
            _validation.userValidate(item);
            try{
                
               item.UpdatedBy=item.UserId;
                item.UpdatedOn=DateTime.Now;
                return userData.UpdateUser(item)?true:false;
                
            }
            
            catch(Exception exception){
                 _logger.LogInformation($"UserServices:Update()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }
        public bool ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword,int currentUser)

        {

            PasswordValidation.IsValidPassword(OldPassword,NewPassword,ConfirmPassword);




            try
            {
                if(NewPassword != ConfirmPassword)
                    throw new ValidationException($"The confirm password should be the same as new password : {ConfirmPassword}");
                else{
                    return userData.EditPassword(OldPassword,NewPassword,ConfirmPassword,currentUser) ? true : false;
                }

            }

            catch (ArgumentException exception)

            {

                _logger.LogInformation($"User service : EditPassword(string OldPassword,string NewPassword,string ConfirmPassword) : {exception.Message}");

                return false;

            }

            catch (ValidationException passwordNotValid)

            {

                _logger.LogInformation($"User service :EditPassword(string OldPassword,string NewPassword,string ConfirmPassword): {passwordNotValid.Message}");

                throw passwordNotValid;

            }

            catch (Exception exception)

            {

                _logger.LogInformation($"User service :EditPassword(string OldPassword,string NewPassword,string ConfirmPassword):{exception.Message}");

                return false;

            }

        }
        public bool Save()
        {
            return userData.save();
        }
    }
}