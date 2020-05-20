using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class PositionMetadata
    {
        [Required]
        public int PositionID { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name ="Job Description")]
        public byte[] JobDescription { get; set; }
    }
    [MetadataType(typeof(PositionMetadata))]
    public partial class Position
    {
    }
}
