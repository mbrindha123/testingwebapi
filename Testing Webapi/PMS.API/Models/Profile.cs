using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class Profile
    {
        [Key]
        public int ProfileId{ get;set;}
        [InverseProperty("profile")]
        public virtual PersonalDetails? personalDetails{get;set;}

        [InverseProperty("profile")]
        public virtual ICollection<Education>? education { get; set;}
        [InverseProperty("profile")]
        public virtual ICollection<Projects>? projects { get; set;}
        [InverseProperty("profile")]
        public virtual ICollection<Skills>? skills { get; set;}
        [InverseProperty("profile")]
        public virtual ICollection<Achievements>? achievements { get; set;}
        [DefaultValue(2)]
        public int ProfileStatusId {get; set;}
        [ForeignKey("ProfileStatusId")]
        public virtual ProfileStatus? profilestatus {get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
       

    }
}
