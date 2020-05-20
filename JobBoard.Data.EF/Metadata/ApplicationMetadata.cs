using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class ApplicationMetadata
    {
        [Required]
        public int ApplicationID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public int OpenPositionsID { get; set; }
        [Required]
        public System.DateTime ApplicationDate { get; set; }
        [Display(Name ="Manager Notes")]
        public string MangerNotes { get; set; }
        [Required]
        public int ApplicationsStatusID { get; set; }
        [Display(Name ="Resume")]
        public string ResumeFileName { get; set; }
    }
    [MetadataType(typeof(ApplicationMetadata))]
    public partial class Application
    {
    }
}
