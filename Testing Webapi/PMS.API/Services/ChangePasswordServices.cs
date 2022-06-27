// using System;
// using System.ComponentModel.DataAnnotations;
// namespace PMS_API
// { 

//     public class ChangePasswordServices : IChangePasswordServices
//     {
//         private IChangePasswordDataAccessLayer _changepasswordData;

//         private ILogger<ChangePasswordServices> _logger;
      
//         public ChangePasswordServices(ILogger<ChangePasswordServices> logger,IChangePasswordDataAccessLayer changepasswordData){
//             _logger=logger;
//             _changepasswordData=changepasswordData;
//         }
//     public bool ChangePassword(string OldPassword, string NewPassword,string ConfirmPassword)
//         {
//             try
//             {
//                 if(NewPassword != ConfirmPassword)
//                     throw new ValidationException($"The confirm password should be the same as new password : {ConfirmPassword}");
                
//                 var changePassword =_changepasswordData.ChangePassword(OldPassword,NewPassword);
//                 return true;
//             }

//             catch (ValidationException InvalidNewPassword)
//             {
//                 _logger.LogInformation($"ChangePassword DAL : ChangePassword throwed an exception : {InvalidNewPassword.Message}");
//                 throw InvalidNewPassword;
//             }
//             catch (Exception exception)
//             {
//                 _logger.LogInformation($"ChangePassword DAL : ChangePassword throwed an exception : {exception.Message}");
//                 throw exception;
//             }
//         }
//     }
// }