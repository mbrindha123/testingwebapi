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
    public class ProfileController : Controller
    {
        private IProfileService _profileService;
        private ILogger _logger;
        public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult AddProfile(Profile profile)
        {
            if (profile == null)
            {
                _logger.LogError("ProfileController:AddProfile():User tries to enter null values");
                return BadRequest("Profile not be null");
            }
            try
            {
                return _profileService.AddProfile(profile) ? Ok("Profile added") : Problem("Some internal Error occured");
            }
           catch(ValidationException exception){
                _logger.LogInformation($"ProfileController :AddProfile()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController :AddProfile()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController :AddProfile()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
        
        [HttpPost]
        public IActionResult AddPersonalDetail(PersonalDetails personalDetails)
        {
            if (User == null)
            {
                _logger.LogError("ProfileController:AddPersonalDetail():User tries to enter null values");
                return BadRequest("PersonalDetail not be null");
            }
            try
            {
                return _profileService.AddPersonalDetail(personalDetails) ? Ok("PersonalDetails added") : Problem("Some internal Error occured");
            }
            catch(ValidationException exception){
                _logger.LogInformation($"ProfileController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
        [HttpGet]
        public IActionResult GetallPersonalDetails()
        {
            try
            {

                return Ok(_profileService.GetAllPersonalDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetAllPersonalDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetPersonalDetailsById(int Personalid)
        {
            try{
                
                return Ok(_profileService.GetPersonalDetailsById(Personalid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetPersonalDetailsById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetPersonalDetailsByProfileId(int Profileid)
        {
            try{
                
                return Ok(_profileService.GetPersonalDetailsByProfileId(Profileid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetPersonalDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }

      
        [HttpPut]
        public IActionResult UpdatePersonalDetail(PersonalDetails personalDetails)

        {

            if (personalDetails == null)
            {
                _logger.LogInformation("ProfileController :UpdatePersonalDetails()-Profile's personaldetails should not be null values");
                return BadRequest("Profile's personaldetails should not be null");
            }

            //updating user via userservices

            try
            {

                return _profileService.UpdatePersonalDetail(personalDetails) ? Ok("PersonalDetails Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdatePersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete]
        public IActionResult DisablePersonalDetails(int PersonalDetailsId)
        {
            if (PersonalDetailsId == 0)
                return BadRequest("PersonalDetailsId can't be null");


            try
            {
                return _profileService.DisablePersonalDetails(PersonalDetailsId) ? Ok("PersonalDetails Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisablePersonalDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            if (education == null)
            {
                _logger.LogError("ProfileController:AddEducation():User tries to enter null values");
                return BadRequest("Education details should not be null");
            }
            try
            {
                return _profileService.AddEducation(education) ? Ok("Education details added") : Problem("Some internal Error occured");
            }
           catch(ValidationException exception){
                _logger.LogInformation($"ProfileController :AddEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController :AddEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController :AddEducation()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }


        }
        [HttpGet]
        public IActionResult GetallEducationDetails()
        {
            try
            {
                return Ok(_profileService.GetallEducationDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallEducationDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetEducationDetailsById(int Educationid)
        {
            try{
                
                return Ok(_profileService.GetEducationDetailsById(Educationid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetEducationById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllEducationDetailsByProfileId(int Profileid)
        {
            try{
                
                return Ok(_profileService.GetAllEducationDetailsByProfileId(Profileid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetAllEducationDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateEducation(Education education)

        {

            if (education == null)
            {
                _logger.LogInformation("ProfileController :UpdateEducation()-Profile's Eucationdetails should not enter null values");
                return BadRequest("Educationdetails should not be null");
            }

            //updating user via userservices

            try
            {

                return _profileService.UpdateEducation(education) ? Ok("Education Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdateEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public IActionResult DisableEducationalDetails(int EducationId)
        {
            if (EducationId == 0)
                return BadRequest("EducationId can't be null");


            try
            {
                return _profileService.DisableEducationalDetails(EducationId) ? Ok("Education Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalService : DisableEducationalDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddProjects(Projects projects)
        {
            if (projects == null)
            {
                _logger.LogError("ProfileController:AddProjects():user tries to enter null values");
                return BadRequest("Project details should not be null");
            }
            try
            {
                return _profileService.AddProjects(projects) ? Ok("Project details added") : Problem("Some internal Error occured");
            }
            catch(ValidationException exception){
                _logger.LogInformation($"ProfileController :AddProjects()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController :AddProjects()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController :AddProjects()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }


        [HttpGet]
        public IActionResult GetallProjectDetails()
        {
            try
            {

                return Ok(_profileService.GetallProjectDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallProjectDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetProjectDetailsById(int Projectid)
        {
            try{
                
                return Ok(_profileService.GetProjectDetailsById(Projectid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetallProjectDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllProjectDetailsByProfileId(int Profileid)
        {
            try{
                
                return Ok(_profileService.GetAllProjectDetailsByProfileId(Profileid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetAllProjectDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        
        [HttpPut]
        public IActionResult UpdateProjects(Projects projects)

        {

            if (projects == null)
            {
                _logger.LogInformation("ProfileController :UpdateProjects()-Profile's Projects should not be null");
                return BadRequest("Project values should not be null");
            }

            //updating user via userservices

            try
            {

                return _profileService.UpdateProjects(projects) ? Ok("Projects Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                // _logger.LogInformation($"UserController:UpdateUser()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public IActionResult DisableProjectDetails(int ProjectsId)
        {
            if (ProjectsId == 0)
                return BadRequest("ProjectsId can't be null");


            try
            {
                return _profileService.DisableProjectDetails(ProjectsId) ? Ok("Project Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableProjectDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
         [HttpPost]
        public IActionResult AddSkills(Skills skill)
        {
            if (skill == null)
            {
                _logger.LogError("ProfileController:AddSkills():user tries to enter null values");
                return BadRequest("Skill details should not be null");
            }
            try
            {
                return _profileService.AddSkills(skill) ? Ok("Skill details added") : Problem("Some internal Error occured");
            }
            catch(ValidationException exception){
                _logger.LogInformation($"ProfileController:AddSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController:AddSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController:AddSkills()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }
        [HttpGet]
        public IActionResult GetallSkillDetails()
        {
            try
            {

                return Ok(_profileService.GetallSkillDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : GetallSkillDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetSkillDetailsById(int Skillid)
        {
            try{
                
                return Ok(_profileService.GetSkillDetailsById(Skillid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController : GetallSkillDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllSkillDetailsByProfileId(int Profileid)
        {
            try{
                
                return Ok(_profileService.GetAllSkillDetailsByProfileId(Profileid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetAllSkillDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
       
        [HttpPut]
        public IActionResult UpdateSkills(Skills skill)

        {

            if (skill == null)
            {
                _logger.LogInformation("PersonalServiceController :UpdateSkills()-Profiles Skill values not be null");
                return BadRequest("Skills values should not be null");
            }

            //updating user via userservices

            try
            {

                return _profileService.UpdateSkills(skill) ? Ok("Skills Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdateSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public IActionResult DisableSkillDetails(int SkillId)
        {
            if (SkillId == 0)
                return BadRequest("SkillId can't be null");


            try
            {
                return _profileService.DisableSkillDetails(SkillId) ? Ok("Skill Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableSkillDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddBreakDuration(BreakDuration duration)
        {
            if (duration == null)
            {
                _logger.LogError("ProfileController:AddBreakDuration():user tries to enter null values");
                return BadRequest("BreakDuration details not be null");
            }
            try
            {
                return _profileService.AddBreakDuration(duration) ? Ok("BreakDuration details added") : Problem("Some internal Error occured");
            }
            catch(ValidationException exception){
                _logger.LogInformation($"ProfileController:AddBreakDuration()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController:AddBreakDuration()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController:AddBreakDuration()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }
        
        [HttpDelete]
        public IActionResult DisableBreakDuration(int BreakDurationId)
        {
            if (BreakDurationId == 0)
                return BadRequest("BreakDurationId can't be null");


            try
            {
                return _profileService.DisableBreakDuration(BreakDurationId) ? Ok("BreakDuration Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableBreakDuration throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddLanguage(Language language)
        {
            if (language == null)
            {
                _logger.LogError("ProfileController:AddLanguage():user tries to enter null values");
                return BadRequest("Language details not be null");
            }
            try
            {
                return _profileService.AddLanguage(language) ? Ok("Language details added") : Problem("Some internal Error occured");
            }
            catch(ValidationException exception){
                _logger.LogInformation($"ProfileController:AddLanguage()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController:AddLanguage()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController:AddLanguage()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }
        [HttpDelete]
        public IActionResult DisableLanguage(int Language_Id)
        {
            if (Language_Id == 0)
                return BadRequest("Language_Id can't be null");


            try
            {
                return _profileService.DisableLanguage(Language_Id) ? Ok("Language_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"SocialMedia_ Service : DisableLanguage throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia media)
        {
            if (media == null)
            {
                _logger.LogError("ProfileController:AddSocialMedia():user tries to enter null values");
                return BadRequest("social media details not be null");
            }
            try
            {
                return _profileService.AddSocialMedia(media) ? Ok("Social media details added") : Problem("Some internal Error occured");
            }
            catch(ValidationException exception){
                _logger.LogInformation($"ProfileController:AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController:AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController:AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }
        [HttpDelete]
        public IActionResult DisableSocialMedia(int SocialMedia_Id)
        {
            if (SocialMedia_Id == 0)
                return BadRequest("SocialMedia_Id can't be null");


            try
            {
                return _profileService.DisableSocialMedia(SocialMedia_Id) ? Ok("SocialMedia_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"SocialMedia_ Service : DisableSocialMedia throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddAchievement(Achievements achievement)
        {
            if(achievement==null)
            {
                _logger.LogError("ProfileController:AddAchievement():user tries to enter null values");
                return BadRequest("achievement details not be null");
            }
            try
            {
                return _profileService.AddAchievements(achievement) ? Ok("Achievements details added") : Problem("Some internal Error occured");
            }
           catch(ValidationException exception){
                _logger.LogInformation($"ProfileController:AddAchievement()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController:AddAchievement()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController:AddAchievement()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
          [HttpGet]
        public IActionResult GetallAchievements()
        {
            try
            {

                return Ok(_profileService.GetallAchievements());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallAchievements()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpDelete]
        public IActionResult DisableAchievements(int achievementId)
        {
            if (achievementId <= 0)
                return BadRequest($"Achievement id can't be zero or less than 0 achievementId is supplied as {achievementId}");


            try
            {
                return _profileService.DisableAchievement(achievementId) ? Ok("Achievement Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($" ProfileController: DisableAchievements() : {exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetallProfiles()
        {
            try
            {

                return Ok(_profileService.GetallProfiles());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallProfiles()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }


       [HttpGet]
        public IActionResult GetProfileById(int id)
        {
            try{
                
                return Ok(_profileService.GetProfileById(id));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetProfileById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
       [HttpPost]
        public IActionResult AddProfileHistory(ProfileHistory profilehistory)
        {
            if (profilehistory == null)
            {
                _logger.LogError("ProfileController:AddProfileHistory():User tries to enter null values");
                return BadRequest("ProfileHistory not be null");
            }
            //if(profilehistory.profile.ProfileStatus!="Approved")throw new Exception("Status should be Approved by Reporting Person");
            try
            {
                return _profileService.AddProfileHistory(profilehistory) ? Ok("ProfileHistory added") : Problem("Some internal Error occured");
            }
           catch(ValidationException exception){
                _logger.LogInformation($"ProfileController:AddProfileHistory()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(ArgumentNullException exception){
                _logger.LogInformation($"ProfileController:AddProfileHistory()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }

            catch(Exception exception){
                _logger.LogInformation($"ProfileController:AddProfileHistory()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
        [HttpGet]
        public IActionResult GetallProfileHistories()
        {
            try
            {

                return Ok(_profileService.GetallProfileHistories());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallProfileHistories()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetProfileHistoryById(int Profileid)
        {
            try{
                
                return Ok(_profileService.GetProfileById(Profileid));
            }
            catch(Exception exception){
                _logger.LogInformation($"ProfileController :GetProfileHistoryById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }

    }
}