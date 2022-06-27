// using Microsoft.EntityFrameworkCore;
// using System.ComponentModel.DataAnnotations;


// namespace PMS_API
// {
//     public class ChangePasswordDataAccessLayer : IChangePasswordDataAccessLayer
//     {
//         private Context _context;
//         private ILogger<ChangePasswordServices> _logger;
//         public ChangePasswordDataAccessLayer(Context context, ILogger<ChangePasswordServices> logger)
//         {
//             _context = context;
//             _logger=logger;
//         }
//         public bool ChangePassword(string OldPassword,string NewPassword)
//         {
//             try
//             {
//                 if(!_context.users.Any(x => x.Password == OldPassword))
//                     throw new ValidationException($"The given old password is not found : {OldPassword}");
//                 if(_context.users.Any(x => x.Password == NewPassword))
//                     throw new ValidationException($"The new password should not be the same as old password : {NewPassword}");
                
//                 return true;
                
//             }
//             catch(Exception exception)
//             {
//                 _logger.LogInformation($"Exception on User DAL : ChangePassword(string OldPassword,string NewPassword) : {exception.Message}");
//                 throw exception;
//             }
//         }

//     }
// }