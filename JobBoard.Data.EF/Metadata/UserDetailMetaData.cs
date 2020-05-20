using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class UserDetailMetaData
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Resume")]
        public string ResumeFileName { get; set; }
    }
    [MetadataType(typeof(UserDetailMetaData))]
    public partial class UserDetail
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
