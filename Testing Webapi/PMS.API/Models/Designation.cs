using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class Designation
    {
        [Key]
        public int DesignationId{get; set;}
        [Required]
        [StringLength(80)]
        public string ? DesignationName{get;set;}
        [InverseProperty("designation")]
        public virtual ICollection<User>?  users  {get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}