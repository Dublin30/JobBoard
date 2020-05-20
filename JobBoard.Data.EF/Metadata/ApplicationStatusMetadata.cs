using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class ApplicationStatusMetadata
    {
        [Required]
        public int ApplicationStatusID { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Display(Name ="Description")]
        public string StatusDescription { get; set; }
    }
    [MetadataType(typeof(ApplicationStatusMetadata))]
    public partial class ApplicationStatus
    {
    }
}
