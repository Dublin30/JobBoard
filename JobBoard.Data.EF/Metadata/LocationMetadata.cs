using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class LocationMetadata
    {
        [Required]
        public int LocationID { get; set; }
        [Required]
        [Display(Name ="Street Address")]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ManagerID { get; set; }
    }

    [MetadataType(typeof(LocationMetadata))]
    public partial class Location
    {
    }
}
