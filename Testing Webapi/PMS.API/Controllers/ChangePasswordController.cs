// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Net;
// using System.ComponentModel.DataAnnotations;
// namespace PMS_API
// {
//    [ApiController]
//     [Route("[controller]/[Action]")]
//     public class ChangePasswordController :Controller{
        
//         private IChangePasswordServices _changepasswordServices;
//          private readonly ILogger<ChangePasswordController> _logger;
//         public ChangePasswordController(IChangePasswordServices changepasswordServices, ILogger<ChangePasswordController> logger)
//         {

//             _changepasswordServices = changepasswordServices;
//             _logger = logger;
//         }
//         [HttpPost("ChangePassword")]
//         public IActionResult ChangePassword(string OldPassword, string NewPassword,string ConfirmPassword)
//         {
//             try
//             {
                
//                 var Result = _changepasswordServices.ChangePassword(OldPassword,NewPassword,ConfirmPassword);                
//                 return Ok(Result);
//             }
//             catch (ValidationException validationException)
//             {
//                 _logger.LogInformation($"ChangePassword Service : AuthLogin() : {validationException.Message}");
//                 return BadRequest(validationException.Message);
//             }
//             catch (Exception exception)
//             {
//                 _logger.LogInformation($"ChangePassword Service : AuthLogin() : {exception.Message}");
//                 return Problem("Sorry some internal error occured");
//             }
//         }
     
// }
// }
